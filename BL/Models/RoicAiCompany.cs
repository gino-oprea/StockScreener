using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using BL.Utils;

namespace BL.Models
{
    public class RoicAiCompany
    {
        public CompanyProfile Profile { get; set; }
        public List<IncomeStatement_Periodical> IncomeStatements { get; set; }
        public List<BalanceSheet_Periodical> BalanceSheets { get; set; }
        public List<CashFlowStatement_Periodical> CashFlowStatements {  get; set; }
        public List<PerShareData_Periodical> PerShareData { get; set; }  
        public List<ProfitabilityRatios_Periodical> ProfitabilityRatios { get; set; }
        public List<ValuationMultiples_Periodical> ValuationMultiples { get; set; }
    }

    public class CompanyProfile
    {
        [JsonProperty("ticker")]
        public string Ticker { get; set; }

        [JsonProperty("company_name")]
        public string Name { get; set; }

        [JsonProperty("cik")]
        public string Cik { get; set; }

        [JsonProperty("cusip")]
        public string Cusip { get; set; }

        [JsonProperty("isin")]
        public string Isin { get; set; }

        [JsonProperty("currency")]
        public string StockCurrency { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("ai_description")]
        public string AiDescription { get; set; }

        [JsonProperty("website")]
        public string Website { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("zip")]
        public string Zip { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("country_code")]
        public string CountryCode { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("sector")]
        public string Sector { get; set; }

        [JsonProperty("industry")]
        public string Industry { get; set; }

        [JsonProperty("ceo")]
        public string Ceo { get; set; }

        [JsonProperty("full_time_employees")]
        [JsonConverter(typeof(StringToIntConverter))]
        public int? FullTimeEmployees { get; set; }

        [JsonProperty("ipo_date")]
        public string IpoDate { get; set; }

        [JsonProperty("is_adr")]
        public bool IsAdr { get; set; }

        [JsonProperty("price")]
        [JsonConverter(typeof(StringToDecimalConverter))]
        public decimal? Price { get; set; }

        [JsonProperty("dividend_yield")]
        public decimal? DividendYield { get; set; }

        [JsonProperty("last_dividend")]
        [JsonConverter(typeof(StringToDecimalConverter))]
        public decimal? LastDividend { get; set; }

        [JsonProperty("dividend_date")]
        public string DividendDate { get; set; }

        [JsonProperty("ex_dividend_date")]
        public string ExDividendDate { get; set; }

        [JsonProperty("earnings_date")]
        public string EarningsDate { get; set; }

        [JsonProperty("percentage_held_by_insiders")]
        public decimal? PercentageHeldByInsiders { get; set; }

        [JsonProperty("percentage_held_by_institutions")]
        public decimal? PercentageHeldByInstitutions { get; set; }

        [JsonProperty("short_shares_outstanding")]
        public long? ShortSharesOutstanding { get; set; }

        [JsonProperty("short_shares_outstanding_percentage")]
        public decimal? ShortSharesOutstandingPercentage { get; set; }

        [JsonProperty("exchange_short_name")]
        public string ExchangeName { get; set; }

        [JsonProperty("exchange")]
        public string Exchange { get; set; }
    }

    public class IncomeStatement_Periodical
    {
        [JsonProperty("ticker")]
        public string Ticker { get; set; }

        [JsonProperty("date")]
        public string Date { get; set; }

        [JsonProperty("period")]
        public string Period { get; set; }

        [JsonProperty("period_label")]
        public string? PeriodLabel { get; set; }

        [JsonProperty("fiscal_year")]
        public int FiscalYear { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("is_sales_revenue_turnover")]
        public long? IsSalesRevenueTurnover { get; set; }

        [JsonProperty("is_sales_and_services_revenues")]
        public long? IsSalesAndServicesRevenues { get; set; }

        [JsonProperty("is_cogs")]
        public long? IsCogs { get; set; }

        [JsonProperty("is_cog_and_services_sold")]
        public long? IsCogAndServicesSold { get; set; }

        [JsonProperty("is_gross_profit")]
        public long? IsGrossProfit { get; set; }

        [JsonProperty("is_other_oper_income")]
        public long? IsOtherOperIncome { get; set; }

        [JsonProperty("is_operating_expn")]
        public long? IsOperatingExpn { get; set; }

        [JsonProperty("is_sg_and_a_expense")]
        public long? IsSgAndAExpense { get; set; }

        [JsonProperty("is_operating_expenses_r_and_d")]
        public long? IsOperatingExpensesRAndD { get; set; }

        [JsonProperty("is_other_operating_expenses")]
        public long? IsOtherOperatingExpenses { get; set; }

