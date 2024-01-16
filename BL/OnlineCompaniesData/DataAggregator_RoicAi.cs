using BL.Models;
using BL.OnlineCompaniesData.DataHelpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;

namespace BL.OnlineCompaniesData
{
    public class DataAggregator_RoicAi : IDataAggregator
    {
        public DataAggregator_RoicAi() { }
        public Company GetCompanyCurrentPrice(string TickerSymbol)
        {
            string generalDetailsHtml = BL.HttpReq.GetUrlHttpWebRequest("https://roic.ai/company/" + TickerSymbol, "GET", null, false);

            Company company = new Company();
            if (generalDetailsHtml != null)
                RoicAiHelper.GetCompanyGeneralInfo(generalDetailsHtml, company);

            return company;
        }

        public Company GetCompanyData(string TickerSymbol, bool isCache = false)
        {
            Company company = new Company();
            if (isCache)
            {
                StreamReader r = new StreamReader("companies.json");
                string jsonString = r.ReadToEnd();
                List<Company> companies = JsonConvert.DeserializeObject<List<Company>>(jsonString);

                company = companies.Find(c => c.Ticker.ToLower() == TickerSymbol.ToLower());

                //for current price
                string generalDetails = BL.HttpReq.GetUrlHttpWebRequest("https://roic.ai/company/" + TickerSymbol, "GET", null, false);
                if (generalDetails != null)
                    RoicAiHelper.GetCompanyGeneralInfo(generalDetails, company);
            }
            else
            {
                company.Ticker = TickerSymbol.ToUpper();
                company.Financials = new Financials();

                string generalDetails = BL.HttpReq.GetUrlHttpWebRequest("https://roic.ai/company/" + TickerSymbol, "GET", null, false);
                if (generalDetails != null)
                    RoicAiHelper.GetCompanyGeneralInfo(generalDetails, company);
                

                if (generalDetails != null)
                {
                    try
                    {
                        Thread.Sleep(50);
                        string financialDetails = BL.HttpReq.GetUrlHttpWebRequest("https://roic.ai/financials/" + TickerSymbol, "GET", null, false);

                        RoicAiHelper.GetCompanyFinancials(financialDetails, company);
                        //MacroTrendsHelper.GetCompanyAveragePriceToFCFMultiple(TickerSymbol, company);

                        company.CalculateGrowthAverages();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }

            return company;
        }
    }
}
