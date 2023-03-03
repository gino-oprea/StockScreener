using BL.Models;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace BL.OnlineCompaniesData.DataHelpers
{
    public static class MorningstarHelper
    {
        public static void GetCompanyFinancials_Morningstar_Old(string ticker, Company company)
        {

            string raw_api_key_html = BL.HttpReq.GetUrlHttpWebRequest("https://www.morningstar.com/assets/7191f38.js", "GET", null, false);
            string api_key = HtmlHelper.ExtractString(raw_api_key_html, "[\"x-api-key\"]=\"", "\")}", false);
            Thread.Sleep(100);
            Hashtable headers = new Hashtable();
            headers.Add("x-api-key", api_key);
            headers.Add("Host", "www.morningstar.com");
            headers.Add("Accept-Encoding", "gzip, deflate, br");
            string raw_searchResults = BL.HttpReq.GetUrlHttpWebRequest("https://www.morningstar.com/api/v1/search/entities?q=" + ticker + "&limit=6&autocomplete=true", "GET", null, false, headers);
            MorningstarAutocomplete searchResults = JsonConvert.DeserializeObject<MorningstarAutocomplete>(raw_searchResults);
            string keyRatiosUrl = "https://financials.morningstar.com/finan/financials/getKeyStatPart.html?&t=" + searchResults.results[0].performanceId + "&region=usa&culture=en-US&cur=&order=asc";
            string financialsUrl = "https://financials.morningstar.com/finan/financials/getFinancePart.html?&t=" + searchResults.results[0].performanceId + "&region=usa&culture=en-US&cur=&order=asc";
            Thread.Sleep(100);
            string morningstar_keyratios_html = BL.HttpReq.GetUrlHttpWebRequest(keyRatiosUrl, "GET", null, false);
            Thread.Sleep(100);
            string morningstar_financials_html = BL.HttpReq.GetUrlHttpWebRequest(financialsUrl, "GET", null, false);

            List<string> rawLines_keyRatios = morningstar_keyratios_html.Split("<", StringSplitOptions.RemoveEmptyEntries).ToList();
            List<string> rawLines_financials = morningstar_financials_html.Split("<", StringSplitOptions.RemoveEmptyEntries).ToList();
            List<string> selectedLines = HtmlHelper.GetImportantLines(rawLines_keyRatios, "Return on Invested Capital", "Interest Coverage");
            selectedLines.AddRange(HtmlHelper.GetImportantLines(rawLines_financials, "Shares", "Book Value Per Share"));

            List<decimal> ROIC_values = new List<decimal>();
            List<float> shares = new List<float>();
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

                if (line.Contains("Y5 i7")
                    || line.Contains("Y6 i7")
                    || line.Contains("Y7 i7")
                    || line.Contains("Y8 i7")
                    || line.Contains("Y9 i7")
                    || line.Contains("Y10 i7"))
                {
                    string rawVal = HtmlHelper.ExtractString(line, "\\\">", "", false).Replace(",", "");
                    int sharesOutstanding;
                    bool converted = Int32.TryParse(rawVal, out sharesOutstanding);

                    if (converted)
                        shares.Add(sharesOutstanding / 1000f);//convert to billions float
                    else
                        shares.Add(0);
                }
            }

            //fill shares using revenue data years
            if (shares.Count > 0)
            {
                int index = shares.Count - 1;
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
                    index--;
                }
                company.Financials.Shares = sharesFinancial;
            }
            //add shares growth
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
                company.SharesOutstanding = shares[shares.Count - 1];
            else
                company.SharesOutstanding = 1;

            if (ROIC_values.Count > 0)
                company.AverageROIC = ROIC_values.Average();
        }

        public static string GetMorningstarApiKeyUrlJs()
        {
            string apiKeyUrl = "";

            string raw_api_js_asset_html = BL.HttpReq.GetUrlHttpWebRequest("https://www.morningstar.com", "GET", null, false);
            string rawLine;
            StringReader sr = new StringReader(raw_api_js_asset_html);
            List<string> rawLines = new List<string>();
            while ((rawLine = sr.ReadLine()) != null)
            {
                if (rawLine != "" && rawLine.Contains("href=\"/assets") && rawLine.Contains(".js"))
                    rawLines.Add(rawLine.Trim());
            }
            if (rawLines.Count > 0)
            {
                var rawJsLines = rawLines[0].Split("<link");

                var scriptLines = new List<string>();
                for (int i = 0; i < rawJsLines.Length; i++)
                {
                    if (rawJsLines[i].Contains("as=\"script\""))
                        scriptLines.Add(rawJsLines[i]);
                }

                apiKeyUrl = HtmlHelper.ExtractString(scriptLines[scriptLines.Count - 2], "href=\"", "\" as=\"script\"", false);
            }


            return apiKeyUrl;
        }
        public static void GetCompanyFinancials_Morningstar(string ticker, Company company)
        {

            string apiKeyUrlJs = GetMorningstarApiKeyUrlJs();

            string Url = "https://www.morningstar.com/assets/6105b70.js";
            if (apiKeyUrlJs != "")
                Url = "https://www.morningstar.com" + apiKeyUrlJs;

            string raw_api_key_html = BL.HttpReq.GetUrlHttpWebRequest(Url, "GET", null, false);
            string api_key = HtmlHelper.ExtractString(raw_api_key_html, "[\"x-api-key\"]=\"", "\")}", false);
            Thread.Sleep(100);
            Hashtable headers = new Hashtable();
            headers.Add("x-api-key", api_key);
            headers.Add("Host", "www.morningstar.com");
            headers.Add("Accept-Encoding", "gzip, deflate, br");
            string raw_searchResults = BL.HttpReq.GetUrlHttpWebRequest("https://www.morningstar.com/api/v1/search/entities?q=" + ticker + "&limit=6&autocomplete=true", "GET", null, false, headers);
            MorningstarAutocomplete searchResults = JsonConvert.DeserializeObject<MorningstarAutocomplete>(raw_searchResults);

            if (searchResults.results.Count == 0)
                return;

            string raw_key_ratios_api_key_html = BL.HttpReq.GetUrlHttpWebRequest("https://www.morningstar.com/assets/quotes/2.9.0/sal-components.umd.min.51.js", "GET", null, false);
            string key_ratios_api_key = HtmlHelper.ExtractString(raw_key_ratios_api_key_html, "keyApigee:\"", "\",", false);


            Hashtable headers_keyRatios = new Hashtable();
            headers_keyRatios.Add("apikey", key_ratios_api_key);
            headers_keyRatios.Add("Host", "api-global.morningstar.com");
            headers_keyRatios.Add("Content-Type", "application/json; charset=utf-8");
            string keyRatiosUrl = "https://api-global.morningstar.com/sal-service/v1/stock/keyStats/OperatingAndEfficiency/" +
                searchResults.results[0].performanceId + "?languageId=en&locale=en&clientId=undefined&component=sal-components-key-stats-oper-efficiency&version=3.71.0";
            string morningstar_keyratios_json = BL.HttpReq.GetUrlHttpWebRequest(keyRatiosUrl, "GET", null, false, headers_keyRatios);

            if (morningstar_keyratios_json != null)
            {
                MorningstarKeyRatios keyRatios = JsonConvert.DeserializeObject<MorningstarKeyRatios>(morningstar_keyratios_json);

                for (int i = keyRatios.dataList.Count - 1; i >= 0; i--)
                {
                    if (!int.TryParse(keyRatios.dataList[i].fiscalPeriodYear, out int n) || keyRatios.dataList[i].operatingMargin == null)
                        keyRatios.dataList.RemoveAt(i);
                }

                //fill operating margin using revenue data years
                if (keyRatios.dataList.Count > 0)
                {
                    int index = keyRatios.dataList.Count - 1;
                    List<YearVal> operatingMargins = new List<YearVal>();
                    for (int i = company.Financials.Revenue.Count - 1; i >= 0; i--)
                    {
                        if (index < keyRatios.dataList.Count)
                        {
                            YearVal yearVal = new YearVal();
                            if (index < 0)//if no data, fill with null objects
                            {
                                yearVal.Year = company.Financials.Revenue[i].Year;
                                yearVal.Value = null;
                            }
                            else
                            {
                                yearVal.Year = company.Financials.Revenue[i].Year;
                                yearVal.Value = (float)keyRatios.dataList[index].operatingMargin;
                            }

                            operatingMargins.Insert(0, yearVal);
                        }
                        index--;
                    }
                    company.Financials.OperatingMargin = operatingMargins;
                }
                //add operating margins growth
                if (company.Financials.OperatingMargin != null)
                    for (int i = 0; i < company.Financials.OperatingMargin.Count; i++)
                    {
                        if (i > 0)
                        {
                            var yearVal = company.Financials.OperatingMargin[i];
                            var newVal = yearVal.Value;
                            var oldVal = company.Financials.OperatingMargin[i - 1].Value;
                            if (newVal != null && oldVal != null && oldVal != 0)
                                yearVal.Growth = ((decimal)newVal - (decimal)oldVal) / Math.Abs((decimal)oldVal) * 100;
                        }
                    }

                var Last5Yr_keyRatios = keyRatios.dataList.Skip(Math.Max(0, keyRatios.dataList.Count() - 5)).ToList();


                if (Last5Yr_keyRatios.Count > 0 && Last5Yr_keyRatios.FindAll(k => k.roic != null).Count > 0)
                    company.AverageROIC = Last5Yr_keyRatios.FindAll(k => k.roic != null).Select(k => k.roic.Value).Average();
            }
        }
    }
}
