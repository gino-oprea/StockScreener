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

namespace BL
{
    public class CompanyScreener
    {
        public static string currentTicker;
        public static List<Company> currentfilteredCompanies;
        public static string progress;


        private IDataAggregator dataAggregator;

        public CompanyScreener(IDataAggregator dataAgg)
        {
            this.dataAggregator = dataAgg;
        }

        public List<Company> GetFilteredCompanies(string Url, CompanyFilter filter, List<Company> allCompanies, BackgroundWorker bgw)
        {
            List<Company> filteredCompanies = new List<Company>();
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

                if (bgw.CancellationPending)
                {
                    filteredCompanies = new List<Company>();
                    currentfilteredCompanies = new List<Company>();
                    currentTicker = "";
                    progress = "";
                    break;
                }

                try
                {
                    Company company = new Company();
                    if (companies == null)
                        company = dataAggregator.GetCompanyData(ticker);
                    else
                    {
                        //get company from casche but current price from online
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

                    Thread.Sleep(200 + rand.Next(100));
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
                        if (rawLines[i].Contains("class=\"screener-link-primary\""))
                        {
                            string country = "";
                            string[] lines = rawLines[i].Split("class=\"screener-link\">");
                            if (lines.Length > 6)
                            {
                                country = HtmlHelper.ExtractString(lines[5], "", "</a>", false);
                            }

                            if (filter==null || !filter.IgnoreADRCompanies || (filter.IgnoreADRCompanies && country.ToUpper() == "USA"))
                                companyLines.Add(HtmlHelper.ExtractString(rawLines[i], "class=\"screener-link-primary\">", "</a>", false));

                        }

                        if (rawLines[i].Contains("<b>next</b>"))
                            nextPageUrlLine = rawLines[i];
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

