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
        	this.button1 = new System.Windows.Forms.Button();
        	this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
        	this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
        	this.label1 = new System.Windows.Forms.Label();
        	this.label2 = new System.Windows.Forms.Label();
        	this.label3 = new System.Windows.Forms.Label();
        	this.listBox1 = new System.Windows.Forms.ListBox();
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
        	this.comboBox1 = new System.Windows.Forms.ComboBox();
        	this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
        	((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
        	this.tabControl1.SuspendLayout();
        	this.tabPage1.SuspendLayout();
        	this.tabPage2.SuspendLayout();
        	((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
        	this.SuspendLayout();
        	// 
        	// button1
        	// 
        	this.button1.Location = new System.Drawing.Point(15, 73);
        	this.button1.Name = "button1";
        	this.button1.Size = new System.Drawing.Size(170, 30);
        	this.button1.TabIndex = 0;
        	this.button1.Text = "Читать данные  с сервера ";
        	this.button1.UseVisualStyleBackColor = true;
        	this.button1.Click += new System.EventHandler(this.button1_Click);
        	// 
        	// dateTimePicker1
        	// 
        	this.dateTimePicker1.Location = new System.Drawing.Point(51, 37);
        	this.dateTimePicker1.MaxDate = new System.DateTime(2100, 12, 31, 0, 0, 0, 0);
        	this.dateTimePicker1.MinDate = new System.DateTime(1990, 1, 1, 0, 0, 0, 0);
        	this.dateTimePicker1.Name = "dateTimePicker1";
        	this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
        	this.dateTimePicker1.TabIndex = 1;
        	// 
        	// dateTimePicker2
        	// 
        	this.dateTimePicker2.Location = new System.Drawing.Point(303, 37);
        	this.dateTimePicker2.MaxDate = new System.DateTime(2100, 12, 31, 0, 0, 0, 0);
        	this.dateTimePicker2.MinDate = new System.DateTime(1990, 1, 1, 0, 0, 0, 0);
        	this.dateTimePicker2.Name = "dateTimePicker2";
        	this.dateTimePicker2.Size = new System.Drawing.Size(200, 20);
        	this.dateTimePicker2.TabIndex = 2;
        	// 
        	// label1
        	// 
        	this.label1.AutoSize = true;
        	this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.label1.Location = new System.Drawing.Point(12, 41);
        	this.label1.Name = "label1";
        	this.label1.Size = new System.Drawing.Size(18, 16);
        	this.label1.TabIndex = 3;
        	this.label1.Text = "C";
        	// 
        	// label2
        	// 
        	this.label2.AutoSize = true;
        	this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.label2.Location = new System.Drawing.Point(265, 41);
        	this.label2.Name = "label2";
        	this.label2.Size = new System.Drawing.Size(30, 16);
        	this.label2.TabIndex = 3;
        	this.label2.Text = "ПО";
        	// 
        	// label3
        	// 
        	this.label3.AutoSize = true;
        	this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.label3.Location = new System.Drawing.Point(12, 9);
        	this.label3.Name = "label3";
        	this.label3.Size = new System.Drawing.Size(315, 16);
        	this.label3.TabIndex = 3;
        	this.label3.Text = "Выберите период просмотра статистики:";
        	// 
        	// listBox1
        	// 
        	this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left)));
        	this.listBox1.FormattingEnabled = true;
        	this.listBox1.Location = new System.Drawing.Point(15, 110);
        	this.listBox1.Name = "listBox1";
        	this.listBox1.Size = new System.Drawing.Size(170, 394);
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
        	this.dataGridView1.Location = new System.Drawing.Point(3, 3);
        	this.dataGridView1.Name = "dataGridView1";
        	this.dataGridView1.ReadOnly = true;
        	this.dataGridView1.RowHeadersVisible = false;
        	this.dataGridView1.Size = new System.Drawing.Size(695, 387);
        	this.dataGridView1.TabIndex = 5;
        	// 
        	// ports
        	// 
        	this.ports.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
        	this.ports.HeaderText = "Порты";
        	this.ports.Name = "ports";
        	this.ports.ReadOnly = true;
        	this.ports.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
        	this.ports.Width = 46;
        	// 
        	// date
        	// 
        	this.date.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
        	this.date.HeaderText = "Дата";
        	this.date.Name = "date";
        	this.date.ReadOnly = true;
        	this.date.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
        	this.date.Width = 39;
        	// 
        	// bbe
        	// 
        	this.bbe.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
        	this.bbe.HeaderText = "BBE";
        	this.bbe.Name = "bbe";
        	this.bbe.ReadOnly = true;
        	this.bbe.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
        	this.bbe.Width = 34;
        	// 
        	// ES
        	// 
        	this.ES.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
        	this.ES.HeaderText = "ES";
        	this.ES.Name = "ES";
        	this.ES.ReadOnly = true;
        	this.ES.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
        	this.ES.Width = 27;
        	// 
        	// SES
        	// 
        	this.SES.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
        	this.SES.HeaderText = "SES";
        	this.SES.Name = "SES";
        	this.SES.ReadOnly = true;
        	this.SES.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
        	this.SES.Width = 34;
        	// 
        	// NEUAS
        	// 
        	this.NEUAS.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
        	this.NEUAS.HeaderText = "NEUAS";
        	this.NEUAS.Name = "NEUAS";
        	this.NEUAS.ReadOnly = true;
        	this.NEUAS.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
        	this.NEUAS.Width = 50;
        	// 
        	// FEBBE
        	// 
        	this.FEBBE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
        	this.FEBBE.HeaderText = "FEBBE";
        	this.FEBBE.Name = "FEBBE";
        	this.FEBBE.ReadOnly = true;
        	this.FEBBE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
        	this.FEBBE.Width = 47;
        	// 
        	// FEES
        	// 
        	this.FEES.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
        	this.FEES.HeaderText = "FEES";
        	this.FEES.Name = "FEES";
        	this.FEES.ReadOnly = true;
        	this.FEES.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
        	this.FEES.Width = 40;
        	// 
        	// FESES
        	// 
        	this.FESES.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
        	this.FESES.HeaderText = "FESES";
        	this.FESES.Name = "FESES";
        	this.FESES.ReadOnly = true;
        	this.FESES.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
        	this.FESES.Width = 47;
        	// 
        	// FEUAS
        	// 
        	this.FEUAS.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
        	this.FEUAS.HeaderText = "FEUAS";
        	this.FEUAS.Name = "FEUAS";
        	this.FEUAS.ReadOnly = true;
        	this.FEUAS.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
        	this.FEUAS.Width = 48;
        	// 
        	// label4
        	// 
        	this.label4.AutoSize = true;
        	this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.label4.Location = new System.Drawing.Point(191, 85);
        	this.label4.Name = "label4";
        	this.label4.Size = new System.Drawing.Size(0, 18);
        	this.label4.TabIndex = 6;
        	// 
        	// button2
        	// 
        	this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        	this.button2.Location = new System.Drawing.Point(777, 9);
        	this.button2.Name = "button2";
        	this.button2.Size = new System.Drawing.Size(113, 48);
        	this.button2.TabIndex = 7;
        	this.button2.Text = "Считать локальную папку";
        	this.button2.UseVisualStyleBackColor = true;
        	this.button2.Click += new System.EventHandler(this.button2_Click);
        	// 
        	// checkBox1
        	// 
        	this.checkBox1.Location = new System.Drawing.Point(333, 6);
        	this.checkBox1.Name = "checkBox1";
        	this.checkBox1.Size = new System.Drawing.Size(321, 24);
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
        	this.tabControl1.Location = new System.Drawing.Point(194, 85);
        	this.tabControl1.Margin = new System.Windows.Forms.Padding(0);
        	this.tabControl1.Name = "tabControl1";
        	this.tabControl1.SelectedIndex = 0;
        	this.tabControl1.Size = new System.Drawing.Size(709, 419);
        	this.tabControl1.TabIndex = 10;
        	// 
        	// tabPage1
        	// 
        	this.tabPage1.Controls.Add(this.dataGridView1);
        	this.tabPage1.Location = new System.Drawing.Point(4, 22);
        	this.tabPage1.Name = "tabPage1";
        	this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
        	this.tabPage1.Size = new System.Drawing.Size(701, 393);
        	this.tabPage1.TabIndex = 0;
        	this.tabPage1.Text = "Таблица";
        	this.tabPage1.UseVisualStyleBackColor = true;
        	// 
        	// tabPage2
        	// 
        	this.tabPage2.Controls.Add(this.comboBox1);
        	this.tabPage2.Controls.Add(this.chart1);
        	this.tabPage2.Location = new System.Drawing.Point(4, 22);
        	this.tabPage2.Name = "tabPage2";
        	this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
        	this.tabPage2.Size = new System.Drawing.Size(701, 393);
        	this.tabPage2.TabIndex = 1;
        	this.tabPage2.Text = "График";
        	this.tabPage2.UseVisualStyleBackColor = true;
        	// 
        	// comboBox1
        	// 
        	this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        	this.comboBox1.FormattingEnabled = true;
        	this.comboBox1.Location = new System.Drawing.Point(538, 20);
        	this.comboBox1.Name = "comboBox1";
        	this.comboBox1.Size = new System.Drawing.Size(121, 21);
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
        	chartArea1.Name = "ChartArea1";
        	this.chart1.ChartAreas.Add(chartArea1);
        	this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
        	legend1.Name = "Legend1";
        	this.chart1.Legends.Add(legend1);
        	this.chart1.Location = new System.Drawing.Point(3, 3);
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
        	this.chart1.Size = new System.Drawing.Size(695, 387);
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
        	// Form1
        	// 
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.ClientSize = new System.Drawing.Size(900, 508);
        	this.Controls.Add(this.tabControl1);
        	this.Controls.Add(this.checkBox1);
        	this.Controls.Add(this.button2);
        	this.Controls.Add(this.label4);
        	this.Controls.Add(this.listBox1);
        	this.Controls.Add(this.label2);
        	this.Controls.Add(this.label3);
        	this.Controls.Add(this.label1);
        	this.Controls.Add(this.dateTimePicker2);
        	this.Controls.Add(this.dateTimePicker1);
        	this.Controls.Add(this.button1);
        	this.MinimumSize = new System.Drawing.Size(664, 416);
        	this.Name = "Form1";
        	this.Text = "PM Reader";
        	((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
        	this.tabControl1.ResumeLayout(false);
        	this.tabPage1.ResumeLayout(false);
        	this.tabPage2.ResumeLayout(false);
        	((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
        	this.ResumeLayout(false);
        	this.PerformLayout();

        }
        private System.Windows.Forms.CheckBox checkBox1;

        #endregion

        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.DateTimePicker dateTimePicker1;
        public System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox listBox1;
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
    }
}

