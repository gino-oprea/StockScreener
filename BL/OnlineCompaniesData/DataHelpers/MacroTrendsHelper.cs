using BL.Models;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading;

namespace BL.OnlineCompaniesData.DataHelpers
{
    public static class MacroTrendsHelper
    {
        public static void GetCompanyDataMacrotrends(string ticker, Company company)
        {

            var httpResult = BL.HttpReq.GetUrlHttpClientAsync("https://www.macrotrends.net", null, "GET", null, null, false).Result;
            string cookies = httpResult.UpdatedCookies;            

            string companyNameTrimmed = "";
            try
            {
                companyNameTrimmed = company.Name.ToLower().Replace("ltd", "").Replace(".", "");
            }
            catch { }

            Thread.Sleep(200);
            httpResult = BL.HttpReq.GetUrlHttpClientAsync("https://www.macrotrends.net/assets/php/all_pages_query.php?q=" + ticker, cookies, "GET", null, null, false).Result;
            string categoryLinkJsonString = httpResult.Result;
            if (categoryLinkJsonString == null || categoryLinkJsonString == "null" || categoryLinkJsonString == string.Empty)
            {
                Thread.Sleep(100);
                httpResult = BL.HttpReq.GetUrlHttpClientAsync("https://www.macrotrends.net/assets/php/all_pages_query.php?q=" + companyNameTrimmed, cookies, "GET", null, null, false).Result;
                categoryLinkJsonString = httpResult?.Result;
            }

            if (categoryLinkJsonString == null || categoryLinkJsonString == "null" || categoryLinkJsonString == string.Empty)
                return;

            List<MacroTrendsCategoryLink> categoryLinks = JsonConvert.DeserializeObject<List<MacroTrendsCategoryLink>>(categoryLinkJsonString);

            if (categoryLinks == null)
            {                
                return;
            }

            MacroTrendsCategoryLink sharesOutstandingLink = categoryLinks.Find(l => l.url.Contains("shares-outstanding"));

            if (sharesOutstandingLink == null)
            {                
                return;
            }


            Thread.Sleep(100);
            //shares outsanding
            var shOutResult = BL.HttpReq.GetUrlHttpClientAsync("https://www.macrotrends.net" + sharesOutstandingLink.url, cookies, "GET", null, null, false).Result;
            string sharesOutstandingHtml = shOutResult.Result;

            List<decimal> shares = new List<decimal>();

            if (sharesOutstandingHtml != null)
            {
                List<string> rawLines_sharesOutstanding = sharesOutstandingHtml.Split("<", StringSplitOptions.RemoveEmptyEntries).ToList();
                List<string> selectedLines = HtmlHelper.GetImportantLines(rawLines_sharesOutstanding, "Annual Shares Outstanding", "/tbody");

                for (int i = 0; i < selectedLines.Count; i++)
                {
                    if (i < selectedLines.Count - 2 && selectedLines[i].Contains("text-align:center") && selectedLines[i + 2].Contains("text-align:center"))
                    {
                        string line = selectedLines[i + 2];
                        string rawVal = HtmlHelper.ExtractString(line, "text-align:center\">", "", false).Replace(",", "");
                        int sharesOutstanding;
                        bool converted = Int32.TryParse(rawVal, out sharesOutstanding);

                        if (converted)
                            shares.Add((decimal)sharesOutstanding / 1000);//convert to billions
                        else
                            shares.Add(0);
                    }
                }
            }

            //fill shares using revenue data years
            if (shares.Count > 0)
            {
                int index = 0;
                List<YearVal> sharesFinancial = new List<YearVal>();
                for (int i = company.Financials.Revenue.Count - 1; i >= 0; i--)
                {
                    if (index < shares.Count)
                    {
                        YearVal yearVal = new YearVal();
                        yearVal.Year = company.Financials.Revenue[i].Year;
                        yearVal.Value = shares[index];

                        sharesFinancial.Insert(0, yearVal);
                    }
                    index++;
                }
                company.Financials.Shares = sharesFinancial;
            }

            //add shares growth
            if (shares.Count > 0)
                for (int i = 0; i < company.Financials.Shares.Count; i++)
                {
                    if (i > 0)
                    {
                        var yearVal = company.Financials.Shares[i];
                        var newVal = yearVal.Value;
                        var oldVal = company.Financials.Shares[i - 1].Value;
                        if (newVal != null && oldVal != null && oldVal != 0)
                            yearVal.Growth = ((decimal)newVal - (decimal)oldVal) / Math.Abs((decimal)oldVal) * 100;
                    }
                }

            if (shares.Count > 0)
                company.SharesOutstanding = shares[0];//if not, the share will remain the ones got from marketwatch
            


            //price to FCF multiple
            string priceToFcfUrl = $"https://www.macrotrends.net{sharesOutstandingLink.url.Substring(0, sharesOutstandingLink.url.LastIndexOf("/"))}/price-fcf";


            Thread.Sleep(100);
            GetCompanyAveragePriceToFCFMultiple(priceToFcfUrl, cookies, company);
        }