        [JsonProperty("is_operating_expenses")]
        public long? IsOperatingExpenses { get; set; }

        [JsonProperty("is_oper_income")]
        public long? IsOperIncome { get; set; }

        [JsonProperty("is_nonop_income_loss")]
        public long? IsNonopIncomeLoss { get; set; }

        [JsonProperty("is_net_interest_expense")]
        public long? IsNetInterestExpense { get; set; }

        [JsonProperty("is_int_expense")]
        public long? IsIntExpense { get; set; }

        [JsonProperty("is_int_income")]
        public long? IsIntIncome { get; set; }

        [JsonProperty("is_other_nonop_income_loss")]
        public long? IsOtherNonopIncomeLoss { get; set; }

        [JsonProperty("is_pretax_income")]
        public long? IsPretaxIncome { get; set; }

        [JsonProperty("is_inc_tax_exp")]
        public long? IsIncTaxExp { get; set; }

        [JsonProperty("is_inc_loss_affil")]
        public long? IsIncLossAffil { get; set; }

        [JsonProperty("is_inc_bef_xo_item")]
        public long? IsIncBefXoItem { get; set; }

        [JsonProperty("is_xo_gl_net_of_tax")]
        public long? IsXoGlNetOfTax { get; set; }

        [JsonProperty("is_discontinued_operations")]
        public long? IsDiscontinuedOperations { get; set; }

        [JsonProperty("is_extraord_items_and_acctg_chng")]
        public long? IsExtraordItemsAndAcctgChng { get; set; }

        [JsonProperty("is_ni_including_minority_int_ratio")]
        public long? IsNiIncludingMinorityIntRatio { get; set; }

        [JsonProperty("is_min_noncontrol_interest_credits")]
        public long? IsMinNoncontrolInterestCredits { get; set; }

        [JsonProperty("is_net_income")]
        public long? IsNetIncome { get; set; }

        [JsonProperty("is_tot_cash_pfd_dvd")]
        public long? IsTotCashPfdDvd { get; set; }

        [JsonProperty("is_other_adjustments")]
        public long? IsOtherAdjustments { get; set; }

        [JsonProperty("is_earn_for_common")]
        public long? IsEarnForCommon { get; set; }

        [JsonProperty("is_avg_num_sh_for_eps")]
        public long? IsAvgNumShForEps { get; set; }

        [JsonProperty("eps")]
        public decimal? Eps { get; set; }

        [JsonProperty("eps_cont_ops")]
        public decimal? EpsContOps { get; set; }

        [JsonProperty("is_sh_for_diluted_eps")]
        public long? IsShForDilutedEps { get; set; }

        [JsonProperty("diluted_eps")]
        public decimal? DilutedEps { get; set; }

        [JsonProperty("dil_eps_cont_ops")]
        public decimal? DilEpsContOps { get; set; }

        [JsonProperty("ebitda")]
        public long? Ebitda { get; set; }

        [JsonProperty("ebitda_margin")]
        public decimal? EbitdaMargin { get; set; }

        [JsonProperty("ebita")]
        public long? Ebita { get; set; }

        [JsonProperty("ebit")]
        public long? Ebit { get; set; }

        [JsonProperty("gross_margin")]
        public decimal? GrossMargin { get; set; }

        [JsonProperty("oper_margin")]
        public decimal? OperMargin { get; set; }

        [JsonProperty("profit_margin")]
        public decimal? ProfitMargin { get; set; }

        [JsonProperty("actual_sales_per_empl")]
        public decimal? ActualSalesPerEmpl { get; set; }

        [JsonProperty("div_per_shr")]
        public decimal? DivPerShr { get; set; }

        [JsonProperty("is_depr_exp")]
        public long? IsDeprExp { get; set; }
    }
    public class BalanceSheet_Periodical
    {
        [JsonProperty("ticker")]
        public string Ticker { get; set; }

        [JsonProperty("date")]
        public string Date { get; set; }

        [JsonProperty("period")]
        public string Period { get; set; }

        [JsonProperty("period_label")]
        public string? PeriodLabel { get; set; }

        [JsonProperty("fiscal_year")]
        public int FiscalYear { get; set; }

        [JsonProperty("currency")]
        public string StockCurrency { get; set; }
        // Assets
        [JsonProperty("bs_c_and_ce_and_sti_detailed")]
        public long? BsCAndCeAndStiDetailed { get; set; }

        [JsonProperty("bs_cash_near_cash_item")]
        public long? BsCashNearCashItem { get; set; }

