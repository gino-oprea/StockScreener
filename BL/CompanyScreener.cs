using BL.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading;

namespace BL
{
    public static class CompanyScreener
    {
        public static string currentTicker;
        public static List<Company> currentfilteredCompanies;
        public static List<Company> GetFilteredCompanies(string Url)
        {
            List<Company> filteredCompanies = new List<Company>();

            List<string> allTickers = GetCompaniesTickers(Url);

            foreach (var ticker in allTickers)
            {
                try
                {
                    Company company = DataAggregator.GetCompanyData(ticker);

                    currentTicker = company.Ticker;

                    List<decimal> values = company.CalculateIntrinsicAndDiscountedValues();

                    company.IntrinsicValue = values[0];
                    company.IntrinsicValue_Discounted30 = values[1];
                    company.IntrinsicValue_Discounted50 = values[2];

                    if (company.Financials.Count > 0)
                    {
                        if (company.Financials[0].FreeCashFlow.Count > 3
                            && company.AverageEquityGrowth >= 10
                            && company.AverageRevenueGrowth >= 10
                            && company.AverageEPSGrowth >= 10
                            && company.AverageFreeCashFlowGrowth >= 10)
                        {
                            if (company.Financials[0].Equity.Find(v => v.Growth < 0) == null
                                && company.Financials[0].EPS.Find(v => v.Growth < 0) == null
                                && company.Financials[0].NetIncome.Find(v => v.Growth < 0) == null
                                && company.Financials[0].Revenue.Find(v => v.Growth < 0) == null
                                && company.Financials[0].FreeCashFlow.Find(v => v.Growth < 0) == null)
                                if ((decimal)company.CurrentPrice < company.IntrinsicValue && company.IntrinsicValue > 0)
                                    filteredCompanies.Add(company);
                        }
                    }

                    currentfilteredCompanies = filteredCompanies;
                    Thread.Sleep(200);
                }
                catch(Exception ex)
                {
                    //log
                }
            }

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

