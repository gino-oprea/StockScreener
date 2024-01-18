using BL.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BL.OnlineCompaniesData.DataHelpers
{
    public static class MarketWatchHelper
    {
        public static void GetCompanyGeneralInfo_MarketWatch(string html, Company company)
        {
            string rawLine;
            StringReader sr = new StringReader(html);
            List<string> rawLines = new List<string>();
            while ((rawLine = sr.ReadLine()) != null)
            {
                if (rawLine != "")
                    rawLines.Add(rawLine.Trim());
            }

            List<string> selectedLines = new List<string>();
            for (int i = 0; i < rawLines.Count; i++)
            {
                if (rawLines[i].Contains("h1 class=\"company__name\""))
                    selectedLines.Add(rawLines[i]);

                if (i > 1 &&
                    (rawLines[i].Contains("bg-quote class=\"value\"") || rawLines[i].Contains("span class=\"value\"")) && rawLines[i - 2].Contains("h2 class=\"intraday__price")
                    )
                    selectedLines.Add(rawLines[i]);

                if (i > 0 && rawLines[i].Contains("span class=\"primary") &&
                    (rawLines[i - 1].Contains("Shares Outstanding") || rawLines[i - 1].Contains("P/E Ratio") || rawLines[i - 1].Contains("Market Cap")))
                    selectedLines.Add(rawLines[i]);

            }

            if (selectedLines.Count == 5)
            {
                string name = HtmlHelper.ExtractString(selectedLines[0], ">", "</", false);
                string currentPrice = HtmlHelper.ExtractString(selectedLines[1], ">", "</", false);
                string marketCap = HtmlHelper.ExtractString(selectedLines[2], ">$", "</", false);
                string sharesOutstanding = HtmlHelper.ExtractString(selectedLines[3], ">", "</", false);
                string pe_ratio = HtmlHelper.ExtractString(selectedLines[4], ">", "</", false);

                company.Name = name.Replace("&amp;", "&").Replace("&#x27;", "'");                
                company.CurrentPrice = decimal.Parse(currentPrice);
                company.MarketCap = marketCap != "N/A" ? ConvertStringToBillions(marketCap) : null;
                company.SharesOutstanding = sharesOutstanding != "N/A" ? ConvertStringToBillions(sharesOutstanding) : 1;
                if (pe_ratio != "N/A")
                    company.PE_Ratio = decimal.Parse(pe_ratio);
            }
        }

        public static void GetCompanyFinancials_MarketWatch(string html_incomeStatement, string html_balanceSheet, string html_cashFlow, Company company)
        {
            Financials financials = new Financials();            

            List<string> rawLines_incomeStatement = HtmlHelper.GetRawLinesFromHtml(html_incomeStatement);
            List<string> rawLines_balanceSheet = HtmlHelper.GetRawLinesFromHtml(html_balanceSheet);
            List<string> rawLines_cashFlow = HtmlHelper.GetRawLinesFromHtml(html_cashFlow);

            //List<string> selectedLines = HtmlHelper.GetImportantLines(rawLines_incomeStatement, "thead class=\"table__header\"", "/thead");           

            financials.Revenue = GetFinancialData(rawLines_incomeStatement, "<div class=\"cell__content \">Sales/Revenue</div>", "</tr>");
            financials.NetIncome = GetFinancialData(rawLines_incomeStatement, "<div class=\"cell__content \">Net Income</div>", "</tr>");
            financials.EPS = GetFinancialData(rawLines_incomeStatement, "<div class=\"cell__content \">EPS (Diluted)</div>", "</tr>");
            financials.Cash = GetFinancialData(rawLines_balanceSheet, "<div class=\"cell__content \">Cash &amp; Short Term Investments</div>", "</tr>");

            if (financials.Cash.Count == 0)
                financials.Cash = GetFinancialData(rawLines_balanceSheet, "<div class=\"cell__content \">Cash Only</div>", "</tr>");

            financials.ShortTermDebt = GetFinancialData(rawLines_balanceSheet, ">Short Term Debt</div>", "</tr>");
            financials.LongTermDebt = GetFinancialData(rawLines_balanceSheet, ">Long-Term Debt</div>", "</tr>");
            financials.Equity = GetFinancialData(rawLines_balanceSheet, "<div class=\"cell__content \">Total Equity</div>", "</tr>");
            financials.FreeCashFlow = GetFinancialData(rawLines_cashFlow, "<div class=\"cell__content \">Free Cash Flow</div>", "</tr>");

            financials.RetainedEarnings = GetFinancialData(rawLines_balanceSheet, "<div class=\"cell__content indent--small\">Retained Earnings</div>", "</tr>");
            financials.CapitalExpenditures = GetFinancialData(rawLines_cashFlow, "<div class=\"cell__content \">Capital Expenditures</div>", "</tr>");
            //financials.ROE = GetROE(financials);

            company.Financials = financials;

            
        }
        private static List<int> GetAvailableYears(List<string> rawLines)
        {
            List<string> selectedLines = HtmlHelper.GetImportantLines(rawLines, "thead class=\"table__header\"", "/thead");

            //years
            List<int> years = new List<int>();
            for (int i = 0; i < selectedLines.Count; i++)
            {
                string selectedLine = selectedLines[i];
                int year;
                if (selectedLines[i].Contains("class=\"cell__content\">") && selectedLines[i].IndexOf("class=\"cell__content\">") < selectedLines[i].IndexOf("</"))
                {
                    bool isYear = int.TryParse(HtmlHelper.ExtractString(selectedLines[i], "class=\"cell__content\">", "</", false), out year);

                    if (isYear)
                        years.Add(year);
                }
            }



            return years;
        }
        private static List<YearVal> GetFinancialData(List<string> rawLines, string stringToStartRecording, string stringToStopRecording, bool leaveNumberAsIs = false)
        {
            List<int> years = GetAvailableYears(rawLines);

            List<string> selectedLines = new List<string>();
            selectedLines = HtmlHelper.GetImportantLines(rawLines, stringToStartRecording, stringToStopRecording);


            List<YearVal> financialData = new List<YearVal>();

            if (selectedLines.Count > 0)
            {
                List<string> values = new List<string>();
                for (int i = 0; i < selectedLines.Count; i++)
                {
                    string selectedLine = selectedLines[i];

                    if (selectedLines[i].Contains("span"))
                    {
                        string val = HtmlHelper.ExtractString(selectedLines[i], "<span class", "</", false);
                        val = val.Substring(val.IndexOf(">") + 1);
                        values.Add(val);
                    }
                }

                for (int i = 0; i < years.Count; i++)
                {
                    YearVal yearVal = new YearVal();
                    yearVal.Year = years[i];
                    yearVal.Value = ConvertStringToBillions(values[i]);

                    if (i > 0)
                    {
                        var newVal = yearVal.Value;
                        var oldVal = ConvertStringToBillions(values[i - 1]);
                        if (newVal != null && oldVal != null && oldVal != 0)
                            yearVal.Growth = ((decimal)newVal - (decimal)oldVal) / Math.Abs((decimal)oldVal) * 100;
                    }

                    financialData.Add(yearVal);
                }
            }

            financialData.Sort((a, b) => a.Year.CompareTo(b.Year));// ascending sort

            return financialData;
        }
        private static decimal? ConvertStringToBillions(string value)
        {
            if (value != "-" && value != "—")
            {
                //try
                //{
                value = value.Replace("(", "-").Replace(")", "");


                decimal? number = null;
                if (value.ToUpper().EndsWith("K"))
                    number = decimal.Parse(value.Substring(0, value.Length - 1)) / 1000000;
                else
                    if (value.ToUpper().EndsWith("M"))
                    number = decimal.Parse(value.Substring(0, value.Length - 1)) / 1000;
                else
                        if (value.ToUpper().EndsWith("B"))
                    number = decimal.Parse(value.Substring(0, value.Length - 1));
                else
                            if (value.ToUpper().EndsWith("T"))
                    number = decimal.Parse(value.Substring(0, value.Length - 1)) * 1000;
                else
                    number = decimal.Parse(value);

                return number;

                //}
                //catch (Exception ex)
                //{
                //    return null;
                //}
            }
            else
                return null;
        }
    }
}