        [JsonProperty("bs_mkt_sec_other_st_invest")]
        public long? BsMktSecOtherStInvest { get; set; }

        [JsonProperty("bs_acct_note_rcv")]
        public long? BsAcctNoteRcv { get; set; }

        [JsonProperty("bs_accts_rec_excl_notes_rec")]
        public long? BsAcctsRecExclNotesRec { get; set; }

        [JsonProperty("bs_notes_receivable")]
        public long? BsNotesReceivable { get; set; }

        [JsonProperty("bs_loans_receivable")]
        public long? BsLoansReceivable { get; set; }

        [JsonProperty("bs_other_current_receivable")]
        public long? BsOtherCurrentReceivable { get; set; }

        [JsonProperty("bs_inventories")]
        public long? BsInventories { get; set; }

        [JsonProperty("bs_invtry_raw_materials")]
        public long? BsInvtryRawMaterials { get; set; }

        [JsonProperty("bs_invtry_in_progress")]
        public long? BsInvtryInProgress { get; set; }

        [JsonProperty("bs_invtry_finished_goods")]
        public long? BsInvtryFinishedGoods { get; set; }

        [JsonProperty("bs_invtry_adj")]
        public long? BsInvtryAdj { get; set; }

        [JsonProperty("bs_other_inv")]
        public long? BsOtherInv { get; set; }

        [JsonProperty("bs_other_current_assets_detailed")]
        public long? BsOtherCurrentAssetsDetailed { get; set; }

        [JsonProperty("bs_prepay")]
        public long? BsPrepay { get; set; }

        [JsonProperty("bs_deriv_and_hedging_assets_st")]
        public long? BsDerivAndHedgingAssetsSt { get; set; }

        [JsonProperty("bs_assets_held_for_sale_st")]
        public long? BsAssetsHeldForSaleSt { get; set; }

        [JsonProperty("bs_deferred_tax_assets_st")]
        public long? BsDeferredTaxAssetsSt { get; set; }

        [JsonProperty("bs_other_cur_asset_less_prepay")]
        public long? BsOtherCurAssetLessPrepay { get; set; }

        [JsonProperty("bs_cur_asset_report")]
        public long? BsCurAssetReport { get; set; }

        [JsonProperty("bs_net_fix_asset")]
        public long? BsNetFixAsset { get; set; }

        [JsonProperty("bs_gross_fix_asset")]
        public long? BsGrossFixAsset { get; set; }

        [JsonProperty("bs_accum_depr")]
        public long? BsAccumDepr { get; set; }

        [JsonProperty("bs_lt_invest")]
        public long? BsLtInvest { get; set; }

        [JsonProperty("bs_long_term_investments")]
        public long? BsLongTermInvestments { get; set; }

        [JsonProperty("bs_lt_receivables")]
        public long? BsLtReceivables { get; set; }

        [JsonProperty("bs_other_assets_def_chrg_other")]
        public long? BsOtherAssetsDefChrgOther { get; set; }

        [JsonProperty("bs_disclosed_intangibles")]
        public long? BsDisclosedIntangibles { get; set; }

        [JsonProperty("bs_goodwill")]
        public long? BsGoodwill { get; set; }

        [JsonProperty("bs_other_intangible_assets_detailed")]
        public long? BsOtherIntangibleAssetsDetailed { get; set; }

        [JsonProperty("bs_deferred_tax_assets_lt")]
        public long? BsDeferredTaxAssetsLt { get; set; }

        [JsonProperty("bs_deriv_and_hedging_assets_lt")]
        public long? BsDerivAndHedgingAssetsLt { get; set; }

        [JsonProperty("bs_other_noncurrent_assets_detailed")]
        public long? BsOtherNoncurrentAssetsDetailed { get; set; }

        [JsonProperty("bs_tot_non_cur_asset")]
        public long? BsTotNonCurAsset { get; set; }

        [JsonProperty("bs_tot_asset")]
        public long? BsTotAsset { get; set; }

        // Liabilities
        [JsonProperty("bs_acct_payable_and_accruals_detailed")]
        public long? BsAcctPayableAndAccrualsDetailed { get; set; }

        [JsonProperty("bs_acct_payable")]
        public long? BsAcctPayable { get; set; }

        [JsonProperty("bs_taxes_payable")]
        public long? BsTaxesPayable { get; set; }

        [JsonProperty("bs_interest_and_dividends_payable")]
        public long? BsInterestAndDividendsPayable { get; set; }

        [JsonProperty("bs_accrual")]
        public long? BsAccrual { get; set; }

        [JsonProperty("bs_st_borrow")]
        public long? BsStBorrow { get; set; }

