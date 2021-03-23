
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
            this.tabControl1.SuspendLayout();
            this.tabCheckCompany.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvIntrinsicVal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLoading)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvFinancials)).BeginInit();
            this.tabSearchCompanies.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLoadingCompanies)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCompanies)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabCheckCompany);
            this.tabControl1.Controls.Add(this.tabSearchCompanies);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1059, 980);
            this.tabControl1.TabIndex = 0;
            // 
            // tabCheckCompany
            // 
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
            this.tabCheckCompany.Size = new System.Drawing.Size(1051, 947);
            this.tabCheckCompany.TabIndex = 0;
            this.tabCheckCompany.Text = "Check Company";
            this.tabCheckCompany.UseVisualStyleBackColor = true;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(956, 613);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(21, 20);
            this.label19.TabIndex = 35;
            this.label19.Text = "%";
            // 
            // txtGrowth
            // 
            this.txtGrowth.Location = new System.Drawing.Point(754, 610);
            this.txtGrowth.Name = "txtGrowth";
            this.txtGrowth.Size = new System.Drawing.Size(196, 27);
            this.txtGrowth.TabIndex = 34;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(572, 613);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(168, 20);
            this.label18.TabIndex = 33;
            this.label18.Text = "Growth (limited to 20%)";
            // 
            // txtLastFreeCashFlow
            // 
            this.txtLastFreeCashFlow.Location = new System.Drawing.Point(754, 568);
            this.txtLastFreeCashFlow.Name = "txtLastFreeCashFlow";
            this.txtLastFreeCashFlow.Size = new System.Drawing.Size(196, 27);
            this.txtLastFreeCashFlow.TabIndex = 32;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(572, 571);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(160, 20);
            this.label17.TabIndex = 31;
            this.label17.Text = "Last Free Cash Flow (B)";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(956, 531);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(21, 20);
            this.label16.TabIndex = 30;
            this.label16.Text = "%";
            // 
            // txtDiscountInterestRate
            // 
            this.txtDiscountInterestRate.Location = new System.Drawing.Point(754, 528);
            this.txtDiscountInterestRate.Name = "txtDiscountInterestRate";
            this.txtDiscountInterestRate.Size = new System.Drawing.Size(196, 27);
            this.txtDiscountInterestRate.TabIndex = 29;
            this.txtDiscountInterestRate.Text = "10";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(572, 531);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(154, 20);
            this.label15.TabIndex = 28;
            this.label15.Text = "Discount Interest Rate";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label14.Location = new System.Drawing.Point(572, 674);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(159, 30);
            this.label14.TabIndex = 27;
            this.label14.Text = "Intrinsic Value";
            // 
            // gvIntrinsicVal
            // 
            this.gvIntrinsicVal.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gvIntrinsicVal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvIntrinsicVal.Location = new System.Drawing.Point(572, 707);
            this.gvIntrinsicVal.Name = "gvIntrinsicVal";
            this.gvIntrinsicVal.RowHeadersWidth = 51;
            this.gvIntrinsicVal.RowTemplate.Height = 29;
            this.gvIntrinsicVal.Size = new System.Drawing.Size(449, 188);
            this.gvIntrinsicVal.TabIndex = 26;
            // 
            // btnCalculateIntrinsicValue
            // 
            this.btnCalculateIntrinsicValue.Location = new System.Drawing.Point(572, 901);
            this.btnCalculateIntrinsicValue.Name = "btnCalculateIntrinsicValue";
            this.btnCalculateIntrinsicValue.Size = new System.Drawing.Size(302, 29);
            this.btnCalculateIntrinsicValue.TabIndex = 25;
            this.btnCalculateIntrinsicValue.Text = "Calculate Intrinsic Value";
            this.btnCalculateIntrinsicValue.UseVisualStyleBackColor = true;
            this.btnCalculateIntrinsicValue.Click += new System.EventHandler(this.btnCalculateIntrinsicValue_Click);
            // 
            // lblCurrentSharePrice
            // 
            this.lblCurrentSharePrice.AutoSize = true;
            this.lblCurrentSharePrice.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblCurrentSharePrice.Location = new System.Drawing.Point(791, 126);
            this.lblCurrentSharePrice.Name = "lblCurrentSharePrice";
            this.lblCurrentSharePrice.Size = new System.Drawing.Size(0, 30);
            this.lblCurrentSharePrice.TabIndex = 24;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label13.Location = new System.Drawing.Point(567, 126);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(218, 30);
            this.label13.TabIndex = 23;
            this.label13.Text = "Current share price:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(400, 667);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(21, 20);
            this.label12.TabIndex = 22;
            this.label12.Text = "%";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(400, 634);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(21, 20);
            this.label11.TabIndex = 21;
            this.label11.Text = "%";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(400, 601);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(21, 20);
            this.label10.TabIndex = 20;
            this.label10.Text = "%";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(400, 568);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(21, 20);
            this.label9.TabIndex = 19;
            this.label9.Text = "%";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(400, 535);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(21, 20);
            this.label8.TabIndex = 18;
            this.label8.Text = "%";
            // 
            // txtAvgFreeCashFlowGrowth
            // 
            this.txtAvgFreeCashFlowGrowth.Location = new System.Drawing.Point(198, 664);
            this.txtAvgFreeCashFlowGrowth.Name = "txtAvgFreeCashFlowGrowth";
            this.txtAvgFreeCashFlowGrowth.Size = new System.Drawing.Size(196, 27);
            this.txtAvgFreeCashFlowGrowth.TabIndex = 17;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(32, 667);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(154, 20);
            this.label7.TabIndex = 16;
            this.label7.Text = "Avg Free Cash Growth";
            // 
            // txtAvgNetIncomeGrowth
            // 
            this.txtAvgNetIncomeGrowth.Location = new System.Drawing.Point(198, 631);
            this.txtAvgNetIncomeGrowth.Name = "txtAvgNetIncomeGrowth";
            this.txtAvgNetIncomeGrowth.Size = new System.Drawing.Size(196, 27);
            this.txtAvgNetIncomeGrowth.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 634);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(168, 20);
            this.label6.TabIndex = 14;
            this.label6.Text = "Avg Net Income Growth";
            // 
            // txtAvgEPSGrowth
            // 
            this.txtAvgEPSGrowth.Location = new System.Drawing.Point(198, 598);
            this.txtAvgEPSGrowth.Name = "txtAvgEPSGrowth";
            this.txtAvgEPSGrowth.Size = new System.Drawing.Size(196, 27);
            this.txtAvgEPSGrowth.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(71, 601);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(115, 20);
            this.label5.TabIndex = 12;
            this.label5.Text = "Avg EPS Growth";
            // 
            // txtAvgRevenueGrowth
            // 
            this.txtAvgRevenueGrowth.Location = new System.Drawing.Point(198, 565);
            this.txtAvgRevenueGrowth.Name = "txtAvgRevenueGrowth";
            this.txtAvgRevenueGrowth.Size = new System.Drawing.Size(196, 27);
            this.txtAvgRevenueGrowth.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(39, 568);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(147, 20);
            this.label4.TabIndex = 10;
            this.label4.Text = "Avg Revenue Growth";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(588, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(160, 20);
            this.label3.TabIndex = 9;
            this.label3.Text = "Shares Outstanding (B)";
            // 
            // txtSharesOutstanding
            // 
            this.txtSharesOutstanding.Location = new System.Drawing.Point(754, 80);
            this.txtSharesOutstanding.Name = "txtSharesOutstanding";
            this.txtSharesOutstanding.Size = new System.Drawing.Size(196, 27);
            this.txtSharesOutstanding.TabIndex = 8;
            // 
            // txtAvgEquityGrowth
            // 
            this.txtAvgEquityGrowth.Location = new System.Drawing.Point(198, 532);
            this.txtAvgEquityGrowth.Name = "txtAvgEquityGrowth";
            this.txtAvgEquityGrowth.Size = new System.Drawing.Size(196, 27);
            this.txtAvgEquityGrowth.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(54, 535);
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
            // 
            // pbLoading
            // 
            this.pbLoading.Image = ((System.Drawing.Image)(resources.GetObject("pbLoading.Image")));
            this.pbLoading.Location = new System.Drawing.Point(506, 22);
            this.pbLoading.Name = "pbLoading";
            this.pbLoading.Size = new System.Drawing.Size(29, 26);
            this.pbLoading.TabIndex = 4;
            this.pbLoading.TabStop = false;
            this.pbLoading.Visible = false;
            // 
            // gvFinancials
            // 
            this.gvFinancials.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gvFinancials.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvFinancials.Location = new System.Drawing.Point(23, 159);
            this.gvFinancials.Name = "gvFinancials";
            this.gvFinancials.RowHeadersWidth = 51;
            this.gvFinancials.RowTemplate.Height = 29;
            this.gvFinancials.Size = new System.Drawing.Size(996, 336);
            this.gvFinancials.TabIndex = 3;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(378, 19);
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
            this.tabSearchCompanies.Controls.Add(this.lblTickerInProcess);
            this.tabSearchCompanies.Controls.Add(this.pbLoadingCompanies);
            this.tabSearchCompanies.Controls.Add(this.gvCompanies);
            this.tabSearchCompanies.Controls.Add(this.btnGo);
            this.tabSearchCompanies.Controls.Add(this.txtURL);
            this.tabSearchCompanies.Controls.Add(this.label20);
            this.tabSearchCompanies.Location = new System.Drawing.Point(4, 29);
            this.tabSearchCompanies.Name = "tabSearchCompanies";
            this.tabSearchCompanies.Padding = new System.Windows.Forms.Padding(3);
            this.tabSearchCompanies.Size = new System.Drawing.Size(1051, 947);
            this.tabSearchCompanies.TabIndex = 1;
            this.tabSearchCompanies.Text = "Search Companies";
            this.tabSearchCompanies.UseVisualStyleBackColor = true;
            // 
            // lblTickerInProcess
            // 
            this.lblTickerInProcess.AutoSize = true;
            this.lblTickerInProcess.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTickerInProcess.Location = new System.Drawing.Point(922, 59);
            this.lblTickerInProcess.Name = "lblTickerInProcess";
            this.lblTickerInProcess.Size = new System.Drawing.Size(51, 20);
            this.lblTickerInProcess.TabIndex = 5;
            this.lblTickerInProcess.Text = "Ticker";
            // 
            // pbLoadingCompanies
            // 
            this.pbLoadingCompanies.Image = ((System.Drawing.Image)(resources.GetObject("pbLoadingCompanies.Image")));
            this.pbLoadingCompanies.Location = new System.Drawing.Point(989, 30);
            this.pbLoadingCompanies.Name = "pbLoadingCompanies";
            this.pbLoadingCompanies.Size = new System.Drawing.Size(31, 26);
            this.pbLoadingCompanies.TabIndex = 4;
            this.pbLoadingCompanies.TabStop = false;
            this.pbLoadingCompanies.Visible = false;
            // 
            // gvCompanies
            // 
            this.gvCompanies.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gvCompanies.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvCompanies.Location = new System.Drawing.Point(16, 142);
            this.gvCompanies.Name = "gvCompanies";
            this.gvCompanies.RowHeadersWidth = 51;
            this.gvCompanies.Size = new System.Drawing.Size(1016, 792);
            this.gvCompanies.TabIndex = 3;
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(916, 27);
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
            this.txtURL.Size = new System.Drawing.Size(840, 27);
            this.txtURL.TabIndex = 1;
            this.txtURL.Text = resources.GetString("txtURL.Text");
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
            this.lblErrorMessage.Location = new System.Drawing.Point(12, 1030);
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
            this.bgwSearchCompanies.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwSearchCompanies_DoWork);
            this.bgwSearchCompanies.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwSearchCompanies_RunWorkerCompleted);
            // 
            // tmrCompanies
            // 
            this.tmrCompanies.Interval = 500;
            this.tmrCompanies.Tick += new System.EventHandler(this.tmrCompanies_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1075, 1059);
            this.Controls.Add(this.lblErrorMessage);
            this.Controls.Add(this.tabControl1);
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
    }
}

