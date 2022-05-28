
namespace StockScreener
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabCheckCompany = new System.Windows.Forms.TabPage();
            this.label31 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.txtTerminalMultiple = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.lblMarketCap = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.txtAvgROIC = new System.Windows.Forms.TextBox();
            this.label30 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.txtGrowth = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txtLastFreeCashFlow = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.txtDiscountInterestRate = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.gvIntrinsicVal = new System.Windows.Forms.DataGridView();
            this.btnCalculateIntrinsicValue = new System.Windows.Forms.Button();
            this.lblCurrentSharePrice = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtAvgFreeCashFlowGrowth = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtAvgNetIncomeGrowth = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtAvgEPSGrowth = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtAvgRevenueGrowth = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSharesOutstanding = new System.Windows.Forms.TextBox();
            this.txtAvgEquityGrowth = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblCompanyName = new System.Windows.Forms.Label();
            this.pbLoading = new System.Windows.Forms.PictureBox();
            this.gvFinancials = new System.Windows.Forms.DataGridView();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTicker = new System.Windows.Forms.TextBox();
            this.tabSearchCompanies = new System.Windows.Forms.TabPage();
            this.btnGetAllCompaniesInCache = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbCacheSearch = new System.Windows.Forms.RadioButton();
            this.rbFreshSearch = new System.Windows.Forms.RadioButton();
            this.chkIgnoreADR = new System.Windows.Forms.CheckBox();
            this.txtFilterAvgROIC = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.lblProgress = new System.Windows.Forms.Label();
            this.cbFilterValue = new System.Windows.Forms.ComboBox();
            this.btnStop = new System.Windows.Forms.Button();
            this.txtFilterRateOfReturn = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.txtFilterAvgFcfGrowth = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.txtFilterAvgEPSGrowth = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.txtFilterAvgRevGrowth = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.txtFilterAvgEqGrowth = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.lblTickerInProcess = new System.Windows.Forms.Label();
            this.pbLoadingCompanies = new System.Windows.Forms.PictureBox();
            this.gvCompanies = new System.Windows.Forms.DataGridView();
            this.btnGo = new System.Windows.Forms.Button();
            this.txtURL = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.lblErrorMessage = new System.Windows.Forms.Label();
            this.bgwCheckCompany = new System.ComponentModel.BackgroundWorker();
            this.bgwSearchCompanies = new System.ComponentModel.BackgroundWorker();
            this.tmrCompanies = new System.Windows.Forms.Timer(this.components);
            this.tmrTicker = new System.Windows.Forms.Timer(this.components);
            this.bgwGetCache = new System.ComponentModel.BackgroundWorker();
            this.tabControl1.SuspendLayout();
            this.tabCheckCompany.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvIntrinsicVal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLoading)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvFinancials)).BeginInit();
            this.tabSearchCompanies.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLoadingCompanies)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCompanies)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabCheckCompany);
            this.tabControl1.Controls.Add(this.tabSearchCompanies);
            this.tabControl1.Location = new System.Drawing.Point(4, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1196, 771);
            this.tabControl1.TabIndex = 0;
            // 
            // tabCheckCompany
            // 
            this.tabCheckCompany.Controls.Add(this.label31);
            this.tabCheckCompany.Controls.Add(this.label33);
            this.tabCheckCompany.Controls.Add(this.txtTerminalMultiple);
            this.tabCheckCompany.Controls.Add(this.label26);
            this.tabCheckCompany.Controls.Add(this.lblMarketCap);
            this.tabCheckCompany.Controls.Add(this.label27);
            this.tabCheckCompany.Controls.Add(this.label29);
            this.tabCheckCompany.Controls.Add(this.txtAvgROIC);
            this.tabCheckCompany.Controls.Add(this.label30);
            this.tabCheckCompany.Controls.Add(this.label19);
            this.tabCheckCompany.Controls.Add(this.txtGrowth);
            this.tabCheckCompany.Controls.Add(this.label18);
            this.tabCheckCompany.Controls.Add(this.txtLastFreeCashFlow);
            this.tabCheckCompany.Controls.Add(this.label17);
            this.tabCheckCompany.Controls.Add(this.label16);
            this.tabCheckCompany.Controls.Add(this.txtDiscountInterestRate);
            this.tabCheckCompany.Controls.Add(this.label15);
            this.tabCheckCompany.Controls.Add(this.label14);
            this.tabCheckCompany.Controls.Add(this.gvIntrinsicVal);
            this.tabCheckCompany.Controls.Add(this.btnCalculateIntrinsicValue);
            this.tabCheckCompany.Controls.Add(this.lblCurrentSharePrice);
            this.tabCheckCompany.Controls.Add(this.label13);
            this.tabCheckCompany.Controls.Add(this.label12);
            this.tabCheckCompany.Controls.Add(this.label11);
            this.tabCheckCompany.Controls.Add(this.label10);
            this.tabCheckCompany.Controls.Add(this.label9);
            this.tabCheckCompany.Controls.Add(this.label8);
            this.tabCheckCompany.Controls.Add(this.txtAvgFreeCashFlowGrowth);
            this.tabCheckCompany.Controls.Add(this.label7);
            this.tabCheckCompany.Controls.Add(this.txtAvgNetIncomeGrowth);
            this.tabCheckCompany.Controls.Add(this.label6);
            this.tabCheckCompany.Controls.Add(this.txtAvgEPSGrowth);
            this.tabCheckCompany.Controls.Add(this.label5);
            this.tabCheckCompany.Controls.Add(this.txtAvgRevenueGrowth);
            this.tabCheckCompany.Controls.Add(this.label4);
            this.tabCheckCompany.Controls.Add(this.label3);
            this.tabCheckCompany.Controls.Add(this.txtSharesOutstanding);
            this.tabCheckCompany.Controls.Add(this.txtAvgEquityGrowth);
            this.tabCheckCompany.Controls.Add(this.label2);
            this.tabCheckCompany.Controls.Add(this.lblCompanyName);
            this.tabCheckCompany.Controls.Add(this.pbLoading);
            this.tabCheckCompany.Controls.Add(this.gvFinancials);
            this.tabCheckCompany.Controls.Add(this.btnSearch);
            this.tabCheckCompany.Controls.Add(this.label1);
            this.tabCheckCompany.Controls.Add(this.txtTicker);
            this.tabCheckCompany.Location = new System.Drawing.Point(4, 29);
            this.tabCheckCompany.Name = "tabCheckCompany";
            this.tabCheckCompany.Padding = new System.Windows.Forms.Padding(3);
            this.tabCheckCompany.Size = new System.Drawing.Size(1188, 738);
            this.tabCheckCompany.TabIndex = 0;
            this.tabCheckCompany.Text = "Check Company";
            this.tabCheckCompany.UseVisualStyleBackColor = true;
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(804, 659);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(139, 20);
            this.label31.TabIndex = 50;
            this.label31.Text = "last 3 years average";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label33.Location = new System.Drawing.Point(594, 358);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(0, 23);
            this.label33.TabIndex = 49;
            // 
            // txtTerminalMultiple
            // 
            this.txtTerminalMultiple.Location = new System.Drawing.Point(732, 689);
            this.txtTerminalMultiple.Name = "txtTerminalMultiple";
            this.txtTerminalMultiple.Size = new System.Drawing.Size(65, 27);
            this.txtTerminalMultiple.TabIndex = 45;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(595, 693);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(125, 20);
            this.label26.TabIndex = 44;
            this.label26.Text = "Terminal Multiple";
            // 
            // lblMarketCap
            // 
            this.lblMarketCap.AutoSize = true;
            this.lblMarketCap.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblMarketCap.Location = new System.Drawing.Point(1029, 57);
            this.lblMarketCap.Name = "lblMarketCap";
            this.lblMarketCap.Size = new System.Drawing.Size(0, 23);
            this.lblMarketCap.TabIndex = 43;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label27.Location = new System.Drawing.Point(886, 57);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(137, 23);
            this.label27.TabIndex = 42;
            this.label27.Text = "Market Cap (B):";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(267, 663);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(21, 20);
            this.label29.TabIndex = 41;
            this.label29.Text = "%";
            // 
            // txtAvgROIC
            // 
            this.txtAvgROIC.Location = new System.Drawing.Point(196, 660);
            this.txtAvgROIC.Name = "txtAvgROIC";
            this.txtAvgROIC.Size = new System.Drawing.Size(65, 27);
            this.txtAvgROIC.TabIndex = 40;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(117, 663);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(72, 20);
            this.label30.TabIndex = 39;
            this.label30.Text = "Avg ROIC";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(803, 626);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(21, 20);
            this.label19.TabIndex = 35;
            this.label19.Text = "%";
            // 
            // txtGrowth
            // 
            this.txtGrowth.Location = new System.Drawing.Point(732, 623);
            this.txtGrowth.Name = "txtGrowth";
            this.txtGrowth.Size = new System.Drawing.Size(65, 27);
            this.txtGrowth.TabIndex = 34;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(663, 626);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(57, 20);
            this.label18.TabIndex = 33;
            this.label18.Text = "Growth";
            // 
            // txtLastFreeCashFlow
            // 
            this.txtLastFreeCashFlow.Location = new System.Drawing.Point(732, 656);
            this.txtLastFreeCashFlow.Name = "txtLastFreeCashFlow";
            this.txtLastFreeCashFlow.Size = new System.Drawing.Size(65, 27);
            this.txtLastFreeCashFlow.TabIndex = 32;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(560, 659);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(160, 20);
            this.label17.TabIndex = 31;
            this.label17.Text = "Avg Free Cash Flow (B)";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(803, 592);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(21, 20);
            this.label16.TabIndex = 30;
            this.label16.Text = "%";
            // 
            // txtDiscountInterestRate
            // 
            this.txtDiscountInterestRate.Location = new System.Drawing.Point(732, 590);
            this.txtDiscountInterestRate.Name = "txtDiscountInterestRate";
            this.txtDiscountInterestRate.Size = new System.Drawing.Size(65, 27);
            this.txtDiscountInterestRate.TabIndex = 29;
            this.txtDiscountInterestRate.Text = "12";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(566, 593);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(154, 20);
            this.label15.TabIndex = 28;
            this.label15.Text = "Discount Interest Rate";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label14.Location = new System.Drawing.Point(569, 470);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(159, 30);
            this.label14.TabIndex = 27;
            this.label14.Text = "Intrinsic Value";
            // 
            // gvIntrinsicVal
            // 
            this.gvIntrinsicVal.AllowUserToAddRows = false;
            this.gvIntrinsicVal.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gvIntrinsicVal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvIntrinsicVal.Location = new System.Drawing.Point(569, 503);
            this.gvIntrinsicVal.Name = "gvIntrinsicVal";
            this.gvIntrinsicVal.RowHeadersWidth = 51;
            this.gvIntrinsicVal.RowTemplate.Height = 29;
            this.gvIntrinsicVal.Size = new System.Drawing.Size(528, 79);
            this.gvIntrinsicVal.TabIndex = 26;
            // 
            // btnCalculateIntrinsicValue
            // 
            this.btnCalculateIntrinsicValue.Location = new System.Drawing.Point(854, 588);
            this.btnCalculateIntrinsicValue.Name = "btnCalculateIntrinsicValue";
            this.btnCalculateIntrinsicValue.Size = new System.Drawing.Size(243, 29);
            this.btnCalculateIntrinsicValue.TabIndex = 25;
            this.btnCalculateIntrinsicValue.Text = "Calculate Intrinsic Value";
            this.btnCalculateIntrinsicValue.UseVisualStyleBackColor = true;
            this.btnCalculateIntrinsicValue.Click += new System.EventHandler(this.btnCalculateIntrinsicValue_Click);
            // 
            // lblCurrentSharePrice
            // 
            this.lblCurrentSharePrice.AutoSize = true;
            this.lblCurrentSharePrice.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblCurrentSharePrice.Location = new System.Drawing.Point(1029, 80);
            this.lblCurrentSharePrice.Name = "lblCurrentSharePrice";
            this.lblCurrentSharePrice.Size = new System.Drawing.Size(0, 23);
            this.lblCurrentSharePrice.TabIndex = 24;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label13.Location = new System.Drawing.Point(855, 80);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(168, 23);
            this.label13.TabIndex = 23;
            this.label13.Text = "Current share price:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(267, 630);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(21, 20);
            this.label12.TabIndex = 22;
            this.label12.Text = "%";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(267, 597);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(21, 20);
            this.label11.TabIndex = 21;
            this.label11.Text = "%";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(267, 564);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(21, 20);
            this.label10.TabIndex = 20;
            this.label10.Text = "%";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(267, 531);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(21, 20);
            this.label9.TabIndex = 19;
            this.label9.Text = "%";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(267, 498);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(21, 20);
            this.label8.TabIndex = 18;
            this.label8.Text = "%";
            // 
            // txtAvgFreeCashFlowGrowth
            // 
            this.txtAvgFreeCashFlowGrowth.Location = new System.Drawing.Point(196, 627);
            this.txtAvgFreeCashFlowGrowth.Name = "txtAvgFreeCashFlowGrowth";
            this.txtAvgFreeCashFlowGrowth.Size = new System.Drawing.Size(65, 27);
            this.txtAvgFreeCashFlowGrowth.TabIndex = 17;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(30, 630);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(154, 20);
            this.label7.TabIndex = 16;
            this.label7.Text = "Avg Free Cash Growth";
            // 
            // txtAvgNetIncomeGrowth
            // 
            this.txtAvgNetIncomeGrowth.Location = new System.Drawing.Point(196, 594);
            this.txtAvgNetIncomeGrowth.Name = "txtAvgNetIncomeGrowth";
            this.txtAvgNetIncomeGrowth.Size = new System.Drawing.Size(65, 27);
            this.txtAvgNetIncomeGrowth.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 597);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(168, 20);
            this.label6.TabIndex = 14;
            this.label6.Text = "Avg Net Income Growth";
            // 
            // txtAvgEPSGrowth
            // 
            this.txtAvgEPSGrowth.Location = new System.Drawing.Point(196, 561);
            this.txtAvgEPSGrowth.Name = "txtAvgEPSGrowth";
            this.txtAvgEPSGrowth.Size = new System.Drawing.Size(65, 27);
            this.txtAvgEPSGrowth.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(69, 564);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(115, 20);
            this.label5.TabIndex = 12;
            this.label5.Text = "Avg EPS Growth";
            // 
            // txtAvgRevenueGrowth
            // 
            this.txtAvgRevenueGrowth.Location = new System.Drawing.Point(196, 528);
            this.txtAvgRevenueGrowth.Name = "txtAvgRevenueGrowth";
            this.txtAvgRevenueGrowth.Size = new System.Drawing.Size(65, 27);
            this.txtAvgRevenueGrowth.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(37, 531);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(147, 20);
            this.label4.TabIndex = 10;
            this.label4.Text = "Avg Revenue Growth";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(661, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(160, 20);
            this.label3.TabIndex = 9;
            this.label3.Text = "Shares Outstanding (B)";
            // 
            // txtSharesOutstanding
            // 
            this.txtSharesOutstanding.Location = new System.Drawing.Point(827, 12);
            this.txtSharesOutstanding.Name = "txtSharesOutstanding";
            this.txtSharesOutstanding.Size = new System.Drawing.Size(196, 27);
            this.txtSharesOutstanding.TabIndex = 8;
            // 
            // txtAvgEquityGrowth
            // 
            this.txtAvgEquityGrowth.Location = new System.Drawing.Point(196, 495);
            this.txtAvgEquityGrowth.Name = "txtAvgEquityGrowth";
            this.txtAvgEquityGrowth.Size = new System.Drawing.Size(65, 27);
            this.txtAvgEquityGrowth.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(52, 498);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Avg Equity Growth";
            // 
            // lblCompanyName
            // 
            this.lblCompanyName.AutoSize = true;
            this.lblCompanyName.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblCompanyName.Location = new System.Drawing.Point(32, 71);
            this.lblCompanyName.Name = "lblCompanyName";
            this.lblCompanyName.Size = new System.Drawing.Size(0, 25);
            this.lblCompanyName.TabIndex = 5;
            this.lblCompanyName.UseMnemonic = false;
            // 
            // pbLoading
            // 
            this.pbLoading.Image = ((System.Drawing.Image)(resources.GetObject("pbLoading.Image")));
            this.pbLoading.Location = new System.Drawing.Point(469, 23);
            this.pbLoading.Name = "pbLoading";
            this.pbLoading.Size = new System.Drawing.Size(22, 20);
            this.pbLoading.TabIndex = 4;
            this.pbLoading.TabStop = false;
            this.pbLoading.Visible = false;
            // 
            // gvFinancials
            // 
            this.gvFinancials.AllowUserToAddRows = false;
            this.gvFinancials.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gvFinancials.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvFinancials.Location = new System.Drawing.Point(4, 106);
            this.gvFinancials.Name = "gvFinancials";
            this.gvFinancials.RowHeadersWidth = 51;
            this.gvFinancials.RowTemplate.Height = 29;
            this.gvFinancials.Size = new System.Drawing.Size(1177, 353);
            this.gvFinancials.TabIndex = 3;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(351, 19);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(112, 29);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Company Ticker:";
            // 
            // txtTicker
            // 
            this.txtTicker.Location = new System.Drawing.Point(147, 21);
            this.txtTicker.Name = "txtTicker";
            this.txtTicker.Size = new System.Drawing.Size(198, 27);
            this.txtTicker.TabIndex = 0;
            // 
            // tabSearchCompanies
            // 
            this.tabSearchCompanies.Controls.Add(this.btnGetAllCompaniesInCache);
            this.tabSearchCompanies.Controls.Add(this.groupBox1);
            this.tabSearchCompanies.Controls.Add(this.chkIgnoreADR);
            this.tabSearchCompanies.Controls.Add(this.txtFilterAvgROIC);
            this.tabSearchCompanies.Controls.Add(this.label28);
            this.tabSearchCompanies.Controls.Add(this.lblProgress);
            this.tabSearchCompanies.Controls.Add(this.cbFilterValue);
            this.tabSearchCompanies.Controls.Add(this.btnStop);
            this.tabSearchCompanies.Controls.Add(this.txtFilterRateOfReturn);
            this.tabSearchCompanies.Controls.Add(this.label25);
            this.tabSearchCompanies.Controls.Add(this.txtFilterAvgFcfGrowth);
            this.tabSearchCompanies.Controls.Add(this.label24);
            this.tabSearchCompanies.Controls.Add(this.txtFilterAvgEPSGrowth);
            this.tabSearchCompanies.Controls.Add(this.label23);
            this.tabSearchCompanies.Controls.Add(this.txtFilterAvgRevGrowth);
            this.tabSearchCompanies.Controls.Add(this.label22);
            this.tabSearchCompanies.Controls.Add(this.txtFilterAvgEqGrowth);
            this.tabSearchCompanies.Controls.Add(this.label21);
            this.tabSearchCompanies.Controls.Add(this.lblTickerInProcess);
            this.tabSearchCompanies.Controls.Add(this.pbLoadingCompanies);
            this.tabSearchCompanies.Controls.Add(this.gvCompanies);
            this.tabSearchCompanies.Controls.Add(this.btnGo);
            this.tabSearchCompanies.Controls.Add(this.txtURL);
            this.tabSearchCompanies.Controls.Add(this.label20);
            this.tabSearchCompanies.Location = new System.Drawing.Point(4, 29);
            this.tabSearchCompanies.Name = "tabSearchCompanies";
            this.tabSearchCompanies.Padding = new System.Windows.Forms.Padding(3);
            this.tabSearchCompanies.Size = new System.Drawing.Size(1188, 738);
            this.tabSearchCompanies.TabIndex = 1;
            this.tabSearchCompanies.Text = "Search Companies";
            this.tabSearchCompanies.UseVisualStyleBackColor = true;
            // 
            // btnGetAllCompaniesInCache
            // 
            this.btnGetAllCompaniesInCache.Location = new System.Drawing.Point(1019, 86);
            this.btnGetAllCompaniesInCache.Name = "btnGetAllCompaniesInCache";
            this.btnGetAllCompaniesInCache.Size = new System.Drawing.Size(151, 66);
            this.btnGetAllCompaniesInCache.TabIndex = 26;
            this.btnGetAllCompaniesInCache.Text = "Get all companies in cache";
            this.btnGetAllCompaniesInCache.UseVisualStyleBackColor = true;
            this.btnGetAllCompaniesInCache.Click += new System.EventHandler(this.btnGetAllCompaniesInCache_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbCacheSearch);
            this.groupBox1.Controls.Add(this.rbFreshSearch);
            this.groupBox1.Location = new System.Drawing.Point(1019, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(151, 65);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            // 
            // rbCacheSearch
            // 
            this.rbCacheSearch.AutoSize = true;
            this.rbCacheSearch.Checked = true;
            this.rbCacheSearch.Location = new System.Drawing.Point(7, 35);
            this.rbCacheSearch.Name = "rbCacheSearch";
            this.rbCacheSearch.Size = new System.Drawing.Size(116, 24);
            this.rbCacheSearch.TabIndex = 1;
            this.rbCacheSearch.TabStop = true;
            this.rbCacheSearch.Text = "Cache search";
            this.rbCacheSearch.UseVisualStyleBackColor = true;
            // 
            // rbFreshSearch
            // 
            this.rbFreshSearch.AutoSize = true;
            this.rbFreshSearch.Location = new System.Drawing.Point(7, 13);
            this.rbFreshSearch.Name = "rbFreshSearch";
            this.rbFreshSearch.Size = new System.Drawing.Size(110, 24);
            this.rbFreshSearch.TabIndex = 0;
            this.rbFreshSearch.Text = "Fresh search";
            this.rbFreshSearch.UseVisualStyleBackColor = true;
            // 
            // chkIgnoreADR
            // 
            this.chkIgnoreADR.AutoSize = true;
            this.chkIgnoreADR.Checked = true;
            this.chkIgnoreADR.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIgnoreADR.Location = new System.Drawing.Point(657, 71);
            this.chkIgnoreADR.Name = "chkIgnoreADR";
            this.chkIgnoreADR.Size = new System.Drawing.Size(184, 24);
            this.chkIgnoreADR.TabIndex = 24;
            this.chkIgnoreADR.Text = "Ignore ADR companies";
            this.chkIgnoreADR.UseVisualStyleBackColor = true;
            // 
            // txtFilterAvgROIC
            // 
            this.txtFilterAvgROIC.Location = new System.Drawing.Point(619, 113);
            this.txtFilterAvgROIC.Name = "txtFilterAvgROIC";
            this.txtFilterAvgROIC.Size = new System.Drawing.Size(32, 27);
            this.txtFilterAvgROIC.TabIndex = 22;
            this.txtFilterAvgROIC.Text = "10";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(488, 117);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(124, 20);
            this.label28.TabIndex = 21;
            this.label28.Text = "Min avg ROIC(%):";
            // 
            // lblProgress
            // 
            this.lblProgress.AutoSize = true;
            this.lblProgress.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblProgress.Location = new System.Drawing.Point(919, 67);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(70, 20);
            this.lblProgress.TabIndex = 20;
            this.lblProgress.Text = "Progress";
            // 
            // cbFilterValue
            // 
            this.cbFilterValue.FormattingEnabled = true;
            this.cbFilterValue.Items.AddRange(new object[] {
            "Intrinsic Value",
            "MOS 10%",
            "MOS 30%",
            "MOS 50%",
            "Premium 10%",
            "Premium 20%",
            "Unlimited"});
            this.cbFilterValue.Location = new System.Drawing.Point(657, 112);
            this.cbFilterValue.Name = "cbFilterValue";
            this.cbFilterValue.Size = new System.Drawing.Size(184, 28);
            this.cbFilterValue.TabIndex = 19;
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(847, 63);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(57, 29);
            this.btnStop.TabIndex = 18;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // txtFilterRateOfReturn
            // 
            this.txtFilterRateOfReturn.Location = new System.Drawing.Point(619, 72);
            this.txtFilterRateOfReturn.Name = "txtFilterRateOfReturn";
            this.txtFilterRateOfReturn.Size = new System.Drawing.Size(32, 27);
            this.txtFilterRateOfReturn.TabIndex = 15;
            this.txtFilterRateOfReturn.Text = "12";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(488, 75);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(125, 20);
            this.label25.TabIndex = 14;
            this.label25.Text = "Rate of return(%):";
            // 
            // txtFilterAvgFcfGrowth
            // 
            this.txtFilterAvgFcfGrowth.Location = new System.Drawing.Point(438, 114);
            this.txtFilterAvgFcfGrowth.Name = "txtFilterAvgFcfGrowth";
            this.txtFilterAvgFcfGrowth.Size = new System.Drawing.Size(34, 27);
            this.txtFilterAvgFcfGrowth.TabIndex = 13;
            this.txtFilterAvgFcfGrowth.Text = "0";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(266, 117);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(165, 20);
            this.label24.TabIndex = 12;
            this.label24.Text = "Min avg FCF growth(%):";
            // 
            // txtFilterAvgEPSGrowth
            // 
            this.txtFilterAvgEPSGrowth.Location = new System.Drawing.Point(438, 72);
            this.txtFilterAvgEPSGrowth.Name = "txtFilterAvgEPSGrowth";
            this.txtFilterAvgEPSGrowth.Size = new System.Drawing.Size(34, 27);
            this.txtFilterAvgEPSGrowth.TabIndex = 11;
            this.txtFilterAvgEPSGrowth.Text = "0";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(266, 75);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(166, 20);
            this.label23.TabIndex = 10;
            this.label23.Text = "Min avg EPS growth(%):";
            // 
            // txtFilterAvgRevGrowth
            // 
            this.txtFilterAvgRevGrowth.Location = new System.Drawing.Point(213, 114);
            this.txtFilterAvgRevGrowth.Name = "txtFilterAvgRevGrowth";
            this.txtFilterAvgRevGrowth.Size = new System.Drawing.Size(37, 27);
            this.txtFilterAvgRevGrowth.TabIndex = 9;
            this.txtFilterAvgRevGrowth.Text = "0";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(13, 116);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(194, 20);
            this.label22.TabIndex = 8;
            this.label22.Text = "Min avg revenue growth(%):";
            // 
            // txtFilterAvgEqGrowth
            // 
            this.txtFilterAvgEqGrowth.Location = new System.Drawing.Point(213, 72);
            this.txtFilterAvgEqGrowth.Name = "txtFilterAvgEqGrowth";
            this.txtFilterAvgEqGrowth.Size = new System.Drawing.Size(37, 27);
            this.txtFilterAvgEqGrowth.TabIndex = 7;
            this.txtFilterAvgEqGrowth.Text = "0";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(24, 75);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(183, 20);
            this.label21.TabIndex = 6;
            this.label21.Text = "Min avg equity growth(%):";
            // 
            // lblTickerInProcess
            // 
            this.lblTickerInProcess.AutoSize = true;
            this.lblTickerInProcess.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTickerInProcess.Location = new System.Drawing.Point(938, 30);
            this.lblTickerInProcess.Name = "lblTickerInProcess";
            this.lblTickerInProcess.Size = new System.Drawing.Size(51, 20);
            this.lblTickerInProcess.TabIndex = 5;
            this.lblTickerInProcess.Text = "Ticker";
            // 
            // pbLoadingCompanies
            // 
            this.pbLoadingCompanies.Image = ((System.Drawing.Image)(resources.GetObject("pbLoadingCompanies.Image")));
            this.pbLoadingCompanies.Location = new System.Drawing.Point(910, 30);
            this.pbLoadingCompanies.Name = "pbLoadingCompanies";
            this.pbLoadingCompanies.Size = new System.Drawing.Size(22, 20);
            this.pbLoadingCompanies.TabIndex = 4;
            this.pbLoadingCompanies.TabStop = false;
            this.pbLoadingCompanies.Visible = false;
            // 
            // gvCompanies
            // 
            this.gvCompanies.AllowUserToAddRows = false;
            this.gvCompanies.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gvCompanies.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvCompanies.Location = new System.Drawing.Point(6, 158);
            this.gvCompanies.Name = "gvCompanies";
            this.gvCompanies.RowHeadersWidth = 51;
            this.gvCompanies.Size = new System.Drawing.Size(1176, 570);
            this.gvCompanies.TabIndex = 3;
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(847, 27);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(57, 29);
            this.btnGo.TabIndex = 2;
            this.btnGo.Text = "Go";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // txtURL
            // 
            this.txtURL.Location = new System.Drawing.Point(70, 27);
            this.txtURL.Name = "txtURL";
            this.txtURL.Size = new System.Drawing.Size(771, 27);
            this.txtURL.TabIndex = 1;
            this.txtURL.Text = "https://finviz.com/screener.ashx?v=111&f=cap_smallover";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(16, 30);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(38, 20);
            this.label20.TabIndex = 0;
            this.label20.Text = "URL:";
            // 
            // lblErrorMessage
            // 
            this.lblErrorMessage.AutoSize = true;
            this.lblErrorMessage.ForeColor = System.Drawing.Color.Red;
            this.lblErrorMessage.Location = new System.Drawing.Point(12, 754);
            this.lblErrorMessage.Name = "lblErrorMessage";
            this.lblErrorMessage.Size = new System.Drawing.Size(0, 20);
            this.lblErrorMessage.TabIndex = 1;
            // 
            // bgwCheckCompany
            // 
            this.bgwCheckCompany.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwCheckCompany_DoWork);
            this.bgwCheckCompany.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwCheckCompany_RunWorkerCompleted);
            // 
            // bgwSearchCompanies
            // 
            this.bgwSearchCompanies.WorkerSupportsCancellation = true;
            this.bgwSearchCompanies.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwSearchCompanies_DoWork);
            this.bgwSearchCompanies.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwSearchCompanies_RunWorkerCompleted);
            // 
            // tmrCompanies
            // 
            this.tmrCompanies.Interval = 30000;
            this.tmrCompanies.Tick += new System.EventHandler(this.tmrCompanies_Tick);
            // 
            // tmrTicker
            // 
            this.tmrTicker.Interval = 500;
            this.tmrTicker.Tick += new System.EventHandler(this.tmrTicker_Tick);
            // 
            // bgwGetCache
            // 
            this.bgwGetCache.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwGetCache_DoWork);
            this.bgwGetCache.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwGetCache_RunWorkerCompleted);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1203, 781);
            this.Controls.Add(this.lblErrorMessage);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Stock Screener";
            this.tabControl1.ResumeLayout(false);
            this.tabCheckCompany.ResumeLayout(false);
            this.tabCheckCompany.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvIntrinsicVal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLoading)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvFinancials)).EndInit();
            this.tabSearchCompanies.ResumeLayout(false);
            this.tabSearchCompanies.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLoadingCompanies)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCompanies)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabCheckCompany;
        private System.Windows.Forms.DataGridView gvFinancials;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTicker;
        private System.Windows.Forms.TabPage tabSearchCompanies;
        private System.Windows.Forms.Label lblErrorMessage;
        private System.Windows.Forms.PictureBox pbLoading;
        private System.Windows.Forms.Label lblCompanyName;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtAvgFreeCashFlowGrowth;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtAvgNetIncomeGrowth;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtAvgEPSGrowth;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtAvgRevenueGrowth;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSharesOutstanding;
        private System.Windows.Forms.TextBox txtAvgEquityGrowth;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblCurrentSharePrice;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DataGridView gvIntrinsicVal;
        private System.Windows.Forms.Button btnCalculateIntrinsicValue;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtDiscountInterestRate;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtLastFreeCashFlow;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtGrowth;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.DataGridView gvCompanies;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.TextBox txtURL;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.PictureBox pbLoadingCompanies;
        private System.ComponentModel.BackgroundWorker bgwCheckCompany;
        private System.ComponentModel.BackgroundWorker bgwSearchCompanies;
        private System.Windows.Forms.Label lblTickerInProcess;
        private System.Windows.Forms.Timer tmrCompanies;
        private System.Windows.Forms.TextBox txtFilterRateOfReturn;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox txtFilterAvgFcfGrowth;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox txtFilterAvgEPSGrowth;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox txtFilterAvgRevGrowth;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox txtFilterAvgEqGrowth;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.ComboBox cbFilterValue;
        private System.Windows.Forms.Timer tmrTicker;
        private System.Windows.Forms.Label lblProgress;
        private System.Windows.Forms.TextBox txtFilterAvgROIC;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.TextBox txtAvgROIC;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label lblMarketCap;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.TextBox txtTerminalMultiple;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.CheckBox chkIgnoreADR;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbCacheSearch;
        private System.Windows.Forms.RadioButton rbFreshSearch;
        private System.Windows.Forms.Button btnGetAllCompaniesInCache;
        private System.ComponentModel.BackgroundWorker bgwGetCache;
        private System.Windows.Forms.Label label31;
    }
}

