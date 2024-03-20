using BL.Adapters;
using BL.CompaniesData.JsonModels.RoicAi;
using BL.Models;
using BL.OfflineCompaniesData.Models.RoicAi;
using BL.OnlineCompaniesData.DataHelpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;


namespace BL.CompaniesData
{
    public class CompaniesDataAggregator
    {
        private string workingFolder = "Companies_2023";

        private Company company;
        public CompaniesDataAggregator() 
        {
            company = new Company();
        }
        public Company GetCompany(string tickerSymbol, int discountedInterestRate = 13)
        {
            try
            {
                company = new Company();
                
                GetGeneralInfo(tickerSymbol);
                if (company.CurrentPrice == null && (tickerSymbol.Contains("-")))
                    GetGeneralInfo(tickerSymbol.Replace("-", "."));//retry with different ticker

                GetFinancialData(tickerSymbol);

                //backup in case macrotrends data is not already on disk, and save it if able to get data online
                if (!MacrotrendsDataExists(tickerSymbol.ToUpper()))
                    try
                    {
                        GetMacroTrendsData(tickerSymbol.ToUpper());
                    }
                    catch (Exception ex) { }

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
            //var httpRes = BL.HttpReq.GetUrlHttpClientAsync("https://www.marketwatch.com/investing/stock/" + tickerSymbol + "?mod=over_search", null, "GET", null, null, false).Result;
            //string generalDetails = httpRes.Result;
            //if (generalDetails != null)
            //    MarketWatchHelper.GetCompanyGeneralInfo_MarketWatch(generalDetails, company);

            var httpRes = BL.HttpReq.GetUrlHttpClientAsync("https://roic.ai/quote/" + tickerSymbol + ":US/financials", null, "GET", null, null, false).Result;
            string generalDetails = httpRes.Result;
            if (generalDetails != null)
                RoicAiHelper.GetCompanyGeneralInfo(generalDetails, company);
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

                    company.CalculateGrowthAverages();
                }
            }            
        }

        private void GetMacroTrendsData(string tickerSymbol)
        {
            MacroTrendsData macroTrendsData = MacroTrendsHelper.GetCompanyDataMacrotrends(tickerSymbol, company);

            //if (company.Financials.Shares?.Count > 0 && company.Average_P_FCF_Multiple != null)
            if (macroTrendsData.AveragePriceToFreeCashFlowMultiple != null)
            {
                company.Average_P_FCF_Multiple = macroTrendsData.AveragePriceToFreeCashFlowMultiple;

                var json = JsonConvert.SerializeObject(macroTrendsData);
                var companyFolder = Path.Combine(workingFolder, tickerSymbol);
                SaveJsonToDisk(json, companyFolder, $"{tickerSymbol}_MacrotrendsData.json");
            }
        }

        private async Task SaveJsonToDisk(string json, string folderPath, string fileName)
        {
            string filePath = Path.Combine(folderPath, fileName);
            // Ensure that the directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(filePath));
            // Write the JSON string to the file
            await File.WriteAllTextAsync(filePath, json);
        }        
        private RoicAiCompany MapJsonToRoicAiCompany(string companyFolder, string ticker)
        {
            CompanySummary companySummary = GetJsonToModel<CompanySummary>(Path.Combine(companyFolder, $"{ticker}_Summary.json"));
            IncomeStatement incomeStatement = GetJsonToModel<IncomeStatement>(Path.Combine(companyFolder, $"{ticker}_IncomeStatement.json"));
            BalanceSheet balanceSheet = GetJsonToModel<BalanceSheet>(Path.Combine(companyFolder, $"{ticker}_BalanceSheet.json"));
            CashFlowStatement cashFlowStatement = GetJsonToModel<CashFlowStatement>(Path.Combine(companyFolder, $"{ticker}_CashFlowStatment.json"));
            MacroTrendsData macroTrendsData = GetJsonToModel<MacroTrendsData>(Path.Combine(companyFolder, $"{ticker}_MacrotrendsData.json"));

            RoicAiCompany roicAiCompany = new RoicAiCompany()
            {
                CompanySummary = companySummary,
                IncomeStatement = incomeStatement,
                BalanceSheet = balanceSheet,
                CashFlowStatement = cashFlowStatement,
                MacroTrendsData = macroTrendsData
            };

            return roicAiCompany;
        }
        private bool MacrotrendsDataExists(string ticker)
        {
            bool exists = false;
            var filePath = Path.Combine(workingFolder, ticker, $"{ticker}_MacrotrendsData.json");

            if (File.Exists(filePath))
            {
                MacroTrendsData macroTrendsData = GetJsonToModel<MacroTrendsData>(filePath);
                if (macroTrendsData?.SharesOutstanding.Count > 0 && macroTrendsData.AveragePriceToFreeCashFlowMultiple != null)
                    exists = true;
            }

            return exists;
        }

        private T GetJsonToModel<T>(string jsonFile)
        {
            if (!File.Exists(jsonFile))
                return default(T);

            
            using (StreamReader r = new StreamReader(jsonFile))
            {
                string json = r.ReadToEnd();
                T model = JsonConvert.DeserializeObject<T>(json);
                return model;
            }
        }
    }
}