        [JsonProperty("bs_short_term_debt_detailed")]
        public long? BsShortTermDebtDetailed { get; set; }

        [JsonProperty("bs_st_capital_lease_obligations")]
        public long? BsStCapitalLeaseObligations { get; set; }

        [JsonProperty("bs_other_current_liabs_sub_detailed")]
        public long? BsOtherCurrentLiabsSubDetailed { get; set; }

        [JsonProperty("bs_st_deferred_revenue")]
        public long? BsStDeferredRevenue { get; set; }

        [JsonProperty("bs_derivative_and_hedging_liabs_st")]
        public long? BsDerivativeAndHedgingLiabsSt { get; set; }

        [JsonProperty("bs_deferred_tax_liabs_st")]
        public long? BsDeferredTaxLiabsSt { get; set; }

        [JsonProperty("bs_other_current_liabs_detailed")]
        public long? BsOtherCurrentLiabsDetailed { get; set; }

        [JsonProperty("bs_cur_liab")]
        public long? BsCurLiab { get; set; }

        [JsonProperty("bs_lt_borrow")]
        public long? BsLtBorrow { get; set; }

        [JsonProperty("bs_long_term_borrowings_detailed")]
        public long? BsLongTermBorrowingsDetailed { get; set; }

        [JsonProperty("bs_lt_capital_lease_obligations")]
        public long? BsLtCapitalLeaseObligations { get; set; }

        [JsonProperty("bs_other_noncur_liabs_sub_detailed")]
        public long? BsOtherNoncurLiabsSubDetailed { get; set; }

        [JsonProperty("bs_accrued_liabilities")]
        public long? BsAccruedLiabilities { get; set; }

        [JsonProperty("bs_pension_liabilities")]
        public long? BsPensionLiabilities { get; set; }

        [JsonProperty("bs_lt_deferred_revenue")]
        public long? BsLtDeferredRevenue { get; set; }

        [JsonProperty("bs_deferred_tax_liabilities_lt")]
        public long? BsDeferredTaxLiabilitiesLt { get; set; }

        [JsonProperty("bs_derivative_and_hedging_liabs_lt")]
        public long? BsDerivativeAndHedgingLiabsLt { get; set; }

        [JsonProperty("bs_other_noncurrent_liabs_detailed")]
        public long? BsOtherNoncurrentLiabsDetailed { get; set; }

        [JsonProperty("bs_non_cur_liab")]
        public long? BsNonCurLiab { get; set; }

        [JsonProperty("bs_tot_liab")]
        public long? BsTotLiab { get; set; }

        // Equity
        [JsonProperty("bs_pfd_eqty_and_hybrid_cptl")]
        public long? BsPfdEqtyAndHybridCptl { get; set; }

        [JsonProperty("bs_sh_cap_and_apic")]
        public long? BsShCapAndApic { get; set; }

        [JsonProperty("bs_common_stock")]
        public long? BsCommonStock { get; set; }

        [JsonProperty("bs_add_paid_in_cap")]
        public long? BsAddPaidInCap { get; set; }

        [JsonProperty("bs_amt_of_tsy_stock")]
        public long? BsAmtOfTsyStock { get; set; }

        [JsonProperty("bs_pure_retained_earnings")]
        public long? BsPureRetainedEarnings { get; set; }

        [JsonProperty("bs_other_ins_res_to_shrhldr_eqy")]
        public long? BsOtherInsResToShrhldrEqy { get; set; }

        [JsonProperty("bs_eqty_bef_minority_int_detailed")]
        public long? BsEqtyBefMinorityIntDetailed { get; set; }

        [JsonProperty("bs_minority_noncontrolling_interest")]
        public long? BsMinorityNoncontrollingInterest { get; set; }

        [JsonProperty("bs_total_equity")]
        public long? BsTotalEquity { get; set; }

        [JsonProperty("bs_tot_liab_and_eqy")]
        public long? BsTotLiabAndEqy { get; set; }

        // Metrics & Ratios
        [JsonProperty("bs_sh_out")]
        public long? BsShOut { get; set; }

        [JsonProperty("bs_total_capital_leases")]
        public long? BsTotalCapitalLeases { get; set; }

        [JsonProperty("net_debt")]
        public long? NetDebt { get; set; }

        [JsonProperty("net_debt_to_shrhldr_eqty")]
        public decimal? NetDebtToShrhldrEqty { get; set; }

        [JsonProperty("tce_ratio")]
        public decimal? TceRatio { get; set; }

        [JsonProperty("cur_ratio")]
        public decimal? CurRatio { get; set; }

