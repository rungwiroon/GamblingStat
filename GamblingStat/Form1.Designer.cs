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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dragonButton = new System.Windows.Forms.Button();
            this.tigerButton = new System.Windows.Forms.Button();
            this.undoButton = new System.Windows.Forms.Button();
            this.actualTigerPercentageLabel = new System.Windows.Forms.Label();
            this.actualDragonPercentageLabel = new System.Windows.Forms.Label();
            this.topPredictionModeComboBox = new System.Windows.Forms.ComboBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.AlgorithmType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WrongCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.betTigerPercentageLabel = new System.Windows.Forms.Label();
            this.betDragonPercentageLabel = new System.Windows.Forms.Label();
            this.dragonPredictionButton = new System.Windows.Forms.Button();
            this.tigerPredictionButton = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Result = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clearButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lookBehideNumeric = new System.Windows.Forms.NumericUpDown();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.winCountNumeric = new System.Windows.Forms.NumericUpDown();
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
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookBehideNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.winCountNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.topPredictionModelBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.keyValueModelBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scoreBoardModelBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.topPredictionModelBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // dragonButton
            // 
            this.dragonButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.854546F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.dragonButton.ForeColor = System.Drawing.Color.Red;
            this.dragonButton.Location = new System.Drawing.Point(29, 24);
            this.dragonButton.Name = "dragonButton";
            this.dragonButton.Size = new System.Drawing.Size(104, 32);
            this.dragonButton.TabIndex = 1;
            this.dragonButton.Text = "Dragon";
            this.dragonButton.UseVisualStyleBackColor = true;
            this.dragonButton.Click += new System.EventHandler(this.dragonButton_Click);
            // 
            // tigerButton
            // 
            this.tigerButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.854546F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.tigerButton.ForeColor = System.Drawing.Color.Blue;
            this.tigerButton.Location = new System.Drawing.Point(171, 24);
            this.tigerButton.Name = "tigerButton";
            this.tigerButton.Size = new System.Drawing.Size(104, 32);
            this.tigerButton.TabIndex = 2;
            this.tigerButton.Text = "Tiger";
            this.tigerButton.UseVisualStyleBackColor = true;
            this.tigerButton.Click += new System.EventHandler(this.tigerButton_Click);
            // 
            // undoButton
            // 
            this.undoButton.Location = new System.Drawing.Point(322, 24);
            this.undoButton.Name = "undoButton";
            this.undoButton.Size = new System.Drawing.Size(66, 32);
            this.undoButton.TabIndex = 7;
            this.undoButton.Text = "Undo";
            this.undoButton.UseVisualStyleBackColor = true;
            this.undoButton.Click += new System.EventHandler(this.undoButton_Click);
            // 
            // actualTigerPercentageLabel
            // 
            this.actualTigerPercentageLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.actualTigerPercentageLabel.AutoSize = true;
            this.actualTigerPercentageLabel.Location = new System.Drawing.Point(261, 532);
            this.actualTigerPercentageLabel.Name = "actualTigerPercentageLabel";
            this.actualTigerPercentageLabel.Size = new System.Drawing.Size(37, 13);
            this.actualTigerPercentageLabel.TabIndex = 9;
            this.actualTigerPercentageLabel.Text = "T : 0%";
            // 
            // actualDragonPercentageLabel
            // 
            this.actualDragonPercentageLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.actualDragonPercentageLabel.AutoSize = true;
            this.actualDragonPercentageLabel.Location = new System.Drawing.Point(126, 533);
            this.actualDragonPercentageLabel.Name = "actualDragonPercentageLabel";
            this.actualDragonPercentageLabel.Size = new System.Drawing.Size(38, 13);
            this.actualDragonPercentageLabel.TabIndex = 8;
            this.actualDragonPercentageLabel.Text = "D : 0%";
            // 
            // topPredictionModeComboBox
            // 
            this.topPredictionModeComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.topPredictionModeComboBox.FormattingEnabled = true;
            this.topPredictionModeComboBox.Items.AddRange(new object[] {
            "100%",
            ">= 80%",
            ">= 70%",
            ">= 60%",
            ">= 50%"});
            this.topPredictionModeComboBox.Location = new System.Drawing.Point(466, 543);
            this.topPredictionModeComboBox.Name = "topPredictionModeComboBox";
            this.topPredictionModeComboBox.Size = new System.Drawing.Size(92, 21);
            this.topPredictionModeComboBox.TabIndex = 15;
            this.topPredictionModeComboBox.SelectedIndexChanged += new System.EventHandler(this.topPredictionModeComboBox_SelectedIndexChanged);
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView2.AutoGenerateColumns = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.predictionScoreDataGridViewTextBoxColumn,
            this.winRateDataGridViewTextBoxColumn1,
            this.selectedDataGridViewTextBoxColumn,
            this.AlgorithmType,
            this.WrongCount});
            this.dataGridView2.DataSource = this.topPredictionModelBindingSource;
            this.dataGridView2.Location = new System.Drawing.Point(429, 74);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(306, 452);
            this.dataGridView2.TabIndex = 12;
            this.dataGridView2.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView2_CellFormatting);
            // 
            // AlgorithmType
            // 
            this.AlgorithmType.DataPropertyName = "AlgorithmType";
            this.AlgorithmType.HeaderText = "AlgorithmType";
            this.AlgorithmType.Name = "AlgorithmType";
            this.AlgorithmType.ReadOnly = true;
            this.AlgorithmType.Width = 50;
            // 
            // WrongCount
            // 
            this.WrongCount.DataPropertyName = "WrongCount";
            this.WrongCount.HeaderText = "WrongCount";
            this.WrongCount.Name = "WrongCount";
            this.WrongCount.ReadOnly = true;
            this.WrongCount.Width = 40;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 532);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Actual Score";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 556);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Bet Score";
            // 
            // betTigerPercentageLabel
            // 
            this.betTigerPercentageLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.betTigerPercentageLabel.AutoSize = true;
            this.betTigerPercentageLabel.Location = new System.Drawing.Point(261, 555);
            this.betTigerPercentageLabel.Name = "betTigerPercentageLabel";
            this.betTigerPercentageLabel.Size = new System.Drawing.Size(37, 13);
            this.betTigerPercentageLabel.TabIndex = 19;
            this.betTigerPercentageLabel.Text = "T : 0%";
            // 
            // betDragonPercentageLabel
            // 
            this.betDragonPercentageLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.betDragonPercentageLabel.AutoSize = true;
            this.betDragonPercentageLabel.Location = new System.Drawing.Point(126, 556);
            this.betDragonPercentageLabel.Name = "betDragonPercentageLabel";
            this.betDragonPercentageLabel.Size = new System.Drawing.Size(38, 13);
            this.betDragonPercentageLabel.TabIndex = 18;
            this.betDragonPercentageLabel.Text = "D : 0%";
            // 
            // dragonPredictionButton
            // 
            this.dragonPredictionButton.BackColor = System.Drawing.Color.Red;
            this.dragonPredictionButton.FlatAppearance.BorderSize = 4;
            this.dragonPredictionButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.dragonPredictionButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dragonPredictionButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.818182F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.dragonPredictionButton.ForeColor = System.Drawing.Color.White;
            this.dragonPredictionButton.Location = new System.Drawing.Point(425, 24);
            this.dragonPredictionButton.Name = "dragonPredictionButton";
            this.dragonPredictionButton.Size = new System.Drawing.Size(138, 32);
            this.dragonPredictionButton.TabIndex = 20;
            this.dragonPredictionButton.Text = "Bet D : 0%";
            this.dragonPredictionButton.UseVisualStyleBackColor = false;
            this.dragonPredictionButton.Click += new System.EventHandler(this.dragonPredictionButton_Click);
            // 
            // tigerPredictionButton
            // 
            this.tigerPredictionButton.BackColor = System.Drawing.Color.Blue;
            this.tigerPredictionButton.FlatAppearance.BorderSize = 4;
            this.tigerPredictionButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.tigerPredictionButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tigerPredictionButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.818182F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.tigerPredictionButton.ForeColor = System.Drawing.Color.White;
            this.tigerPredictionButton.Location = new System.Drawing.Point(601, 25);
            this.tigerPredictionButton.Name = "tigerPredictionButton";
            this.tigerPredictionButton.Size = new System.Drawing.Size(138, 32);
            this.tigerPredictionButton.TabIndex = 21;
            this.tigerPredictionButton.Text = "Bet T : 0%";
            this.tigerPredictionButton.UseVisualStyleBackColor = false;
            this.tigerPredictionButton.Click += new System.EventHandler(this.tigerPredictionButton_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.noDataGridViewTextBoxColumn,
            this.actualScoreDataGridViewTextBoxColumn,
            this.betScoreDataGridViewTextBoxColumn,
            this.Result,
            this.winRateDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.scoreBoardModelBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(29, 74);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(360, 452);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            // 
            // Result
            // 
            this.Result.DataPropertyName = "Result";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Result.DefaultCellStyle = dataGridViewCellStyle4;
            this.Result.HeaderText = "Result";
            this.Result.Name = "Result";
            this.Result.ReadOnly = true;
            this.Result.Width = 50;
            // 
            // clearButton
            // 
            this.clearButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.clearButton.Location = new System.Drawing.Point(370, 536);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(75, 32);
            this.clearButton.TabIndex = 24;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(589, 532);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "Look behide";
            // 
            // lookBehideNumeric
            // 
            this.lookBehideNumeric.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lookBehideNumeric.Location = new System.Drawing.Point(591, 550);
            this.lookBehideNumeric.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.lookBehideNumeric.Name = "lookBehideNumeric";
            this.lookBehideNumeric.Size = new System.Drawing.Size(63, 20);
            this.lookBehideNumeric.TabIndex = 22;
            this.lookBehideNumeric.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
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
            this.label4.Location = new System.Drawing.Point(675, 532);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 26;
            this.label4.Text = "Win count";
            // 
            // winCountNumeric
            // 
            this.winCountNumeric.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.winCountNumeric.Location = new System.Drawing.Point(671, 550);
            this.winCountNumeric.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.winCountNumeric.Name = "winCountNumeric";
            this.winCountNumeric.Size = new System.Drawing.Size(63, 20);
            this.winCountNumeric.TabIndex = 25;
            this.winCountNumeric.Value = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.winCountNumeric.ValueChanged += new System.EventHandler(this.winCountNumeric_ValueChanged);
            // 
            // predictionScoreDataGridViewTextBoxColumn
            // 
            this.predictionScoreDataGridViewTextBoxColumn.DataPropertyName = "PredictionScore";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            this.predictionScoreDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.predictionScoreDataGridViewTextBoxColumn.HeaderText = "PredictionScore";
            this.predictionScoreDataGridViewTextBoxColumn.Name = "predictionScoreDataGridViewTextBoxColumn";
            this.predictionScoreDataGridViewTextBoxColumn.ReadOnly = true;
            this.predictionScoreDataGridViewTextBoxColumn.Width = 50;
            // 
            // winRateDataGridViewTextBoxColumn1
            // 
            this.winRateDataGridViewTextBoxColumn1.DataPropertyName = "WinRate";
            this.winRateDataGridViewTextBoxColumn1.HeaderText = "WinRate";
            this.winRateDataGridViewTextBoxColumn1.Name = "winRateDataGridViewTextBoxColumn1";
            this.winRateDataGridViewTextBoxColumn1.ReadOnly = true;
            this.winRateDataGridViewTextBoxColumn1.Width = 60;
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
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            this.actualScoreDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.actualScoreDataGridViewTextBoxColumn.HeaderText = "ActualScore";
            this.actualScoreDataGridViewTextBoxColumn.MinimumWidth = 20;
            this.actualScoreDataGridViewTextBoxColumn.Name = "actualScoreDataGridViewTextBoxColumn";
            this.actualScoreDataGridViewTextBoxColumn.ReadOnly = true;
            this.actualScoreDataGridViewTextBoxColumn.Width = 50;
            // 
            // betScoreDataGridViewTextBoxColumn
            // 
            this.betScoreDataGridViewTextBoxColumn.DataPropertyName = "BetScore";
            this.betScoreDataGridViewTextBoxColumn.DataSource = this.keyValueModelBindingSource;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.betScoreDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.betScoreDataGridViewTextBoxColumn.DisplayMember = "Key";
            this.betScoreDataGridViewTextBoxColumn.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.betScoreDataGridViewTextBoxColumn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.betScoreDataGridViewTextBoxColumn.HeaderText = "BetScore";
            this.betScoreDataGridViewTextBoxColumn.Name = "betScoreDataGridViewTextBoxColumn";
            this.betScoreDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.betScoreDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.betScoreDataGridViewTextBoxColumn.ValueMember = "Value";
            this.betScoreDataGridViewTextBoxColumn.Width = 70;
            // 
            // keyValueModelBindingSource
            // 
            this.keyValueModelBindingSource.DataSource = typeof(GamblingStat.Models.KeyValueModel);
            // 
            // winRateDataGridViewTextBoxColumn
            // 
            this.winRateDataGridViewTextBoxColumn.DataPropertyName = "WinRate";
            dataGridViewCellStyle5.NullValue = null;
            this.winRateDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.winRateDataGridViewTextBoxColumn.HeaderText = "WinRate %";
            this.winRateDataGridViewTextBoxColumn.Name = "winRateDataGridViewTextBoxColumn";
            this.winRateDataGridViewTextBoxColumn.ReadOnly = true;
            this.winRateDataGridViewTextBoxColumn.Width = 70;
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
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(766, 578);
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
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.actualTigerPercentageLabel);
            this.Controls.Add(this.actualDragonPercentageLabel);
            this.Controls.Add(this.undoButton);
            this.Controls.Add(this.tigerButton);
            this.Controls.Add(this.dragonButton);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookBehideNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.winCountNumeric)).EndInit();
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
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn predictionScoreDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn winRateDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn selectedDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn AlgorithmType;
        private System.Windows.Forms.DataGridViewTextBoxColumn WrongCount;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn noDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn actualScoreDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn betScoreDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Result;
        private System.Windows.Forms.DataGridViewTextBoxColumn winRateDataGridViewTextBoxColumn;
    }
}

