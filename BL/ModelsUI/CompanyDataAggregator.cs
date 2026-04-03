using BL.Adapters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json.Linq;
using BL.Utils;
using BL.OnlineDataHelpers;
using BL.Models;


namespace BL.ModelsUI
{
    public class CompanyDataAggregator
    {
        private string workingFolder = Constants.WorkingDirectory;

        private Company company;
        public CompanyDataAggregator() 
        {
            company = new Company();
        }
        public Company GetCompany(string tickerSymbol, int discountedInterestRate = 13)
        {
            try
            {
                company = new Company();                

                GetFinancialData(tickerSymbol);

                GetGeneralInfo(tickerSymbol);
                if (company.CurrentPrice == null && tickerSymbol.Contains("-"))
                    GetGeneralInfo(tickerSymbol.Replace("-", "."));//retry with different ticker               

                company.Ticker = tickerSymbol;

                company.CalculateIntrinsicAndDiscountedValues(discountedInterestRate: discountedInterestRate, terminalMultiple: company.Average_P_FCF_Multiple.Value);

                if (company.MarketCap == null && company.SharesOutstanding != null && company.CurrentPrice != null)
                    company.MarketCap = company.SharesOutstanding * company.CurrentPrice;

                return company;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private void GetGeneralInfo(string tickerSymbol)
        {
            var httpRes = HttpReq.GetUrlHttpClientAsync($"https://finviz.com/quote.ashx?t={tickerSymbol}&p=d", null, "GET", null, null, false).Result;
            string generalDetails = httpRes.Result;
            if (generalDetails != null)
                FinvizHelper.GetCompanyGeneralInfo(generalDetails, company);
        }
        private void GetFinancialData(string tickerSymbol)
        {
            var ticker = tickerSymbol.ToUpper();
            List<string> existingTickers = new List<string>();
            if (Directory.Exists(workingFolder))
            {
                // Get all first-level child folders
                var childFolders = Directory.GetDirectories(workingFolder).ToList();

                var companyFolder = childFolders.FirstOrDefault(f => Path.GetFileName(f) == ticker);
                if (companyFolder != null)
                {                    
                    RoicAiCompany roicAiCompany = MapJsonToRoicAiCompany(companyFolder, ticker);

                    //adapter for converting roicAiCompany to Company                    
                    CompanyRoicAiAdapter.MergeCompanyFromRoicAi(roicAiCompany, company);

                    company.CalculateGrowthAverages();//also sets up the average price to FCF if it's not available from macrotrends
                }
            }            
        }                    

        private RoicAiCompany MapJsonToRoicAiCompany(string companyFolder, string ticker)
         {
            RoicAiCompany roicAiCompany = new RoicAiCompany();


            roicAiCompany.Profile = GetJsonToModel<List<CompanyProfile>>(Path.Combine(companyFolder, $"{ticker}_profile.json")).FirstOrDefault();
            roicAiCompany.IncomeStatements = GetJsonToModel<List<IncomeStatement_Periodical>>(Path.Combine(companyFolder, $"{ticker}_income_statement.json"));
            roicAiCompany.BalanceSheets = GetJsonToModel<List<BalanceSheet_Periodical>>(Path.Combine(companyFolder, $"{ticker}_balance_sheet.json"));
            roicAiCompany.CashFlowStatements = GetJsonToModel<List<CashFlowStatement_Periodical>>(Path.Combine(companyFolder, $"{ticker}_cash_flow_statement.json"));
            roicAiCompany.PerShareData = GetJsonToModel<List<PerShareData_Periodical>>(Path.Combine(companyFolder, $"{ticker}_per_share_data.json"));
            roicAiCompany.ProfitabilityRatios = GetJsonToModel<List<ProfitabilityRatios_Periodical>>(Path.Combine(companyFolder, $"{ticker}_profitability_ratios.json"));
            roicAiCompany.ValuationMultiples = GetJsonToModel<List<ValuationMultiples_Periodical>>(Path.Combine(companyFolder, $"{ticker}_valuation_multiples.json"));           

            return roicAiCompany;
        }        
       
        private T GetJsonToModel<T>(string jsonFile)
        {
            if (!File.Exists(jsonFile))
                return default;

            
            using (StreamReader r = new StreamReader(jsonFile))
            {
                string json = r.ReadToEnd();
                T model = JsonConvert.DeserializeObject<T>(json);
                return model;
            }
        }
    }
}
