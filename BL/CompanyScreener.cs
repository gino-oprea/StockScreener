using BL.Adapters;
using BL.CompaniesData;
using BL.CompaniesData.JsonModels.RoicAi;
using BL.Models;
using BL.OnlineCompaniesData;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace BL
{
    public class CompanyScreener
    {
        private string workingFolder = "Companies_2023";

        private IDataAggregator dataAggregator;

        public string currentTicker;
        public List<Company> currentfilteredCompanies;
        public string progress;        

        public CompanyScreener(IDataAggregator dataAgg)
        {
            this.dataAggregator = dataAgg;
        }


        public List<Company> GetFilteredCompanies(CompanyFilter filter, BackgroundWorker bgw)
        {
            List<Company> filteredCompanies = new List<Company>();           

            if (Directory.Exists(workingFolder))
            {
                // Get all first-level child folders
                var childFolders = Directory.GetDirectories(workingFolder).ToList();

                int counter = 0;
                Random rand = new Random();               

                foreach (var companyFolder in childFolders)
                {
                    Company company = new Company();
                    counter++;
                    progress = $"{counter.ToString()} of {childFolders.Count.ToString()}";

                    if (bgw.CancellationPending)
                    {
                        return filteredCompanies;
                    }

                    try
                    {
                        CompaniesDataAggregator companiesDataAggregator = new CompaniesDataAggregator();
                        company = companiesDataAggregator.GetCompany(Path.GetFileName(companyFolder), filter.DiscountRate);

                        if (company == null)
                            continue;

                        currentTicker = company.Ticker;


                        if (filter != null)
                        {
                            //List<decimal> values = company.CalculateIntrinsicAndDiscountedValues(discountedInterestRate: filter.DiscountRate, terminalMultiple: company.Average_P_FCF_Multiple.Value);

                            if (company.Financials != null)
                            {
                                if (company.Financials.FreeCashFlow.Count > 2
                                    && company.AverageEquityGrowth >= filter.MinAvgEqGrowth
                                    && company.AverageRevenueGrowth >= filter.MinAvgRevenueGrowth
                                    && company.AverageEPSGrowth >= filter.MinAvgEPSGrowth
                                    && company.AverageFreeCashFlowGrowth >= filter.MinAvgFreeCashFlowGrowth
                                    && company.AverageROIC >= filter.MinAvgROIC)
                                {
                                    var refPrice = GetRefPrice(company, filter);

                                    if ((decimal)company.CurrentPrice <= refPrice && company.IntrinsicValue > 0)
                                    {
                                        filteredCompanies.Add(company);                                        
                                    }
                                }
                            }

                            currentfilteredCompanies = filteredCompanies;
                        }


                        //await Task.Delay(100 + rand.Next(50));
                        Thread.Sleep(100 + rand.Next(50));
                    }
                    catch (Exception ex)
                    {
                        
                    }
                }
            }


            return filteredCompanies;
        }


        //obsolete
        public List<Company> GetFilteredCompanies_Old(string Url, CompanyFilter filter, List<Company> allCompanies,             
            BackgroundWorker bgw, 
            List<Company> companiesAlreadyInCache = null)//send this param only when getting companies for caching
        {
            List<Company> filteredCompanies = companiesAlreadyInCache?.Count > 0 ? companiesAlreadyInCache : new List<Company>();
            
            List<Company> companies = null;

            Random rand = new Random();

            List<string> allTickers = new List<string>();
            if (allCompanies == null)
                allTickers = GetCompaniesTickers_FinvizScreener(Url, filter, bgw);
            else
            {
                if (filter != null && filter.IgnoreADRCompanies)
                    companies = allCompanies.FindAll(c => c.Name != null && !c.Name.Contains(" ADR"));
                else
                    companies = allCompanies;

                allTickers = companies.Select(c => c.Ticker).ToList();
            }

            progress = "0 of " + allTickers.Count.ToString();


            for (int i = 0; i < allTickers.Count; i++)
            {
                var ticker = allTickers[i];                

                progress = (i + 1).ToString() + " of " + allTickers.Count.ToString();

                if (companiesAlreadyInCache?.Count > 0 && companiesAlreadyInCache.Find(c => c.Ticker == ticker)!=null)//skip if already in cache
                    continue;

                if (bgw.CancellationPending)
                {
                    //filteredCompanies = new List<Company>();
                    //currentfilteredCompanies = new List<Company>();
                    //currentTicker = "";
                    //progress = "";
                    //break;

                    return filteredCompanies;                    
                }

                try
                {
                    Company company = new Company();
                    if (companies == null)
                        company = dataAggregator.GetCompanyData(ticker);
                    else
                    {
                        //get company from cache but current price from online
                        company = companies[i];
                        company.CurrentPrice = dataAggregator.GetCompanyCurrentPrice(ticker).CurrentPrice;
                    }

                    currentTicker = company.Ticker;

                    if (filter != null)
                    {
                        List<decimal> values = company.CalculateIntrinsicAndDiscountedValues(discountedInterestRate: filter.DiscountRate, terminalMultiple: company.Average_P_FCF_Multiple.Value);



                        if (company.Financials!= null)
                        {
                            if (company.Financials.FreeCashFlow.Count > 2
                                && company.AverageEquityGrowth >= filter.MinAvgEqGrowth
                                && company.AverageRevenueGrowth >= filter.MinAvgRevenueGrowth
                                && company.AverageEPSGrowth >= filter.MinAvgEPSGrowth
                                && company.AverageFreeCashFlowGrowth >= filter.MinAvgFreeCashFlowGrowth
                                && company.AverageROIC >= filter.MinAvgROIC)
                            {
                                var refPrice = GetRefPrice(company, filter);

                                if ((decimal)company.CurrentPrice <= refPrice && company.IntrinsicValue > 0)
                                    filteredCompanies.Add(company);
                            }
                        }

                        currentfilteredCompanies = filteredCompanies;
                    }
                    else//le adaugam pe toate fare filtru
                    {
                        filteredCompanies.Add(company);
                    }

                    Thread.Sleep(100 + rand.Next(50));
                }
                catch (Exception ex)
                {
                    var currentTicker = allTickers[i];
                    //log
                }
            }

            currentTicker = "";
            progress = "";

            return filteredCompanies;
        }
        public async Task SaveCompanies(List<Company> companies)
        {
            string json = JsonConvert.SerializeObject(companies);
            await File.WriteAllTextAsync("companies.json", json);
        }
        private decimal GetRefPrice(Company company, CompanyFilter filter)
        {
            var refPrice = company.IntrinsicValue;
            switch (filter.PriceFilter)
            {
                case PriceFilter.IntrinsicValue:
                    refPrice = company.IntrinsicValue;
                    break;
                case PriceFilter.MOS10:
                    refPrice = company.IntrinsicValue_Discounted10;
                    break;
                case PriceFilter.MOS30:
                    refPrice = company.IntrinsicValue_Discounted30;
                    break;
                case PriceFilter.MOS50:
                    refPrice = company.IntrinsicValue_Discounted50;
                    break;
                case PriceFilter.IntrinsicValuePremium10:
                    refPrice = company.IntrinsicValue * (decimal)1.1;
                    break;
                case PriceFilter.IntrinsicValuePremium20:
                    refPrice = company.IntrinsicValue * (decimal)1.2;
                    break;
                case PriceFilter.Unlimited:
                    refPrice = decimal.MaxValue;
                    break;
                default:
                    refPrice = company.IntrinsicValue;
                    break;
            }

            return (decimal)refPrice;
        }
        private List<string> GetCompaniesTickers_FinvizScreener(string Url, CompanyFilter filter, BackgroundWorker bgw)
        {
            List<string> allTickers = new List<string>();
            string nextPageFooterHTML = "";
            string nextPageUrlLine = "";
            do
            {
                if (bgw.CancellationPending)
                {
                    currentTicker = "";
                    progress = "";
                    break;
                }

                nextPageUrlLine = "";

                string htmlCompanies = BL.HttpReq.GetUrlHttpWebRequest(Url, "GET", null, false);
                if (htmlCompanies != null)
                {
                    var rawLines = HtmlHelper.GetRawLinesFromHtml(htmlCompanies);

                    List<string> companyLines = new List<string>();

                    for (int i = 0; i < rawLines.Count; i++)
                    {
                        if (rawLines[i].Contains("<td height=\"10\" align=\"left\" data-boxover="))
                        {
                            string country = "";
                            string[] lines = rawLines[i].Split(">", StringSplitOptions.RemoveEmptyEntries);
                            if (lines.Length > 31)
                            {
                                country = HtmlHelper.ExtractString(lines[31], "", "</a", false);
                            }

                            if (filter == null || !filter.IgnoreADRCompanies || (filter.IgnoreADRCompanies && country.ToUpper() == "USA"))
                                companyLines.Add(HtmlHelper.ExtractString(rawLines[i], "class=\"tab-link\">", "</a>", false));

                        }

                        if (rawLines[i].Contains("screener-pages is-next"))
                        {
                            nextPageFooterHTML = rawLines[i];

                            var footerRawLines = nextPageFooterHTML.Split("<a");
                            nextPageUrlLine = footerRawLines.Last();
                        }
                    }


                    for (int i = 0; i < companyLines.Count; i++)
                    {                        
                        allTickers.Add(companyLines[i]);
                    }

                    if (nextPageUrlLine != "")
                    {
                        string[] splits = nextPageUrlLine.Split("<a href=", StringSplitOptions.RemoveEmptyEntries);
                        
                        string nextPageUrl = WebUtility.HtmlDecode("https://finviz.com/" + HtmlHelper.ExtractString(splits[splits.Length-1], "\"", "\" class", false));
                        Url = nextPageUrl;
                    }
                }

                Thread.Sleep(100);

            }
            while (nextPageUrlLine != "");

            return allTickers;
        }
    }
}

