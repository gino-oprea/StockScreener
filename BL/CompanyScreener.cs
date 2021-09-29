using BL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net;
using System.Text;
using System.Threading;

namespace BL
{
    public static class CompanyScreener
    {
        public static string currentTicker;
        public static List<Company> currentfilteredCompanies;
        public static string progress;

        public static List<Company> GetFilteredCompanies(string Url, CompanyFilter filter, BackgroundWorker bgw)
        {
            List<Company> filteredCompanies = new List<Company>();

            List<string> allTickers = GetCompaniesTickers_FinvizScreener(Url, bgw);

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
                    Company company = DataAggregator.GetCompanyData(ticker);

                    currentTicker = company.Ticker;

                    List<decimal> values = company.CalculateIntrinsicAndDiscountedValues(discountedInterestRate: filter.DiscountRate, terminalMultiple: filter.TerminalMultiple);

                    company.IntrinsicValue = values[0];
                    company.IntrinsicValue_Discounted30 = values[1];
                    company.IntrinsicValue_Discounted50 = values[2];

                    if (company.Financials.Count > 0)
                    {
                        if (company.Financials[0].FreeCashFlow.Count > 2
                            && company.AverageEquityGrowth >= filter.MinAvgEqGrowth
                            && company.AverageRevenueGrowth >= filter.MinAvgRevenueGrowth
                            && company.AverageEPSGrowth >= filter.MinAvgEPSGrowth
                            && company.AverageFreeCashFlowGrowth >= filter.MinAvgFreeCashFlowGrowth
                            && company.AverageROIC >= filter.MinAvgROIC)
                        {
                            if (!filter.IsAllGrowthPositive)
                            {
                                var refPrice = GetRefPrice(company, filter);

                                if ((decimal)company.CurrentPrice <= refPrice && company.IntrinsicValue > 0)
                                    filteredCompanies.Add(company);
                            }
                            else
                            {
                                //all growth positive
                                int negativeYearsNo = 0;
                                if (filter.AllowOneNegativeYear) negativeYearsNo = 1;

                                if (company.Financials[0].Equity.FindAll(v => v.Growth < 0).Count <= negativeYearsNo
                                && company.Financials[0].EPS.FindAll(v => v.Growth < 0).Count <= negativeYearsNo
                                && company.Financials[0].Revenue.FindAll(v => v.Growth < 0).Count <= negativeYearsNo
                                && company.Financials[0].FreeCashFlow.FindAll(v => v.Growth < 0).Count <= negativeYearsNo)
                                {                                   
                                    var refPrice = GetRefPrice(company, filter);

                                    if ((decimal)company.CurrentPrice <= refPrice && company.IntrinsicValue > 0)
                                        filteredCompanies.Add(company);                                 
                                }
                            }
                        }
                    }

                    currentfilteredCompanies = filteredCompanies;
                    Thread.Sleep(200);
                }
                catch (Exception ex)
                {
                    //log
                }
            }

            currentTicker = "";
            progress = "";

            return filteredCompanies;
        }
        public static decimal GetRefPrice(Company company, CompanyFilter filter)
        {
            var refPrice = company.IntrinsicValue;
            switch (filter.PriceFilter)
            {
                case PriceFilter.IntrinsicValue:
                    refPrice = company.IntrinsicValue;
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
        public static List<string> GetCompaniesTickers_MarketwatchScreener(string Url, BackgroundWorker bgw)
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
                        if (rawLines[i].Contains("<td class=\"aleft\"><a href=\"/investing/stock"))
                            companyLines.Add(HtmlHelper.ExtractString(rawLines[i], "<td class=\"aleft\"><a href=", "</a>", false));

                        if (rawLines[i].Contains("<a href=\"/tools/stockresearch/screener/results.asp") && rawLines[i].Contains("Next"))
                            nextPageUrlLine = rawLines[i];
                    }


                    for (int i = 0; i < companyLines.Count; i++)
                    {
                        var ticker = companyLines[i].Substring(companyLines[i].IndexOf(">") + 1);
                        allTickers.Add(ticker);
                    }

                    if (nextPageUrlLine != "")
                    {
                        string nextPageUrl = WebUtility.HtmlDecode("https://www.marketwatch.com" + HtmlHelper.ExtractString(nextPageUrlLine, "href=\"", "\">Next", false));
                        Url = nextPageUrl;
                    }
                }

                Thread.Sleep(250);

            }
            while (nextPageUrlLine != "");

            return allTickers;
        }

        public static List<string> GetCompaniesTickers_FinvizScreener(string Url, BackgroundWorker bgw)
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
                            companyLines.Add(HtmlHelper.ExtractString(rawLines[i], "class=\"screener-link-primary\">", "</a>", false));

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