        [JsonProperty("cash_conversion_cycle")]
        public decimal? CashConversionCycle { get; set; }

        [JsonProperty("num_of_employees")]
        public int? NumOfEmployees { get; set; }
    }
    public class CashFlowStatement_Periodical
    {
        [JsonProperty("ticker")]
        public string Ticker { get; set; }

        [JsonProperty("date")]
        public string Date { get; set; }

        [JsonProperty("period")]
        public string Period { get; set; }

        [JsonProperty("period_label")]
        public string? PeriodLabel { get; set; }

        [JsonProperty("fiscal_year")]
        public int FiscalYear { get; set; }

        [JsonProperty("currency")]
        public string StockCurrency { get; set; }

        // Operating Activities
        [JsonProperty("cf_net_inc")]
        public long? CfNetInc { get; set; }

        [JsonProperty("cf_net_income")]
        public long? CfNetIncome { get; set; }

        [JsonProperty("cf_depr_amort")]
        public long? CfDeprAmort { get; set; }

        [JsonProperty("cf_non_cash_items_detailed")]
        public long? CfNonCashItemsDetailed { get; set; }

        [JsonProperty("cf_stock_based_compensation")]
        public long? CfStockBasedCompensation { get; set; }

        [JsonProperty("cf_def_inc_tax")]
        public long? CfDefIncTax { get; set; }

        [JsonProperty("cf_asset_impairment_charge")]
        public long? CfAssetImpairmentCharge { get; set; }

        [JsonProperty("cf_other_non_cash_adj_less_detailed")]
        public long? CfOtherNonCashAdjLessDetailed { get; set; }

        [JsonProperty("cf_chng_non_cash_work_cap")]
        public long? CfChngNonCashWorkCap { get; set; }

        [JsonProperty("cf_acct_rcv_unbilled_rev")]
        public long? CfAcctRcvUnbilledRev { get; set; }

        [JsonProperty("cf_change_in_inventories")]
        public long? CfChangeInInventories { get; set; }

        [JsonProperty("cf_change_in_prepaid_assets")]
        public long? CfChangeInPrepaidAssets { get; set; }

        [JsonProperty("cf_change_in_accounts_payable")]
        public long? CfChangeInAccountsPayable { get; set; }

        [JsonProperty("cf_inc_dec_in_ot_op_ast_liab_detail")]
        public long? CfIncDecInOtOpAstLiabDetail { get; set; }

        [JsonProperty("cf_net_cash_discont_ops_oper")]
        public long? CfNetCashDiscontOpsOper { get; set; }

        [JsonProperty("cf_cash_from_oper")]
        public long? CfCashFromOper { get; set; }

        [JsonProperty("cf_cash_from_operating_activities")]
        public long? CfCashFromOperatingActivities { get; set; }

        // Investing Activities
        [JsonProperty("cf_chg_in_fxd_and_intang_ast_detailed")]
        public long? CfChgInFxdAndIntangAstDetailed { get; set; }

        [JsonProperty("cf_disp_fxd_and_intangibles_detailed")]
        public long? CfDispFxdAndIntangiblesDetailed { get; set; }

        [JsonProperty("cf_disposal_of_fixed_prod_assets")]
        public long? CfDisposalOfFixedProdAssets { get; set; }

        [JsonProperty("cf_disposal_of_intangible_assets")]
        public long? CfDisposalOfIntangibleAssets { get; set; }

        [JsonProperty("cf_acquis_fxd_and_intang_detailed")]
        public long? CfAcquisFxdAndIntangDetailed { get; set; }

        [JsonProperty("cf_purchase_of_fixed_prod_assets")]
        public long? CfPurchaseOfFixedProdAssets { get; set; }

        [JsonProperty("cf_acquisition_of_intang_assets")]
        public long? CfAcquisitionOfIntangAssets { get; set; }

        [JsonProperty("cf_net_chg_in_lt_invest_detailed")]
        public long? CfNetChgInLtInvestDetailed { get; set; }

        [JsonProperty("cf_decr_invest")]
        public long? CfDecrInvest { get; set; }

        [JsonProperty("cf_incr_invest")]
        public long? CfIncrInvest { get; set; }

        [JsonProperty("cf_nt_csh_rcvd_pd_for_acquis_div")]
        public long? CfNtCshRcvdPdForAcquisDiv { get; set; }

        [JsonProperty("cf_cash_for_divestitures")]
        public long? CfCashForDivestitures { get; set; }

        [JsonProperty("cf_cash_for_acquis_subsidiaries")]
        public long? CfCashForAcquisSubsidiaries { get; set; }

