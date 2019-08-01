namespace PMReader
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
        	System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
        	System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
        	System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
        	System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
        	System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
        	System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
        	System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
        	System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
        	this.button1 = new System.Windows.Forms.Button();
        	this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
        	this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
        	this.label1 = new System.Windows.Forms.Label();
        	this.label2 = new System.Windows.Forms.Label();
        	this.label3 = new System.Windows.Forms.Label();
        	this.listBox1 = new PMReader.Form1.MyListBox();
        	this.dataGridView1 = new System.Windows.Forms.DataGridView();
        	this.ports = new System.Windows.Forms.DataGridViewTextBoxColumn();
        	this.date = new System.Windows.Forms.DataGridViewTextBoxColumn();
        	this.bbe = new System.Windows.Forms.DataGridViewTextBoxColumn();
        	this.ES = new System.Windows.Forms.DataGridViewTextBoxColumn();
        	this.SES = new System.Windows.Forms.DataGridViewTextBoxColumn();
        	this.NEUAS = new System.Windows.Forms.DataGridViewTextBoxColumn();
        	this.FEBBE = new System.Windows.Forms.DataGridViewTextBoxColumn();
        	this.FEES = new System.Windows.Forms.DataGridViewTextBoxColumn();
        	this.FESES = new System.Windows.Forms.DataGridViewTextBoxColumn();
        	this.FEUAS = new System.Windows.Forms.DataGridViewTextBoxColumn();
        	this.label4 = new System.Windows.Forms.Label();
        	this.button2 = new System.Windows.Forms.Button();
        	this.checkBox1 = new System.Windows.Forms.CheckBox();
        	this.tabControl1 = new System.Windows.Forms.TabControl();
        	this.tabPage1 = new System.Windows.Forms.TabPage();
        	this.tabPage2 = new System.Windows.Forms.TabPage();
        	this.comboBox3 = new System.Windows.Forms.ComboBox();
        	this.comboBox1 = new System.Windows.Forms.ComboBox();
        	this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
        	this.tabPage3 = new System.Windows.Forms.TabPage();
        	this.dataGridView2 = new System.Windows.Forms.DataGridView();
        	this.ports15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        	this.date15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        	this.BBE15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        	this.ES15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        	this.SES15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        	this.NEUAS15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        	this.FEBBE15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        	this.FEES15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        	this.FESES15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        	this.FEUAS15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        	this.tabPage4 = new System.Windows.Forms.TabPage();
        	this.comboBox4 = new System.Windows.Forms.ComboBox();
        	this.comboBox2 = new System.Windows.Forms.ComboBox();
        	this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
        	this.button3 = new System.Windows.Forms.Button();
        	((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
        	this.tabControl1.SuspendLayout();
        	this.tabPage1.SuspendLayout();
        	this.tabPage2.SuspendLayout();
        	((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
        	this.tabPage3.SuspendLayout();
        	((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
        	this.tabPage4.SuspendLayout();
        	((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
        	this.SuspendLayout();
        	// 
        	// button1
        	// 
        	this.button1.Location = new System.Drawing.Point(4, 90);
        	this.button1.Margin = new System.Windows.Forms.Padding(4);
        	this.button1.Name = "button1";
        	this.button1.Size = new System.Drawing.Size(229, 37);
        	this.button1.TabIndex = 0;
        	this.button1.Text = "Показать статистику";
        	this.button1.UseVisualStyleBackColor = true;
        	this.button1.Click += new System.EventHandler(this.button1_Click);
        	// 
        	// dateTimePicker1
        	// 
        	this.dateTimePicker1.Location = new System.Drawing.Point(68, 46);
        	this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(4);
        	this.dateTimePicker1.MaxDate = new System.DateTime(2100, 12, 31, 0, 0, 0, 0);
        	this.dateTimePicker1.MinDate = new System.DateTime(1990, 1, 1, 0, 0, 0, 0);
        	this.dateTimePicker1.Name = "dateTimePicker1";
        	this.dateTimePicker1.Size = new System.Drawing.Size(265, 22);
        	this.dateTimePicker1.TabIndex = 1;
        	// 
        	// dateTimePicker2
        	// 
        	this.dateTimePicker2.Location = new System.Drawing.Point(404, 46);
        	this.dateTimePicker2.Margin = new System.Windows.Forms.Padding(4);
        	this.dateTimePicker2.MaxDate = new System.DateTime(2100, 12, 31, 0, 0, 0, 0);
        	this.dateTimePicker2.MinDate = new System.DateTime(1990, 1, 1, 0, 0, 0, 0);
        	this.dateTimePicker2.Name = "dateTimePicker2";
        	this.dateTimePicker2.Size = new System.Drawing.Size(265, 22);
        	this.dateTimePicker2.TabIndex = 2;
        	// 
        	// label1
        	// 
        	this.label1.AutoSize = true;
        	this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.label1.Location = new System.Drawing.Point(16, 50);
        	this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
        	this.label1.Name = "label1";
        	this.label1.Size = new System.Drawing.Size(22, 20);
        	this.label1.TabIndex = 3;
        	this.label1.Text = "C";
        	// 
        	// label2
        	// 
        	this.label2.AutoSize = true;
        	this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.label2.Location = new System.Drawing.Point(353, 50);
        	this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
        	this.label2.Name = "label2";
        	this.label2.Size = new System.Drawing.Size(37, 20);
        	this.label2.TabIndex = 3;
        	this.label2.Text = "ПО";
        	// 
        	// label3
        	// 
        	this.label3.AutoSize = true;
        	this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.label3.Location = new System.Drawing.Point(16, 11);
        	this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
        	this.label3.Name = "label3";
        	this.label3.Size = new System.Drawing.Size(400, 20);
        	this.label3.TabIndex = 3;
        	this.label3.Text = "Выберите период просмотра статистики:";
        	// 
        	// listBox1
        	// 
        	this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left)));
        	this.listBox1.FormattingEnabled = true;
        	this.listBox1.ItemHeight = 16;
        	this.listBox1.Location = new System.Drawing.Point(4, 135);
        	this.listBox1.Margin = new System.Windows.Forms.Padding(4);
        	this.listBox1.MultiColumn = true;
        	this.listBox1.Name = "listBox1";
        	this.listBox1.Size = new System.Drawing.Size(118, 484);
        	this.listBox1.TabIndex = 4;
        	// 
        	// dataGridView1
        	// 
        	this.dataGridView1.AllowUserToAddRows = false;
        	this.dataGridView1.AllowUserToDeleteRows = false;
        	this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        	this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
			this.ports,
			this.date,
			this.bbe,
			this.ES,
			this.SES,
			this.NEUAS,
			this.FEBBE,
			this.FEES,
			this.FESES,
			this.FEUAS});
        	this.dataGridView1.Cursor = System.Windows.Forms.Cursors.IBeam;
        	this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.dataGridView1.Location = new System.Drawing.Point(4, 4);
        	this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
        	this.dataGridView1.Name = "dataGridView1";
        	this.dataGridView1.ReadOnly = true;
        	this.dataGridView1.RowHeadersVisible = false;
        	this.dataGridView1.Size = new System.Drawing.Size(951, 479);
        	this.dataGridView1.TabIndex = 5;
        	this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView1CellContentClick);
        	// 
        	// ports
        	// 
        	this.ports.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
        	this.ports.HeaderText = "Порты";
        	this.ports.Name = "ports";
        	this.ports.ReadOnly = true;
        	this.ports.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
        	this.ports.Width = 57;
        	// 
        	// date
        	// 
        	this.date.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
        	this.date.HeaderText = "Дата";
        	this.date.Name = "date";
        	this.date.ReadOnly = true;
        	this.date.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
        	this.date.Width = 48;
        	// 
        	// bbe
        	// 
        	this.bbe.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
        	this.bbe.HeaderText = "BBE";
        	this.bbe.Name = "bbe";
        	this.bbe.ReadOnly = true;
        	this.bbe.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
        	this.bbe.Width = 41;
        	// 
        	// ES
        	// 
        	this.ES.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
        	this.ES.HeaderText = "ES";
        	this.ES.Name = "ES";
        	this.ES.ReadOnly = true;
        	this.ES.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
        	this.ES.Width = 32;
        	// 
        	// SES
        	// 
        	this.SES.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
        	this.SES.HeaderText = "SES";
        	this.SES.Name = "SES";
        	this.SES.ReadOnly = true;
        	this.SES.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
        	this.SES.Width = 41;
        	// 
        	// NEUAS
        	// 
        	this.NEUAS.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
        	this.NEUAS.HeaderText = "NEUAS";
        	this.NEUAS.Name = "NEUAS";
        	this.NEUAS.ReadOnly = true;
        	this.NEUAS.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
        	this.NEUAS.Width = 61;
        	// 
        	// FEBBE
        	// 
        	this.FEBBE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
        	this.FEBBE.HeaderText = "FEBBE";
        	this.FEBBE.Name = "FEBBE";
        	this.FEBBE.ReadOnly = true;
        	this.FEBBE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
        	this.FEBBE.Width = 58;
        	// 
        	// FEES
        	// 
        	this.FEES.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
        	this.FEES.HeaderText = "FEES";
        	this.FEES.Name = "FEES";
        	this.FEES.ReadOnly = true;
        	this.FEES.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
        	this.FEES.Width = 49;
        	// 
        	// FESES
        	// 
        	this.FESES.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
        	this.FESES.HeaderText = "FESES";
        	this.FESES.Name = "FESES";
        	this.FESES.ReadOnly = true;
        	this.FESES.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
        	this.FESES.Width = 58;
        	// 
        	// FEUAS
        	// 
        	this.FEUAS.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
        	this.FEUAS.HeaderText = "FEUAS";
        	this.FEUAS.Name = "FEUAS";
        	this.FEUAS.ReadOnly = true;
        	this.FEUAS.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
        	this.FEUAS.Width = 59;
        	// 
        	// label4
        	// 
        	this.label4.AutoSize = true;
        	this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.label4.Location = new System.Drawing.Point(263, 72);
        	this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
        	this.label4.Name = "label4";
        	this.label4.Size = new System.Drawing.Size(0, 24);
        	this.label4.TabIndex = 6;
        	// 
        	// button2
        	// 
        	this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        	this.button2.Location = new System.Drawing.Point(1036, 11);
        	this.button2.Margin = new System.Windows.Forms.Padding(4);
        	this.button2.Name = "button2";
        	this.button2.Size = new System.Drawing.Size(151, 59);
        	this.button2.TabIndex = 7;
        	this.button2.Text = "Считать локальную папку";
        	this.button2.UseVisualStyleBackColor = true;
        	this.button2.Click += new System.EventHandler(this.button2_Click);
        	// 
        	// checkBox1
        	// 
        	this.checkBox1.Checked = true;
        	this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
        	this.checkBox1.Location = new System.Drawing.Point(444, 7);
        	this.checkBox1.Margin = new System.Windows.Forms.Padding(4);
        	this.checkBox1.Name = "checkBox1";
        	this.checkBox1.Size = new System.Drawing.Size(428, 30);
        	this.checkBox1.TabIndex = 9;
        	this.checkBox1.Text = "Показать только результаты с ошибками";
        	this.checkBox1.UseVisualStyleBackColor = true;
        	this.checkBox1.CheckedChanged += new System.EventHandler(this.CheckBox1CheckedChanged);
        	// 
        	// tabControl1
        	// 
        	this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
        	this.tabControl1.Controls.Add(this.tabPage1);
        	this.tabControl1.Controls.Add(this.tabPage2);
        	this.tabControl1.Controls.Add(this.tabPage3);
        	this.tabControl1.Controls.Add(this.tabPage4);
        	this.tabControl1.Location = new System.Drawing.Point(237, 105);
        	this.tabControl1.Margin = new System.Windows.Forms.Padding(0);
        	this.tabControl1.Name = "tabControl1";
        	this.tabControl1.SelectedIndex = 0;
        	this.tabControl1.Size = new System.Drawing.Size(967, 516);
        	this.tabControl1.TabIndex = 10;
        	// 
        	// tabPage1
        	// 
        	this.tabPage1.Controls.Add(this.dataGridView1);
        	this.tabPage1.Location = new System.Drawing.Point(4, 25);
        	this.tabPage1.Margin = new System.Windows.Forms.Padding(4);
        	this.tabPage1.Name = "tabPage1";
        	this.tabPage1.Padding = new System.Windows.Forms.Padding(4);
        	this.tabPage1.Size = new System.Drawing.Size(959, 487);
        	this.tabPage1.TabIndex = 0;
        	this.tabPage1.Text = "ТаблицаPM24";
        	this.tabPage1.UseVisualStyleBackColor = true;
        	// 
        	// tabPage2
        	// 
        	this.tabPage2.Controls.Add(this.comboBox3);
        	this.tabPage2.Controls.Add(this.comboBox1);
        	this.tabPage2.Controls.Add(this.chart1);
        	this.tabPage2.Location = new System.Drawing.Point(4, 25);
        	this.tabPage2.Margin = new System.Windows.Forms.Padding(4);
        	this.tabPage2.Name = "tabPage2";
        	this.tabPage2.Padding = new System.Windows.Forms.Padding(4);
        	this.tabPage2.Size = new System.Drawing.Size(920, 487);
        	this.tabPage2.TabIndex = 1;
        	this.tabPage2.Text = "ГрафикPM24";
        	this.tabPage2.UseVisualStyleBackColor = true;
        	// 
        	// comboBox3
        	// 
        	this.comboBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        	this.comboBox3.FormattingEnabled = true;
        	this.comboBox3.Location = new System.Drawing.Point(163, 25);
        	this.comboBox3.Margin = new System.Windows.Forms.Padding(4);
        	this.comboBox3.Name = "comboBox3";
        	this.comboBox3.Size = new System.Drawing.Size(389, 24);
        	this.comboBox3.TabIndex = 11;
        	// 
        	// comboBox1
        	// 
        	this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        	this.comboBox1.FormattingEnabled = true;
        	this.comboBox1.Location = new System.Drawing.Point(700, 25);
        	this.comboBox1.Margin = new System.Windows.Forms.Padding(4);
        	this.comboBox1.Name = "comboBox1";
        	this.comboBox1.Size = new System.Drawing.Size(160, 24);
        	this.comboBox1.TabIndex = 11;
        	// 
        	// chart1
        	// 
        	this.chart1.AntiAliasing = System.Windows.Forms.DataVisualization.Charting.AntiAliasingStyles.Text;
        	this.chart1.BackColor = System.Drawing.SystemColors.Control;
        	this.chart1.BorderSkin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
        	this.chart1.BorderSkin.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom;
        	this.chart1.BorderSkin.BackSecondaryColor = System.Drawing.Color.Blue;
        	this.chart1.BorderSkin.PageColor = System.Drawing.SystemColors.Control;
        	this.chart1.BorderSkin.SkinStyle = System.Windows.Forms.DataVisualization.Charting.BorderSkinStyle.FrameThin5;
        	chartArea1.AxisX.ScaleBreakStyle.Enabled = true;
        	chartArea1.Name = "ChartArea1";
        	this.chart1.ChartAreas.Add(chartArea1);
        	this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
        	legend1.Alignment = System.Drawing.StringAlignment.Center;
        	legend1.Name = "Legend1";
        	this.chart1.Legends.Add(legend1);
        	this.chart1.Location = new System.Drawing.Point(4, 4);
        	this.chart1.Margin = new System.Windows.Forms.Padding(0);
        	this.chart1.Name = "chart1";
        	this.chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Berry;
        	series1.ChartArea = "ChartArea1";
        	series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
        	series1.Color = System.Drawing.Color.Red;
        	series1.CustomProperties = "EmptyPointValue=Zero";
        	series1.Legend = "Legend1";
        	series1.LegendText = "BBE";
        	series1.Name = "Series1";
        	series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Date;
        	series1.YValuesPerPoint = 2;
        	series1.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
        	this.chart1.Series.Add(series1);
        	this.chart1.Size = new System.Drawing.Size(912, 479);
        	this.chart1.TabIndex = 0;
        	this.chart1.Text = "BBE";
        	this.chart1.TextAntiAliasingQuality = System.Windows.Forms.DataVisualization.Charting.TextAntiAliasingQuality.SystemDefault;
        	title1.Alignment = System.Drawing.ContentAlignment.TopCenter;
        	title1.BackColor = System.Drawing.SystemColors.Control;
        	title1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	title1.Name = "Title1";
        	title1.Text = "График появления ошибок за выбранный период";
        	title1.ToolTip = "Период, за который отображены данные";
        	this.chart1.Titles.Add(title1);
        	this.chart1.Click += new System.EventHandler(this.Chart1Click);
        	// 
        	// tabPage3
        	// 
        	this.tabPage3.Controls.Add(this.dataGridView2);
        	this.tabPage3.Location = new System.Drawing.Point(4, 25);
        	this.tabPage3.Margin = new System.Windows.Forms.Padding(4);
        	this.tabPage3.Name = "tabPage3";
        	this.tabPage3.Size = new System.Drawing.Size(920, 487);
        	this.tabPage3.TabIndex = 2;
        	this.tabPage3.Text = "ТаблицаPM15";
        	this.tabPage3.UseVisualStyleBackColor = true;
        	// 
        	// dataGridView2
        	// 
        	this.dataGridView2.AllowUserToAddRows = false;
        	this.dataGridView2.AllowUserToDeleteRows = false;
        	this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        	this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
			this.ports15,
			this.date15,
			this.BBE15,
			this.ES15,
			this.SES15,
			this.NEUAS15,
			this.FEBBE15,
			this.FEES15,
			this.FESES15,
			this.FEUAS15});
        	this.dataGridView2.Cursor = System.Windows.Forms.Cursors.IBeam;
        	this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.dataGridView2.Location = new System.Drawing.Point(0, 0);
        	this.dataGridView2.Margin = new System.Windows.Forms.Padding(4);
        	this.dataGridView2.Name = "dataGridView2";
        	this.dataGridView2.ReadOnly = true;
        	this.dataGridView2.RowHeadersVisible = false;
        	this.dataGridView2.Size = new System.Drawing.Size(920, 487);
        	this.dataGridView2.TabIndex = 6;
        	// 
        	// ports15
        	// 
        	this.ports15.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
        	this.ports15.HeaderText = "Порты";
        	this.ports15.Name = "ports15";
        	this.ports15.ReadOnly = true;
        	this.ports15.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
        	this.ports15.Width = 57;
        	// 
        	// date15
        	// 
        	this.date15.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
        	this.date15.HeaderText = "Дата";
        	this.date15.Name = "date15";
        	this.date15.ReadOnly = true;
        	this.date15.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
        	this.date15.Width = 48;
        	// 
        	// BBE15
        	// 
        	this.BBE15.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
        	this.BBE15.HeaderText = "BBE";
        	this.BBE15.Name = "BBE15";
        	this.BBE15.ReadOnly = true;
        	this.BBE15.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
        	this.BBE15.Width = 41;
        	// 
        	// ES15
        	// 
        	this.ES15.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
        	this.ES15.HeaderText = "ES";
        	this.ES15.Name = "ES15";
        	this.ES15.ReadOnly = true;
        	this.ES15.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
        	this.ES15.Width = 32;
        	// 
        	// SES15
        	// 
        	this.SES15.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
        	this.SES15.HeaderText = "SES";
        	this.SES15.Name = "SES15";
        	this.SES15.ReadOnly = true;
        	this.SES15.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
        	this.SES15.Width = 41;
        	// 
        	// NEUAS15
        	// 
        	this.NEUAS15.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
        	this.NEUAS15.HeaderText = "NEUAS";
        	this.NEUAS15.Name = "NEUAS15";
        	this.NEUAS15.ReadOnly = true;
        	this.NEUAS15.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
        	this.NEUAS15.Width = 61;
        	// 
        	// FEBBE15
        	// 
        	this.FEBBE15.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
        	this.FEBBE15.HeaderText = "FEBBE";
        	this.FEBBE15.Name = "FEBBE15";
        	this.FEBBE15.ReadOnly = true;
        	this.FEBBE15.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
        	this.FEBBE15.Width = 58;
        	// 
        	// FEES15
        	// 
        	this.FEES15.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
        	this.FEES15.HeaderText = "FEES";
        	this.FEES15.Name = "FEES15";
        	this.FEES15.ReadOnly = true;
        	this.FEES15.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
        	this.FEES15.Width = 49;
        	// 
        	// FESES15
        	// 
        	this.FESES15.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
        	this.FESES15.HeaderText = "FESES";
        	this.FESES15.Name = "FESES15";
        	this.FESES15.ReadOnly = true;
        	this.FESES15.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
        	this.FESES15.Width = 58;
        	// 
        	// FEUAS15
        	// 
        	this.FEUAS15.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
        	this.FEUAS15.HeaderText = "FEUAS";
        	this.FEUAS15.Name = "FEUAS15";
        	this.FEUAS15.ReadOnly = true;
        	this.FEUAS15.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
        	this.FEUAS15.Width = 59;
        	// 
        	// tabPage4
        	// 
        	this.tabPage4.Controls.Add(this.comboBox4);
        	this.tabPage4.Controls.Add(this.comboBox2);
        	this.tabPage4.Controls.Add(this.chart2);
        	this.tabPage4.Location = new System.Drawing.Point(4, 25);
        	this.tabPage4.Margin = new System.Windows.Forms.Padding(4);
        	this.tabPage4.Name = "tabPage4";
        	this.tabPage4.Size = new System.Drawing.Size(920, 487);
        	this.tabPage4.TabIndex = 3;
        	this.tabPage4.Text = "ГрафикPM15";
        	this.tabPage4.UseVisualStyleBackColor = true;
        	// 
        	// comboBox4
        	// 
        	this.comboBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        	this.comboBox4.FormattingEnabled = true;
        	this.comboBox4.Location = new System.Drawing.Point(164, 21);
        	this.comboBox4.Margin = new System.Windows.Forms.Padding(4);
        	this.comboBox4.Name = "comboBox4";
        	this.comboBox4.Size = new System.Drawing.Size(395, 24);
        	this.comboBox4.TabIndex = 13;
        	// 
        	// comboBox2
        	// 
        	this.comboBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        	this.comboBox2.FormattingEnabled = true;
        	this.comboBox2.Location = new System.Drawing.Point(700, 21);
        	this.comboBox2.Margin = new System.Windows.Forms.Padding(4);
        	this.comboBox2.Name = "comboBox2";
        	this.comboBox2.Size = new System.Drawing.Size(160, 24);
        	this.comboBox2.TabIndex = 12;
        	// 
        	// chart2
        	// 
        	this.chart2.AntiAliasing = System.Windows.Forms.DataVisualization.Charting.AntiAliasingStyles.Text;
        	this.chart2.BackColor = System.Drawing.SystemColors.Control;
        	this.chart2.BorderSkin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
        	this.chart2.BorderSkin.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom;
        	this.chart2.BorderSkin.BackSecondaryColor = System.Drawing.Color.Blue;
        	this.chart2.BorderSkin.PageColor = System.Drawing.SystemColors.Control;
        	this.chart2.BorderSkin.SkinStyle = System.Windows.Forms.DataVisualization.Charting.BorderSkinStyle.FrameThin5;
        	chartArea2.AxisX.ScaleBreakStyle.Enabled = true;
        	chartArea2.Name = "ChartArea1";
        	this.chart2.ChartAreas.Add(chartArea2);
        	this.chart2.Dock = System.Windows.Forms.DockStyle.Fill;
        	legend2.Name = "Legend1";
        	this.chart2.Legends.Add(legend2);
        	this.chart2.Location = new System.Drawing.Point(0, 0);
        	this.chart2.Margin = new System.Windows.Forms.Padding(0);
        	this.chart2.Name = "chart2";
        	this.chart2.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Berry;
        	series2.ChartArea = "ChartArea1";
        	series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
        	series2.Color = System.Drawing.Color.Red;
        	series2.CustomProperties = "EmptyPointValue=Zero";
        	series2.Legend = "Legend1";
        	series2.LegendText = "BBE";
        	series2.Name = "Series1";
        	series2.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Date;
        	series2.YValuesPerPoint = 2;
        	series2.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
        	this.chart2.Series.Add(series2);
        	this.chart2.Size = new System.Drawing.Size(920, 487);
        	this.chart2.TabIndex = 1;
        	this.chart2.Text = "BBE";
        	this.chart2.TextAntiAliasingQuality = System.Windows.Forms.DataVisualization.Charting.TextAntiAliasingQuality.SystemDefault;
        	title2.Alignment = System.Drawing.ContentAlignment.TopCenter;
        	title2.BackColor = System.Drawing.SystemColors.Control;
        	title2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	title2.Name = "Title1";
        	title2.Text = "График появления ошибок за выбранный период";
        	title2.ToolTip = "Период, за который отображены данные";
        	this.chart2.Titles.Add(title2);
        	// 
        	// button3
        	// 
        	this.button3.Location = new System.Drawing.Point(715, 72);
        	this.button3.Name = "button3";
        	this.button3.Size = new System.Drawing.Size(75, 23);
        	this.button3.TabIndex = 11;
        	this.button3.Text = "button3";
        	this.button3.UseVisualStyleBackColor = true;
        	this.button3.Click += new System.EventHandler(this.Button3Click);
        	// 
        	// Form1
        	// 
        	this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
        	this.ClientSize = new System.Drawing.Size(1200, 625);
        	this.Controls.Add(this.button3);
        	this.Controls.Add(this.checkBox1);
        	this.Controls.Add(this.button2);
        	this.Controls.Add(this.label4);
        	this.Controls.Add(this.label2);
        	this.Controls.Add(this.label3);
        	this.Controls.Add(this.label1);
        	this.Controls.Add(this.dateTimePicker2);
        	this.Controls.Add(this.dateTimePicker1);
        	this.Controls.Add(this.button1);
        	this.Controls.Add(this.tabControl1);
        	this.Controls.Add(this.listBox1);
        	this.Margin = new System.Windows.Forms.Padding(4);
        	this.MinimumSize = new System.Drawing.Size(878, 500);
        	this.Name = "Form1";
        	this.Text = "PM Reader";
        	this.Load += new System.EventHandler(this.Form1Load);
        	((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
        	this.tabControl1.ResumeLayout(false);
        	this.tabPage1.ResumeLayout(false);
        	this.tabPage2.ResumeLayout(false);
        	((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
        	this.tabPage3.ResumeLayout(false);
        	((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
        	this.tabPage4.ResumeLayout(false);
        	((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
        	this.ResumeLayout(false);
        	this.PerformLayout();

        }
        public System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.CheckBox checkBox1;

        #endregion

        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.DateTimePicker dateTimePicker1;
        public System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ports;
        private System.Windows.Forms.DataGridViewTextBoxColumn date;
        private System.Windows.Forms.DataGridViewTextBoxColumn bbe;
        private System.Windows.Forms.DataGridViewTextBoxColumn ES;
        private System.Windows.Forms.DataGridViewTextBoxColumn SES;
        private System.Windows.Forms.DataGridViewTextBoxColumn NEUAS;
        private System.Windows.Forms.DataGridViewTextBoxColumn FEBBE;
        private System.Windows.Forms.DataGridViewTextBoxColumn FEES;
        private System.Windows.Forms.DataGridViewTextBoxColumn FESES;
        private System.Windows.Forms.DataGridViewTextBoxColumn FEUAS;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button2;
        public System.Windows.Forms.TabControl tabControl1;
        public System.Windows.Forms.TabPage tabPage1;
        public System.Windows.Forms.TabPage tabPage2;
        public System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ComboBox comboBox4;
        private System.Windows.Forms.DataGridViewTextBoxColumn ports15;
        private System.Windows.Forms.DataGridViewTextBoxColumn date15;
        private System.Windows.Forms.DataGridViewTextBoxColumn BBE15;
        private System.Windows.Forms.DataGridViewTextBoxColumn ES15;
        private System.Windows.Forms.DataGridViewTextBoxColumn SES15;
        private System.Windows.Forms.DataGridViewTextBoxColumn NEUAS15;
        private System.Windows.Forms.DataGridViewTextBoxColumn FEBBE15;
        private System.Windows.Forms.DataGridViewTextBoxColumn FEES15;
        private System.Windows.Forms.DataGridViewTextBoxColumn FESES15;
        private System.Windows.Forms.DataGridViewTextBoxColumn FEUAS15;
        public MyListBox listBox1;
    
    }
}