        public static void GetCompanyAveragePriceToFCFMultiple(string priceToFcfUrl, string cookies, Company company)
        {
            //string priceToFcfHtml = BL.HttpReq.GetUrlHttpWebRequest(priceToFcfUrl, "GET", null, false, headers);
            var httpResult = BL.HttpReq.GetUrlHttpClientAsync(priceToFcfUrl, cookies, "GET", null, null, false).Result;
            string priceToFcfHtml = httpResult.Result;

            List<decimal> pFcfMultiples = new List<decimal>();

            if (priceToFcfHtml != null)
            {
                List<string> rawLines_sharesOutstanding = priceToFcfHtml.Split("</tr>", StringSplitOptions.RemoveEmptyEntries).ToList();
                List<string> selectedLines = HtmlHelper.GetImportantLines(rawLines_sharesOutstanding, "Price to Free Cash Flow Ratio Historical Data", "/tbody");

                for (int i = 2; i < selectedLines.Count; i++)
                {

                    string[] rowlines = selectedLines[i].Split("</td>", StringSplitOptions.RemoveEmptyEntries);

                    string rawVal = HtmlHelper.ExtractString(rowlines[3], "text-align:center;\">", "", false).Replace(",", "");
                    decimal pFCF;
                    bool converted = Decimal.TryParse(rawVal, NumberStyles.AllowDecimalPoint, new CultureInfo("en-US"), out pFCF);

                    if (converted)
                        pFcfMultiples.Add(pFCF);
                    else
                        pFcfMultiples.Add(10);
                }



                if (pFcfMultiples.Count > 0)
                {
                    pFcfMultiples.RemoveAll(h => h == 0);//eliminam valorile 0

                    var avgPriceToFCF = pFcfMultiples.Count > 0 ? pFcfMultiples.Average() : 1;
                    bool noOutliersFound = false;
                    //remove outliers
                    if (pFcfMultiples.Count > 0)
                        while (!noOutliersFound)
                        {
                            noOutliersFound = true;
                            var stdDev = Math.Sqrt(pFcfMultiples.Sum(h => Math.Pow((double)h - (double)avgPriceToFCF, 2)) / pFcfMultiples.Count);
                            for (int i = pFcfMultiples.Count - 1; i >= 0; i--)
                            {
                                if (pFcfMultiples[i] - avgPriceToFCF > (decimal)1.5 * (decimal)stdDev
                                    || avgPriceToFCF - pFcfMultiples[i] > (decimal)2.5 * (decimal)stdDev) //eliminam mai multe din deviatiile pozitive decat din cele negative 
                                {
                                    noOutliersFound = false;
                                    pFcfMultiples.RemoveAt(i);
                                }
                            }
                            avgPriceToFCF = pFcfMultiples.Average();
                        }

                    company.Average_P_FCF_Multiple = Math.Min(Convert.ToInt32(avgPriceToFCF), 15);//terminal multiple maximum 15
                }
                else
                {
                    company.Average_P_FCF_Multiple = null;
                }
            }
           
        }

        //public static void GetCompanyAveragePriceToFCFMultiple_Old(string ticker, Company company)
        //{
        //    string historicalDataHtml = BL.HttpReq.GetUrlHttpWebRequest("https://www.macrotrends.net/assets/php/fundamental_iframe.php?t=" + ticker + "&type=price-fcf&statement=price-ratios&freq=Q", "GET", null, false);

        //    if (historicalDataHtml == null)
        //        return;

        //    List<string> rawLines = historicalDataHtml.Split("\r\n", StringSplitOptions.RemoveEmptyEntries).ToList();
        //    string selectedLine = rawLines.Find(l => l.Contains("chartData"));
        //    if (selectedLine != null)
        //    {
        //        string json = HtmlHelper.ExtractString(selectedLine, "var chartData = ", "", false);

        //        List<HistoricalPriceToFreeCashflowData> histData = JsonConvert.DeserializeObject<List<HistoricalPriceToFreeCashflowData>>(json);

        //        if (histData != null && histData.Count > 0)
        //        {
        //            histData.RemoveAll(h => h.v3 == 0);//eliminam valorile 0

        //            var avgPriceToFCF = histData.Count > 0 ? histData.Average(h => h.v3) : 1;
        //            bool noOutliersFound = false;
        //            //remove outliers
        //            if (histData.Count > 0)
        //                while (!noOutliersFound)
        //                {
        //                    noOutliersFound = true;
        //                    var stdDev = Math.Sqrt(histData.Sum(h => Math.Pow(h.v3 - avgPriceToFCF, 2)) / histData.Count);
        //                    for (int i = histData.Count - 1; i >= 0; i--)
        //                    {
        //                        if (histData[i].v3 - avgPriceToFCF > 1.5 * stdDev
        //                            || avgPriceToFCF - histData[i].v3 > 2.5 * stdDev) //eliminam mai multe din deviatiile pozitive decat din cele negative 
        //                        {
        //                            noOutliersFound = false;
        //                            histData.RemoveAt(i);
        //                        }
        //                    }
        //                    avgPriceToFCF = histData.Average(h => h.v3);
        //                }

        //            company.Average_P_FCF_Multiple = Math.Min(Convert.ToInt32(avgPriceToFCF), 15);//terminal multiple maximum 15
        //        }
        //        else
        //        {
        //            company.Average_P_FCF_Multiple = null;
        //        }
        //    }
        //}
    }
}
