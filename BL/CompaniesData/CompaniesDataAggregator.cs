using BL.Adapters;
using BL.CompaniesData.JsonModels;
using BL.CompaniesData.JsonModels.RoicAi_Old;
using BL.CompaniesData.JsonModels.RoicAI;
using BL.Models;
using BL.OfflineCompaniesData.Models.RoicAi_Old;
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
using Newtonsoft.Json.Linq;


namespace BL.CompaniesData
{
    public class CompaniesDataAggregator
    {
        private string workingFolder = Constants.WorkingDirectory;

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

                GetFinancialData(tickerSymbol);

                GetGeneralInfo(tickerSymbol);
                if (company.CurrentPrice == null && (tickerSymbol.Contains("-")))
                    GetGeneralInfo(tickerSymbol.Replace("-", "."));//retry with different ticker

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
            var httpRes = BL.HttpReq.GetUrlHttpClientAsync($"https://finviz.com/quote.ashx?t={tickerSymbol}&p=d", null, "GET", null, null, false).Result;
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
                    //RoicAiCompany_Old roicAiCompany = MapJsonToRoicAiCompany_Old(companyFolder, ticker);
                    RoicAiCompany roicAiCompany = MapJsonToRoicAiCompany(companyFolder, ticker);

                    //adapter for converting roicAiCompany to Company
                    //CompanyRoicAiAdapter_Old.MergeCompanyFromRoicAi(roicAiCompany, company);
                    CompanyRoicAiAdapter.MergeCompanyFromRoicAi(roicAiCompany, company);

                    company.CalculateGrowthAverages();//also sets up the average price to FCF if it's not available from macrotrends
                }
            }            
        }

        private void GetMacroTrendsData(string tickerSymbol)
        {
            MacroTrendsData macroTrendsData = MacroTrendsHelper.GetCompanyDataMacrotrends(tickerSymbol, company);

            //if (company.Financials.Shares?.Count > 0 && company.Average_P_FCF_Multiple != null)
            if (macroTrendsData?.AveragePriceToFreeCashFlowMultiple != null)
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
        private RoicAiCompany_Old MapJsonToRoicAiCompany_Old(string companyFolder, string ticker)
        {
            CompanySummary_Old companySummary = GetJsonToModel<CompanySummary_Old>(Path.Combine(companyFolder, $"{ticker}_Summary.json"));
            IncomeStatement_Old incomeStatement = GetJsonToModel<IncomeStatement_Old>(Path.Combine(companyFolder, $"{ticker}_IncomeStatement.json"));
            BalanceSheet_Old balanceSheet = GetJsonToModel<BalanceSheet_Old>(Path.Combine(companyFolder, $"{ticker}_BalanceSheet.json"));
            CashFlowStatement_Old cashFlowStatement = GetJsonToModel<CashFlowStatement_Old>(Path.Combine(companyFolder, $"{ticker}_CashFlowStatement.json"));
            MacroTrendsData macroTrendsData = GetJsonToModel<MacroTrendsData>(Path.Combine(companyFolder, $"{ticker}_MacrotrendsData.json"));

            RoicAiCompany_Old roicAiCompany = new RoicAiCompany_Old()
            {
                CompanySummary = companySummary,
                IncomeStatement = incomeStatement,
                BalanceSheet = balanceSheet,
                CashFlowStatement = cashFlowStatement,
                MacroTrendsData = macroTrendsData
            };

            return roicAiCompany;
        }

        private RoicAiCompany MapJsonToRoicAiCompany(string companyFolder, string ticker)
         {
            RoicAiCompany roicAiCompany = new RoicAiCompany();



            roicAiCompany.IncomeStatements = GetJsonToModel_New<List<IncomeStatement>>(Path.Combine(companyFolder, $"{ticker}_financials.json"), 0);
            roicAiCompany.BalanceSheets = GetJsonToModel_New<List<BalanceSheet>>(Path.Combine(companyFolder, $"{ticker}_financials.json"), 1);
            roicAiCompany.CashFlowStatements = GetJsonToModel_New<List<CashFlowStatement>>(Path.Combine(companyFolder, $"{ticker}_financials.json"), 2);

            roicAiCompany.FinancialRatios = new RoicAICompanyRatios();
            roicAiCompany.FinancialRatios.ProfitabilityFinancialRatios = GetJsonToModel_New<List<ProfitabilityFinancialRatios>>(Path.Combine(companyFolder, $"{ticker}_ratios.json"), 0);
            roicAiCompany.FinancialRatios.CreditFinancialRatios = GetJsonToModel_New<List<CreditFinancialRatios>>(Path.Combine(companyFolder, $"{ticker}_ratios.json"), 1);
            roicAiCompany.FinancialRatios.LiquidityFinancialRatios = GetJsonToModel_New<List<LiquidityFinancialRatios>>(Path.Combine(companyFolder, $"{ticker}_ratios.json"), 2);
            roicAiCompany.FinancialRatios.WorkingCapitalFinancialRatios = GetJsonToModel_New<List<WorkingCapitalFinancialRatios>>(Path.Combine(companyFolder, $"{ticker}_ratios.json"), 3);
            roicAiCompany.FinancialRatios.EnterpriseValueFinancialRatios = GetJsonToModel_New<List<EnterpriseValueFinancialRatios>>(Path.Combine(companyFolder, $"{ticker}_ratios.json"), 4);
            roicAiCompany.FinancialRatios.MultiplesFinancialRatios = GetJsonToModel_New<List<MultiplesFinancialRatios>>(Path.Combine(companyFolder, $"{ticker}_ratios.json"), 5);
            roicAiCompany.FinancialRatios.PerShareDataItemsFinancialRatios = GetJsonToModel_New<List<PerShareDataItemsFinancialRatios>>(Path.Combine(companyFolder, $"{ticker}_ratios.json"), 6);

            roicAiCompany.MacroTrendsData = GetJsonToModel<MacroTrendsData>(Path.Combine(companyFolder, $"{ticker}_MacrotrendsData.json"));            

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


        private T GetJsonToModel_New<T>(string jsonFile, int jsonFinancialDataObjectIndex)
        {
            if (!File.Exists(jsonFile))
                return default(T);


            using (StreamReader r = new StreamReader(jsonFile))
            {
                string json = r.ReadToEnd();               

                var jsonObject = JObject.Parse(json);
                var tableDataJson = jsonObject["buildChartParams"]["categoriesData"][jsonFinancialDataObjectIndex]["data"]["tableData"].ToString();
                T model = JsonConvert.DeserializeObject<T>(tableDataJson);
                return model;
            }
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
