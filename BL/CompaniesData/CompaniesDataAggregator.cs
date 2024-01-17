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
                GetFinancialData(tickerSymbol);

                //backup in case macrotrends data is not already on disk, and save it if able to get data online
                if (!MacrotrendsDataExists(tickerSymbol.ToUpper()))
                    GetMacroTrendsData(tickerSymbol.ToUpper());

                company.Ticker = tickerSymbol;

                company.CalculateIntrinsicAndDiscountedValues(discountedInterestRate: discountedInterestRate, terminalMultiple: company.Average_P_FCF_Multiple.Value);

                return company;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        
        private void GetGeneralInfo(string tickerSymbol)
        {
            string generalDetails = BL.HttpReq.GetUrlHttpWebRequest("https://www.marketwatch.com/investing/stock/" + tickerSymbol + "?mod=over_search", "GET", null, false);            
            if (generalDetails != null)
                MarketWatchHelper.GetCompanyGeneralInfo_MarketWatch(generalDetails, company);
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
            MacroTrendsHelper.GetCompanyDataMacrotrends(tickerSymbol, company);

            if (company.Financials.Shares?.Count > 0 && company.Average_P_FCF_Multiple != null)
            {
                MacroTrendsData macroTrendsData = new MacroTrendsData()
                {
                    SharesOutstanding = company.Financials.Shares,
                    AveragePriceToFreeCashFlowMultiple = company.Average_P_FCF_Multiple
                };
                var json = JsonConvert.SerializeObject(macroTrendsData);
                var companyFolder = Path.Combine(workingFolder,tickerSymbol);
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

        private List<YearVal> calculateFCFperShare(Company company)
        {
            List<YearVal> FCFperShare = new List<YearVal>();

            for (int i = 0; i < company.Financials.FreeCashFlow.Count; i++)
            {
                decimal? fcfPerShare = null;
                if (company.Financials.Shares != null && company.Financials.Shares[i].Value != 0)
                    fcfPerShare = company.Financials.FreeCashFlow[i].Value / company.Financials.Shares[i].Value;

                YearVal yearVal = new YearVal();
                yearVal.Year = company.Financials.FreeCashFlow[i].Year;
                yearVal.Value = fcfPerShare;

                if (i > 0)
                {
                    var newVal = yearVal.Value;
                    var oldVal = FCFperShare[i - 1].Value;
                    if (newVal != null && oldVal != null && oldVal != 0)
                        yearVal.Growth = ((decimal)newVal - (decimal)oldVal) / Math.Abs((decimal)oldVal) * 100;
                }
                FCFperShare.Add(yearVal);
            }

            return FCFperShare;
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