        [JsonProperty("cf_cash_for_joint_ventures_assoc")]
        public long? CfCashForJointVenturesAssoc { get; set; }

        [JsonProperty("cf_other_investing_act_detailed")]
        public long? CfOtherInvestingActDetailed { get; set; }

        [JsonProperty("cf_net_cash_discontinued_ops_inv")]
        public long? CfNetCashDiscontinuedOpsInv { get; set; }

        [JsonProperty("cf_cash_from_inv_act")]
        public long? CfCashFromInvAct { get; set; }

        [JsonProperty("cf_cash_from_investing_activities")]
        public long? CfCashFromInvestingActivities { get; set; }

        // Financing Activities
        [JsonProperty("cf_dvd_paid")]
        public long? CfDvdPaid { get; set; }

        [JsonProperty("cf_nt_csh_proc_pymt_debt")]
        public long? CfNtCshProcPymtDebt { get; set; }

        [JsonProperty("cf_proc_debt_and_capital_lease")]
        public long? CfProcDebtAndCapitalLease { get; set; }

        [JsonProperty("cf_pymt_debt_and_capital_lease")]
        public long? CfPymtDebtAndCapitalLease { get; set; }

        [JsonProperty("cf_proc_fr_repurch_eqty_detailed")]
        public long? CfProcFrRepurchEqtyDetailed { get; set; }

        [JsonProperty("cf_incr_cap_stock")]
        public long? CfIncrCapStock { get; set; }

        [JsonProperty("cf_decr_cap_stock")]
        public long? CfDecrCapStock { get; set; }

        [JsonProperty("cf_other_financing_act_excl_fx")]
        public long? CfOtherFinancingActExclFx { get; set; }

        [JsonProperty("cf_net_cash_discontinued_ops_fin")]
        public long? CfNetCashDiscontinuedOpsFin { get; set; }

        [JsonProperty("cf_cash_from_fin_act")]
        public long? CfCashFromFinAct { get; set; }

        [JsonProperty("cf_cash_from_financing_activities")]
        public long? CfCashFromFinancingActivities { get; set; }

        // Net Cash
        [JsonProperty("cf_effect_foreign_exchanges")]
        public long? CfEffectForeignExchanges { get; set; }

        [JsonProperty("cf_net_chng_cash")]
        public long? CfNetChngCash { get; set; }

        [JsonProperty("cf_net_change_in_cash")]
        public long? CfNetChangeInCash { get; set; }

        [JsonProperty("cf_cash_end_period")]
        public long? CfCashEndPeriod { get; set; }

        [JsonProperty("cf_cap_expenditures")]
        public long? CfCapExpenditures { get; set; }

        // Metrics & Ratios
        [JsonProperty("ebitda")]
        public long? Ebitda { get; set; }

        [JsonProperty("ebitda_margin")]
        public decimal? EbitdaMargin { get; set; }

        [JsonProperty("cf_net_cash_paid_for_aquis")]
        public long? CfNetCashPaidForAquis { get; set; }

        [JsonProperty("cf_free_cash_flow")]
        public long? CfFreeCashFlow { get; set; }

        [JsonProperty("cf_free_cash_flow_firm")]
        public long? CfFreeCashFlowFirm { get; set; }

        [JsonProperty("free_cash_flow_equity")]
        public long? FreeCashFlowEquity { get; set; }

        [JsonProperty("free_cash_flow_per_sh")]
        public decimal? FreeCashFlowPerSh { get; set; }

        [JsonProperty("pr_to_free_cash_flow")]
        public decimal? PrToFreeCashFlow { get; set; }

        [JsonProperty("cash_flow_to_net_inc")]
        public decimal? CashFlowToNetInc { get; set; }
    }
    public class PerShareData_Periodical
    {
        [JsonProperty("ticker")]
        public string Ticker { get; set; }

        [JsonProperty("date")]
        public string Date { get; set; }

        [JsonProperty("period")]
        public string Period { get; set; }

        [JsonProperty("period_label")]
        public string? PeriodLabel { get; set; }

        [JsonProperty("fiscal_year")]
        public int FiscalYear { get; set; }

        // Share Counts
        [JsonProperty("bs_sh_out")]
        public long? BsShOut { get; set; }

        [JsonProperty("is_sh_for_diluted_eps")]
        public long? IsShForDilutedEps { get; set; }

        [JsonProperty("is_avg_num_sh_for_eps")]
        public long? IsAvgNumShForEps { get; set; }

        // Per Share Values
        [JsonProperty("revenue_per_sh")]
        public decimal? RevenuePerSh { get; set; }

