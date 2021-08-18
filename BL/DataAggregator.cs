using BL.Models;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;

namespace BL
{
    public static class DataAggregator
    {
        public static Company GetCompanyData(string TickerSymbol)
        {


            Company company = new Company();
            company.Ticker = TickerSymbol.ToUpper();
            company.Financials = new List<Financials>();

            string generalDetails = BL.HttpReq.GetUrlHttpWebRequest("https://www.marketwatch.com/investing/stock/" + TickerSymbol + "?mod=over_search", "GET", null, false);

            if (generalDetails != null)
                GetCompanyGeneralInfo_MarketWatch(generalDetails, company);


            Thread.Sleep(250);
            string financials_incomeStatement = BL.HttpReq.GetUrlHttpWebRequest("https://www.marketwatch.com/investing/stock/" + TickerSymbol + "/financials", "GET", null, false);
            Thread.Sleep(250);
            string financials_balanceSheet = BL.HttpReq.GetUrlHttpWebRequest("https://www.marketwatch.com/investing/stock/" + TickerSymbol + "/financials/balance-sheet", "GET", null, false);
            Thread.Sleep(250);
            string financials_cashFlow = BL.HttpReq.GetUrlHttpWebRequest("https://www.marketwatch.com/investing/stock/" + TickerSymbol + "/financials/cash-flow", "GET", null, false);
            Thread.Sleep(250);            
            //string financials_quickFS = BL.HttpReq.GetUrlHttpWebRequest("https://api.quickfs.net/stocks/" + TickerSymbol + "/ovr/Annual/?sortOrder=ASC" , "GET", null, false);

            if (financials_incomeStatement != null)
            {
                try
                {
                    GetCompanyFinancials_MarketWatch(financials_incomeStatement, financials_balanceSheet, financials_cashFlow, company);
                    //GetCompanyFinancials_QuickFS(financials_quickFS, company);
                    GetCompanyFinancials_Morningstar(TickerSymbol, company);

                    company.AverageRevenueGrowth = CalculateCompoundAnualGrowthRate(company.Financials[0].Revenue);//company.Financials[0].Revenue.Count > 0 ? company.Financials[0].Revenue.Average(r => r.Growth) : null;
                    company.AverageEPSGrowth = CalculateCompoundAnualGrowthRate(company.Financials[0].EPS);// company.Financials[0].EPS.Count > 0 ? company.Financials[0].EPS.Average(r => r.Growth) : null;
                    company.AverageEquityGrowth = CalculateCompoundAnualGrowthRate(company.Financials[0].Equity);//company.Financials[0].Equity.Count > 0 ? company.Financials[0].Equity.Average(r => r.Growth) : null;
                    company.AverageNetIncomeGrowth = CalculateCompoundAnualGrowthRate(company.Financials[0].NetIncome);//company.Financials[0].NetIncome.Count > 0 ? company.Financials[0].NetIncome.Average(r => r.Growth) : null;
                    company.AverageFreeCashFlowGrowth = CalculateCompoundAnualGrowthRate(company.Financials[0].FreeCashFlow);//company.Financials[0].FreeCashFlow.Count > 0 ? company.Financials[0].FreeCashFlow.Average(r => r.Growth) : null;

                    //if (company.Financials[0].ROE.Count > 0)
                    //{
                    //    var avgROE = (decimal)company.Financials[0].ROE.Average(r => r.Value);
                    //    company.AverageROE = avgROE;
                    //}

                    //if (company.AverageROIC != null)
                    //    company.Growth = company.AverageROIC;
                    //else
                    //{
                    if (company.AverageEquityGrowth != null)
                    {
                        var avgGrowth = (decimal)(company.AverageRevenueGrowth +
                            company.AverageEPSGrowth +
                            company.AverageEquityGrowth +
                            company.AverageNetIncomeGrowth +
                            company.AverageFreeCashFlowGrowth) / 5;

                        if (company.AverageROIC != null)
                            avgGrowth = (decimal)(company.AverageRevenueGrowth +
                               company.AverageEPSGrowth +
                               company.AverageEquityGrowth +
                               company.AverageNetIncomeGrowth +
                               company.AverageFreeCashFlowGrowth +
                               company.AverageROIC) / 6;

                        
                        company.Growth = Math.Min(25, avgGrowth);

                    }
                    else
                        company.Growth = 0;
                    //}
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            return company;
        }

        public static decimal? CalculateCompoundAnualGrowthRate(List<YearVal> FinancialIndicator)
        {
            decimal? growth = null;

            if (FinancialIndicator.Count > 0)
            {
                //se poate calcula cresterea compusa(pentru ca sunt pozitive)
                if (FinancialIndicator[FinancialIndicator.Count - 1].Value >= 0
                    && FinancialIndicator[0].Value > 0
                    && FinancialIndicator[FinancialIndicator.Count - 1].Value >= FinancialIndicator[0].Value)
                    growth = ((decimal)Math.Pow(((double)FinancialIndicator[FinancialIndicator.Count - 1].Value / (double)FinancialIndicator[0].Value), (1 / (double)FinancialIndicator.Count)) - 1) * 100;
                else
                {                     
                    //nu se poate calcula cresterea compusa dar exista crestere si se face media
                    if (FinancialIndicator[FinancialIndicator.Count - 1].Value >= FinancialIndicator[0].Value)
                        growth = FinancialIndicator.Average(r => r.Growth);
                    else
                        //nu exista crestere
                        growth = 0;
                }
            }

            return growth;
        }

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

                if (i > 1 && rawLines[i].Contains("bg-quote class=\"value\"") && rawLines[i - 2].Contains("h2 class=\"intraday__price"))
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

                company.Name = name;
                company.CurrentPrice = float.Parse(currentPrice);
                company.MarketCap = marketCap != "N/A" ? ConvertStringToBillions(marketCap) : null;
                company.SharesOutstanding = sharesOutstanding != "N/A" ? ConvertStringToBillions(sharesOutstanding) : 1;
                if (pe_ratio != "N/A")
                    company.PE_Ratio = float.Parse(pe_ratio);
            }
        }

