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

            List<string> allTickers = GetCompaniesTickers(Url);

            progress = "0 of " + allTickers.Count.ToString();
            

            for (int i = 0; i < allTickers.Count; i++)
            {
                var ticker = allTickers[i];

                progress = (i + 1).ToString() + " of " + allTickers.Count.ToString();                

                if (bgw.CancellationPending)
                {
                    currentTicker = "";
                    progress = "";
                    break;
                }

                try
                {
                    Company company = DataAggregator.GetCompanyData(ticker);

                    currentTicker = company.Ticker;

                    List<decimal> values = company.CalculateIntrinsicAndDiscountedValues(discountedInterestRate: filter.DiscountRate);

                    company.IntrinsicValue = values[0];
                    company.IntrinsicValue_Discounted30 = values[1];
                    company.IntrinsicValue_Discounted50 = values[2];

                    if (company.Financials.Count > 0)
                    {
                        if (company.Financials[0].FreeCashFlow.Count > 3
                            && company.AverageEquityGrowth >= filter.MinAvgEqGrowth
                            && company.AverageRevenueGrowth >= filter.MinAvgRevenueGrowth
                            && company.AverageEPSGrowth >= filter.MinAvgEPSGrowth
                            && company.AverageFreeCashFlowGrowth >= filter.MinAvgFreeCashFlowGrowth)
                        {
                            if (!filter.IsAllGrowthPositive ||

                                (company.Financials[0].Equity.Find(v => v.Growth < 0) == null
                                && company.Financials[0].EPS.Find(v => v.Growth < 0) == null
                                && company.Financials[0].Revenue.Find(v => v.Growth < 0) == null
                                && company.Financials[0].FreeCashFlow.Find(v => v.Growth < 0) == null)

                                )
                            {
                                //check if growth exists over the period
                                var eqLastIndex = company.Financials[0].Equity.Count - 1;
                                var revLastIndex = company.Financials[0].Revenue.Count - 1;
                                var epsLastIndex = company.Financials[0].EPS.Count - 1;
                                var fcfLastIndex = company.Financials[0].FreeCashFlow.Count - 1;

                                if (
                                    company.Financials[0].Equity[0].Value < company.Financials[0].Equity[eqLastIndex].Value
                                    && company.Financials[0].Revenue[0].Value < company.Financials[0].Revenue[revLastIndex].Value
                                    && company.Financials[0].EPS[0].Value < company.Financials[0].EPS[epsLastIndex].Value
                                    && company.Financials[0].FreeCashFlow[0].Value < company.Financials[0].FreeCashFlow[fcfLastIndex].Value
                                    )
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
                                        default:
                                            refPrice = company.IntrinsicValue;
                                            break;
                                    }

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
        public static List<string> GetCompaniesTickers(string Url)
        {
            List<string> allTickers = new List<string>();
            string nextPageUrlLine = "";
            do
            {
                nextPageUrlLine = "";

                string htmlCompanies = BL.HttpReq.GetUrlHttpWebRequest(Url, "GET", null, false);
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

                Thread.Sleep(200);

            }
            while (nextPageUrlLine != "");

            return allTickers;
        }
    }
}

