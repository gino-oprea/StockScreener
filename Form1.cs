using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using BL.ModelsUI;

namespace StockScreener
{
    public partial class Form1 : Form
    {

        Company company;

        CompanyFilter companyFilter;        

        BindingSource bindingSourceKeyValues;
        BindingSource bindingSourceIntrinsicValues;

        List<Company> filteredCompanies;
        BindingSource bindingSourcefilteredCompanies;
        
        bool isSearchInProgress = false;
        
        CompaniesScreener companyScreener;
        

        public Form1()
        {
            InitializeComponent();

            cbFilterValue.SelectedIndex = 2;

            companyScreener = new CompaniesScreener();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            lblErrorMessage.Text = "";

            if (txtTicker.Text.Trim() != "")
            {
                pbLoading.Visible = true;
                bgwCheckCompany.RunWorkerAsync();
            }
        }

        private DataTable BuildIntriniscValuesDataTable(List<decimal> values)
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("Intrinsic Value");
            dt.Columns.Add("Intrinsic Value (-30%)");
            dt.Columns.Add("Intrinsic Value (-50%)");            

            DataRow dr = dt.NewRow();
            dr[0] = String.Format("{0:0.00}", values[0]);
            dr[1] = String.Format("{0:0.00}", values[2]);
            dr[2] = String.Format("{0:0.00}", values[3]);
            dt.Rows.Add(dr);

            return dt;
        }

        private DataTable BuildDataTable()
        {
            DataTable dt = new DataTable();

            if (company?.Financials!= null)
            {
                dt.Columns.Add("Item");
                for (int i = 0; i < company.Financials.NetIncome.Count; i++)
                {
                    dt.Columns.Add(company.Financials.NetIncome[i].Year.ToString());
                }

                AddRow("Revenue", company.Financials.Revenue, dt);
                AddRow("Equity", company.Financials.Equity, dt);
                AddRow("EPS", company.Financials.EPS, dt);
                AddRow("FCF per Share", company.Financials.FCFperShare, dt);
                AddRow("Net Income", company.Financials.NetIncome, dt);
                AddRow("Operating Margin %", company.Financials.OperatingMargin, dt);
                AddRow("ROIC %", company.Financials.ROIC, dt);
                AddRow("Retained earnings", company.Financials.RetainedEarnings, dt);
                AddRow("Free Cash Flow", company.Financials.FreeCashFlow, dt);
                AddRow("Capital Expenditures", company.Financials.CapitalExpenditures, dt);
                AddRow("Short Term Debt", company.Financials.ShortTermDebt, dt);
                AddRow("Long Term Debt", company.Financials.LongTermDebt, dt);
                AddRow("Cash and Equivalents", company.Financials.Cash, dt);
                AddRow("Shares Outstanding", company.Financials.Shares, dt);                
            }
            return dt;
        }

        private void AddRow(string item, List<YearVal> values, DataTable dt)
        {
            if (values!=null && values.Count > 0)
            {
                DataRow dr = dt.NewRow();
                dr[0] = item;
                for (int i = 0; i < values.Count; i++)
                {
                    for (int j = 1; j < dt.Columns.Count; j++)
                    {
                        if (dt.Columns[j].ColumnName.Trim() == values[i].Year.ToString())
                            dr[j] = String.Format("{0:0.00}", values[i].Value) + (values[i].Growth != null ? "   (" + String.Format("{0:0.0}", values[i].Growth) + "%)" : "");
                    }                    
                }
                dt.Rows.Add(dr);
            }
        }

        private void btnCalculateIntrinsicValue_Click(object sender, EventArgs e)
        {
            var values = company.CalculateIntrinsicAndDiscountedValues(Convert.ToDecimal(txtLastFreeCashFlow.Text), Convert.ToInt32(txtDiscountInterestRate.Text),
                Convert.ToDecimal(txtGrowth.Text),
                decimal.Parse(txtSharesOutstanding.Text), Convert.ToInt32(txtTerminalMultiple.Text));


            DataTable dtIntrinsicValues = BuildIntriniscValuesDataTable(values);
            BindingSource bindingSourceIntrinsicValues = new BindingSource();
            bindingSourceIntrinsicValues.DataSource = dtIntrinsicValues;
            gvIntrinsicVal.DataSource = bindingSourceIntrinsicValues;
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
                gvCompanies.DataSource = null;
                gvCompanies.Rows.Clear();

                lblErrorMessage.Text = "";
                lblTickerInProcess.Text = "";
                lblProgress.Text = "";
                
                companyFilter = GetFilter();

                try
                {
                    tmrTicker.Start();
                    tmrCompanies.Start();
                    pbLoadingCompanies.Visible = true;
                    isSearchInProgress = true;
                    bgwSearchCompanies.RunWorkerAsync();
                }
                catch(Exception ex)
                {
                    lblErrorMessage.Text = ex.Message;
                }
            
        }
        private void btnStop_Click(object sender, EventArgs e)
        {
            bgwSearchCompanies.CancelAsync();            
        }

