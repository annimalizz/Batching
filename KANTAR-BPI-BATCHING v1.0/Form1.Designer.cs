namespace KANTAR_BPI_BATCHING_v1._0
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
            this.driveListBox1 = new Microsoft.VisualBasic.Compatibility.VB6.DriveListBox();
            this.dirListBox1 = new Microsoft.VisualBasic.Compatibility.VB6.DirListBox();
            this.batchgridSML = new System.Windows.Forms.DataGridView();
            this.BatchName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalIMGCNT_COL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.batchgridLrg = new System.Windows.Forms.DataGridView();
            this.Pathname_COL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.batchname_COL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status_COL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalImagesCount_COL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalDuplicates_COL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addAltA_BTN = new System.Windows.Forms.Button();
            this.AddALL_BTN = new System.Windows.Forms.Button();
            this.truncate_BTN = new System.Windows.Forms.Button();
            this.Batch_BTN = new System.Windows.Forms.Button();
            this.cancel_BTN = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.Remove_BTN = new System.Windows.Forms.Button();
            this.Clear_BTN = new System.Windows.Forms.Button();
            this.Exit_BTN = new System.Windows.Forms.Button();
            this.TotalImgCnt = new System.Windows.Forms.Label();
            this.TotalImgCnt_TXTBOX = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.totalDup_TXTBOX = new System.Windows.Forms.TextBox();
            this.elapsedTime_TXTBOX = new System.Windows.Forms.TextBox();
            this.operator_txtbox = new System.Windows.Forms.TextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.ElapsedTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.batchgridSML)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.batchgridLrg)).BeginInit();
            this.SuspendLayout();
            // 
            // driveListBox1
            // 
            this.driveListBox1.FormattingEnabled = true;
            this.driveListBox1.Location = new System.Drawing.Point(12, 92);
            this.driveListBox1.Name = "driveListBox1";
            this.driveListBox1.Size = new System.Drawing.Size(232, 23);
            this.driveListBox1.TabIndex = 0;
            this.driveListBox1.SelectedIndexChanged += new System.EventHandler(this.driveListBox1_SelectedIndexChanged);
            // 
            // dirListBox1
            // 
            this.dirListBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dirListBox1.BackColor = System.Drawing.Color.PeachPuff;
            this.dirListBox1.FormattingEnabled = true;
            this.dirListBox1.IntegralHeight = false;
            this.dirListBox1.Location = new System.Drawing.Point(12, 121);
            this.dirListBox1.Name = "dirListBox1";
            this.dirListBox1.Size = new System.Drawing.Size(312, 378);
            this.dirListBox1.TabIndex = 1;
            this.dirListBox1.SelectedIndexChanged += new System.EventHandler(this.dirListBox1_SelectedIndexChanged);
            this.dirListBox1.DoubleClick += new System.EventHandler(this.dirListBox1_DoubleClick);
            // 
            // batchgridSML
            // 
            this.batchgridSML.AllowUserToAddRows = false;
            this.batchgridSML.AllowUserToDeleteRows = false;
            this.batchgridSML.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.batchgridSML.BackgroundColor = System.Drawing.Color.AntiqueWhite;
            this.batchgridSML.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.batchgridSML.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.BatchName,
            this.totalIMGCNT_COL,
            this.Column1,
            this.Column2});
            this.batchgridSML.Location = new System.Drawing.Point(330, 121);
            this.batchgridSML.Name = "batchgridSML";
            this.batchgridSML.ReadOnly = true;
            this.batchgridSML.RowHeadersVisible = false;
            this.batchgridSML.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.batchgridSML.Size = new System.Drawing.Size(273, 378);
            this.batchgridSML.TabIndex = 3;
            // 
            // BatchName
            // 
            this.BatchName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.BatchName.HeaderText = "BatchName";
            this.BatchName.Name = "BatchName";
            this.BatchName.ReadOnly = true;
            // 
            // totalIMGCNT_COL
            // 
            this.totalIMGCNT_COL.HeaderText = "Total Image Count";
            this.totalIMGCNT_COL.Name = "totalIMGCNT_COL";
            this.totalIMGCNT_COL.ReadOnly = true;
            this.totalIMGCNT_COL.Width = 139;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Pathname";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Visible = false;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "duplicates";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Visible = false;
            // 
            // batchgridLrg
            // 
            this.batchgridLrg.AllowUserToAddRows = false;
            this.batchgridLrg.AllowUserToDeleteRows = false;
            this.batchgridLrg.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.batchgridLrg.BackgroundColor = System.Drawing.Color.AntiqueWhite;
            this.batchgridLrg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.batchgridLrg.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Pathname_COL,
            this.batchname_COL,
            this.status_COL,
            this.TotalImagesCount_COL,
            this.Column3,
            this.totalDuplicates_COL});
            this.batchgridLrg.GridColor = System.Drawing.Color.Peru;
            this.batchgridLrg.Location = new System.Drawing.Point(609, 121);
            this.batchgridLrg.Name = "batchgridLrg";
            this.batchgridLrg.ReadOnly = true;
            this.batchgridLrg.RowHeadersVisible = false;
            this.batchgridLrg.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.batchgridLrg.Size = new System.Drawing.Size(735, 380);
            this.batchgridLrg.TabIndex = 4;
            this.batchgridLrg.SelectionChanged += new System.EventHandler(this.batchgridLrg_SelectionChanged);
            // 
            // Pathname_COL
            // 
            this.Pathname_COL.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Pathname_COL.HeaderText = "Pathname";
            this.Pathname_COL.Name = "Pathname_COL";
            this.Pathname_COL.ReadOnly = true;
            this.Pathname_COL.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // batchname_COL
            // 
            this.batchname_COL.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.batchname_COL.HeaderText = "BatchName";
            this.batchname_COL.Name = "batchname_COL";
            this.batchname_COL.ReadOnly = true;
            this.batchname_COL.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // status_COL
            // 
            this.status_COL.HeaderText = "Status";
            this.status_COL.Name = "status_COL";
            this.status_COL.ReadOnly = true;
            this.status_COL.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.status_COL.Width = 108;
            // 
            // TotalImagesCount_COL
            // 
            this.TotalImagesCount_COL.HeaderText = "Total Images Count";
            this.TotalImagesCount_COL.Name = "TotalImagesCount_COL";
            this.TotalImagesCount_COL.ReadOnly = true;
            this.TotalImagesCount_COL.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.TotalImagesCount_COL.Width = 108;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Total Valid Images Count";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column3.Width = 109;
            // 
            // totalDuplicates_COL
            // 
            this.totalDuplicates_COL.HeaderText = "Total Duplicates";
            this.totalDuplicates_COL.Name = "totalDuplicates_COL";
            this.totalDuplicates_COL.ReadOnly = true;
            this.totalDuplicates_COL.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.totalDuplicates_COL.Width = 108;
            // 
            // addAltA_BTN
            // 
            this.addAltA_BTN.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.addAltA_BTN.BackColor = System.Drawing.Color.PeachPuff;
            this.addAltA_BTN.Location = new System.Drawing.Point(340, 78);
            this.addAltA_BTN.Name = "addAltA_BTN";
            this.addAltA_BTN.Size = new System.Drawing.Size(105, 37);
            this.addAltA_BTN.TabIndex = 5;
            this.addAltA_BTN.Text = "&Add (Alt + A)";
            this.addAltA_BTN.UseVisualStyleBackColor = false;
            this.addAltA_BTN.Click += new System.EventHandler(this.add_BTN_Click);
            // 
            // AddALL_BTN
            // 
            this.AddALL_BTN.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.AddALL_BTN.BackColor = System.Drawing.Color.PeachPuff;
            this.AddALL_BTN.Location = new System.Drawing.Point(451, 78);
            this.AddALL_BTN.Name = "AddALL_BTN";
            this.AddALL_BTN.Size = new System.Drawing.Size(120, 37);
            this.AddALL_BTN.TabIndex = 6;
            this.AddALL_BTN.Text = "A&dd All (Alt + D)";
            this.AddALL_BTN.UseVisualStyleBackColor = false;
            this.AddALL_BTN.Click += new System.EventHandler(this.AddALL_BTN_Click);
            // 
            // truncate_BTN
            // 
            this.truncate_BTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.truncate_BTN.BackColor = System.Drawing.Color.DarkSalmon;
            this.truncate_BTN.ForeColor = System.Drawing.SystemColors.Desktop;
            this.truncate_BTN.Location = new System.Drawing.Point(1221, 67);
            this.truncate_BTN.Name = "truncate_BTN";
            this.truncate_BTN.Size = new System.Drawing.Size(122, 50);
            this.truncate_BTN.TabIndex = 7;
            this.truncate_BTN.Text = "TRUNCATE";
            this.truncate_BTN.UseVisualStyleBackColor = false;
            this.truncate_BTN.Click += new System.EventHandler(this.truncate_BTN_Click);
            // 
            // Batch_BTN
            // 
            this.Batch_BTN.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Batch_BTN.BackColor = System.Drawing.Color.Peru;
            this.Batch_BTN.Location = new System.Drawing.Point(609, 78);
            this.Batch_BTN.Name = "Batch_BTN";
            this.Batch_BTN.Size = new System.Drawing.Size(131, 39);
            this.Batch_BTN.TabIndex = 8;
            this.Batch_BTN.Text = "&Batch (Alt + B)";
            this.Batch_BTN.UseVisualStyleBackColor = false;
            this.Batch_BTN.Click += new System.EventHandler(this.Batch_BTN_Click);
            // 
            // cancel_BTN
            // 
            this.cancel_BTN.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cancel_BTN.BackColor = System.Drawing.Color.Peru;
            this.cancel_BTN.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancel_BTN.Location = new System.Drawing.Point(756, 78);
            this.cancel_BTN.Name = "cancel_BTN";
            this.cancel_BTN.Size = new System.Drawing.Size(165, 37);
            this.cancel_BTN.TabIndex = 9;
            this.cancel_BTN.Text = " &Cancel Batch (Alt + C)";
            this.cancel_BTN.UseVisualStyleBackColor = false;
            this.cancel_BTN.Click += new System.EventHandler(this.cancel_BTN_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(49, 547);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 22);
            this.label3.TabIndex = 11;
            this.label3.Text = "Operator:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // Remove_BTN
            // 
            this.Remove_BTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Remove_BTN.BackColor = System.Drawing.Color.Tomato;
            this.Remove_BTN.Location = new System.Drawing.Point(916, 514);
            this.Remove_BTN.Name = "Remove_BTN";
            this.Remove_BTN.Size = new System.Drawing.Size(139, 31);
            this.Remove_BTN.TabIndex = 12;
            this.Remove_BTN.Text = "&Remove (Alt + R)";
            this.Remove_BTN.UseVisualStyleBackColor = false;
            this.Remove_BTN.Click += new System.EventHandler(this.remove_Click);
            // 
            // Clear_BTN
            // 
            this.Clear_BTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Clear_BTN.BackColor = System.Drawing.Color.Tomato;
            this.Clear_BTN.Location = new System.Drawing.Point(1066, 514);
            this.Clear_BTN.Name = "Clear_BTN";
            this.Clear_BTN.Size = new System.Drawing.Size(116, 31);
            this.Clear_BTN.TabIndex = 13;
            this.Clear_BTN.Text = "C&lear (Alt + L)";
            this.Clear_BTN.UseVisualStyleBackColor = false;
            this.Clear_BTN.Click += new System.EventHandler(this.clearButtonClick);
            // 
            // Exit_BTN
            // 
            this.Exit_BTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Exit_BTN.BackColor = System.Drawing.Color.DarkOrange;
            this.Exit_BTN.Location = new System.Drawing.Point(1189, 514);
            this.Exit_BTN.Name = "Exit_BTN";
            this.Exit_BTN.Size = new System.Drawing.Size(112, 31);
            this.Exit_BTN.TabIndex = 14;
            this.Exit_BTN.Text = "Exit (Alt + &F4)";
            this.Exit_BTN.UseVisualStyleBackColor = false;
            this.Exit_BTN.Click += new System.EventHandler(this.Exit_BTN_Click);
            this.Exit_BTN.Enter += new System.EventHandler(this.Exit_BTN_Enter);
            this.Exit_BTN.MouseEnter += new System.EventHandler(this.Exit_BTN_MouseEnter);
            // 
            // TotalImgCnt
            // 
            this.TotalImgCnt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.TotalImgCnt.AutoSize = true;
            this.TotalImgCnt.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalImgCnt.Location = new System.Drawing.Point(527, 516);
            this.TotalImgCnt.Name = "TotalImgCnt";
            this.TotalImgCnt.Size = new System.Drawing.Size(184, 22);
            this.TotalImgCnt.TabIndex = 16;
            this.TotalImgCnt.Text = "Total Images Count :";
            this.TotalImgCnt.Click += new System.EventHandler(this.label2_Click);
            // 
            // TotalImgCnt_TXTBOX
            // 
            this.TotalImgCnt_TXTBOX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.TotalImgCnt_TXTBOX.BackColor = System.Drawing.Color.LightSalmon;
            this.TotalImgCnt_TXTBOX.Location = new System.Drawing.Point(717, 516);
            this.TotalImgCnt_TXTBOX.Name = "TotalImgCnt_TXTBOX";
            this.TotalImgCnt_TXTBOX.Size = new System.Drawing.Size(184, 22);
            this.TotalImgCnt_TXTBOX.TabIndex = 17;
            this.TotalImgCnt_TXTBOX.TextChanged += new System.EventHandler(this.TotalImgCnt_TXTBOX_TextChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(527, 549);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 22);
            this.label1.TabIndex = 18;
            this.label1.Text = "Total Duplicates :";
            this.label1.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(527, 575);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 22);
            this.label2.TabIndex = 19;
            this.label2.Text = "Elapsed Time :";
            // 
            // totalDup_TXTBOX
            // 
            this.totalDup_TXTBOX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.totalDup_TXTBOX.BackColor = System.Drawing.Color.LightSalmon;
            this.totalDup_TXTBOX.Location = new System.Drawing.Point(717, 549);
            this.totalDup_TXTBOX.Name = "totalDup_TXTBOX";
            this.totalDup_TXTBOX.Size = new System.Drawing.Size(184, 22);
            this.totalDup_TXTBOX.TabIndex = 20;
            // 
            // elapsedTime_TXTBOX
            // 
            this.elapsedTime_TXTBOX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.elapsedTime_TXTBOX.BackColor = System.Drawing.Color.LightSalmon;
            this.elapsedTime_TXTBOX.Location = new System.Drawing.Point(717, 579);
            this.elapsedTime_TXTBOX.Name = "elapsedTime_TXTBOX";
            this.elapsedTime_TXTBOX.Size = new System.Drawing.Size(184, 22);
            this.elapsedTime_TXTBOX.TabIndex = 21;
            this.elapsedTime_TXTBOX.TextChanged += new System.EventHandler(this.elapsedTime_TXTBOX_TextChanged);
            // 
            // operator_txtbox
            // 
            this.operator_txtbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.operator_txtbox.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.operator_txtbox.Location = new System.Drawing.Point(155, 544);
            this.operator_txtbox.Name = "operator_txtbox";
            this.operator_txtbox.Size = new System.Drawing.Size(119, 29);
            this.operator_txtbox.TabIndex = 22;
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.BackColor = System.Drawing.Color.Tan;
            this.progressBar1.Location = new System.Drawing.Point(997, 570);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(261, 23);
            this.progressBar1.TabIndex = 23;
            this.progressBar1.Click += new System.EventHandler(this.progressBar1_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // ElapsedTimer
            // 
            this.ElapsedTimer.Interval = 1000;
            this.ElapsedTimer.Tick += new System.EventHandler(this.ElapsedTimer_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Tan;
            this.ClientSize = new System.Drawing.Size(1364, 661);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.operator_txtbox);
            this.Controls.Add(this.elapsedTime_TXTBOX);
            this.Controls.Add(this.totalDup_TXTBOX);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TotalImgCnt_TXTBOX);
            this.Controls.Add(this.TotalImgCnt);
            this.Controls.Add(this.Exit_BTN);
            this.Controls.Add(this.Clear_BTN);
            this.Controls.Add(this.Remove_BTN);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cancel_BTN);
            this.Controls.Add(this.Batch_BTN);
            this.Controls.Add(this.truncate_BTN);
            this.Controls.Add(this.AddALL_BTN);
            this.Controls.Add(this.addAltA_BTN);
            this.Controls.Add(this.batchgridLrg);
            this.Controls.Add(this.batchgridSML);
            this.Controls.Add(this.dirListBox1);
            this.Controls.Add(this.driveListBox1);
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1150, 700);
            this.Name = "Form1";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "KANTAR-BPI BATCHING v1.8";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.batchgridSML)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.batchgridLrg)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.VisualBasic.Compatibility.VB6.DriveListBox driveListBox1;
        private Microsoft.VisualBasic.Compatibility.VB6.DirListBox dirListBox1;
        private System.Windows.Forms.DataGridView batchgridSML;
        private System.Windows.Forms.Button addAltA_BTN;
        private System.Windows.Forms.Button AddALL_BTN;
        private System.Windows.Forms.Button truncate_BTN;
        private System.Windows.Forms.Button Batch_BTN;
        private System.Windows.Forms.Button cancel_BTN;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button Remove_BTN;
        private System.Windows.Forms.Button Clear_BTN;
        private System.Windows.Forms.Button Exit_BTN;
        private System.Windows.Forms.Label TotalImgCnt;
        private System.Windows.Forms.TextBox TotalImgCnt_TXTBOX;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox totalDup_TXTBOX;
        private System.Windows.Forms.TextBox elapsedTime_TXTBOX;
        private System.Windows.Forms.TextBox operator_txtbox;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.DataGridViewTextBoxColumn BatchName;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalIMGCNT_COL;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Timer ElapsedTimer;
        public System.Windows.Forms.DataGridView batchgridLrg;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pathname_COL;
        private System.Windows.Forms.DataGridViewTextBoxColumn batchname_COL;
        private System.Windows.Forms.DataGridViewTextBoxColumn status_COL;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalImagesCount_COL;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalDuplicates_COL;
    }
}

