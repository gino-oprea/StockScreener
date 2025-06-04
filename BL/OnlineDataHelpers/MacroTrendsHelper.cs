using BL.Models;
using BL.ModelsUI;
using BL.Utils;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading;

namespace BL.OnlineDataHelpers
{
    public static class MacroTrendsHelper
    {
        private static Random random = new Random();
        public static MacroTrendsData GetCompanyDataMacrotrends(string ticker, Company company)
        {

            var httpResult = HttpReq.GetUrlHttpClientAsync("https://www.macrotrends.net", null, "GET", null, null, false).Result;
            string cookies = httpResult.UpdatedCookies;            

            string companyNameTrimmed = "";
            try
            {
                companyNameTrimmed = company.Name?.ToLower().Replace("ltd", "").Replace(".", "");
            }
            catch { }

            Thread.Sleep(200);
            httpResult = HttpReq.GetUrlHttpClientAsync("https://www.macrotrends.net/assets/php/all_pages_query.php?q=" + ticker, cookies, "GET", null, null, false).Result;
            string categoryLinkJsonString = httpResult.Result;
            if (categoryLinkJsonString == null || categoryLinkJsonString == "null" || categoryLinkJsonString == string.Empty)
            {
                Thread.Sleep(100);
                httpResult = HttpReq.GetUrlHttpClientAsync("https://www.macrotrends.net/assets/php/all_pages_query.php?q=" + companyNameTrimmed, cookies, "GET", null, null, false).Result;
                categoryLinkJsonString = httpResult?.Result;
            }

            if (categoryLinkJsonString == null || categoryLinkJsonString == "null" || categoryLinkJsonString == string.Empty)
                return null;

            List<MacroTrendsCategoryLink> categoryLinks = JsonConvert.DeserializeObject<List<MacroTrendsCategoryLink>>(categoryLinkJsonString);

            if (categoryLinks == null)
            {                
                return null;
            }

            MacroTrendsCategoryLink sharesOutstandingLink = categoryLinks.Find(l => l.url.Contains("shares-outstanding"));

            if (sharesOutstandingLink == null)
            {                
                return null;
            }


            Thread.Sleep(100);
            //shares outsanding
            var shOutResult = HttpReq.GetUrlHttpClientAsync("https://www.macrotrends.net" + sharesOutstandingLink.url, cookies, "GET", null, null, false).Result;
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
                        bool converted = int.TryParse(rawVal, out sharesOutstanding);

                        if (converted)
                            shares.Add((decimal)sharesOutstanding / 1000);//convert to billions
                        else
                            shares.Add(0);
                    }
                }
            }

            //fill shares using revenue data years
            List<YearVal> sharesFinancial = new List<YearVal>();
            if (shares.Count > 0)
            {
                int index = 0;                
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
                
            }

            //add shares growth
            if (shares.Count > 0)
                for (int i = 0; i < sharesFinancial.Count; i++)
                {
                    if (i > 0)
                    {
                        var yearVal = sharesFinancial[i];
                        var newVal = yearVal.Value;
                        var oldVal = sharesFinancial[i - 1].Value;
                        if (newVal != null && oldVal != null && oldVal != 0)
                            yearVal.Growth = ((decimal)newVal - (decimal)oldVal) / Math.Abs((decimal)oldVal) * 100;
                    }
                }

            //price to FCF multiple
            string priceToFcfUrl = $"https://www.macrotrends.net{sharesOutstandingLink.url.Substring(0, sharesOutstandingLink.url.LastIndexOf("/"))}/price-fcf";


            Thread.Sleep(500 + random.Next(1000));
            int? averagePriceToFcfMultiple = GetCompanyAveragePriceToFCFMultiple(priceToFcfUrl, cookies);

            MacroTrendsData data = new MacroTrendsData()
            {
                SharesOutstanding = sharesFinancial,
                AveragePriceToFreeCashFlowMultiple = averagePriceToFcfMultiple
            };

            return data;
        }

        public static int? GetCompanyAveragePriceToFCFMultiple(string priceToFcfUrl, string cookies)
        {
            int? Average_P_FCF_Multiple = null;
            //string priceToFcfHtml = BL.HttpReq.GetUrlHttpWebRequest(priceToFcfUrl, "GET", null, false, headers);
            var httpResult = HttpReq.GetUrlHttpClientAsync(priceToFcfUrl, cookies, "GET", null, null, false).Result;
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
                    bool converted = decimal.TryParse(rawVal, NumberStyles.AllowDecimalPoint, new CultureInfo("en-US"), out pFCF);

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
                    
                    Average_P_FCF_Multiple = Math.Min(Convert.ToInt32(avgPriceToFCF), 15);//terminal multiple maximum 15
                }                
            }

            return Average_P_FCF_Multiple;           
        }        
    }
}