        [JsonProperty("ebitda_per_sh")]
        public decimal? EbitdaPerSh { get; set; }

        [JsonProperty("oper_inc_per_sh")]
        public decimal? OperIncPerSh { get; set; }

        [JsonProperty("eps")]
        public decimal? Eps { get; set; }

        [JsonProperty("eps_cont_ops")]
        public decimal? EpsContOps { get; set; }

        [JsonProperty("diluted_eps")]
        public decimal? DilutedEps { get; set; }

        [JsonProperty("dil_eps_cont_ops")]
        public decimal? DilEpsContOps { get; set; }

        [JsonProperty("div_per_shr")]
        public decimal? DivPerShr { get; set; }

        [JsonProperty("cash_flow_per_sh")]
        public decimal? CashFlowPerSh { get; set; }

        [JsonProperty("free_cash_flow_per_sh")]
        public decimal? FreeCashFlowPerSh { get; set; }

        [JsonProperty("cash_st_investments_per_sh")]
        public decimal? CashStInvestmentsPerSh { get; set; }

        [JsonProperty("book_val_per_sh")]
        public decimal? BookValPerSh { get; set; }

        [JsonProperty("tang_book_val_per_sh")]
        public decimal? TangBookValPerSh { get; set; }
    }
    public class ProfitabilityRatios_Periodical
    {
        [JsonProperty("ticker")]
        public string Ticker { get; set; }

        [JsonProperty("date")]
        public string Date { get; set; }

        [JsonProperty("period")]
        public string Period { get; set; }

        [JsonProperty("period_label")]
        public string? PeriodLabel { get; set; }

        [JsonProperty("fiscal_year")]
        public int FiscalYear { get; set; }

        [JsonProperty("return_com_eqy")]
        public decimal? ReturnComEqy { get; set; }

        [JsonProperty("return_on_asset")]
        public decimal? ReturnOnAsset { get; set; }

        [JsonProperty("return_on_cap")]
        public decimal? ReturnOnCap { get; set; }

        [JsonProperty("return_on_inv_capital")]
        public decimal? ReturnOnInvCapital { get; set; }

        [JsonProperty("gross_margin")]
        public decimal? GrossMargin { get; set; }

        [JsonProperty("ebitda_margin")]
        public decimal? EbitdaMargin { get; set; }

        [JsonProperty("oper_margin")]
        public decimal? OperMargin { get; set; }

        [JsonProperty("incremental_operating_margin")]
        public decimal? IncrementalOperatingMargin { get; set; }

        [JsonProperty("pretax_inc_to_net_sales")]
        public decimal? PretaxIncToNetSales { get; set; }

        [JsonProperty("profit_margin")]
        public decimal? ProfitMargin { get; set; }

        [JsonProperty("net_income_to_common_margin")]
        public decimal? NetIncomeToCommonMargin { get; set; }

        [JsonProperty("eff_tax_rate")]
        public decimal? EffTaxRate { get; set; }

        [JsonProperty("dvd_payout_ratio")]
        public decimal? DvdPayoutRatio { get; set; }

        [JsonProperty("sustain_growth_rt")]
        public decimal? SustainGrowthRt { get; set; }
    }
    public class ValuationMultiples_Periodical
    {
        [JsonProperty("ticker")]
        public string Ticker { get; set; }

        [JsonProperty("date")]
        public string Date { get; set; }

        [JsonProperty("period")]
        public string Period { get; set; }

        [JsonProperty("period_label")]
        public string? PeriodLabel { get; set; }

        [JsonProperty("fiscal_year")]
        public int FiscalYear { get; set; }

        // P/E Ratio
        [JsonProperty("pe_ratio")]
        public decimal? PeRatio { get; set; }

        [JsonProperty("average_price_earnings_ratio")]
        public decimal? AveragePriceEarningsRatio { get; set; }

        [JsonProperty("pe_ratio_with_high_clos_pr")]
        public decimal? PeRatioWithHighClosPr { get; set; }

        [JsonProperty("pe_ratio_with_low_clos_pr")]
        public decimal? PeRatioWithLowClosPr { get; set; }

        // Price to Book
        [JsonProperty("pr_to_book_ratio")]
        public decimal? PrToBookRatio { get; set; }

        [JsonProperty("average_price_to_book_ratio")]
        public decimal? AveragePriceToBookRatio { get; set; }

        [JsonProperty("high_closing_price_to_book_ratio")]
        public decimal? HighClosingPriceToBookRatio { get; set; }

        [JsonProperty("low_closing_price_to_book_ratio")]
        public decimal? LowClosingPriceToBookRatio { get; set; }

