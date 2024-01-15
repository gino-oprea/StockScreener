using System;
using System.Collections.Generic;
using System.Text;

namespace BL.OfflineCompaniesData.Models.RoicAi
{
    public class CompanySummary
    {
        public CompanySummaryData data { get; set; }
        public List<CompanySummaryView> view { get; set; }
        public string name { get; set; }
    }

    public class CompanySummaryData
    {
        public List<string> isSalesRevenueTurnover_annual { get; set; }
        public List<string> isSalesRevenueTurnover_ttm { get; set; }
        public List<string> isNetIncome_annual { get; set; }
        public List<string> isNetIncome_ttm { get; set; }
        public List<string> eps_annual { get; set; }
        public List<string> eps_ttm { get; set; }
        public List<string> bsLtBorrow_annual { get; set; }
        public List<string> bsLtBorrow_ttm { get; set; }
        public List<string> bsTotalEquity_annual { get; set; }
        public List<string> bsTotalEquity_ttm { get; set; }
        public List<string> isAvgNumShForEps_annual { get; set; }
        public List<string> isAvgNumShForEps_ttm { get; set; }
        public List<string> operMargin_annual { get; set; }
        public List<string> operMargin_ttm { get; set; }
        public List<string> profitMargin_annual { get; set; }
        public List<string> profitMargin_ttm { get; set; }
        public List<string> divPerShr_annual { get; set; }
        public List<string> divPerShr_ttm { get; set; }
        public List<string> isDeprExp_annual { get; set; }
        public List<string> isDeprExp_ttm { get; set; }
        public List<string> returnOnCap_annual { get; set; }
        public List<string> returnOnCap_ttm { get; set; }
        public List<string> returnOnInvCapital_annual { get; set; }
        public List<string> returnOnInvCapital_ttm { get; set; }
        public List<string> freeCashFlowPerSh_annual { get; set; }
        public List<string> freeCashFlowPerSh_ttm { get; set; }
        public List<string> returnComEqy_annual { get; set; }
        public List<string> returnComEqy_ttm { get; set; }
        public List<string> effTaxRate_annual { get; set; }
        public List<string> effTaxRate_ttm { get; set; }
        public List<string> revenuePerSh_annual { get; set; }
        public List<string> revenuePerSh_ttm { get; set; }
        public List<string> bookValPerSh_annual { get; set; }
        public List<string> bookValPerSh_ttm { get; set; }
        public List<string> tangBookValPerSh_annual { get; set; }
        public List<string> tangBookValPerSh_ttm { get; set; }
        public List<string> workingCapital_annual { get; set; }
        public List<string> workingCapital_ttm { get; set; }
        public List<string> fiscal_period_annual { get; set; }
        public List<string> fiscal_period_ttm { get; set; }
        public List<object> fiscal_period_quarterly { get; set; }
    }    

    public class CompanySummaryView
    {
        public string id { get; set; }
        public string financialId { get; set; }
        public string definitionSubType { get; set; }
        public string units { get; set; }
        public bool currencyConvertible { get; set; }
        public string templateCategory { get; set; }
        public string templateType { get; set; }
        public string templateSubtype { get; set; }
        public bool bold { get; set; }
        public int position { get; set; }
        public object financialSign { get; set; }
        public string templateId { get; set; }
        public object parent { get; set; }
        public string name { get; set; }
        public int precision { get; set; }
        public string period { get; set; }
        public int divider { get; set; }
    }

}
