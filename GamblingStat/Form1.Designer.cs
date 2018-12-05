namespace GamblingStat
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
            this.components = new System.ComponentModel.Container();
            GamblingStat.Properties.Settings settings1 = new GamblingStat.Properties.Settings();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dragonButton = new System.Windows.Forms.Button();
            this.tigerButton = new System.Windows.Forms.Button();
            this.undoButton = new System.Windows.Forms.Button();
            this.actualTigerPercentageLabel = new System.Windows.Forms.Label();
            this.actualDragonPercentageLabel = new System.Windows.Forms.Label();
            this.topPredictionModeComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.betTigerPercentageLabel = new System.Windows.Forms.Label();
            this.betDragonPercentageLabel = new System.Windows.Forms.Label();
            this.dragonPredictionButton = new System.Windows.Forms.Button();
            this.tigerPredictionButton = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Result = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DrTom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DrTomInfo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clearButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lookBehideNumeric = new System.Windows.Forms.NumericUpDown();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.winCountNumeric = new System.Windows.Forms.NumericUpDown();
            this.cartesianChart1 = new LiveCharts.WinForms.CartesianChart();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.WrongCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AlgorithmType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.predictionScoreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.winRateDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.selectedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.topPredictionModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.noDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.actualScoreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.betScoreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.keyValueModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.winRateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.scoreBoardModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.topPredictionModelBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookBehideNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.winCountNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.topPredictionModelBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.keyValueModelBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scoreBoardModelBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.topPredictionModelBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // dragonButton
            // 
            settings1.DragonColor = System.Drawing.Color.Red;
            settings1.LookBehide = new decimal(new int[] {
            15,
            0,
            0,
            0});
            settings1.MappingTableSize = 8;
            settings1.SettingsKey = "";
            settings1.TigerColor = System.Drawing.Color.Blue;
            this.dragonButton.DataBindings.Add(new System.Windows.Forms.Binding("ForeColor", settings1, "DragonColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dragonButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.854546F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.dragonButton.ForeColor = settings1.DragonColor;
            this.dragonButton.Location = new System.Drawing.Point(14, 15);
            this.dragonButton.Margin = new System.Windows.Forms.Padding(4);
            this.dragonButton.Name = "dragonButton";
            this.dragonButton.Size = new System.Drawing.Size(99, 39);
            this.dragonButton.TabIndex = 1;
            this.dragonButton.Text = "Dragon";
            this.dragonButton.UseVisualStyleBackColor = true;
            this.dragonButton.Click += new System.EventHandler(this.dragonButton_Click);
            // 
            // tigerButton
            // 
            this.tigerButton.DataBindings.Add(new System.Windows.Forms.Binding("ForeColor", settings1, "TigerColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tigerButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.854546F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.tigerButton.ForeColor = settings1.TigerColor;
            this.tigerButton.Location = new System.Drawing.Point(134, 15);
            this.tigerButton.Margin = new System.Windows.Forms.Padding(4);
            this.tigerButton.Name = "tigerButton";
            this.tigerButton.Size = new System.Drawing.Size(100, 39);
            this.tigerButton.TabIndex = 2;
            this.tigerButton.Text = "Tiger";
            this.tigerButton.UseVisualStyleBackColor = true;
            this.tigerButton.Click += new System.EventHandler(this.tigerButton_Click);
            // 
            // undoButton
            // 
            this.undoButton.Location = new System.Drawing.Point(263, 18);
            this.undoButton.Margin = new System.Windows.Forms.Padding(4);
            this.undoButton.Name = "undoButton";
            this.undoButton.Size = new System.Drawing.Size(69, 33);
            this.undoButton.TabIndex = 7;
            this.undoButton.Text = "Undo";
            this.undoButton.UseVisualStyleBackColor = true;
            this.undoButton.Click += new System.EventHandler(this.undoButton_Click);
            // 
            // actualTigerPercentageLabel
            // 
            this.actualTigerPercentageLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.actualTigerPercentageLabel.AutoSize = true;
            this.actualTigerPercentageLabel.Location = new System.Drawing.Point(237, 582);
            this.actualTigerPercentageLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.actualTigerPercentageLabel.Name = "actualTigerPercentageLabel";
            this.actualTigerPercentageLabel.Size = new System.Drawing.Size(49, 17);
            this.actualTigerPercentageLabel.TabIndex = 9;
            this.actualTigerPercentageLabel.Text = "T : 0%";
            // 
            // actualDragonPercentageLabel
            // 
            this.actualDragonPercentageLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.actualDragonPercentageLabel.AutoSize = true;
            this.actualDragonPercentageLabel.Location = new System.Drawing.Point(135, 583);
            this.actualDragonPercentageLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.actualDragonPercentageLabel.Name = "actualDragonPercentageLabel";
            this.actualDragonPercentageLabel.Size = new System.Drawing.Size(50, 17);
            this.actualDragonPercentageLabel.TabIndex = 8;
            this.actualDragonPercentageLabel.Text = "D : 0%";
            // 
            // topPredictionModeComboBox
            // 
            this.topPredictionModeComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.topPredictionModeComboBox.FormattingEnabled = true;
            this.topPredictionModeComboBox.Items.AddRange(new object[] {
            "100%",
            ">= 90%",
            ">= 80%",
            ">= 70%",
            ">= 60%",
            ">= 50%"});
            this.topPredictionModeComboBox.Location = new System.Drawing.Point(407, 595);
            this.topPredictionModeComboBox.Margin = new System.Windows.Forms.Padding(4);
            this.topPredictionModeComboBox.Name = "topPredictionModeComboBox";
            this.topPredictionModeComboBox.Size = new System.Drawing.Size(80, 24);
            this.topPredictionModeComboBox.TabIndex = 15;
            this.topPredictionModeComboBox.SelectedIndexChanged += new System.EventHandler(this.topPredictionModeComboBox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 582);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 17);
            this.label2.TabIndex = 16;
            this.label2.Text = "Actual Score";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 611);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 17);
            this.label3.TabIndex = 17;
            this.label3.Text = "Bet Score";
            // 
            // betTigerPercentageLabel
            // 
            this.betTigerPercentageLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.betTigerPercentageLabel.AutoSize = true;
            this.betTigerPercentageLabel.Location = new System.Drawing.Point(237, 610);
            this.betTigerPercentageLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.betTigerPercentageLabel.Name = "betTigerPercentageLabel";
            this.betTigerPercentageLabel.Size = new System.Drawing.Size(49, 17);
            this.betTigerPercentageLabel.TabIndex = 19;
            this.betTigerPercentageLabel.Text = "T : 0%";
            // 
            // betDragonPercentageLabel
            // 
            this.betDragonPercentageLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.betDragonPercentageLabel.AutoSize = true;
            this.betDragonPercentageLabel.Location = new System.Drawing.Point(135, 611);
            this.betDragonPercentageLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.betDragonPercentageLabel.Name = "betDragonPercentageLabel";
            this.betDragonPercentageLabel.Size = new System.Drawing.Size(50, 17);
            this.betDragonPercentageLabel.TabIndex = 18;
            this.betDragonPercentageLabel.Text = "D : 0%";
            // 
            // dragonPredictionButton
            // 
            this.dragonPredictionButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dragonPredictionButton.BackColor = settings1.DragonColor;
            this.dragonPredictionButton.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", settings1, "DragonColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dragonPredictionButton.FlatAppearance.BorderSize = 4;
            this.dragonPredictionButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.dragonPredictionButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dragonPredictionButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.765218F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.dragonPredictionButton.ForeColor = System.Drawing.Color.White;
            this.dragonPredictionButton.Location = new System.Drawing.Point(358, 8);
            this.dragonPredictionButton.Margin = new System.Windows.Forms.Padding(4);
            this.dragonPredictionButton.Name = "dragonPredictionButton";
            this.dragonPredictionButton.Size = new System.Drawing.Size(93, 58);
            this.dragonPredictionButton.TabIndex = 20;
            this.dragonPredictionButton.Text = "Bet D : 0%";
            this.dragonPredictionButton.UseVisualStyleBackColor = false;
            this.dragonPredictionButton.Click += new System.EventHandler(this.dragonPredictionButton_Click);
            // 
            // tigerPredictionButton
            // 
            this.tigerPredictionButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tigerPredictionButton.BackColor = settings1.TigerColor;
            this.tigerPredictionButton.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", settings1, "TigerColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tigerPredictionButton.FlatAppearance.BorderSize = 4;
            this.tigerPredictionButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.tigerPredictionButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tigerPredictionButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.765218F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.tigerPredictionButton.ForeColor = System.Drawing.Color.White;
            this.tigerPredictionButton.Location = new System.Drawing.Point(487, 8);
            this.tigerPredictionButton.Margin = new System.Windows.Forms.Padding(4);
            this.tigerPredictionButton.Name = "tigerPredictionButton";
            this.tigerPredictionButton.Size = new System.Drawing.Size(88, 58);
            this.tigerPredictionButton.TabIndex = 21;
            this.tigerPredictionButton.Text = "Bet T : 0%";
            this.tigerPredictionButton.UseVisualStyleBackColor = false;
            this.tigerPredictionButton.Click += new System.EventHandler(this.tigerPredictionButton_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.noDataGridViewTextBoxColumn,
            this.actualScoreDataGridViewTextBoxColumn,
            this.betScoreDataGridViewTextBoxColumn,
            this.Result,
            this.winRateDataGridViewTextBoxColumn,
            this.DrTom,
            this.DrTomInfo});
            this.dataGridView1.DataSource = this.scoreBoardModelBindingSource;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.01739F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView1.Location = new System.Drawing.Point(14, 76);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.139131F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridView1.RowHeadersWidth = 30;
            this.dataGridView1.Size = new System.Drawing.Size(299, 356);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            // 
            // Result
            // 
            this.Result.DataPropertyName = "Result";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.01739F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Result.DefaultCellStyle = dataGridViewCellStyle3;
            this.Result.HeaderText = "Result";
            this.Result.Name = "Result";
            this.Result.ReadOnly = true;
            this.Result.Width = 40;
            // 
            // DrTom
            // 
            this.DrTom.DataPropertyName = "DrTomResult";
            this.DrTom.HeaderText = "Dr.Tom Result";
            this.DrTom.Name = "DrTom";
            this.DrTom.ReadOnly = true;
            this.DrTom.Width = 40;
            // 
            // DrTomInfo
            // 
            this.DrTomInfo.DataPropertyName = "DrTomInfo";
            this.DrTomInfo.HeaderText = "Dr.Tom Info";
            this.DrTomInfo.Name = "DrTomInfo";
            this.DrTomInfo.ReadOnly = true;
            this.DrTomInfo.Width = 70;
            // 
            // clearButton
            // 
            this.clearButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.clearButton.Location = new System.Drawing.Point(314, 592);
            this.clearButton.Margin = new System.Windows.Forms.Padding(4);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(71, 32);
            this.clearButton.TabIndex = 24;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(508, 582);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 17);
            this.label1.TabIndex = 23;
            this.label1.Text = "Look behide";
            // 
            // lookBehideNumeric
            // 
            this.lookBehideNumeric.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lookBehideNumeric.DataBindings.Add(new System.Windows.Forms.Binding("Value", settings1, "LookBehide", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.lookBehideNumeric.Location = new System.Drawing.Point(510, 604);
            this.lookBehideNumeric.Margin = new System.Windows.Forms.Padding(4);
            this.lookBehideNumeric.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.lookBehideNumeric.Name = "lookBehideNumeric";
            this.lookBehideNumeric.Size = new System.Drawing.Size(57, 22);
            this.lookBehideNumeric.TabIndex = 22;
            this.lookBehideNumeric.Value = settings1.LookBehide;
            this.lookBehideNumeric.ValueChanged += new System.EventHandler(this.lookBehideNumeric_ValueChanged);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 400;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(763, 573);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 17);
            this.label4.TabIndex = 26;
            this.label4.Text = "Win count";
            this.label4.Visible = false;
            // 
            // winCountNumeric
            // 
            this.winCountNumeric.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.winCountNumeric.Location = new System.Drawing.Point(763, 595);
            this.winCountNumeric.Margin = new System.Windows.Forms.Padding(4);
            this.winCountNumeric.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.winCountNumeric.Name = "winCountNumeric";
            this.winCountNumeric.Size = new System.Drawing.Size(84, 22);
            this.winCountNumeric.TabIndex = 25;
            this.winCountNumeric.Value = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.winCountNumeric.Visible = false;
            this.winCountNumeric.ValueChanged += new System.EventHandler(this.winCountNumeric_ValueChanged);
            // 
            // cartesianChart1
            // 
            this.cartesianChart1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cartesianChart1.Location = new System.Drawing.Point(13, 440);
            this.cartesianChart1.Margin = new System.Windows.Forms.Padding(4);
            this.cartesianChart1.Name = "cartesianChart1";
            this.cartesianChart1.Size = new System.Drawing.Size(565, 138);
            this.cartesianChart1.TabIndex = 28;
            this.cartesianChart1.Text = "cartesianChart1";
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView2.AutoGenerateColumns = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.predictionScoreDataGridViewTextBoxColumn,
            this.winRateDataGridViewTextBoxColumn1,
            this.selectedDataGridViewTextBoxColumn,
            this.WrongCount,
            this.AlgorithmType});
            this.dataGridView2.DataSource = this.topPredictionModelBindingSource;
            this.dataGridView2.Location = new System.Drawing.Point(321, 76);
            this.dataGridView2.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 30;
            this.dataGridView2.Size = new System.Drawing.Size(254, 356);
            this.dataGridView2.TabIndex = 29;
            this.dataGridView2.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView2_CellFormatting);
            // 
            // WrongCount
            // 
            this.WrongCount.DataPropertyName = "WrongCount";
            this.WrongCount.HeaderText = "Wrong Count";
            this.WrongCount.Name = "WrongCount";
            this.WrongCount.ReadOnly = true;
            this.WrongCount.Width = 40;
            // 
            // AlgorithmType
            // 
            this.AlgorithmType.DataPropertyName = "AlgorithmType";
            this.AlgorithmType.HeaderText = "AlgorithmType";
            this.AlgorithmType.Name = "AlgorithmType";
            this.AlgorithmType.ReadOnly = true;
            this.AlgorithmType.Width = 50;
            // 
            // predictionScoreDataGridViewTextBoxColumn
            // 
            this.predictionScoreDataGridViewTextBoxColumn.DataPropertyName = "PredictionScore";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.White;
            this.predictionScoreDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle7;
            this.predictionScoreDataGridViewTextBoxColumn.HeaderText = "PredictionScore";
            this.predictionScoreDataGridViewTextBoxColumn.Name = "predictionScoreDataGridViewTextBoxColumn";
            this.predictionScoreDataGridViewTextBoxColumn.ReadOnly = true;
            this.predictionScoreDataGridViewTextBoxColumn.Width = 50;
            // 
            // winRateDataGridViewTextBoxColumn1
            // 
            this.winRateDataGridViewTextBoxColumn1.DataPropertyName = "WinRate";
            this.winRateDataGridViewTextBoxColumn1.HeaderText = "Win Rate";
            this.winRateDataGridViewTextBoxColumn1.Name = "winRateDataGridViewTextBoxColumn1";
            this.winRateDataGridViewTextBoxColumn1.ReadOnly = true;
            this.winRateDataGridViewTextBoxColumn1.Width = 40;
            // 
            // selectedDataGridViewTextBoxColumn
            // 
            this.selectedDataGridViewTextBoxColumn.DataPropertyName = "Selected";
            this.selectedDataGridViewTextBoxColumn.HeaderText = "Selected";
            this.selectedDataGridViewTextBoxColumn.Name = "selectedDataGridViewTextBoxColumn";
            this.selectedDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.selectedDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.selectedDataGridViewTextBoxColumn.Visible = false;
            this.selectedDataGridViewTextBoxColumn.Width = 40;
            // 
            // topPredictionModelBindingSource
            // 
            this.topPredictionModelBindingSource.AllowNew = false;
            this.topPredictionModelBindingSource.DataSource = typeof(GamblingStat.Models.PredictionModel);
            // 
            // noDataGridViewTextBoxColumn
            // 
            this.noDataGridViewTextBoxColumn.DataPropertyName = "No";
            this.noDataGridViewTextBoxColumn.HeaderText = "No";
            this.noDataGridViewTextBoxColumn.Name = "noDataGridViewTextBoxColumn";
            this.noDataGridViewTextBoxColumn.ReadOnly = true;
            this.noDataGridViewTextBoxColumn.Width = 40;
            // 
            // actualScoreDataGridViewTextBoxColumn
            // 
            this.actualScoreDataGridViewTextBoxColumn.DataPropertyName = "ActualScore";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.01739F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            this.actualScoreDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.actualScoreDataGridViewTextBoxColumn.HeaderText = "Actual Score";
            this.actualScoreDataGridViewTextBoxColumn.MinimumWidth = 20;
            this.actualScoreDataGridViewTextBoxColumn.Name = "actualScoreDataGridViewTextBoxColumn";
            this.actualScoreDataGridViewTextBoxColumn.ReadOnly = true;
            this.actualScoreDataGridViewTextBoxColumn.Width = 50;
            // 
            // betScoreDataGridViewTextBoxColumn
            // 
            this.betScoreDataGridViewTextBoxColumn.DataPropertyName = "BetScore";
            this.betScoreDataGridViewTextBoxColumn.DataSource = this.keyValueModelBindingSource;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.01739F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.betScoreDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.betScoreDataGridViewTextBoxColumn.DisplayMember = "Key";
            this.betScoreDataGridViewTextBoxColumn.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.betScoreDataGridViewTextBoxColumn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.betScoreDataGridViewTextBoxColumn.HeaderText = "Bet Score";
            this.betScoreDataGridViewTextBoxColumn.Name = "betScoreDataGridViewTextBoxColumn";
            this.betScoreDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.betScoreDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.betScoreDataGridViewTextBoxColumn.ValueMember = "Value";
            this.betScoreDataGridViewTextBoxColumn.Width = 60;
            // 
            // keyValueModelBindingSource
            // 
            this.keyValueModelBindingSource.DataSource = typeof(GamblingStat.Models.KeyValueModel);
            // 
            // winRateDataGridViewTextBoxColumn
            // 
            this.winRateDataGridViewTextBoxColumn.DataPropertyName = "WinRate";
            dataGridViewCellStyle4.NullValue = null;
            this.winRateDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.winRateDataGridViewTextBoxColumn.HeaderText = "Win Rate %";
            this.winRateDataGridViewTextBoxColumn.Name = "winRateDataGridViewTextBoxColumn";
            this.winRateDataGridViewTextBoxColumn.ReadOnly = true;
            this.winRateDataGridViewTextBoxColumn.Width = 40;
            // 
            // scoreBoardModelBindingSource
            // 
            this.scoreBoardModelBindingSource.AllowNew = false;
            this.scoreBoardModelBindingSource.DataSource = typeof(GamblingStat.Models.ScoreBoardModel);
            // 
            // topPredictionModelBindingSource1
            // 
            this.topPredictionModelBindingSource1.DataSource = typeof(GamblingStat.Models.PredictionModel);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(591, 640);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.cartesianChart1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.winCountNumeric);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lookBehideNumeric);
            this.Controls.Add(this.tigerPredictionButton);
            this.Controls.Add(this.dragonPredictionButton);
            this.Controls.Add(this.betTigerPercentageLabel);
            this.Controls.Add(this.betDragonPercentageLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.topPredictionModeComboBox);
            this.Controls.Add(this.actualTigerPercentageLabel);
            this.Controls.Add(this.actualDragonPercentageLabel);
            this.Controls.Add(this.undoButton);
            this.Controls.Add(this.tigerButton);
            this.Controls.Add(this.dragonButton);
            this.Controls.Add(this.dataGridView1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookBehideNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.winCountNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.topPredictionModelBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.keyValueModelBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.scoreBoardModelBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.topPredictionModelBindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button dragonButton;
        private System.Windows.Forms.Button tigerButton;
        private System.Windows.Forms.BindingSource scoreBoardModelBindingSource;
        private System.Windows.Forms.BindingSource topPredictionModelBindingSource;
        private System.Windows.Forms.BindingSource topPredictionModelBindingSource1;
        private System.Windows.Forms.Button undoButton;
        private System.Windows.Forms.Label actualTigerPercentageLabel;
        private System.Windows.Forms.Label actualDragonPercentageLabel;
        private System.Windows.Forms.ComboBox topPredictionModeComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label betTigerPercentageLabel;
        private System.Windows.Forms.Label betDragonPercentageLabel;
        private System.Windows.Forms.Button dragonPredictionButton;
        private System.Windows.Forms.Button tigerPredictionButton;
        private System.Windows.Forms.BindingSource keyValueModelBindingSource;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown lookBehideNumeric;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown winCountNumeric;
        private LiveCharts.WinForms.CartesianChart cartesianChart1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn predictionScoreDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn winRateDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn selectedDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn WrongCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn AlgorithmType;
        private System.Windows.Forms.DataGridViewTextBoxColumn noDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn actualScoreDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn betScoreDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Result;
        private System.Windows.Forms.DataGridViewTextBoxColumn winRateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DrTom;
        private System.Windows.Forms.DataGridViewTextBoxColumn DrTomInfo;
    }
}

