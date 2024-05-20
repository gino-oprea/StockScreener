using BL.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace BL.OnlineCompaniesData.DataHelpers
{
    public static class RoicAiHelper
    {
        public static void GetCompanyGeneralInfo(string html, Company company)
        {
            string rawLine;
            StringReader sr = new StringReader(html);
            List<string> rawLines = new List<string>();
            while ((rawLine = sr.ReadLine()) != null)
            {
                if (rawLine != "")
                    rawLines.AddRange(rawLine.Trim().Split("<",StringSplitOptions.RemoveEmptyEntries));
            }

            string nameLine = "";
            string peLine = "";
            string priceLine = "";
            string marketCapLine = "";
            for (int i = 0; i < rawLines.Count; i++)
            {
                if (rawLines[i].Contains("text-4xl font-semibold uppercase text-foreground sm:flex\">") && nameLine == string.Empty)//get only the first occurence
                {
                    nameLine = rawLines[i].Trim();
                }

                if (rawLines[i].Contains("P/E") && peLine == string.Empty)
                {
                    List<string> rawPeLines = rawLines[i].Split("]").ToList();
                    for (int j = 0; j < rawPeLines.Count; j++)
                    {
                        if (rawPeLines[j].Contains("P/E") && j > 0)
                            peLine = rawPeLines[j - 1] + rawPeLines[j];
                    }
                }

                if (rawLines[i].Replace("Capitalization","").Contains("Market Cap") && marketCapLine == string.Empty)
                {                    
                    List<string> rawMarketCapLines = rawLines[i].Split("]").ToList();
                    for (int j = 0; j < rawMarketCapLines.Count; j++)
                    {
                        if (rawMarketCapLines[j].Contains("Market Cap") && j > 0)
                            marketCapLine = rawMarketCapLines[j - 1] + rawMarketCapLines[j];
                    }
                }                  

                if (rawLines[i].Contains("company_header_price\">") && priceLine.Trim()==string.Empty)
                    priceLine = rawLines[i];
            }

            string name = "";
            string pe = "";
            string marketCap = "";
            string price = "";

            if (nameLine != string.Empty)
            {
                try
                {
                    name = HtmlHelper.ExtractString(nameLine, ">", "", false);
                }
                catch (Exception ex) { }
            }

            if (peLine != string.Empty)
            {
                try
                {
                    pe = HtmlHelper.ExtractString(peLine, "flex text-lg text-foreground\\\",\\\"children\\\":\\\"", "\\\"}", false);
                }
                catch (Exception ex) { }
            }

            if (marketCapLine != string.Empty)
            {
                try
                {
                    marketCap = HtmlHelper.ExtractString(marketCapLine, "flex text-lg text-foreground\\\",\\\"children\\\":\\\"", "\\\"}", false);
                }
                catch (Exception ex) { }
            }

            if(priceLine!=string.Empty)
            {
                try
                {
                    price = HtmlHelper.ExtractString(priceLine, ">", "", false);
                }
                catch (Exception ex) { }
            }

            company.Name = name;
            company.PE_Ratio = Convert.ToDecimal(pe);
            company.MarketCap = ConvertStringToBillions(marketCap);

            try
            {
                company.CurrentPrice = decimal.Parse(price, CultureInfo.InvariantCulture);
            }
            catch (Exception ex) { }
        }


        private static decimal? ConvertStringToBillions(string value)
        {
            if (value == string.Empty)
            {
                return null;
            }

            try
            {
                decimal? number = null;
                if (value.ToUpper().EndsWith("K"))
                    number = decimal.Parse(value.Substring(0, value.Length - 1), CultureInfo.InvariantCulture) / 1000000;
                else
                    if (value.ToUpper().EndsWith("M"))
                    number = decimal.Parse(value.Substring(0, value.Length - 1), CultureInfo.InvariantCulture) / 1000;
                else
                        if (value.ToUpper().EndsWith("B"))
                    number = decimal.Parse(value.Substring(0, value.Length - 1), CultureInfo.InvariantCulture);
                else
                            if (value.ToUpper().EndsWith("T"))
                    number = decimal.Parse(value.Substring(0, value.Length - 1), CultureInfo.InvariantCulture) * 1000;
                else
                    number = decimal.Parse(value);

                return number;

            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