        public static void GetCompanyFinancials_MarketWatch(string html_incomeStatement, string html_balanceSheet, string html_cashFlow, Company company)
        {
            Financials financials = new Financials();
            financials.Source = SourceType.MarketWatch;

            List<string> rawLines_incomeStatement = HtmlHelper.GetRawLinesFromHtml(html_incomeStatement);
            List<string> rawLines_balanceSheet = HtmlHelper.GetRawLinesFromHtml(html_balanceSheet);
            List<string> rawLines_cashFlow = HtmlHelper.GetRawLinesFromHtml(html_cashFlow);

            List<string> selectedLines = HtmlHelper.GetImportantLines(rawLines_incomeStatement, "thead class=\"table__header\"", "/thead");           

            financials.Revenue = GetFinancialData(rawLines_incomeStatement, "<div class=\"cell__content \">Sales/Revenue</div>", "</tr>");
            financials.NetIncome = GetFinancialData(rawLines_incomeStatement, "<div class=\"cell__content \">Net Income</div>", "</tr>");
            financials.EPS = GetFinancialData(rawLines_incomeStatement, "<div class=\"cell__content \">EPS (Diluted)</div>", "</tr>");
            financials.LongTermDebt = GetFinancialData(rawLines_balanceSheet, ">Long-Term Debt</div>", "</tr>");
            financials.Equity = GetFinancialData(rawLines_balanceSheet, "<div class=\"cell__content \">Total Equity</div>", "</tr>");
            financials.FreeCashFlow = GetFinancialData(rawLines_cashFlow, "<div class=\"cell__content \">Free Cash Flow</div>", "</tr>");
            //financials.ROE = GetROE(financials);

            company.Financials.Add(financials);
        }
        //public static void GetCompanyFinancials_QuickFS(string html_quickFS, Company company)
        //{           

