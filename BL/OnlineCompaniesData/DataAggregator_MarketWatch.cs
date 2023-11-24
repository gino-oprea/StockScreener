using BL.Models;
using BL.OnlineCompaniesData;
using BL.OnlineCompaniesData.DataHelpers;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BL
{
    public class DataAggregator_MarketWatch : IDataAggregator
    {        
        public DataAggregator_MarketWatch() 
        { 

        }
        public Company GetCompanyCurrentPrice(string TickerSymbol)
        {
            string generalDetails = BL.HttpReq.GetUrlHttpWebRequest("https://www.marketwatch.com/investing/stock/" + TickerSymbol + "?mod=over_search", "GET", null, false);

            Company company = new Company();
            if (generalDetails != null)
                MarketWatchHelper.GetCompanyGeneralInfo_MarketWatch(generalDetails, company);

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
                string generalDetails = BL.HttpReq.GetUrlHttpWebRequest("https://www.marketwatch.com/investing/stock/" + TickerSymbol + "?mod=over_search", "GET", null, false);
                if (generalDetails != null)
                    MarketWatchHelper.GetCompanyGeneralInfo_MarketWatch(generalDetails, company);
            }
            else
            {
                company.Ticker = TickerSymbol.ToUpper();
                company.Financials = new Financials();

                string generalDetails = BL.HttpReq.GetUrlHttpWebRequest("https://www.marketwatch.com/investing/stock/" + TickerSymbol + "?mod=over_search", "GET", null, false);

                if (generalDetails != null)
                    MarketWatchHelper.GetCompanyGeneralInfo_MarketWatch(generalDetails, company);


                Thread.Sleep(100);
                string financials_incomeStatement = BL.HttpReq.GetUrlHttpWebRequest("https://www.marketwatch.com/investing/stock/" + TickerSymbol + "/financials", "GET", null, false);
                Thread.Sleep(100);
                string financials_balanceSheet = BL.HttpReq.GetUrlHttpWebRequest("https://www.marketwatch.com/investing/stock/" + TickerSymbol + "/financials/balance-sheet", "GET", null, false);
                Thread.Sleep(100);
                string financials_cashFlow = BL.HttpReq.GetUrlHttpWebRequest("https://www.marketwatch.com/investing/stock/" + TickerSymbol + "/financials/cash-flow", "GET", null, false);
                Thread.Sleep(100);

                if (financials_incomeStatement != null)
                {
                    try
                    {
                        MarketWatchHelper.GetCompanyFinancials_MarketWatch(financials_incomeStatement, financials_balanceSheet, financials_cashFlow, company);
                        //GetCompanyFinancials_QuickFS(financials_quickFS, company);

                        var task1 = Task.Run(() => MorningstarHelper.GetCompanyFinancials_Morningstar(TickerSymbol, company));
                        var task2 = Task.Run(() => MacroTrendsHelper.GetCompanyAveragePriceToFCFMultiple(TickerSymbol, company));
                        var task3 = Task.Run(() => MacroTrendsHelper.GetCompanyDataMacrotrends(TickerSymbol, company));

                        Task.WaitAll(task1, task2, task3);


                        List<YearVal> FCFperShare = calculateFCFperShare(company);

                        company.Financials.FCFperShare = FCFperShare;

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

        private List<YearVal> calculateFCFperShare(Company company)
        {
            List<YearVal> FCFperShare = new List<YearVal>();

            for (int i = 0; i < company.Financials.FreeCashFlow.Count; i++)
            {
                decimal? fcfPerShare = null;
                if (company.Financials.Shares!=null && company.Financials.Shares[i].Value != 0)
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
    }
}
