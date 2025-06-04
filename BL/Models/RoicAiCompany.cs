using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace BL.Models
{
    public class RoicAiCompany
    {
        public List<IncomeStatement> IncomeStatements { get; set; }
        public List<BalanceSheet> BalanceSheets { get; set; }
        public List<CashFlowStatement> CashFlowStatements {  get; set; }
        public RoicAICompanyRatios FinancialRatios { get; set; }
        public MacroTrendsData MacroTrendsData { get; set; }
    }   

    public class IncomeStatement
    {
        public string id { get; set; }
        public string figi_company { get; set; }
        public string figi_global { get; set; }
        public string figi { get; set; }
        public string date { get; set; }
        public string fiscal_year { get; set; }
        public string date_raw { get; set; }
        public string period { get; set; }
        public string period_label { get; set; }
        public string currency { get; set; }
        public string is_sales_revenue_turnover { get; set; }
        public string is_sales_and_services_revenues { get; set; }
        public string is_cogs { get; set; }
        public string is_cog_and_services_sold { get; set; }
        public string is_gross_profit { get; set; }
        public string is_other_oper_income { get; set; }
        public string is_operating_expn { get; set; }
        public string is_sg_and_a_expense { get; set; }
        public string is_operating_expenses_r_and_d { get; set; }
        public string is_other_operating_expenses { get; set; }
        public string is_oper_income { get; set; }
        public string is_nonop_income_loss { get; set; }
        public string is_net_interest_expense { get; set; }
        public string is_int_expense { get; set; }
        public string is_int_income { get; set; }
        public string is_other_nonop_income_loss { get; set; }
        public string is_pretax_income { get; set; }
        public string is_inc_tax_exp { get; set; }
        public string is_inc_loss_affil { get; set; }
        public string is_inc_bef_xo_item { get; set; }
        public string is_xo_gl_net_of_tax { get; set; }
        public string is_discontinued_operations { get; set; }
        public string is_extraord_items_and_acctg_chng { get; set; }
        public string is_ni_including_minority_int_ratio { get; set; }
        public string is_min_noncontrol_interest_credits { get; set; }
        public string is_net_income { get; set; }
        public string is_tot_cash_pfd_dvd { get; set; }
        public string is_other_adjustments { get; set; }
        public string is_earn_for_common { get; set; }
        public string is_avg_num_sh_for_eps { get; set; }
        public string eps { get; set; }
        public string eps_cont_ops { get; set; }
        public string is_sh_for_diluted_eps { get; set; }
        public string diluted_eps { get; set; }
        public string dil_eps_cont_ops { get; set; }
        public string ebitda { get; set; }
        public string ebitda_margin { get; set; }
        public string ebita { get; set; }
        public string ebit { get; set; }
        public string gross_margin { get; set; }
        public string oper_margin { get; set; }
        public string profit_margin { get; set; }
        public string actual_sales_per_empl { get; set; }
        public string div_per_shr { get; set; }
        public string is_depr_exp { get; set; }
    }    
    public class BalanceSheet
    {
        public string id { get; set; }
        public string figi_company { get; set; }
        public string figi_global { get; set; }
        public string figi { get; set; }
        public string date { get; set; }
        public string fiscal_year { get; set; }
        public string date_raw { get; set; }
        public string period { get; set; }
        public string period_label { get; set; }
        public string currency { get; set; }
        public string bs_c_and_ce_and_sti_detailed { get; set; }
        public string bs_cash_near_cash_item { get; set; }
        public string bs_mkt_sec_other_st_invest { get; set; }
        public string bs_acct_note_rcv { get; set; }
        public string bs_accts_rec_excl_notes_rec { get; set; }
        public string bs_notes_receivable { get; set; }
        public string bs_loans_receivable { get; set; }
        public string bs_other_current_receivable { get; set; }
        public string bs_inventories { get; set; }
        public string bs_invtry_raw_materials { get; set; }
        public string bs_invtry_in_progress { get; set; }
        public string bs_invtry_finished_goods { get; set; }
        public string bs_invtry_adj { get; set; }
        public string bs_other_inv { get; set; }
        public string bs_other_current_assets_detailed { get; set; }
        public string bs_prepay { get; set; }
        public string bs_deriv_and_hedging_assets_st { get; set; }
        public string bs_assets_held_for_sale_st { get; set; }
        public string bs_deferred_tax_assets_st { get; set; }
        public string bs_other_cur_asset_less_prepay { get; set; }
        public string bs_cur_asset_report { get; set; }
        public string bs_net_fix_asset { get; set; }
        public string bs_gross_fix_asset { get; set; }
        public string bs_accum_depr { get; set; }
        public string bs_lt_invest { get; set; }
        public string bs_long_term_investments { get; set; }
        public string bs_lt_receivables { get; set; }
        public string bs_other_assets_def_chrg_other { get; set; }
        public string bs_disclosed_intangibles { get; set; }
        public string bs_goodwill { get; set; }
        public string bs_other_intangible_assets_detailed { get; set; }
        public string bs_deferred_tax_assets_lt { get; set; }
        public string bs_deriv_and_hedging_assets_lt { get; set; }
        public string bs_other_noncurrent_assets_detailed { get; set; }
        public string bs_tot_non_cur_asset { get; set; }
        public string bs_tot_asset { get; set; }
        public string bs_acct_payable_and_accruals_detailed { get; set; }
        public string bs_acct_payable { get; set; }
        public string bs_taxes_payable { get; set; }
        public string bs_interest_and_dividends_payable { get; set; }
        public string bs_accrual { get; set; }
        public string bs_st_borrow { get; set; }
        public string bs_short_term_debt_detailed { get; set; }
        public string bs_st_capital_lease_obligations { get; set; }
        public string bs_other_current_liabs_sub_detailed { get; set; }
        public string bs_st_deferred_revenue { get; set; }
        public string bs_derivative_and_hedging_liabs_st { get; set; }
        public string bs_deferred_tax_liabs_st { get; set; }
        public string bs_other_current_liabs_detailed { get; set; }
        public string bs_cur_liab { get; set; }
        public string bs_lt_borrow { get; set; }
        public string bs_long_term_borrowings_detailed { get; set; }
        public string bs_lt_capital_lease_obligations { get; set; }
        public string bs_other_noncur_liabs_sub_detailed { get; set; }
        public string bs_accrued_liabilities { get; set; }
        public string bs_pension_liabilities { get; set; }
        public string bs_lt_deferred_revenue { get; set; }
        public string bs_deferred_tax_liabilities_lt { get; set; }
        public string bs_derivative_and_hedging_liabs_lt { get; set; }
        public string bs_other_noncurrent_liabs_detailed { get; set; }
        public string bs_non_cur_liab { get; set; }
        public string bs_tot_liab { get; set; }
        public string bs_pfd_eqty_and_hybrid_cptl { get; set; }
        public string bs_sh_cap_and_apic { get; set; }
        public string bs_common_stock { get; set; }
        public string bs_add_paid_in_cap { get; set; }
        public string bs_amt_of_tsy_stock { get; set; }
        public string bs_pure_retained_earnings { get; set; }
        public string bs_other_ins_res_to_shrhldr_eqy { get; set; }
        public string bs_eqty_bef_minority_int_detailed { get; set; }
        public string bs_minority_noncontrolling_interest { get; set; }
        public string bs_total_equity { get; set; }
        public string bs_tot_liab_and_eqy { get; set; }
        public string bs_sh_out { get; set; }
        public string bs_total_capital_leases { get; set; }
        public string net_debt { get; set; }
        public string net_debt_to_shrhldr_eqty { get; set; }
        public string tce_ratio { get; set; }
        public string cur_ratio { get; set; }
        public string cash_conversion_cycle { get; set; }
        public string num_of_employees { get; set; }
    }
    public class CashFlowStatement
    {
        public string id { get; set; }
        public string figi_company { get; set; }
        public string figi_global { get; set; }
        public string figi { get; set; }
        public string date { get; set; }
        public string fiscal_year { get; set; }
        public string date_raw { get; set; }
        public string period { get; set; }
        public string period_label { get; set; }
        public string currency { get; set; }
        public string cf_net_inc { get; set; }
        public string cf_depr_amort { get; set; }
        public string cf_non_cash_items_detailed { get; set; }
        public string cf_stock_based_compensation { get; set; }
        public string cf_def_inc_tax { get; set; }
        public string cf_asset_impairment_charge { get; set; }
        public string cf_other_non_cash_adj_less_detailed { get; set; }
        public string cf_chng_non_cash_work_cap { get; set; }
        public string cf_acct_rcv_unbilled_rev { get; set; }
        public string cf_change_in_inventories { get; set; }
        public string cf_change_in_prepaid_assets { get; set; }
        public string cf_change_in_accounts_payable { get; set; }
        public string cf_inc_dec_in_ot_op_ast_liab_detail { get; set; }
        public string cf_net_cash_discont_ops_oper { get; set; }
        public string cf_cash_from_oper { get; set; }
        public string cf_chg_in_fxd_and_intang_ast_detailed { get; set; }
        public string cf_disp_fxd_and_intangibles_detailed { get; set; }
        public string cf_disposal_of_fixed_prod_assets { get; set; }
        public string cf_disposal_of_intangible_assets { get; set; }
        public string cf_acquis_fxd_and_intang_detailed { get; set; }
        public string cf_purchase_of_fixed_prod_assets { get; set; }
        public string cf_acquisition_of_intang_assets { get; set; }
        public string cf_net_chg_in_lt_invest_detailed { get; set; }
        public string cf_decr_invest { get; set; }
        public string cf_incr_invest { get; set; }
        public string cf_nt_csh_rcvd_pd_for_acquis_div { get; set; }
        public string cf_cash_for_divestitures { get; set; }
        public string cf_cash_for_acquis_subsidiaries { get; set; }
        public string cf_cash_for_joint_ventures_assoc { get; set; }
        public string cf_other_investing_act_detailed { get; set; }
        public string cf_net_cash_discontinued_ops_inv { get; set; }
        public string cf_cash_from_inv_act { get; set; }
        public string cf_dvd_paid { get; set; }
        public string cf_nt_csh_proc_pymt_debt { get; set; }
        public string cf_proc_debt_and_capital_lease { get; set; }
        public string cf_pymt_debt_and_capital_lease { get; set; }
        public string cf_proc_fr_repurch_eqty_detailed { get; set; }
        public string cf_incr_cap_stock { get; set; }
        public string cf_decr_cap_stock { get; set; }
        public string cf_other_financing_act_excl_fx { get; set; }
        public string cf_net_cash_discontinued_ops_fin { get; set; }
        public string cf_cash_from_fin_act { get; set; }
        public string cf_effect_foreign_exchanges { get; set; }
        public string cf_net_chng_cash { get; set; }
        public string cf_cap_expenditures { get; set; }
        public string ebitda { get; set; }
        public string ebitda_margin { get; set; }
        public string cf_net_cash_paid_for_aquis { get; set; }
        public string cf_free_cash_flow { get; set; }
        public string cf_free_cash_flow_firm { get; set; }
        public string free_cash_flow_equity { get; set; }
        public string free_cash_flow_per_sh { get; set; }
        public string pr_to_free_cash_flow { get; set; }
        public string cash_flow_to_net_inc { get; set; }
    }


}
