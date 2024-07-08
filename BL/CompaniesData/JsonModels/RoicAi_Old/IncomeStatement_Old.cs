using System;
using System.Collections.Generic;
using System.Text;

namespace BL.OfflineCompaniesData.Models.RoicAi_Old
{
    public class IncomeStatement_Old
    {
        public IncomeStatementData data { get; set; }
        public List<IncomeStatementView> view { get; set; }
        public string name { get; set; }
    }
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class IncomeStatementData
    {
        public List<string> isSalesRevenueTurnover_annual { get; set; }
        public List<string> isSalesRevenueTurnover_ttm { get; set; }
        public List<string> isSalesRevenueTurnover_quarterly { get; set; }
        public List<string> isSalesAndServicesRevenues_annual { get; set; }
        public List<string> isSalesAndServicesRevenues_ttm { get; set; }
        public List<string> isSalesAndServicesRevenues_quarterly { get; set; }
        public List<string> isCogs_annual { get; set; }
        public List<string> isCogs_ttm { get; set; }
        public List<string> isCogs_quarterly { get; set; }
        public List<string> isCogAndServicesSold_annual { get; set; }
        public List<string> isCogAndServicesSold_ttm { get; set; }
        public List<string> isCogAndServicesSold_quarterly { get; set; }
        public List<string> isGrossProfit_annual { get; set; }
        public List<string> isGrossProfit_ttm { get; set; }
        public List<string> isGrossProfit_quarterly { get; set; }
        public List<string> isOtherOperIncome_annual { get; set; }
        public List<string> isOtherOperIncome_ttm { get; set; }
        public List<string> isOtherOperIncome_quarterly { get; set; }
        public List<string> isOperatingExpn_annual { get; set; }
        public List<string> isOperatingExpn_ttm { get; set; }
        public List<string> isOperatingExpn_quarterly { get; set; }
        public List<string> isSgAndAExpense_annual { get; set; }
        public List<string> isSgAndAExpense_ttm { get; set; }
        public List<string> isSgAndAExpense_quarterly { get; set; }
        public List<string> isOperatingExpensesRAndD_annual { get; set; }
        public List<string> isOperatingExpensesRAndD_ttm { get; set; }
        public List<string> isOperatingExpensesRAndD_quarterly { get; set; }
        public List<string> isOtherOperatingExpenses_annual { get; set; }
        public List<string> isOtherOperatingExpenses_ttm { get; set; }
        public List<string> isOtherOperatingExpenses_quarterly { get; set; }
        public List<string> isOperIncome_annual { get; set; }
        public List<string> isOperIncome_ttm { get; set; }
        public List<string> isOperIncome_quarterly { get; set; }
        public List<string> isNonopIncomeLoss_annual { get; set; }
        public List<string> isNonopIncomeLoss_ttm { get; set; }
        public List<string> isNonopIncomeLoss_quarterly { get; set; }
        public List<string> isNetInterestExpense_annual { get; set; }
        public List<string> isNetInterestExpense_ttm { get; set; }
        public List<string> isNetInterestExpense_quarterly { get; set; }
        public List<string> isIntExpense_annual { get; set; }
        public List<string> isIntExpense_ttm { get; set; }
        public List<string> isIntExpense_quarterly { get; set; }
        public List<string> isIntIncome_annual { get; set; }
        public List<string> isIntIncome_ttm { get; set; }
        public List<string> isIntIncome_quarterly { get; set; }
        public List<string> isOtherNonopIncomeLoss_annual { get; set; }
        public List<string> isOtherNonopIncomeLoss_ttm { get; set; }
        public List<string> isOtherNonopIncomeLoss_quarterly { get; set; }
        public List<string> isPretaxIncome_annual { get; set; }
        public List<string> isPretaxIncome_ttm { get; set; }
        public List<string> isPretaxIncome_quarterly { get; set; }
        public List<string> isIncTaxExp_annual { get; set; }
        public List<string> isIncTaxExp_ttm { get; set; }
        public List<string> isIncTaxExp_quarterly { get; set; }
        public List<string> isIncLossAffil_annual { get; set; }
        public List<string> isIncLossAffil_ttm { get; set; }
        public List<string> isIncLossAffil_quarterly { get; set; }
        public List<string> isIncBefXoItem_annual { get; set; }
        public List<string> isIncBefXoItem_ttm { get; set; }
        public List<string> isIncBefXoItem_quarterly { get; set; }
        public List<string> isXoGlNetOfTax_annual { get; set; }
        public List<string> isXoGlNetOfTax_ttm { get; set; }
        public List<string> isXoGlNetOfTax_quarterly { get; set; }
        public List<string> isDiscontinuedOperations_annual { get; set; }
        public List<string> isDiscontinuedOperations_ttm { get; set; }
        public List<string> isDiscontinuedOperations_quarterly { get; set; }
        public List<string> isExtraordItemsAndAcctgChng_annual { get; set; }
        public List<string> isExtraordItemsAndAcctgChng_ttm { get; set; }
        public List<string> isExtraordItemsAndAcctgChng_quarterly { get; set; }
        public List<string> isNiIncludingMinorityIntRatio_annual { get; set; }
        public List<string> isNiIncludingMinorityIntRatio_ttm { get; set; }
        public List<string> isNiIncludingMinorityIntRatio_quarterly { get; set; }
        public List<string> isMinNoncontrolInterestCredits_annual { get; set; }
        public List<string> isMinNoncontrolInterestCredits_ttm { get; set; }
        public List<string> isMinNoncontrolInterestCredits_quarterly { get; set; }
        public List<string> isNetIncome_annual { get; set; }
        public List<string> isNetIncome_ttm { get; set; }
        public List<string> isNetIncome_quarterly { get; set; }
        public List<string> isTotCashPfdDvd_annual { get; set; }
        public List<string> isTotCashPfdDvd_ttm { get; set; }
        public List<string> isTotCashPfdDvd_quarterly { get; set; }
        public List<string> isOtherAdjustments_annual { get; set; }
        public List<string> isOtherAdjustments_ttm { get; set; }
        public List<string> isOtherAdjustments_quarterly { get; set; }
        public List<string> isEarnForCommon_annual { get; set; }
        public List<string> isEarnForCommon_ttm { get; set; }
        public List<string> isEarnForCommon_quarterly { get; set; }
        public List<string> eps_annual { get; set; }
        public List<string> eps_ttm { get; set; }
        public List<string> eps_quarterly { get; set; }
        public List<string> isAvgNumShForEps_annual { get; set; }
        public List<string> isAvgNumShForEps_ttm { get; set; }
        public List<string> isAvgNumShForEps_quarterly { get; set; }
        public List<string> ebitda_annual { get; set; }
        public List<string> ebitda_ttm { get; set; }
        public List<string> ebitda_quarterly { get; set; }
        public List<string> ebitdaMargin_annual { get; set; }
        public List<string> ebitdaMargin_ttm { get; set; }
        public List<string> ebitdaMargin_quarterly { get; set; }
        public List<string> ebita_annual { get; set; }
        public List<string> ebita_ttm { get; set; }
        public List<string> ebita_quarterly { get; set; }
        public List<string> ebit_annual { get; set; }
        public List<string> ebit_ttm { get; set; }
        public List<string> ebit_quarterly { get; set; }
        public List<string> grossMargin_annual { get; set; }
        public List<string> grossMargin_ttm { get; set; }
        public List<string> grossMargin_quarterly { get; set; }
        public List<string> operMargin_annual { get; set; }
        public List<string> operMargin_ttm { get; set; }
        public List<string> operMargin_quarterly { get; set; }
        public List<string> profitMargin_annual { get; set; }
        public List<string> profitMargin_ttm { get; set; }
        public List<string> profitMargin_quarterly { get; set; }
        public List<string> actualSalesPerEmpl_annual { get; set; }
        public List<string> actualSalesPerEmpl_ttm { get; set; }
        public List<string> actualSalesPerEmpl_quarterly { get; set; }
        public List<string> divPerShr_annual { get; set; }
        public List<string> divPerShr_ttm { get; set; }
        public List<string> divPerShr_quarterly { get; set; }
        public List<string> isDeprExp_annual { get; set; }
        public List<string> isDeprExp_ttm { get; set; }
        public List<string> isDeprExp_quarterly { get; set; }
        public List<string> epsContOps_annual { get; set; }
        public List<string> epsContOps_ttm { get; set; }
        public List<string> epsContOps_quarterly { get; set; }
        public List<string> isShForDilutedEps_annual { get; set; }
        public List<string> isShForDilutedEps_ttm { get; set; }
        public List<string> isShForDilutedEps_quarterly { get; set; }
        public List<string> dilutedEps_annual { get; set; }
        public List<string> dilutedEps_ttm { get; set; }
        public List<string> dilutedEps_quarterly { get; set; }
        public List<string> dilEpsContOps_annual { get; set; }
        public List<string> dilEpsContOps_ttm { get; set; }
        public List<string> dilEpsContOps_quarterly { get; set; }
        public List<string> fiscal_period_annual { get; set; }
        public List<string> fiscal_period_ttm { get; set; }
        public List<string> fiscal_period_quarterly { get; set; }
    }    

    public class IncomeStatementView
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
        public string financialSign { get; set; }
        public string templateId { get; set; }
        public string parent { get; set; }
        public string name { get; set; }
        public int precision { get; set; }
        public string period { get; set; }
        public int divider { get; set; }
    }


}
