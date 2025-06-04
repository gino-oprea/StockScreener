
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            tabControl1 = new System.Windows.Forms.TabControl();
            tabCheckCompany = new System.Windows.Forms.TabPage();
            label35 = new System.Windows.Forms.Label();
            txtAvgFcfPerShareGrowth = new System.Windows.Forms.TextBox();
            label36 = new System.Windows.Forms.Label();
            label34 = new System.Windows.Forms.Label();
            txtAvgOperatingMarginGrowth = new System.Windows.Forms.TextBox();
            label32 = new System.Windows.Forms.Label();
            label31 = new System.Windows.Forms.Label();
            label33 = new System.Windows.Forms.Label();
            txtTerminalMultiple = new System.Windows.Forms.TextBox();
            label26 = new System.Windows.Forms.Label();
            lblMarketCap = new System.Windows.Forms.Label();
            label27 = new System.Windows.Forms.Label();
            label29 = new System.Windows.Forms.Label();
            txtAvgROIC = new System.Windows.Forms.TextBox();
            label30 = new System.Windows.Forms.Label();
            label19 = new System.Windows.Forms.Label();
            txtGrowth = new System.Windows.Forms.TextBox();
            label18 = new System.Windows.Forms.Label();
            txtLastFreeCashFlow = new System.Windows.Forms.TextBox();
            label17 = new System.Windows.Forms.Label();
            label16 = new System.Windows.Forms.Label();
            txtDiscountInterestRate = new System.Windows.Forms.TextBox();
            label15 = new System.Windows.Forms.Label();
            label14 = new System.Windows.Forms.Label();
            gvIntrinsicVal = new System.Windows.Forms.DataGridView();
            btnCalculateIntrinsicValue = new System.Windows.Forms.Button();
            lblCurrentSharePrice = new System.Windows.Forms.Label();
            label13 = new System.Windows.Forms.Label();
            label12 = new System.Windows.Forms.Label();
            label11 = new System.Windows.Forms.Label();
            label10 = new System.Windows.Forms.Label();
            label9 = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            txtAvgFreeCashFlowGrowth = new System.Windows.Forms.TextBox();
            label7 = new System.Windows.Forms.Label();
            txtAvgNetIncomeGrowth = new System.Windows.Forms.TextBox();
            label6 = new System.Windows.Forms.Label();
            txtAvgEPSGrowth = new System.Windows.Forms.TextBox();
            label5 = new System.Windows.Forms.Label();
            txtAvgRevenueGrowth = new System.Windows.Forms.TextBox();
            label4 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            txtSharesOutstanding = new System.Windows.Forms.TextBox();
            txtAvgEquityGrowth = new System.Windows.Forms.TextBox();
            label2 = new System.Windows.Forms.Label();
            lblCompanyName = new System.Windows.Forms.Label();
            pbLoading = new System.Windows.Forms.PictureBox();
            gvFinancials = new System.Windows.Forms.DataGridView();
            btnSearch = new System.Windows.Forms.Button();
            label1 = new System.Windows.Forms.Label();
            txtTicker = new System.Windows.Forms.TextBox();
            tabSearchCompanies = new System.Windows.Forms.TabPage();
            txtFilterAvgROIC = new System.Windows.Forms.TextBox();
            label28 = new System.Windows.Forms.Label();
            lblProgress = new System.Windows.Forms.Label();
            cbFilterValue = new System.Windows.Forms.ComboBox();
            btnStop = new System.Windows.Forms.Button();
            txtFilterRateOfReturn = new System.Windows.Forms.TextBox();
            label25 = new System.Windows.Forms.Label();
            txtFilterAvgFcfGrowth = new System.Windows.Forms.TextBox();
            label24 = new System.Windows.Forms.Label();
            txtFilterAvgEPSGrowth = new System.Windows.Forms.TextBox();
            label23 = new System.Windows.Forms.Label();
            txtFilterAvgRevGrowth = new System.Windows.Forms.TextBox();
            label22 = new System.Windows.Forms.Label();
            txtFilterAvgEqGrowth = new System.Windows.Forms.TextBox();
            label21 = new System.Windows.Forms.Label();
            lblTickerInProcess = new System.Windows.Forms.Label();
            pbLoadingCompanies = new System.Windows.Forms.PictureBox();
            gvCompanies = new System.Windows.Forms.DataGridView();
            btnGo = new System.Windows.Forms.Button();
            lblErrorMessage = new System.Windows.Forms.Label();
            bgwCheckCompany = new System.ComponentModel.BackgroundWorker();
            bgwSearchCompanies = new System.ComponentModel.BackgroundWorker();
            tmrCompanies = new System.Windows.Forms.Timer(components);
            tmrTicker = new System.Windows.Forms.Timer(components);
            tabControl1.SuspendLayout();
            tabCheckCompany.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gvIntrinsicVal).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbLoading).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gvFinancials).BeginInit();
            tabSearchCompanies.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbLoadingCompanies).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gvCompanies).BeginInit();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabCheckCompany);
            tabControl1.Controls.Add(tabSearchCompanies);
            tabControl1.Location = new System.Drawing.Point(6, 15);
            tabControl1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new System.Drawing.Size(1820, 973);
            tabControl1.TabIndex = 0;
            // 
            // tabCheckCompany
            // 
            tabCheckCompany.Controls.Add(label35);
            tabCheckCompany.Controls.Add(txtAvgFcfPerShareGrowth);
            tabCheckCompany.Controls.Add(label36);
            tabCheckCompany.Controls.Add(label34);
            tabCheckCompany.Controls.Add(txtAvgOperatingMarginGrowth);
            tabCheckCompany.Controls.Add(label32);
            tabCheckCompany.Controls.Add(label31);
            tabCheckCompany.Controls.Add(label33);
            tabCheckCompany.Controls.Add(txtTerminalMultiple);
            tabCheckCompany.Controls.Add(label26);
            tabCheckCompany.Controls.Add(lblMarketCap);
            tabCheckCompany.Controls.Add(label27);
            tabCheckCompany.Controls.Add(label29);
            tabCheckCompany.Controls.Add(txtAvgROIC);
            tabCheckCompany.Controls.Add(label30);
            tabCheckCompany.Controls.Add(label19);
            tabCheckCompany.Controls.Add(txtGrowth);
            tabCheckCompany.Controls.Add(label18);
            tabCheckCompany.Controls.Add(txtLastFreeCashFlow);
            tabCheckCompany.Controls.Add(label17);
            tabCheckCompany.Controls.Add(label16);
            tabCheckCompany.Controls.Add(txtDiscountInterestRate);
            tabCheckCompany.Controls.Add(label15);
            tabCheckCompany.Controls.Add(label14);
            tabCheckCompany.Controls.Add(gvIntrinsicVal);
            tabCheckCompany.Controls.Add(btnCalculateIntrinsicValue);
            tabCheckCompany.Controls.Add(lblCurrentSharePrice);
            tabCheckCompany.Controls.Add(label13);
            tabCheckCompany.Controls.Add(label12);
            tabCheckCompany.Controls.Add(label11);
            tabCheckCompany.Controls.Add(label10);
            tabCheckCompany.Controls.Add(label9);
            tabCheckCompany.Controls.Add(label8);
            tabCheckCompany.Controls.Add(txtAvgFreeCashFlowGrowth);
            tabCheckCompany.Controls.Add(label7);
            tabCheckCompany.Controls.Add(txtAvgNetIncomeGrowth);
            tabCheckCompany.Controls.Add(label6);
            tabCheckCompany.Controls.Add(txtAvgEPSGrowth);
            tabCheckCompany.Controls.Add(label5);
            tabCheckCompany.Controls.Add(txtAvgRevenueGrowth);
            tabCheckCompany.Controls.Add(label4);
            tabCheckCompany.Controls.Add(label3);
            tabCheckCompany.Controls.Add(txtSharesOutstanding);
            tabCheckCompany.Controls.Add(txtAvgEquityGrowth);
            tabCheckCompany.Controls.Add(label2);
            tabCheckCompany.Controls.Add(lblCompanyName);
            tabCheckCompany.Controls.Add(pbLoading);
            tabCheckCompany.Controls.Add(gvFinancials);
            tabCheckCompany.Controls.Add(btnSearch);
            tabCheckCompany.Controls.Add(label1);
            tabCheckCompany.Controls.Add(txtTicker);
            tabCheckCompany.Location = new System.Drawing.Point(4, 34);
            tabCheckCompany.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tabCheckCompany.Name = "tabCheckCompany";
            tabCheckCompany.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tabCheckCompany.Size = new System.Drawing.Size(1812, 935);
            tabCheckCompany.TabIndex = 0;
            tabCheckCompany.Text = "Check Company";
            tabCheckCompany.UseVisualStyleBackColor = true;
            // 
            // label35
            // 
            label35.AutoSize = true;
            label35.Location = new System.Drawing.Point(374, 718);
            label35.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label35.Name = "label35";
            label35.Size = new System.Drawing.Size(27, 25);
            label35.TabIndex = 58;
            label35.Text = "%";
            // 
            // txtAvgFcfPerShareGrowth
            // 
            txtAvgFcfPerShareGrowth.Location = new System.Drawing.Point(285, 713);
            txtAvgFcfPerShareGrowth.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            txtAvgFcfPerShareGrowth.Name = "txtAvgFcfPerShareGrowth";
            txtAvgFcfPerShareGrowth.Size = new System.Drawing.Size(80, 31);
            txtAvgFcfPerShareGrowth.TabIndex = 57;
            // 
            // label36
            // 
            label36.AutoSize = true;
            label36.Location = new System.Drawing.Point(41, 718);
            label36.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label36.Name = "label36";
            label36.Size = new System.Drawing.Size(221, 25);
            label36.TabIndex = 56;
            label36.Text = "Avg FCF per Share Growth";
            // 
            // label34
            // 
            label34.AutoSize = true;
            label34.Location = new System.Drawing.Point(374, 800);
            label34.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label34.Name = "label34";
            label34.Size = new System.Drawing.Size(27, 25);
            label34.TabIndex = 54;
            label34.Text = "%";
            // 
            // txtAvgOperatingMarginGrowth
            // 
            txtAvgOperatingMarginGrowth.Location = new System.Drawing.Point(285, 795);
            txtAvgOperatingMarginGrowth.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            txtAvgOperatingMarginGrowth.Name = "txtAvgOperatingMarginGrowth";
            txtAvgOperatingMarginGrowth.Size = new System.Drawing.Size(80, 31);
            txtAvgOperatingMarginGrowth.TabIndex = 53;
            // 
            // label32
            // 
            label32.AutoSize = true;
            label32.Location = new System.Drawing.Point(7, 798);
            label32.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label32.Name = "label32";
            label32.Size = new System.Drawing.Size(253, 25);
            label32.TabIndex = 52;
            label32.Text = "Avg Operating Margin Growth";
            // 
            // label31
            // 
            label31.AutoSize = true;
            label31.Location = new System.Drawing.Point(1439, 853);
            label31.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label31.Name = "label31";
            label31.Size = new System.Drawing.Size(167, 25);
            label31.TabIndex = 50;
            label31.Text = "last 3 years average";
            // 
            // label33
            // 
            label33.AutoSize = true;
            label33.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            label33.Location = new System.Drawing.Point(743, 447);
            label33.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label33.Name = "label33";
            label33.Size = new System.Drawing.Size(0, 28);
            label33.TabIndex = 49;
            // 
            // txtTerminalMultiple
            // 
            txtTerminalMultiple.Location = new System.Drawing.Point(1349, 892);
            txtTerminalMultiple.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            txtTerminalMultiple.Name = "txtTerminalMultiple";
            txtTerminalMultiple.Size = new System.Drawing.Size(80, 31);
            txtTerminalMultiple.TabIndex = 45;
            // 
            // label26
            // 
            label26.AutoSize = true;
            label26.Location = new System.Drawing.Point(1178, 895);
            label26.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label26.Name = "label26";
            label26.Size = new System.Drawing.Size(146, 25);
            label26.TabIndex = 44;
            label26.Text = "Terminal Multiple";
            // 
            // lblMarketCap
            // 
            lblMarketCap.AutoSize = true;
            lblMarketCap.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            lblMarketCap.Location = new System.Drawing.Point(1234, 23);
            lblMarketCap.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblMarketCap.Name = "lblMarketCap";
            lblMarketCap.Size = new System.Drawing.Size(0, 28);
            lblMarketCap.TabIndex = 43;
            // 
            // label27
            // 
            label27.AutoSize = true;
            label27.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            label27.Location = new System.Drawing.Point(1054, 23);
            label27.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label27.Name = "label27";
            label27.Size = new System.Drawing.Size(159, 28);
            label27.TabIndex = 42;
            label27.Text = "Market Cap (B):";
            // 
            // label29
            // 
            label29.AutoSize = true;
            label29.Location = new System.Drawing.Point(374, 882);
            label29.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label29.Name = "label29";
            label29.Size = new System.Drawing.Size(27, 25);
            label29.TabIndex = 41;
            label29.Text = "%";
            // 
            // txtAvgROIC
            // 
            txtAvgROIC.Location = new System.Drawing.Point(285, 878);
            txtAvgROIC.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            txtAvgROIC.Name = "txtAvgROIC";
            txtAvgROIC.Size = new System.Drawing.Size(80, 31);
            txtAvgROIC.TabIndex = 40;
            // 
            // label30
            // 
            label30.AutoSize = true;
            label30.Location = new System.Drawing.Point(172, 882);
            label30.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label30.Name = "label30";
            label30.Size = new System.Drawing.Size(90, 25);
            label30.TabIndex = 39;
            label30.Text = "Avg ROIC";
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Location = new System.Drawing.Point(1438, 812);
            label19.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label19.Name = "label19";
            label19.Size = new System.Drawing.Size(27, 25);
            label19.TabIndex = 35;
            label19.Text = "%";
            // 
            // txtGrowth
            // 
            txtGrowth.Location = new System.Drawing.Point(1349, 808);
            txtGrowth.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            txtGrowth.Name = "txtGrowth";
            txtGrowth.Size = new System.Drawing.Size(80, 31);
            txtGrowth.TabIndex = 34;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Location = new System.Drawing.Point(1262, 812);
            label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label18.Name = "label18";
            label18.Size = new System.Drawing.Size(70, 25);
            label18.TabIndex = 33;
            label18.Text = "Growth";
            // 
            // txtLastFreeCashFlow
            // 
            txtLastFreeCashFlow.Location = new System.Drawing.Point(1349, 850);
            txtLastFreeCashFlow.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            txtLastFreeCashFlow.Name = "txtLastFreeCashFlow";
            txtLastFreeCashFlow.Size = new System.Drawing.Size(80, 31);
            txtLastFreeCashFlow.TabIndex = 32;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new System.Drawing.Point(1134, 853);
            label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label17.Name = "label17";
            label17.Size = new System.Drawing.Size(192, 25);
            label17.TabIndex = 31;
            label17.Text = "Avg Free Cash Flow (B)";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new System.Drawing.Point(1438, 770);
            label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label16.Name = "label16";
            label16.Size = new System.Drawing.Size(27, 25);
            label16.TabIndex = 30;
            label16.Text = "%";
            // 
            // txtDiscountInterestRate
            // 
            txtDiscountInterestRate.Location = new System.Drawing.Point(1349, 767);
            txtDiscountInterestRate.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            txtDiscountInterestRate.Name = "txtDiscountInterestRate";
            txtDiscountInterestRate.Size = new System.Drawing.Size(80, 31);
            txtDiscountInterestRate.TabIndex = 29;
            txtDiscountInterestRate.Text = "13";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new System.Drawing.Point(1141, 772);
            label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label15.Name = "label15";
            label15.Size = new System.Drawing.Size(186, 25);
            label15.TabIndex = 28;
            label15.Text = "Discount Interest Rate";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            label14.Location = new System.Drawing.Point(1141, 588);
            label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label14.Name = "label14";
            label14.Size = new System.Drawing.Size(185, 36);
            label14.TabIndex = 27;
            label14.Text = "Intrinsic Value";
            // 
            // gvIntrinsicVal
            // 
            gvIntrinsicVal.AllowUserToAddRows = false;
            gvIntrinsicVal.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            gvIntrinsicVal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gvIntrinsicVal.Location = new System.Drawing.Point(1141, 630);
            gvIntrinsicVal.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gvIntrinsicVal.Name = "gvIntrinsicVal";
            gvIntrinsicVal.RowHeadersWidth = 51;
            gvIntrinsicVal.RowTemplate.Height = 29;
            gvIntrinsicVal.Size = new System.Drawing.Size(660, 113);
            gvIntrinsicVal.TabIndex = 26;
            // 
            // btnCalculateIntrinsicValue
            // 
            btnCalculateIntrinsicValue.BackColor = System.Drawing.Color.GreenYellow;
            btnCalculateIntrinsicValue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            btnCalculateIntrinsicValue.Location = new System.Drawing.Point(1473, 774);
            btnCalculateIntrinsicValue.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnCalculateIntrinsicValue.Name = "btnCalculateIntrinsicValue";
            btnCalculateIntrinsicValue.Size = new System.Drawing.Size(328, 63);
            btnCalculateIntrinsicValue.TabIndex = 25;
            btnCalculateIntrinsicValue.Text = "Recalculate Intrinsic Value";
            btnCalculateIntrinsicValue.UseVisualStyleBackColor = false;
            btnCalculateIntrinsicValue.Click += btnCalculateIntrinsicValue_Click;
            // 
            // lblCurrentSharePrice
            // 
            lblCurrentSharePrice.AutoSize = true;
            lblCurrentSharePrice.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            lblCurrentSharePrice.Location = new System.Drawing.Point(1234, 53);
            lblCurrentSharePrice.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblCurrentSharePrice.Name = "lblCurrentSharePrice";
            lblCurrentSharePrice.Size = new System.Drawing.Size(0, 28);
            lblCurrentSharePrice.TabIndex = 24;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            label13.Location = new System.Drawing.Point(1016, 53);
            label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label13.Name = "label13";
            label13.Size = new System.Drawing.Size(198, 28);
            label13.TabIndex = 23;
            label13.Text = "Current share price:";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new System.Drawing.Point(374, 840);
            label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label12.Name = "label12";
            label12.Size = new System.Drawing.Size(27, 25);
            label12.TabIndex = 22;
            label12.Text = "%";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new System.Drawing.Point(374, 758);
            label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label11.Name = "label11";
            label11.Size = new System.Drawing.Size(27, 25);
            label11.TabIndex = 21;
            label11.Text = "%";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new System.Drawing.Point(374, 680);
            label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(27, 25);
            label10.TabIndex = 20;
            label10.Text = "%";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new System.Drawing.Point(374, 638);
            label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(27, 25);
            label9.TabIndex = 19;
            label9.Text = "%";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new System.Drawing.Point(374, 598);
            label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(27, 25);
            label8.TabIndex = 18;
            label8.Text = "%";
            // 
            // txtAvgFreeCashFlowGrowth
            // 
            txtAvgFreeCashFlowGrowth.Location = new System.Drawing.Point(285, 837);
            txtAvgFreeCashFlowGrowth.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            txtAvgFreeCashFlowGrowth.Name = "txtAvgFreeCashFlowGrowth";
            txtAvgFreeCashFlowGrowth.Size = new System.Drawing.Size(80, 31);
            txtAvgFreeCashFlowGrowth.TabIndex = 17;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(75, 840);
            label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(188, 25);
            label7.TabIndex = 16;
            label7.Text = "Avg Free Cash Growth";
            // 
            // txtAvgNetIncomeGrowth
            // 
            txtAvgNetIncomeGrowth.Location = new System.Drawing.Point(285, 755);
            txtAvgNetIncomeGrowth.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            txtAvgNetIncomeGrowth.Name = "txtAvgNetIncomeGrowth";
            txtAvgNetIncomeGrowth.Size = new System.Drawing.Size(80, 31);
            txtAvgNetIncomeGrowth.TabIndex = 15;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(58, 758);
            label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(204, 25);
            label6.TabIndex = 14;
            label6.Text = "Avg Net Income Growth";
            // 
            // txtAvgEPSGrowth
            // 
            txtAvgEPSGrowth.Location = new System.Drawing.Point(285, 677);
            txtAvgEPSGrowth.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            txtAvgEPSGrowth.Name = "txtAvgEPSGrowth";
            txtAvgEPSGrowth.Size = new System.Drawing.Size(80, 31);
            txtAvgEPSGrowth.TabIndex = 13;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(124, 680);
            label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(141, 25);
            label5.TabIndex = 12;
            label5.Text = "Avg EPS Growth";
            // 
            // txtAvgRevenueGrowth
            // 
            txtAvgRevenueGrowth.Location = new System.Drawing.Point(285, 635);
            txtAvgRevenueGrowth.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            txtAvgRevenueGrowth.Name = "txtAvgRevenueGrowth";
            txtAvgRevenueGrowth.Size = new System.Drawing.Size(80, 31);
            txtAvgRevenueGrowth.TabIndex = 11;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(84, 638);
            label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(178, 25);
            label4.TabIndex = 10;
            label4.Text = "Avg Revenue Growth";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            label3.Location = new System.Drawing.Point(983, 85);
            label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(230, 28);
            label3.TabIndex = 9;
            label3.Text = "Shares Outstanding (B)";
            // 
            // txtSharesOutstanding
            // 
            txtSharesOutstanding.Location = new System.Drawing.Point(1234, 83);
            txtSharesOutstanding.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            txtSharesOutstanding.Name = "txtSharesOutstanding";
            txtSharesOutstanding.Size = new System.Drawing.Size(244, 31);
            txtSharesOutstanding.TabIndex = 8;
            // 
            // txtAvgEquityGrowth
            // 
            txtAvgEquityGrowth.Location = new System.Drawing.Point(285, 593);
            txtAvgEquityGrowth.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            txtAvgEquityGrowth.Name = "txtAvgEquityGrowth";
            txtAvgEquityGrowth.Size = new System.Drawing.Size(80, 31);
            txtAvgEquityGrowth.TabIndex = 7;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(102, 598);
            label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(161, 25);
            label2.TabIndex = 6;
            label2.Text = "Avg Equity Growth";
            // 
            // lblCompanyName
            // 
            lblCompanyName.AutoSize = true;
            lblCompanyName.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            lblCompanyName.Location = new System.Drawing.Point(40, 88);
            lblCompanyName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblCompanyName.Name = "lblCompanyName";
            lblCompanyName.Size = new System.Drawing.Size(0, 30);
            lblCompanyName.TabIndex = 5;
            lblCompanyName.UseMnemonic = false;
            // 
            // pbLoading
            // 
            pbLoading.Image = (System.Drawing.Image)resources.GetObject("pbLoading.Image");
            pbLoading.Location = new System.Drawing.Point(586, 28);
            pbLoading.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            pbLoading.Name = "pbLoading";
            pbLoading.Size = new System.Drawing.Size(27, 25);
            pbLoading.TabIndex = 4;
            pbLoading.TabStop = false;
            pbLoading.Visible = false;
            // 
            // gvFinancials
            // 
            gvFinancials.AllowUserToAddRows = false;
            gvFinancials.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            gvFinancials.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gvFinancials.Location = new System.Drawing.Point(6, 133);
            gvFinancials.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gvFinancials.Name = "gvFinancials";
            gvFinancials.RowHeadersWidth = 51;
            gvFinancials.RowTemplate.Height = 29;
            gvFinancials.Size = new System.Drawing.Size(1795, 445);
            gvFinancials.TabIndex = 3;
            // 
            // btnSearch
            // 
            btnSearch.Location = new System.Drawing.Point(439, 23);
            btnSearch.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new System.Drawing.Size(140, 37);
            btnSearch.TabIndex = 2;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(29, 28);
            label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(143, 25);
            label1.TabIndex = 1;
            label1.Text = "Company Ticker:";
            // 
            // txtTicker
            // 
            txtTicker.Location = new System.Drawing.Point(184, 27);
            txtTicker.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            txtTicker.Name = "txtTicker";
            txtTicker.Size = new System.Drawing.Size(247, 31);
            txtTicker.TabIndex = 0;
            // 
            // tabSearchCompanies
            // 
            tabSearchCompanies.Controls.Add(txtFilterAvgROIC);
            tabSearchCompanies.Controls.Add(label28);
            tabSearchCompanies.Controls.Add(lblProgress);
            tabSearchCompanies.Controls.Add(cbFilterValue);
            tabSearchCompanies.Controls.Add(btnStop);
            tabSearchCompanies.Controls.Add(txtFilterRateOfReturn);
            tabSearchCompanies.Controls.Add(label25);
            tabSearchCompanies.Controls.Add(txtFilterAvgFcfGrowth);
            tabSearchCompanies.Controls.Add(label24);
            tabSearchCompanies.Controls.Add(txtFilterAvgEPSGrowth);
            tabSearchCompanies.Controls.Add(label23);
            tabSearchCompanies.Controls.Add(txtFilterAvgRevGrowth);
            tabSearchCompanies.Controls.Add(label22);
            tabSearchCompanies.Controls.Add(txtFilterAvgEqGrowth);
            tabSearchCompanies.Controls.Add(label21);
            tabSearchCompanies.Controls.Add(lblTickerInProcess);
            tabSearchCompanies.Controls.Add(pbLoadingCompanies);
            tabSearchCompanies.Controls.Add(gvCompanies);
            tabSearchCompanies.Controls.Add(btnGo);
            tabSearchCompanies.Location = new System.Drawing.Point(4, 34);
            tabSearchCompanies.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tabSearchCompanies.Name = "tabSearchCompanies";
            tabSearchCompanies.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tabSearchCompanies.Size = new System.Drawing.Size(1812, 935);
            tabSearchCompanies.TabIndex = 1;
            tabSearchCompanies.Text = "Search Companies";
            tabSearchCompanies.UseVisualStyleBackColor = true;
            // 
            // txtFilterAvgROIC
            // 
            txtFilterAvgROIC.Location = new System.Drawing.Point(769, 60);
            txtFilterAvgROIC.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            txtFilterAvgROIC.Name = "txtFilterAvgROIC";
            txtFilterAvgROIC.Size = new System.Drawing.Size(38, 31);
            txtFilterAvgROIC.TabIndex = 22;
            txtFilterAvgROIC.Text = "10";
            // 
            // label28
            // 
            label28.AutoSize = true;
            label28.Location = new System.Drawing.Point(606, 65);
            label28.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label28.Name = "label28";
            label28.Size = new System.Drawing.Size(151, 25);
            label28.TabIndex = 21;
            label28.Text = "Min avg ROIC(%):";
            // 
            // lblProgress
            // 
            lblProgress.AutoSize = true;
            lblProgress.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            lblProgress.Location = new System.Drawing.Point(1551, 60);
            lblProgress.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblProgress.Name = "lblProgress";
            lblProgress.Size = new System.Drawing.Size(85, 25);
            lblProgress.TabIndex = 20;
            lblProgress.Text = "Progress";
            // 
            // cbFilterValue
            // 
            cbFilterValue.FormattingEnabled = true;
            cbFilterValue.Items.AddRange(new object[] { "Intrinsic Value", "MOS 10%", "MOS 30%", "MOS 50%", "Premium 10%", "Premium 20%", "Unlimited" });
            cbFilterValue.Location = new System.Drawing.Point(821, 7);
            cbFilterValue.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            cbFilterValue.Name = "cbFilterValue";
            cbFilterValue.Size = new System.Drawing.Size(230, 33);
            cbFilterValue.TabIndex = 19;
            // 
            // btnStop
            // 
            btnStop.BackColor = System.Drawing.Color.Red;
            btnStop.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btnStop.ForeColor = System.Drawing.Color.White;
            btnStop.Location = new System.Drawing.Point(1336, 6);
            btnStop.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnStop.Name = "btnStop";
            btnStop.Size = new System.Drawing.Size(195, 92);
            btnStop.TabIndex = 18;
            btnStop.Text = "Stop";
            btnStop.UseVisualStyleBackColor = false;
            btnStop.Click += btnStop_Click;
            // 
            // txtFilterRateOfReturn
            // 
            txtFilterRateOfReturn.Location = new System.Drawing.Point(769, 8);
            txtFilterRateOfReturn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            txtFilterRateOfReturn.Name = "txtFilterRateOfReturn";
            txtFilterRateOfReturn.Size = new System.Drawing.Size(38, 31);
            txtFilterRateOfReturn.TabIndex = 15;
            txtFilterRateOfReturn.Text = "13";
            // 
            // label25
            // 
            label25.AutoSize = true;
            label25.Location = new System.Drawing.Point(606, 13);
            label25.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label25.Name = "label25";
            label25.Size = new System.Drawing.Size(150, 25);
            label25.TabIndex = 14;
            label25.Text = "Rate of return(%):";
            // 
            // txtFilterAvgFcfGrowth
            // 
            txtFilterAvgFcfGrowth.Location = new System.Drawing.Point(543, 62);
            txtFilterAvgFcfGrowth.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            txtFilterAvgFcfGrowth.Name = "txtFilterAvgFcfGrowth";
            txtFilterAvgFcfGrowth.Size = new System.Drawing.Size(41, 31);
            txtFilterAvgFcfGrowth.TabIndex = 13;
            txtFilterAvgFcfGrowth.Text = "0";
            // 
            // label24
            // 
            label24.AutoSize = true;
            label24.Location = new System.Drawing.Point(327, 65);
            label24.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label24.Name = "label24";
            label24.Size = new System.Drawing.Size(201, 25);
            label24.TabIndex = 12;
            label24.Text = "Min avg FCF growth(%):";
            // 
            // txtFilterAvgEPSGrowth
            // 
            txtFilterAvgEPSGrowth.Location = new System.Drawing.Point(543, 8);
            txtFilterAvgEPSGrowth.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            txtFilterAvgEPSGrowth.Name = "txtFilterAvgEPSGrowth";
            txtFilterAvgEPSGrowth.Size = new System.Drawing.Size(41, 31);
            txtFilterAvgEPSGrowth.TabIndex = 11;
            txtFilterAvgEPSGrowth.Text = "0";
            // 
            // label23
            // 
            label23.AutoSize = true;
            label23.Location = new System.Drawing.Point(327, 13);
            label23.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label23.Name = "label23";
            label23.Size = new System.Drawing.Size(201, 25);
            label23.TabIndex = 10;
            label23.Text = "Min avg EPS growth(%):";
            // 
            // txtFilterAvgRevGrowth
            // 
            txtFilterAvgRevGrowth.Location = new System.Drawing.Point(261, 62);
            txtFilterAvgRevGrowth.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            txtFilterAvgRevGrowth.Name = "txtFilterAvgRevGrowth";
            txtFilterAvgRevGrowth.Size = new System.Drawing.Size(45, 31);
            txtFilterAvgRevGrowth.TabIndex = 9;
            txtFilterAvgRevGrowth.Text = "0";
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.Location = new System.Drawing.Point(11, 63);
            label22.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label22.Name = "label22";
            label22.Size = new System.Drawing.Size(234, 25);
            label22.TabIndex = 8;
            label22.Text = "Min avg revenue growth(%):";
            // 
            // txtFilterAvgEqGrowth
            // 
            txtFilterAvgEqGrowth.Location = new System.Drawing.Point(261, 8);
            txtFilterAvgEqGrowth.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            txtFilterAvgEqGrowth.Name = "txtFilterAvgEqGrowth";
            txtFilterAvgEqGrowth.Size = new System.Drawing.Size(45, 31);
            txtFilterAvgEqGrowth.TabIndex = 7;
            txtFilterAvgEqGrowth.Text = "0";
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Location = new System.Drawing.Point(26, 13);
            label21.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label21.Name = "label21";
            label21.Size = new System.Drawing.Size(221, 25);
            label21.TabIndex = 6;
            label21.Text = "Min avg equity growth(%):";
            // 
            // lblTickerInProcess
            // 
            lblTickerInProcess.AutoSize = true;
            lblTickerInProcess.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            lblTickerInProcess.Location = new System.Drawing.Point(1586, 15);
            lblTickerInProcess.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblTickerInProcess.Name = "lblTickerInProcess";
            lblTickerInProcess.Size = new System.Drawing.Size(64, 25);
            lblTickerInProcess.TabIndex = 5;
            lblTickerInProcess.Text = "Ticker";
            // 
            // pbLoadingCompanies
            // 
            pbLoadingCompanies.Image = (System.Drawing.Image)resources.GetObject("pbLoadingCompanies.Image");
            pbLoadingCompanies.Location = new System.Drawing.Point(1551, 15);
            pbLoadingCompanies.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            pbLoadingCompanies.Name = "pbLoadingCompanies";
            pbLoadingCompanies.Size = new System.Drawing.Size(27, 25);
            pbLoadingCompanies.TabIndex = 4;
            pbLoadingCompanies.TabStop = false;
            pbLoadingCompanies.Visible = false;
            // 
            // gvCompanies
            // 
            gvCompanies.AllowUserToAddRows = false;
            gvCompanies.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            gvCompanies.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gvCompanies.Location = new System.Drawing.Point(8, 101);
            gvCompanies.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gvCompanies.Name = "gvCompanies";
            gvCompanies.RowHeadersWidth = 51;
            gvCompanies.Size = new System.Drawing.Size(1796, 828);
            gvCompanies.TabIndex = 3;
            // 
            // btnGo
            // 
            btnGo.BackColor = System.Drawing.Color.LawnGreen;
            btnGo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btnGo.Location = new System.Drawing.Point(1134, 8);
            btnGo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnGo.Name = "btnGo";
            btnGo.Size = new System.Drawing.Size(194, 87);
            btnGo.TabIndex = 2;
            btnGo.Text = "Start";
            btnGo.UseVisualStyleBackColor = false;
            btnGo.Click += btnGo_Click;
            // 
            // lblErrorMessage
            // 
            lblErrorMessage.AutoSize = true;
            lblErrorMessage.ForeColor = System.Drawing.Color.Red;
            lblErrorMessage.Location = new System.Drawing.Point(13, 991);
            lblErrorMessage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblErrorMessage.Name = "lblErrorMessage";
            lblErrorMessage.Size = new System.Drawing.Size(57, 25);
            lblErrorMessage.TabIndex = 1;
            lblErrorMessage.Text = "         ";
            // 
            // bgwCheckCompany
            // 
            bgwCheckCompany.DoWork += bgwCheckCompany_DoWork;
            bgwCheckCompany.RunWorkerCompleted += bgwCheckCompany_RunWorkerCompleted;
            // 
            // bgwSearchCompanies
            // 
            bgwSearchCompanies.WorkerSupportsCancellation = true;
            bgwSearchCompanies.DoWork += bgwSearchCompanies_DoWork;
            bgwSearchCompanies.RunWorkerCompleted += bgwSearchCompanies_RunWorkerCompleted;
            // 
            // tmrCompanies
            // 
            tmrCompanies.Interval = 30000;
            tmrCompanies.Tick += tmrCompanies_Tick;
            // 
            // tmrTicker
            // 
            tmrTicker.Interval = 500;
            tmrTicker.Tick += tmrTicker_Tick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1829, 1047);
            Controls.Add(lblErrorMessage);
            Controls.Add(tabControl1);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "Form1";
            Text = "Stock Screener";
            tabControl1.ResumeLayout(false);
            tabCheckCompany.ResumeLayout(false);
            tabCheckCompany.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gvIntrinsicVal).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbLoading).EndInit();
            ((System.ComponentModel.ISupportInitialize)gvFinancials).EndInit();
            tabSearchCompanies.ResumeLayout(false);
            tabSearchCompanies.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbLoadingCompanies).EndInit();
            ((System.ComponentModel.ISupportInitialize)gvCompanies).EndInit();
            ResumeLayout(false);
            PerformLayout();
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
        private System.Windows.Forms.Label label33;
           
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.TextBox txtAvgOperatingMarginGrowth;
        private System.Windows.Forms.Label label32;
        
        
        
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.TextBox txtAvgFcfPerShareGrowth;
        private System.Windows.Forms.Label label36;
    }
}

