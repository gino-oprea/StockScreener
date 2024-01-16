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
                GetMacroTrendsData(tickerSymbol);

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

            RoicAiCompany roicAiCompany = new RoicAiCompany()
            {
                CompanySummary = companySummary,
                IncomeStatement = incomeStatement,
                BalanceSheet = balanceSheet,
                CashFlowStatement = cashFlowStatement
            };

            return roicAiCompany;
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