        //    if (html_quickFS!=null && html_quickFS.Trim()!=string.Empty)
        //    {
        //        var avgRoicString = HtmlHelper.ExtractString(html_quickFS, "<td class='lt'>ROIC<\\/td><td class='rt'>", "%<\\/td>", false);
        //        company.AverageROIC = Convert.ToDecimal(avgRoicString);
        //    }
        //}

        public static void GetCompanyFinancials_Morningstar(string ticker, Company company)
        {
            string raw_api_key_html = BL.HttpReq.GetUrlHttpWebRequest("https://www.morningstar.com/gamma/assets/8b9e7ff2e51e33cc6303.js", "GET", null, false);
            string api_key = HtmlHelper.ExtractString(raw_api_key_html, "[\"x-api-key\"]=\"", "\")}", false);
            Thread.Sleep(50);
            Hashtable headers = new Hashtable();
            headers.Add("x-api-key", api_key);
            string raw_searchResults = BL.HttpReq.GetUrlHttpWebRequest("https://www.morningstar.com/api/v1/search/entities?q=" + ticker + "&limit=6&autocomplete=true", "GET", null, false, headers);
            MorningstarAutocomplete searchResults = JsonConvert.DeserializeObject<MorningstarAutocomplete>(raw_searchResults);
            string keyRatiosUrl = "https://financials.morningstar.com/finan/financials/getKeyStatPart.html?&t=" + searchResults.results[0].performanceId + "&region=usa&culture=en-US&cur=&order=asc";
            Thread.Sleep(50);
            string morningstar_keyratios_html = BL.HttpReq.GetUrlHttpWebRequest(keyRatiosUrl, "GET", null, false);

            List<string> rawLines_keyRatios = morningstar_keyratios_html.Split("<", StringSplitOptions.RemoveEmptyEntries).ToList();
            List<string> selectedLines = HtmlHelper.GetImportantLines(rawLines_keyRatios, "Return on Invested Capital", "Interest Coverage");

            List<decimal> ROIC_values = new List<decimal>();
            foreach (string line in selectedLines)
            {
                if (line.Contains("pr-profit"))
                {
                    string rawVal = HtmlHelper.ExtractString(line, "\\\">", "", false);
                    decimal RoicVal;
                    bool converted = Decimal.TryParse(rawVal, out RoicVal);

                    if (converted)
                        ROIC_values.Add(RoicVal);
                }
            }

            if (ROIC_values.Count > 0)
                company.AverageROIC = ROIC_values.Average();
        }

        public static List<int> GetAvailableYears(List<string> rawLines)
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

        public static List<YearVal> GetFinancialData(List<string> rawLines, string stringToStartRecording, string stringToStopRecording, bool leaveNumberAsIs = false)
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

            return financialData;
        }

        //public static List<YearVal> GetROE(Financials financials)
        //{
        //    List<YearVal> roe = new List<YearVal>();

        //    for (int i = 0; i < financials.NetIncome.Count; i++)
        //    {
        //        var year = financials.NetIncome[i].Year;
        //        var val = financials.NetIncome[i].Value / financials.Equity[i].Value * 100;

        //        YearVal roe_item = new YearVal();
        //        roe_item.Value = val;
        //        roe_item.Year = year;

        //        roe.Add(roe_item);
        //    }

        //    return roe;
        //}

        public static float? ConvertStringToBillions(string value)
        {



            if (value != "-")
            {
                //try
                //{
                value = value.Replace("(", "-").Replace(")", "");


                float? number = null;
                if (value.ToUpper().EndsWith("K"))
                    number = float.Parse(value.Substring(0, value.Length - 1)) / 1000000;
                else
                    if (value.ToUpper().EndsWith("M"))
                        number = float.Parse(value.Substring(0, value.Length - 1)) / 1000;
                    else
                        if (value.ToUpper().EndsWith("B"))
                            number = float.Parse(value.Substring(0, value.Length - 1));
                        else
                            if (value.ToUpper().EndsWith("T"))
                                number = float.Parse(value.Substring(0, value.Length - 1)) * 1000;
                            else
                                number = float.Parse(value);

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
