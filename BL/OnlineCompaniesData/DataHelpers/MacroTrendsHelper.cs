using BL.Models;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BL.OnlineCompaniesData.DataHelpers
{
    public static class MacroTrendsHelper
    {
        public static void GetCompanyDataMacrotrends(string ticker, Company company)
        {
            Hashtable headers = new Hashtable();
            headers.Add("Cookie", "__cf_bm=YzILsMBBHSEiSdsP9kWROxF.jJ4QSh4C3gHSn7Bsq04-1703409277-1-AYozGZFa+2FbVXVNB4o75EQ7lu90H9aUFqxTjdoZjCXy4LGA87pkvp58MLWq9VwVE8uax0OtKcBDcjmicnqO4Cs=");

            string companyNameTrimmed = "";

            try
            {
                companyNameTrimmed = company.Name.ToLower().Replace("ltd", "").Replace(".", "");
            }
            catch { }

            string categoryLinkJsonString = BL.HttpReq.GetUrlHttpWebRequest("https://www.macrotrends.net/assets/php/all_pages_query.php?q=" + ticker, "GET", null, false, headers);
            if (categoryLinkJsonString == null || categoryLinkJsonString == "null" || categoryLinkJsonString == string.Empty)
                categoryLinkJsonString = BL.HttpReq.GetUrlHttpWebRequest("https://www.macrotrends.net/assets/php/all_pages_query.php?q=" + companyNameTrimmed, "GET", null, false, headers);

            if (categoryLinkJsonString == null || categoryLinkJsonString == "null" || categoryLinkJsonString == string.Empty)
                return;

            List<MacroTrendsCategoryLink> categoryLinks = JsonConvert.DeserializeObject<List<MacroTrendsCategoryLink>>(categoryLinkJsonString);

            if (categoryLinks == null)
            {
                company.SharesOutstanding = 1;
                return;
            }

            MacroTrendsCategoryLink sharesOutstandingLink = categoryLinks.Find(l => l.url.Contains("shares-outstanding"));

            if (sharesOutstandingLink == null)
            {
                company.SharesOutstanding = 1;
                return;
            }

            string sharesOutstandingHtml = BL.HttpReq.GetUrlHttpWebRequest("https://www.macrotrends.net" + sharesOutstandingLink.url, "GET", null, false, headers);

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
                company.SharesOutstanding = shares[0];
            else
                company.SharesOutstanding = 1;
        }

        public static void GetCompanyAveragePriceToFCFMultiple(string ticker, Company company)
        {
            string historicalDataHtml = BL.HttpReq.GetUrlHttpWebRequest("https://www.macrotrends.net/assets/php/fundamental_iframe.php?t=" + ticker + "&type=price-fcf&statement=price-ratios&freq=Q", "GET", null, false);

            if (historicalDataHtml == null)
                return;

            List<string> rawLines = historicalDataHtml.Split("\r\n", StringSplitOptions.RemoveEmptyEntries).ToList();
            string selectedLine = rawLines.Find(l => l.Contains("chartData"));
            if (selectedLine != null)
            {
                string json = HtmlHelper.ExtractString(selectedLine, "var chartData = ", "", false);

                List<HistoricalPriceToFreeCashflowData> histData = JsonConvert.DeserializeObject<List<HistoricalPriceToFreeCashflowData>>(json);

                if (histData != null && histData.Count > 0)
                {
                    histData.RemoveAll(h => h.v3 == 0);//eliminam valorile 0

                    var avgPriceToFCF = histData.Count > 0 ? histData.Average(h => h.v3) : 1;
                    bool noOutliersFound = false;
                    //remove outliers
                    if (histData.Count > 0)
                        while (!noOutliersFound)
                        {
                            noOutliersFound = true;
                            var stdDev = Math.Sqrt(histData.Sum(h => Math.Pow(h.v3 - avgPriceToFCF, 2)) / histData.Count);
                            for (int i = histData.Count - 1; i >= 0; i--)
                            {
                                if (histData[i].v3 - avgPriceToFCF > 1.5 * stdDev
                                    || avgPriceToFCF - histData[i].v3 > 2.5 * stdDev) //eliminam mai multe din deviatiile pozitive decat din cele negative 
                                {
                                    noOutliersFound = false;
                                    histData.RemoveAt(i);
                                }
                            }
                            avgPriceToFCF = histData.Average(h => h.v3);
                        }

                    company.Average_P_FCF_Multiple = Math.Min(Convert.ToInt32(avgPriceToFCF), 15);//terminal multiple maximum 15
                }
                else
                {
                    company.Average_P_FCF_Multiple = null;
                }
            }
        }
    }
}