        private CompanyFilter GetFilter()
        {
            CompanyFilter filter = new CompanyFilter();

            filter.PriceFilter = (PriceFilter)cbFilterValue.SelectedIndex;

            filter.DiscountRate = Convert.ToInt32(txtFilterRateOfReturn.Text);

            filter.MinAvgRevenueGrowth = Convert.ToInt32(txtFilterAvgRevGrowth.Text);
            filter.MinAvgEqGrowth = Convert.ToInt32(txtFilterAvgEqGrowth.Text);
            filter.MinAvgEPSGrowth = Convert.ToInt32(txtFilterAvgEPSGrowth.Text);
            filter.MinAvgFreeCashFlowGrowth = Convert.ToInt32(txtFilterAvgFcfGrowth.Text);
            filter.MinAvgROIC = Convert.ToInt32(txtFilterAvgROIC.Text);

            return filter;
        }

        private DataTable BuildFilteredCompaniesDataTable(List<Company> companies)
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("Ticker");
            dt.Columns.Add("Name");
            dt.Columns.Add("P/E");
            dt.Columns.Add("Price");

            dt.Columns.Add("Intrinsic Value");
            //dt.Columns.Add("Intrinsic Value (-30%)");
            dt.Columns.Add("Intrinsic Value (-50%)");
            dt.Columns.Add("Price-Value Delta %");

            dt.Columns.Add("ROIC %");
            dt.Columns.Add("Growth %");

            dt.Columns.Add("Terminal Multiple FCF");

            foreach (var company in companies)
            {
                DataRow dr = dt.NewRow();

                dr[0] = company.Ticker;
                dr[1] = company.Name;
                dr[2] = String.Format("{0:0.00}", company.PE_Ratio);
                dr[3] = String.Format("{0:0.00}", company.CurrentPrice);

                dr[4] = String.Format("{0:0.00}", company.IntrinsicValue);
                //dr[5] = String.Format("{0:0.00}", company.IntrinsicValue_Discounted30);
                dr[5] = String.Format("{0:0.00}", company.IntrinsicValue_Discounted50);

                dr[6] = String.Format("{0:0.00}", ((decimal)company.CurrentPrice/company.IntrinsicValue - 1) * 100);

                dr[7] = String.Format("{0:0.00}", company.AverageROIC);
                dr[8] = String.Format("{0:0.00}", company.Growth);
                dr[9] = String.Format("{0:0}", company.Average_P_FCF_Multiple);
                dt.Rows.Add(dr);
            }           