        // Price to Tangible Book Value
        [JsonProperty("pr_to_tang_bv_per_sh")]
        public decimal? PrToTangBvPerSh { get; set; }

        [JsonProperty("average_price_to_tangible_bps")]
        public decimal? AveragePriceToTangibleBps { get; set; }

        [JsonProperty("high_price_to_tangible_bps")]
        public decimal? HighPriceToTangibleBps { get; set; }

        [JsonProperty("low_price_to_tangible_bps")]
        public decimal? LowPriceToTangibleBps { get; set; }

        // Price to Sales
        [JsonProperty("pr_to_sales_ratio")]
        public decimal? PrToSalesRatio { get; set; }

        [JsonProperty("average_price_to_sales_ratio")]
        public decimal? AveragePriceToSalesRatio { get; set; }

        [JsonProperty("high_closing_price_to_sales_ratio")]
        public decimal? HighClosingPriceToSalesRatio { get; set; }

        [JsonProperty("low_closing_price_to_sales_ratio")]
        public decimal? LowClosingPriceToSalesRatio { get; set; }

        // Price to Cash Flow
        [JsonProperty("pr_to_cash_flow")]
        public decimal? PrToCashFlow { get; set; }

        [JsonProperty("average_price_to_cash_flow")]
        public decimal? AveragePriceToCashFlow { get; set; }

        [JsonProperty("high_closing_price_to_cash_flow")]
        public decimal? HighClosingPriceToCashFlow { get; set; }

        [JsonProperty("low_closing_price_to_cash_flow")]
        public decimal? LowClosingPriceToCashFlow { get; set; }

        // Price to Free Cash Flow
        [JsonProperty("pr_to_free_cash_flow")]
        public decimal? PrToFreeCashFlow { get; set; }

        [JsonProperty("average_price_to_free_cash_flow")]
        public decimal? AveragePriceToFreeCashFlow { get; set; }

        [JsonProperty("high_price_to_free_cash_flow")]
        public decimal? HighPriceToFreeCashFlow { get; set; }

        [JsonProperty("low_price_to_free_cash_flow")]
        public decimal? LowPriceToFreeCashFlow { get; set; }

        // EV to TTM Sales
        [JsonProperty("ev_to_ttm_sales")]
        public decimal? EvToTtmSales { get; set; }

        [JsonProperty("average_ev_to_ttm_sales")]
        public decimal? AverageEvToTtmSales { get; set; }

        [JsonProperty("high_ev_to_ttm_sales")]
        public decimal? HighEvToTtmSales { get; set; }

        [JsonProperty("low_ev_to_ttm_sales")]
        public decimal? LowEvToTtmSales { get; set; }

        // EV to TTM EBITDA
        [JsonProperty("ev_to_ttm_ebitda")]
        public decimal? EvToTtmEbitda { get; set; }

        [JsonProperty("avg_ev_to_ttm_ebitda")]
        public decimal? AvgEvToTtmEbitda { get; set; }

        [JsonProperty("high_ev_to_ttm_ebitda")]
        public decimal? HighEvToTtmEbitda { get; set; }

        [JsonProperty("low_ev_to_ttm_ebitda")]
        public decimal? LowEvToTtmEbitda { get; set; }

        // EV to TTM EBIT
        [JsonProperty("ev_to_ttm_ebit")]
        public decimal? EvToTtmEbit { get; set; }

        [JsonProperty("average_ev_to_ttm_ebit")]
        public decimal? AverageEvToTtmEbit { get; set; }

        [JsonProperty("high_ev_to_ttm_ebit")]
        public decimal? HighEvToTtmEbit { get; set; }

        [JsonProperty("low_ev_to_ttm_ebit")]
        public decimal? LowEvToTtmEbit { get; set; }

        // Prices
        [JsonProperty("pr_last")]
        public decimal? PrLast { get; set; }

        [JsonProperty("pr_high")]
        public decimal? PrHigh { get; set; }

        [JsonProperty("pr_low")]
        public decimal? PrLow { get; set; }

        // Enterprise Value
        [JsonProperty("enterprise_value")]
        public long? EnterpriseValue { get; set; }

        [JsonProperty("average_enterprise_value")]
        public long? AverageEnterpriseValue { get; set; }

        [JsonProperty("high_enterprise_value")]
        public long? HighEnterpriseValue { get; set; }

        [JsonProperty("low_enterprise_value")]
        public long? LowEnterpriseValue { get; set; }

        // Shares Outstanding
        [JsonProperty("bs_sh_out")]
        public long? BsShOut { get; set; }
    }
}
