using BL.Models;
using BL.ModelsUI;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace BL.Adapters
{
    public class CompanyRoicAiAdapter
    {
        private static readonly int lastNoOfYears = 10;
        private static readonly int finDataDivider = 1000000000;//billions
        public static void MergeCompanyFromRoicAi(RoicAiCompany comp, Company company)
        {
            company.Financials = new Financials();

            List<int> financialYears = comp.IncomeStatements.Select(i => i.FiscalYear).ToList();
            List<int> ratiosYears = comp.ProfitabilityRatios.Select(r => r.FiscalYear).ToList();

            company.Financials.Revenue = GetFinancialData(comp.IncomeStatements.Select(i => i.IsSalesRevenueTurnover).ToList(), financialYears, finDataDivider);
            company.Financials.NetIncome = GetFinancialData(comp.IncomeStatements.Select(i => i.IsNetIncome).ToList(), financialYears, finDataDivider);
            company.Financials.EPS = GetFinancialData(comp.IncomeStatements.Select(i => i.DilutedEps).ToList(), financialYears);
            company.Financials.OperatingMargin = GetFinancialData(comp.IncomeStatements.Select(i => i.OperMargin).ToList(), financialYears);

            company.Financials.Cash = GetFinancialData(comp.BalanceSheets.Select(b => b.BsCAndCeAndStiDetailed).ToList(), financialYears, finDataDivider);
            company.Financials.ShortTermDebt = GetFinancialData(comp.BalanceSheets.Select(b => b.BsStBorrow).ToList(), financialYears, finDataDivider);
            company.Financials.LongTermDebt = GetFinancialData(comp.BalanceSheets.Select(b => b.BsLtBorrow).ToList(), financialYears, finDataDivider);
            company.Financials.Equity = GetFinancialData(comp.BalanceSheets.Select(b => b.BsTotalEquity).ToList(), financialYears, finDataDivider);
            company.Financials.RetainedEarnings = GetFinancialData(comp.BalanceSheets.Select(b => b.BsPureRetainedEarnings).ToList(), financialYears, finDataDivider);
            company.Financials.Shares = GetFinancialData(comp.BalanceSheets.Select(b => b.BsShOut).ToList(), financialYears, finDataDivider);

            company.Financials.FreeCashFlow = GetFinancialData(comp.CashFlowStatements.Select(c => c.CfFreeCashFlow).ToList(), financialYears, finDataDivider);
            company.Financials.CapitalExpenditures = GetFinancialData(comp.CashFlowStatements.Select(c => c.CfCapExpenditures).ToList(), financialYears, finDataDivider);

            company.Financials.FCFperShare = GetFinancialData(comp.PerShareData.Select(r => r.FreeCashFlowPerSh).ToList(), ratiosYears);
            company.Financials.ROIC = GetFinancialData(comp.ProfitabilityRatios.Select(r => r.ReturnOnInvCapital).ToList(), ratiosYears);

            List<decimal?> priceFCFMultiples = comp.ValuationMultiples.Select(r => r.PrToFreeCashFlow).ToList();
            company.Average_P_FCF_Multiple = Math.Min(15, (int)GetMedian(priceFCFMultiples));

            if (company.Financials.Shares?.Count > 0)
            {
                if (company.Financials.Shares.Last() != null)
                    company.SharesOutstanding = company.Financials.Shares.Last().Value;
            }

            company.FinancialDataCurrency = comp.IncomeStatements.FirstOrDefault()?.Currency;
        }

        private static decimal? ToDecimal<T>(T value)
        {
            if (value is null) return null;
            return Convert.ToDecimal(value);
        }

        private static int? GetMedian(List<decimal?> values)
        {
            if (values == null) return null;

            List<decimal> sorted = values
                .Where(v => v != null)
                .Select(v => v!.Value)
                .Order()
                .ToList();

            if (sorted.Count == 0) return null;

            int mid = sorted.Count / 2;
            return sorted.Count % 2 != 0
                ? (int?)sorted[mid]
                : (int?)((sorted[mid - 1] + sorted[mid]) / 2m);
        }

        private static List<T> GetLastYearsData<T>(List<T> data)
        {
            if (data == null)
                return null;

            //data.Reverse();
            //List<T> lastData = data.Take(Math.Min(data.Count, lastNoOfYears)).ToList();
            //lastData.Reverse();
            //data.Reverse();

            //return lastData;

            return data.Take(Math.Min(data.Count, lastNoOfYears)).Reverse().ToList();
        }

        private static List<YearVal> GetFinancialData<T>(List<T> values, List<int> years, int divider = 1)
        {
            var lastFinVal = GetLastYearsData<T>(values);
            var lastYears = GetLastYearsData<int>(years);

            List<YearVal> financialData = new List<YearVal>();

            for (int i = 0; i < lastYears.Count; i++)
            {
                YearVal yearVal = new YearVal();
                yearVal.Year = lastYears[i];
                yearVal.Value = ToDecimal(lastFinVal[i]) / divider;

                if (i > 0)
                {
                    var newVal = yearVal.Value;
                    var oldVal = ToDecimal(lastFinVal[i - 1]) / divider;
                    if (newVal != null && oldVal != null && oldVal != 0)
                        yearVal.Growth = ((decimal)newVal - (decimal)oldVal) / Math.Abs((decimal)oldVal) * 100;
                }

                financialData.Add(yearVal);
            }

            return financialData;
        }
    }
}