            return dt;
        }

        private void bgwCheckCompany_DoWork(object sender, DoWorkEventArgs e)
        {
            CompanyDataAggregator companiesDataAggregator =new CompanyDataAggregator();
            company = companiesDataAggregator.GetCompany(txtTicker.Text.Trim());
            if (company == null)
                throw new Exception("Company has no data or error occured!");            

            DataTable dt = BuildDataTable();
            bindingSourceKeyValues = new BindingSource();
            bindingSourceKeyValues.DataSource = dt;

            int discount;
            bool converted = int.TryParse(txtDiscountInterestRate.Text.Trim(), out discount);
            if (!converted)
                discount = 10;
            
            DataTable dtIntrinsicValues = BuildIntriniscValuesDataTable(new List<decimal> {
                company.IntrinsicValue.Value,
                company.IntrinsicValue_Discounted10.Value,
                company.IntrinsicValue_Discounted30.Value,
                company.IntrinsicValue_Discounted50.Value });//BuildIntriniscValuesDataTable(values);

            bindingSourceIntrinsicValues = new BindingSource();
            bindingSourceIntrinsicValues.DataSource = dtIntrinsicValues;
        }

        private void bgwCheckCompany_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                lblErrorMessage.Text = e.Error.ToString();
            }
            else
            {
                try
                {
                    lblCompanyName.Text = company.Name;
                    txtSharesOutstanding.Text = String.Format("{0:0.000}", company.SharesOutstanding);
                    lblCurrentSharePrice.Text = String.Format("{0:0.00}", company.CurrentPrice);                    
                    lblMarketCap.Text = String.Format("{0:0.000}", company.MarketCap);                    

                    txtAvgRevenueGrowth.Text = String.Format("{0:0.00}", company.AverageRevenueGrowth);

                    txtAvgEquityGrowth.Text = String.Format("{0:0.00}", company.AverageEquityGrowth);
                    txtGrowth.Text = String.Format("{0:0.00}", company.Growth);

                    txtAvgEPSGrowth.Text = String.Format("{0:0.00}", company.AverageEPSGrowth);
                    txtAvgFcfPerShareGrowth.Text = String.Format("{0:0.00}", company.AverageFCFperShareGrowth);
                    txtAvgNetIncomeGrowth.Text = String.Format("{0:0.00}", company.AverageNetIncomeGrowth);
                    txtAvgOperatingMarginGrowth.Text = String.Format("{0:0.00}", company.AverageOperatingMarginGrowth);
                    txtAvgFreeCashFlowGrowth.Text = String.Format("{0:0.00}", company.AverageFreeCashFlowGrowth);
                    
                    txtAvgROIC.Text = String.Format("{0:0.00}", company.AverageROIC);
                    txtTerminalMultiple.Text = company.Average_P_FCF_Multiple.ToString();

                    var avgCf = company.Financials.FreeCashFlow.Skip(company.Financials.FreeCashFlow.Count() - 3).Select(c => c.Value).Average(); //media ultimilor 3 ani                    

                    if (avgCf > 0)
                        txtLastFreeCashFlow.Text = String.Format("{0:0.00}", (decimal)avgCf);
                    else
                    {
                        var lastCf = company.Financials.FreeCashFlow.FindLast(c => c.Value > 0);
                        if (lastCf != null)
                            txtLastFreeCashFlow.Text = String.Format("{0:0.00}", (decimal)lastCf.Value);
                        else
                            throw new Exception("No positive cashflow found!");
                    }

                    gvFinancials.DataSource = bindingSourceKeyValues;
                    foreach (DataGridViewColumn col in gvFinancials.Columns)
                    {
                        col.DisplayIndex = col.Index;
                    }

                    gvIntrinsicVal.DataSource = bindingSourceIntrinsicValues;
                    foreach (DataGridViewColumn col in gvIntrinsicVal.Columns)
                    {
                        col.DisplayIndex = col.Index;
                    }

                }
                catch (Exception ex)
                {
                    lblErrorMessage.Text = ex.Message;
                }
            }
            pbLoading.Visible = false;
        }       

        private void bgwSearchCompanies_DoWork(object sender, DoWorkEventArgs e)
        {           
            filteredCompanies = companyScreener.GetFilteredCompanies(companyFilter, bgwSearchCompanies);

            DataTable dtFilteredCompanies = BuildFilteredCompaniesDataTable(filteredCompanies);
            bindingSourcefilteredCompanies = new BindingSource();
            bindingSourcefilteredCompanies.DataSource = dtFilteredCompanies;

            if (bgwSearchCompanies.CancellationPending)
                e.Cancel = true;
        }

        private void bgwSearchCompanies_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                lblErrorMessage.Text = e.Error.ToString();
            }
            if (e.Cancelled)
            {
                lblTickerInProcess.Text = "";
                lblProgress.Text = "";
                lblErrorMessage.Text = "Cancelled";
            }
            else
            {
                try
                {
                    gvCompanies.DataSource = bindingSourcefilteredCompanies;
                    foreach (DataGridViewColumn col in gvCompanies.Columns)
                    {
                        col.DisplayIndex = col.Index;
                    }
                    gvCompanies.FirstDisplayedScrollingRowIndex = gvCompanies.RowCount - 1;
                }
                catch (Exception ex)
                {
                    lblErrorMessage.Text = ex.Message;
                }
            }

            tmrTicker.Stop();
            tmrCompanies.Stop();
            isSearchInProgress = false;
            pbLoadingCompanies.Visible = false;
            lblTickerInProcess.Text = "";
            lblProgress.Text = "";
        }

        private void tmrCompanies_Tick(object sender, EventArgs e)
        {
            if(isSearchInProgress)
            {
                if (companyScreener.currentfilteredCompanies != null && companyScreener.currentfilteredCompanies.Count > 0)
                {
                    DataTable dtFilteredCompanies = BuildFilteredCompaniesDataTable(companyScreener.currentfilteredCompanies);
                    bindingSourcefilteredCompanies = new BindingSource();
                    bindingSourcefilteredCompanies.DataSource = dtFilteredCompanies;

                    gvCompanies.DataSource = bindingSourcefilteredCompanies;
                    foreach (DataGridViewColumn col in gvCompanies.Columns)
                    {
                        col.DisplayIndex = col.Index;
                    }
                    gvCompanies.FirstDisplayedScrollingRowIndex = gvCompanies.RowCount - 1;
                }
            }
        }

        private void tmrTicker_Tick(object sender, EventArgs e)
        {
            if (isSearchInProgress)
            {
                lblTickerInProcess.Text = companyScreener.currentTicker;
                lblProgress.Text = companyScreener.progress;
            }
        }       

        private void bgwGetCache_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                lblErrorMessage.Text = e.Error.ToString();
            }
            if (e.Cancelled)
            {
                lblTickerInProcess.Text = "";
                lblProgress.Text = "";
                lblErrorMessage.Text = "Cancelled";
            }           

            tmrTicker.Stop();            
            pbLoadingCompanies.Visible = false;
            isSearchInProgress = false;
            lblTickerInProcess.Text = "";
            lblProgress.Text = "";
        }        
    }
}
