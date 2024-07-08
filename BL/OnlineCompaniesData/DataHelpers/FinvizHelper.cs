using BL.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BL.OnlineCompaniesData.DataHelpers
{
    public static class FinvizHelper
    {
        public static void GetCompanyGeneralInfo(string html, Company company)
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
                if (rawLines[i].Contains("quote-header_ticker-wrapper_company text-xl"))
                    selectedLines.Add(rawLines[i + 2]);

                if (rawLines[i].Contains("quote-price_wrapper_price"))
                    selectedLines.Add(rawLines[i]);
            }

            if (selectedLines.Count == 2)
            {
                string name = selectedLines[0];
                string currentPrice = HtmlHelper.ExtractString(selectedLines[1], ">", "</", false);


                decimal decimalPrice;
                bool priceParsed = Decimal.TryParse(currentPrice, out decimalPrice);

                decimal? marketCap = null;
                if (priceParsed)
                    marketCap = decimalPrice * company.SharesOutstanding;


                company.Name = name.Replace("&amp;", "&").Replace("&#x27;", "'");
                company.CurrentPrice = decimalPrice;
                company.MarketCap = marketCap;

                if (company.Financials.EPS.Last().Value > 0)
                    company.PE_Ratio = company.CurrentPrice / company.Financials.EPS.Last().Value;
            }
        }       
        
    }
}
