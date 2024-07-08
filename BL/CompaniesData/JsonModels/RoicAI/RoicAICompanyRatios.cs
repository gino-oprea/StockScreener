using System;
using System.Collections.Generic;
using System.Text;

namespace BL.CompaniesData.JsonModels.RoicAI
{
    public class RoicAICompanyRatios
    {
        public List<ProfitabilityFinancialRatios> ProfitabilityFinancialRatios { get; set; }
        public List<CreditFinancialRatios> CreditFinancialRatios { get; set; }
        public List<LiquidityFinancialRatios> LiquidityFinancialRatios { get; set; }
        public List<WorkingCapitalFinancialRatios> WorkingCapitalFinancialRatios { get; set; }
        public List<EnterpriseValueFinancialRatios> EnterpriseValueFinancialRatios { get; set; }
        public List<MultiplesFinancialRatios> MultiplesFinancialRatios { get; set; }
        public List<PerShareDataItemsFinancialRatios> PerShareDataItemsFinancialRatios { get; set; }
    }

    public class ProfitabilityFinancialRatios 
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
        public string return_com_eqy { get; set; }
        public string return_on_asset { get; set; }
        public string return_on_cap { get; set; }
        public string return_on_inv_capital { get; set; }
        public string gross_margin { get; set; }
        public string ebitda_margin { get; set; }
        public string oper_margin { get; set; }
        public string incremental_operating_margin { get; set; }
        public string pretax_inc_to_net_sales { get; set; }
        public string profit_margin { get; set; }
        public string net_income_to_common_margin { get; set; }
        public string eff_tax_rate { get; set; }
        public string dvd_payout_ratio { get; set; }
        public string sustain_growth_rt { get; set; }
    }
    public class CreditFinancialRatios 
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
        public string short_and_long_term_debt { get; set; }
        public string bs_st_borrow { get; set; }
        public string bs_lt_borrow { get; set; }
        public string tot_debt_to_ebitda { get; set; }
        public string net_debt_to_ebitda { get; set; }
        public string total_debt_to_ebit { get; set; }
        public string net_debt_to_ebit { get; set; }
        public string ebitda_to_interest_expn { get; set; }
        public string ebitda_les_cap_expend_to_int_exp { get; set; }
        public string oper_inc_to_int_exp { get; set; }
        public string is_int_expense { get; set; }
        public string com_eqy_to_tot_asset { get; set; }
        public string lt_debt_to_tot_eqy { get; set; }
        public string lt_debt_to_tot_cap { get; set; }
        public string lt_debt_to_tot_asset { get; set; }
        public string tot_debt_to_tot_eqy { get; set; }
        public string tot_debt_to_tot_cap { get; set; }
        public string tot_debt_to_tot_asset { get; set; }
        public string net_debt_to_shrhldr_eqty { get; set; }
        public string net_debt_to_capital { get; set; }
        public string ebitda { get; set; }
        public string ebitda_after_capex { get; set; }
        public string is_oper_income { get; set; }
    }
    public class LiquidityFinancialRatios 
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
        public string cash_ratio { get; set; }
        public string cur_ratio { get; set; }
        public string quick_ratio { get; set; }
        public string cfo_to_avg_current_liabilities { get; set; }
        public string com_eqy_to_tot_asset { get; set; }
        public string lt_debt_to_tot_eqy { get; set; }
        public string lt_debt_to_tot_cap { get; set; }
        public string lt_debt_to_tot_asset { get; set; }
        public string tot_debt_to_tot_eqy { get; set; }
        public string tot_debt_to_tot_cap { get; set; }
        public string tot_debt_to_tot_asset { get; set; }
        public string cash_flow_to_tot_liab { get; set; }
        public string cap_expend_ratio { get; set; }
        public string altman_z_score { get; set; }
    }
    public class WorkingCapitalFinancialRatios 
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
        public string acct_rcv_turn { get; set; }
        public string acct_rcv_days { get; set; }
        public string invent_turn { get; set; }
        public string invent_days { get; set; }
        public string accounts_payable_turnover { get; set; }
        public string accounts_payable_turnover_days { get; set; }
        public string cash_conversion_cycle { get; set; }
        public string inv_to_cash_days { get; set; }
        public string bs_inventories { get; set; }
        public string bs_invtry_raw_materials { get; set; }
        public string bs_invtry_in_progress { get; set; }
        public string bs_invtry_finished_goods { get; set; }
        public string bs_other_inv { get; set; }
    }
    public class EnterpriseValueFinancialRatios 
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
        public string market_cap { get; set; }
        public string bs_cash_near_cash_item { get; set; }
        public string bs_pfd_eqty_and_hybrid_cptl { get; set; }
        public string bs_minority_noncontrolling_interest { get; set; }
        public string short_and_long_term_debt { get; set; }
        public string enterprise_value { get; set; }
        public string bs_tot_cap { get; set; }
        public string tot_debt_to_tot_cap { get; set; }
        public string total_debt_to_ev { get; set; }
        public string ev_to_ttm_sales { get; set; }
        public string ev_to_ttm_ebitda { get; set; }
        public string ev_to_ttm_ebit { get; set; }
        public string ev_to_ttm_cash_flow_firm { get; set; }
        public string ev_to_ttm_free_cash_flow_firm { get; set; }
        public string diluted_mkt_cap { get; set; }
        public string diluted_ev { get; set; }
        public string ev_to_sh_out { get; set; }
        public string ttm_net_sales { get; set; }
        public string ttm_ebitda { get; set; }
        public string ttm_oper_inc { get; set; }
        public string ttm_cash_flow_firm { get; set; }
        public string ttm_free_cash_flow_firm { get; set; }
    }
    public class MultiplesFinancialRatios 
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
        public string pe_ratio { get; set; }
        public string average_price_earnings_ratio { get; set; }
        public string pe_ratio_with_high_clos_pr { get; set; }
        public string pe_ratio_with_low_clos_pr { get; set; }
        public string pr_to_book_ratio { get; set; }
        public string average_price_to_book_ratio { get; set; }
        public string high_closing_price_to_book_ratio { get; set; }
        public string low_closing_price_to_book_ratio { get; set; }
        public string pr_to_tang_bv_per_sh { get; set; }
        public string average_price_to_tangible_bps { get; set; }
        public string high_price_to_tangible_bps { get; set; }
        public string low_price_to_tangible_bps { get; set; }
        public string pr_to_sales_ratio { get; set; }
        public string average_price_to_sales_ratio { get; set; }
        public string high_closing_price_to_sales_ratio { get; set; }
        public string low_closing_price_to_sales_ratio { get; set; }
        public string pr_to_cash_flow { get; set; }
        public string average_price_to_cash_flow { get; set; }
        public string high_closing_price_to_cash_flow { get; set; }
        public string low_closing_price_to_cash_flow { get; set; }
        public string pr_to_free_cash_flow { get; set; }
        public string average_price_to_free_cash_flow { get; set; }
        public string high_price_to_free_cash_flow { get; set; }
        public string low_price_to_free_cash_flow { get; set; }
        public string ev_to_ttm_sales { get; set; }
        public string average_ev_to_ttm_sales { get; set; }
        public string high_ev_to_ttm_sales { get; set; }
        public string low_ev_to_ttm_sales { get; set; }
        public string ev_to_ttm_ebitda { get; set; }
        public string avg_ev_to_ttm_ebitda { get; set; }
        public string high_ev_to_ttm_ebitda { get; set; }
        public string low_ev_to_ttm_ebitda { get; set; }
        public string ev_to_ttm_ebit { get; set; }
        public string average_ev_to_ttm_ebit { get; set; }
        public string high_ev_to_ttm_ebit { get; set; }
        public string low_ev_to_ttm_ebit { get; set; }
        public string pr_last { get; set; }
        public string pr_high { get; set; }
        public string pr_low { get; set; }
        public string enterprise_value { get; set; }
        public string average_enterprise_value { get; set; }
        public string high_enterprise_value { get; set; }
        public string low_enterprise_value { get; set; }
    }
    public class PerShareDataItemsFinancialRatios 
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
        public string bs_sh_out { get; set; }
        public string is_sh_for_diluted_eps { get; set; }
        public string is_avg_num_sh_for_eps { get; set; }
        public string revenue_per_sh { get; set; }
        public string ebitda_per_sh { get; set; }
        public string oper_inc_per_sh { get; set; }
        public string eps { get; set; }
        public string eps_cont_ops { get; set; }
        public string diluted_eps { get; set; }
        public string dil_eps_cont_ops { get; set; }
        public string div_per_shr { get; set; }
        public string cash_flow_per_sh { get; set; }
        public string free_cash_flow_per_sh { get; set; }
        public string cash_st_investments_per_sh { get; set; }
        public string book_val_per_sh { get; set; }
        public string tang_book_val_per_sh { get; set; }
    }
}
