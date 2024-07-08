using System;
using System.Collections.Generic;
using System.Text;

namespace BL.OfflineCompaniesData.Models.RoicAi_Old
{
    public class CashFlowStatement_Old
    {
        public CashFlowStatementData data { get; set; }
        public List<CashFlowStatementView> view { get; set; }
        public string name { get; set; }
    }

    public class CashFlowStatementData
    {
        public List<string> cfProcDebtAndCapitalLease_annual { get; set; }
        public List<string> cfProcDebtAndCapitalLease_ttm { get; set; }
        public List<string> cfProcDebtAndCapitalLease_quarterly { get; set; }
        public List<string> cfNetInc_annual { get; set; }
        public List<string> cfNetInc_ttm { get; set; }
        public List<string> cfNetInc_quarterly { get; set; }
        public List<string> cfDeprAmort_annual { get; set; }
        public List<string> cfDeprAmort_ttm { get; set; }
        public List<string> cfDeprAmort_quarterly { get; set; }
        public List<string> cfNonCashItemsDetailed_annual { get; set; }
        public List<string> cfNonCashItemsDetailed_ttm { get; set; }
        public List<string> cfNonCashItemsDetailed_quarterly { get; set; }
        public List<string> cfStockBasedCompensation_annual { get; set; }
        public List<string> cfStockBasedCompensation_ttm { get; set; }
        public List<string> cfStockBasedCompensation_quarterly { get; set; }
        public List<string> cfDefIncTax_annual { get; set; }
        public List<string> cfDefIncTax_ttm { get; set; }
        public List<string> cfDefIncTax_quarterly { get; set; }
        public List<string> cfAssetImpairmentCharge_annual { get; set; }
        public List<string> cfAssetImpairmentCharge_ttm { get; set; }
        public List<string> cfAssetImpairmentCharge_quarterly { get; set; }
        public List<string> cfOtherNonCashAdjLessDetailed_annual { get; set; }
        public List<string> cfOtherNonCashAdjLessDetailed_ttm { get; set; }
        public List<string> cfOtherNonCashAdjLessDetailed_quarterly { get; set; }
        public List<string> cfChngNonCashWorkCap_annual { get; set; }
        public List<string> cfChngNonCashWorkCap_ttm { get; set; }
        public List<string> cfChngNonCashWorkCap_quarterly { get; set; }
        public List<string> cfAcctRcvUnbilledRev_annual { get; set; }
        public List<string> cfAcctRcvUnbilledRev_ttm { get; set; }
        public List<string> cfAcctRcvUnbilledRev_quarterly { get; set; }
        public List<string> cfChangeInInventories_annual { get; set; }
        public List<string> cfChangeInInventories_ttm { get; set; }
        public List<string> cfChangeInInventories_quarterly { get; set; }
        public List<string> cfChangeInPrepaidAssets_annual { get; set; }
        public List<string> cfChangeInPrepaidAssets_ttm { get; set; }
        public List<string> cfChangeInPrepaidAssets_quarterly { get; set; }
        public List<string> cfChangeInAccountsPayable_annual { get; set; }
        public List<string> cfChangeInAccountsPayable_ttm { get; set; }
        public List<string> cfChangeInAccountsPayable_quarterly { get; set; }
        public List<string> cfIncDecInOtOpAstLiabDetail_annual { get; set; }
        public List<string> cfIncDecInOtOpAstLiabDetail_ttm { get; set; }
        public List<string> cfIncDecInOtOpAstLiabDetail_quarterly { get; set; }
        public List<string> cfNetCashDiscontOpsOper_annual { get; set; }
        public List<string> cfNetCashDiscontOpsOper_ttm { get; set; }
        public List<string> cfNetCashDiscontOpsOper_quarterly { get; set; }
        public List<string> cfCashFromOper_annual { get; set; }
        public List<string> cfCashFromOper_ttm { get; set; }
        public List<string> cfCashFromOper_quarterly { get; set; }
        public List<string> cfChgInFxdAndIntangAstDetailed_annual { get; set; }
        public List<string> cfChgInFxdAndIntangAstDetailed_ttm { get; set; }
        public List<string> cfChgInFxdAndIntangAstDetailed_quarterly { get; set; }
        public List<string> cfDispFxdAndIntangiblesDetailed_annual { get; set; }
        public List<string> cfDispFxdAndIntangiblesDetailed_ttm { get; set; }
        public List<string> cfDispFxdAndIntangiblesDetailed_quarterly { get; set; }
        public List<string> cfDisposalOfFixedProdAssets_annual { get; set; }
        public List<string> cfDisposalOfFixedProdAssets_ttm { get; set; }
        public List<string> cfDisposalOfFixedProdAssets_quarterly { get; set; }
        public List<string> cfDisposalOfIntangibleAssets_annual { get; set; }
        public List<string> cfDisposalOfIntangibleAssets_ttm { get; set; }
        public List<string> cfDisposalOfIntangibleAssets_quarterly { get; set; }
        public List<string> cfAcquisFxdAndIntangDetailed_annual { get; set; }
        public List<string> cfAcquisFxdAndIntangDetailed_ttm { get; set; }
        public List<string> cfAcquisFxdAndIntangDetailed_quarterly { get; set; }
        public List<string> cfPurchaseOfFixedProdAssets_annual { get; set; }
        public List<string> cfPurchaseOfFixedProdAssets_ttm { get; set; }
        public List<string> cfPurchaseOfFixedProdAssets_quarterly { get; set; }
        public List<string> cfAcquisitionOfIntangAssets_annual { get; set; }
        public List<string> cfAcquisitionOfIntangAssets_ttm { get; set; }
        public List<string> cfAcquisitionOfIntangAssets_quarterly { get; set; }
        public List<string> cfNetChgInLtInvestDetailed_annual { get; set; }
        public List<string> cfNetChgInLtInvestDetailed_ttm { get; set; }
        public List<string> cfNetChgInLtInvestDetailed_quarterly { get; set; }
        public List<string> cfDecrInvest_annual { get; set; }
        public List<string> cfDecrInvest_ttm { get; set; }
        public List<string> cfDecrInvest_quarterly { get; set; }
        public List<string> cfNtCshProcPymtDebt_annual { get; set; }
        public List<string> cfNtCshProcPymtDebt_ttm { get; set; }
        public List<string> cfNtCshProcPymtDebt_quarterly { get; set; }
        public List<string> cfIncrInvest_annual { get; set; }
        public List<string> cfIncrInvest_ttm { get; set; }
        public List<string> cfIncrInvest_quarterly { get; set; }
        public List<string> cfNtCshRcvdPdForAcquisDiv_annual { get; set; }
        public List<string> cfNtCshRcvdPdForAcquisDiv_ttm { get; set; }
        public List<string> cfNtCshRcvdPdForAcquisDiv_quarterly { get; set; }
        public List<string> cfCashForDivestitures_annual { get; set; }
        public List<string> cfCashForDivestitures_ttm { get; set; }
        public List<string> cfCashForDivestitures_quarterly { get; set; }
        public List<string> cfCashForAcquisSubsidiaries_annual { get; set; }
        public List<string> cfCashForAcquisSubsidiaries_ttm { get; set; }
        public List<string> cfCashForAcquisSubsidiaries_quarterly { get; set; }
        public List<string> cfCashForJointVenturesAssoc_annual { get; set; }
        public List<string> cfCashForJointVenturesAssoc_ttm { get; set; }
        public List<string> cfCashForJointVenturesAssoc_quarterly { get; set; }
        public List<string> cfOtherInvestingActDetailed_annual { get; set; }
        public List<string> cfOtherInvestingActDetailed_ttm { get; set; }
        public List<string> cfOtherInvestingActDetailed_quarterly { get; set; }
        public List<string> cfNetCashDiscontinuedOpsInv_annual { get; set; }
        public List<string> cfNetCashDiscontinuedOpsInv_ttm { get; set; }
        public List<string> cfNetCashDiscontinuedOpsInv_quarterly { get; set; }
        public List<string> cfCashFromInvAct_annual { get; set; }
        public List<string> cfCashFromInvAct_ttm { get; set; }
        public List<string> cfCashFromInvAct_quarterly { get; set; }
        public List<string> cfDvdPaid_annual { get; set; }
        public List<string> cfDvdPaid_ttm { get; set; }
        public List<string> cfDvdPaid_quarterly { get; set; }
        public List<string> cfPymtDebtAndCapitalLease_annual { get; set; }
        public List<string> cfPymtDebtAndCapitalLease_ttm { get; set; }
        public List<string> cfPymtDebtAndCapitalLease_quarterly { get; set; }
        public List<string> cfProcFrRepurchEqtyDetailed_annual { get; set; }
        public List<string> cfProcFrRepurchEqtyDetailed_ttm { get; set; }
        public List<string> cfProcFrRepurchEqtyDetailed_quarterly { get; set; }
        public List<string> cfIncrCapStock_annual { get; set; }
        public List<string> cfIncrCapStock_ttm { get; set; }
        public List<string> cfIncrCapStock_quarterly { get; set; }
        public List<string> cfDecrCapStock_annual { get; set; }
        public List<string> cfDecrCapStock_ttm { get; set; }
        public List<string> cfDecrCapStock_quarterly { get; set; }
        public List<string> cfOtherFinancingActExclFx_annual { get; set; }
        public List<string> cfOtherFinancingActExclFx_ttm { get; set; }
        public List<string> cfOtherFinancingActExclFx_quarterly { get; set; }
        public List<string> cfNetCashDiscontinuedOpsFin_annual { get; set; }
        public List<string> cfNetCashDiscontinuedOpsFin_ttm { get; set; }
        public List<string> cfNetCashDiscontinuedOpsFin_quarterly { get; set; }
        public List<string> cfCashFromFinAct_annual { get; set; }
        public List<string> cfCashFromFinAct_ttm { get; set; }
        public List<string> cfCashFromFinAct_quarterly { get; set; }
        public List<string> cfEffectForeignExchanges_annual { get; set; }
        public List<string> cfEffectForeignExchanges_ttm { get; set; }
        public List<string> cfEffectForeignExchanges_quarterly { get; set; }
        public List<string> cfNetChngCash_annual { get; set; }
        public List<string> cfNetChngCash_ttm { get; set; }
        public List<string> cfNetChngCash_quarterly { get; set; }
        public List<string> ebitda_annual { get; set; }
        public List<string> ebitda_ttm { get; set; }
        public List<string> ebitda_quarterly { get; set; }
        public List<string> ebitdaMargin_annual { get; set; }
        public List<string> ebitdaMargin_ttm { get; set; }
        public List<string> ebitdaMargin_quarterly { get; set; }
        public List<string> cfNetCashPaidForAquis_annual { get; set; }
        public List<string> cfNetCashPaidForAquis_ttm { get; set; }
        public List<string> cfNetCashPaidForAquis_quarterly { get; set; }
        public List<string> cfFreeCashFlow_annual { get; set; }
        public List<string> cfFreeCashFlow_ttm { get; set; }
        public List<string> cfFreeCashFlow_quarterly { get; set; }
        public List<string> cfFreeCashFlowFirm_annual { get; set; }
        public List<string> cfFreeCashFlowFirm_ttm { get; set; }
        public List<string> cfFreeCashFlowFirm_quarterly { get; set; }
        public List<string> freeCashFlowEquity_annual { get; set; }
        public List<string> freeCashFlowEquity_ttm { get; set; }
        public List<string> freeCashFlowEquity_quarterly { get; set; }
        public List<string> freeCashFlowPerSh_annual { get; set; }
        public List<string> freeCashFlowPerSh_ttm { get; set; }
        public List<string> freeCashFlowPerSh_quarterly { get; set; }
        public List<string> prToFreeCashFlow_annual { get; set; }
        public List<string> prToFreeCashFlow_ttm { get; set; }
        public List<string> prToFreeCashFlow_quarterly { get; set; }
        public List<string> cashFlowToNetInc_annual { get; set; }
        public List<string> cashFlowToNetInc_ttm { get; set; }
        public List<string> cashFlowToNetInc_quarterly { get; set; }
        public List<string> fiscal_period_annual { get; set; }
        public List<string> fiscal_period_ttm { get; set; }
        public List<string> fiscal_period_quarterly { get; set; }
    }

   

    public class CashFlowStatementView
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
