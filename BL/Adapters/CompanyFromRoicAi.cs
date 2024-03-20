using BL.CompaniesData.JsonModels.RoicAi;
using BL.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace BL.Adapters
{
    public class CompanyRoicAiAdapter
    {
        private static readonly int lastNoOfYears = 10;
        public static void MergeCompanyFromRoicAi(RoicAiCompany comp, Company company)
        {
            company.Financials = new Financials();

            List<int> financialYears = GetYears(comp.IncomeStatement.data.fiscal_period_annual);
            List<int> summaryYears = GetYears(comp.CompanySummary.data.fiscal_period_annual);

            company.Financials.Revenue = GetFinancialData(comp.IncomeStatement.data.isSalesRevenueTurnover_annual, financialYears, 1000);
            company.Financials.NetIncome = GetFinancialData(comp.IncomeStatement.data.isNetIncome_annual, financialYears, 1000);
            company.Financials.EPS = GetFinancialData(comp.IncomeStatement.data.dilutedEps_annual, financialYears);
            company.Financials.OperatingMargin = GetFinancialData(comp.IncomeStatement.data.operMargin_annual, financialYears);                        

            company.Financials.Cash = GetFinancialData(comp.BalanceSheet.data.bsCAndCeAndStiDetailed_annual, financialYears, 1000);
            company.Financials.ShortTermDebt = GetFinancialData(comp.BalanceSheet.data.bsStBorrow_annual, financialYears, 1000);
            company.Financials.LongTermDebt = GetFinancialData(comp.BalanceSheet.data.bsLtBorrow_annual, financialYears, 1000);
            company.Financials.Equity = GetFinancialData(comp.BalanceSheet.data.bsTotalEquity_annual, financialYears, 1000);
            company.Financials.RetainedEarnings = GetFinancialData(comp.BalanceSheet.data.bsPureRetainedEarnings_annual, financialYears, 1000);
            company.Financials.Shares = GetFinancialData(comp.BalanceSheet.data.bsShOut_annual, financialYears, 1000);

            company.Financials.FreeCashFlow = GetFinancialData(comp.CashFlowStatement.data.cfFreeCashFlow_annual, financialYears, 1000);
            company.Financials.CapitalExpenditures = GetFinancialData(comp.CashFlowStatement.data.cfAcquisFxdAndIntangDetailed_annual, financialYears, 1000);

            company.Financials.FCFperShare = GetFinancialData(comp.CompanySummary.data.freeCashFlowPerSh_annual, summaryYears);
            company.Financials.ROIC = GetFinancialData(comp.CompanySummary.data.returnOnInvCapital_annual, summaryYears);

            if (comp.MacroTrendsData != null)
            {
                //company.Financials.Shares = GetLastYearsData(comp.MacroTrendsData.SharesOutstanding);
                company.Average_P_FCF_Multiple = comp.MacroTrendsData.AveragePriceToFreeCashFlowMultiple;
            }

            //CalculateSharesOutstanding(company);
            if (company.Financials.Shares?.Count > 0)
            {
                if (company.Financials.Shares.Last() != null)
                    company.SharesOutstanding = company.Financials.Shares.Last().Value;
            }
        }

        private static void CalculateSharesOutstanding(Company company)
        {
            List<YearVal> shares = company.Financials.NetIncome
            .Join(company.Financials.EPS, l1 => l1.Year, l2 => l2.Year, (l1, l2) => new YearVal
            {
                Year = l1.Year,
                Value = l1.Value / l2.Value,//net income must be converted back from millions(not billions to cut the divider later) to divide correctly
                Growth = null // Optionally include Growth from the first list
            })
            .ToList();

            //calculate growth
            for (int i = 0; i < shares.Count; i++)
            {
                if (i > 0)
                {
                    var newVal = shares[i].Value;
                    var oldVal = shares[i - 1].Value;
                    if (newVal != null && oldVal != null && oldVal != 0)
                        shares[i].Growth = ((decimal)newVal - (decimal)oldVal) / Math.Abs((decimal)oldVal) * 100;
                }
            }

            company.Financials.Shares = shares;

            if (company.Financials.Shares.Count > 0)
                company.SharesOutstanding = company.Financials.Shares[company.Financials.Shares.Count - 1].Value;
        }

        private static List<T> GetLastYearsData<T>(List<T> data)
        {
            if (data == null)
                return null;

            data.Reverse();
            List<T> lastData = data.Take(Math.Min(data.Count, lastNoOfYears)).ToList();
            lastData.Reverse();
            data.Reverse();

            return lastData;
        }


        private static List<int> GetYears(List<string> values)
        {
            List<int> years = new List<int>();

            foreach (string yearString in values)
            {
                string year = yearString.Substring(0, 4);
                years.Add(Convert.ToInt32(year));
            }

            return years;
        }

        private static List<YearVal> GetFinancialData(List<string> values, List<int> years, int divider = 1)
        {
            var lastFinVal = GetLastYearsData<string>(values);
            var lastYears = GetLastYearsData<int>(years);

            List<YearVal> financialData = new List<YearVal>();

            for (int i = 0; i < lastYears.Count; i++)
            {
                YearVal yearVal = new YearVal();
                yearVal.Year = lastYears[i];
                yearVal.Value = ConvertFinValueToDecimal(lastFinVal[i]) / divider;

                if (i > 0)
                {
                    var newVal = yearVal.Value;
                    var oldVal = ConvertFinValueToDecimal(lastFinVal[i - 1]) / divider;
                    if (newVal != null && oldVal != null && oldVal != 0)
                        yearVal.Growth = ((decimal)newVal - (decimal)oldVal) / Math.Abs((decimal)oldVal) * 100;
                }

                financialData.Add(yearVal);
            }

            return financialData;
        }
       

        private static decimal? ConvertFinValueToDecimal(string val)
        {
            bool converted = Decimal.TryParse(val, NumberStyles.Any, new CultureInfo("en-US"), out var decimalVal);
            if (converted)
                return decimalVal;
            else
                return null;
        }
    }
}
