namespace BigSpender
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
      this.tabPage3 = new System.Windows.Forms.TabPage();
      this.label2 = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.tbHistory = new System.Windows.Forms.NumericUpDown();
      this.cbDisplay = new System.Windows.Forms.ComboBox();
      this.monthGrid = new System.Windows.Forms.DataGridView();
      this.tabPage1 = new System.Windows.Forms.TabPage();
      this.tabControl2 = new System.Windows.Forms.TabControl();
      this.tabPage4 = new System.Windows.Forms.TabPage();
      this.tbMutationCategory = new System.Windows.Forms.TextBox();
      this.label4 = new System.Windows.Forms.Label();
      this.tbMutationAccount = new System.Windows.Forms.TextBox();
      this.label3 = new System.Windows.Forms.Label();
      this.mutationGrid = new System.Windows.Forms.DataGridView();
      this.tabPage5 = new System.Windows.Forms.TabPage();
      this.tbAccountsCategory = new System.Windows.Forms.TextBox();
      this.label5 = new System.Windows.Forms.Label();
      this.tbAccountsAccount = new System.Windows.Forms.TextBox();
      this.label6 = new System.Windows.Forms.Label();
      this.accountGrid = new System.Windows.Forms.DataGridView();
      this.tabPage6 = new System.Windows.Forms.TabPage();
      this.plansGrid = new System.Windows.Forms.DataGridView();
      this.tabControl1 = new System.Windows.Forms.TabControl();
      this.tabPage2 = new System.Windows.Forms.TabPage();
      this.label7 = new System.Windows.Forms.Label();
      this.tbCashflowForecast = new System.Windows.Forms.NumericUpDown();
      this.cashFlowGrid = new System.Windows.Forms.DataGridView();
      this.btnMaxPlan = new System.Windows.Forms.Button();
      this.tabPage3.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.tbHistory)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.monthGrid)).BeginInit();
      this.tabPage1.SuspendLayout();
      this.tabControl2.SuspendLayout();
      this.tabPage4.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.mutationGrid)).BeginInit();
      this.tabPage5.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.accountGrid)).BeginInit();
      this.tabPage6.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.plansGrid)).BeginInit();
      this.tabControl1.SuspendLayout();
      this.tabPage2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.tbCashflowForecast)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.cashFlowGrid)).BeginInit();
      this.SuspendLayout();
      // 
      // tabPage3
      // 
      this.tabPage3.Controls.Add(this.label2);
      this.tabPage3.Controls.Add(this.label1);
      this.tabPage3.Controls.Add(this.tbHistory);
      this.tabPage3.Controls.Add(this.cbDisplay);
      this.tabPage3.Controls.Add(this.monthGrid);
      this.tabPage3.Location = new System.Drawing.Point(4, 22);
      this.tabPage3.Name = "tabPage3";
      this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
      this.tabPage3.Size = new System.Drawing.Size(976, 391);
      this.tabPage3.TabIndex = 2;
      this.tabPage3.Text = "Month";
      this.tabPage3.UseVisualStyleBackColor = true;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(180, 9);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(39, 13);
      this.label2.TabIndex = 7;
      this.label2.Text = "History";
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(6, 9);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(41, 13);
      this.label1.TabIndex = 6;
      this.label1.Text = "Display";
      // 
      // tbHistory
      // 
      this.tbHistory.Location = new System.Drawing.Point(225, 7);
      this.tbHistory.Maximum = new decimal(new int[] {
            36,
            0,
            0,
            0});
      this.tbHistory.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.tbHistory.Name = "tbHistory";
      this.tbHistory.Size = new System.Drawing.Size(120, 20);
      this.tbHistory.TabIndex = 5;
      this.tbHistory.Value = new decimal(new int[] {
            12,
            0,
            0,
            0});
      this.tbHistory.ValueChanged += new System.EventHandler(this.DoUpdate);
      // 
      // cbDisplay
      // 
      this.cbDisplay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbDisplay.FormattingEnabled = true;
      this.cbDisplay.Items.AddRange(new object[] {
            "Registered",
            "Predicted",
            "Full",
            "Unknown"});
      this.cbDisplay.Location = new System.Drawing.Point(53, 6);
      this.cbDisplay.Name = "cbDisplay";
      this.cbDisplay.Size = new System.Drawing.Size(121, 21);
      this.cbDisplay.TabIndex = 4;
      this.cbDisplay.SelectedIndexChanged += new System.EventHandler(this.DoUpdate);
      // 
      // monthGrid
      // 
      this.monthGrid.AllowUserToAddRows = false;
      this.monthGrid.AllowUserToDeleteRows = false;
      this.monthGrid.AllowUserToResizeRows = false;
      this.monthGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.monthGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
      this.monthGrid.Location = new System.Drawing.Point(6, 33);
      this.monthGrid.Name = "monthGrid";
      this.monthGrid.ReadOnly = true;
      this.monthGrid.Size = new System.Drawing.Size(964, 352);
      this.monthGrid.TabIndex = 3;
      // 
      // tabPage1
      // 
      this.tabPage1.Controls.Add(this.tabControl2);
      this.tabPage1.Location = new System.Drawing.Point(4, 22);
      this.tabPage1.Name = "tabPage1";
      this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
      this.tabPage1.Size = new System.Drawing.Size(976, 391);
      this.tabPage1.TabIndex = 0;
      this.tabPage1.Text = "Data";
      this.tabPage1.UseVisualStyleBackColor = true;
      // 
      // tabControl2
      // 
      this.tabControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.tabControl2.Controls.Add(this.tabPage4);
      this.tabControl2.Controls.Add(this.tabPage5);
      this.tabControl2.Controls.Add(this.tabPage6);
      this.tabControl2.Location = new System.Drawing.Point(6, 6);
      this.tabControl2.Name = "tabControl2";
      this.tabControl2.SelectedIndex = 0;
      this.tabControl2.Size = new System.Drawing.Size(964, 379);
      this.tabControl2.TabIndex = 3;
      // 
      // tabPage4
      // 
      this.tabPage4.Controls.Add(this.tbMutationCategory);
      this.tabPage4.Controls.Add(this.label4);
      this.tabPage4.Controls.Add(this.tbMutationAccount);
      this.tabPage4.Controls.Add(this.label3);
      this.tabPage4.Controls.Add(this.mutationGrid);
      this.tabPage4.Location = new System.Drawing.Point(4, 22);
      this.tabPage4.Name = "tabPage4";
      this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
      this.tabPage4.Size = new System.Drawing.Size(956, 353);
      this.tabPage4.TabIndex = 0;
      this.tabPage4.Text = "Mutations";
      this.tabPage4.UseVisualStyleBackColor = true;
      // 
      // tbMutationCategory
      // 
      this.tbMutationCategory.Location = new System.Drawing.Point(220, 6);
      this.tbMutationCategory.Name = "tbMutationCategory";
      this.tbMutationCategory.Size = new System.Drawing.Size(100, 20);
      this.tbMutationCategory.TabIndex = 7;
      this.tbMutationCategory.TextChanged += new System.EventHandler(this.DoUpdate);
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(165, 9);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(49, 13);
      this.label4.TabIndex = 6;
      this.label4.Text = "Category";
      // 
      // tbMutationAccount
      // 
      this.tbMutationAccount.Location = new System.Drawing.Point(59, 6);
      this.tbMutationAccount.Name = "tbMutationAccount";
      this.tbMutationAccount.Size = new System.Drawing.Size(100, 20);
      this.tbMutationAccount.TabIndex = 5;
      this.tbMutationAccount.TextChanged += new System.EventHandler(this.DoUpdate);
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(6, 9);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(47, 13);
      this.label3.TabIndex = 3;
      this.label3.Text = "Account";
      // 
      // mutationGrid
      // 
      this.mutationGrid.AllowUserToAddRows = false;
      this.mutationGrid.AllowUserToDeleteRows = false;
      this.mutationGrid.AllowUserToOrderColumns = true;
      this.mutationGrid.AllowUserToResizeRows = false;
      this.mutationGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.mutationGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
      this.mutationGrid.Location = new System.Drawing.Point(6, 32);
      this.mutationGrid.Name = "mutationGrid";
      this.mutationGrid.ReadOnly = true;
      this.mutationGrid.Size = new System.Drawing.Size(944, 315);
      this.mutationGrid.TabIndex = 2;
      // 
      // tabPage5
      // 
      this.tabPage5.Controls.Add(this.tbAccountsCategory);
      this.tabPage5.Controls.Add(this.label5);
      this.tabPage5.Controls.Add(this.tbAccountsAccount);
      this.tabPage5.Controls.Add(this.label6);
      this.tabPage5.Controls.Add(this.accountGrid);
      this.tabPage5.Location = new System.Drawing.Point(4, 22);
      this.tabPage5.Name = "tabPage5";
      this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
      this.tabPage5.Size = new System.Drawing.Size(956, 353);
      this.tabPage5.TabIndex = 1;
      this.tabPage5.Text = "Accounts";
      this.tabPage5.UseVisualStyleBackColor = true;
      // 
      // tbAccountsCategory
      // 
      this.tbAccountsCategory.Location = new System.Drawing.Point(220, 6);
      this.tbAccountsCategory.Name = "tbAccountsCategory";
      this.tbAccountsCategory.Size = new System.Drawing.Size(100, 20);
      this.tbAccountsCategory.TabIndex = 12;
      this.tbAccountsCategory.TextChanged += new System.EventHandler(this.DoUpdate);
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(165, 9);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(49, 13);
      this.label5.TabIndex = 11;
      this.label5.Text = "Category";
      // 
      // tbAccountsAccount
      // 
      this.tbAccountsAccount.Location = new System.Drawing.Point(59, 6);
      this.tbAccountsAccount.Name = "tbAccountsAccount";
      this.tbAccountsAccount.Size = new System.Drawing.Size(100, 20);
      this.tbAccountsAccount.TabIndex = 10;
      this.tbAccountsAccount.TextChanged += new System.EventHandler(this.DoUpdate);
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Location = new System.Drawing.Point(6, 9);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(47, 13);
      this.label6.TabIndex = 8;
      this.label6.Text = "Account";
      // 
      // accountGrid
      // 
      this.accountGrid.AllowUserToAddRows = false;
      this.accountGrid.AllowUserToDeleteRows = false;
      this.accountGrid.AllowUserToOrderColumns = true;
      this.accountGrid.AllowUserToResizeRows = false;
      this.accountGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.accountGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
      this.accountGrid.Location = new System.Drawing.Point(6, 32);
      this.accountGrid.Name = "accountGrid";
      this.accountGrid.ReadOnly = true;
      this.accountGrid.Size = new System.Drawing.Size(944, 315);
      this.accountGrid.TabIndex = 4;
      // 
      // tabPage6
      // 
      this.tabPage6.Controls.Add(this.btnMaxPlan);
      this.tabPage6.Controls.Add(this.plansGrid);
      this.tabPage6.Location = new System.Drawing.Point(4, 22);
      this.tabPage6.Name = "tabPage6";
      this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
      this.tabPage6.Size = new System.Drawing.Size(956, 353);
      this.tabPage6.TabIndex = 2;
      this.tabPage6.Text = "Plans";
      this.tabPage6.UseVisualStyleBackColor = true;
      // 
      // plansGrid
      // 
      this.plansGrid.AllowUserToAddRows = false;
      this.plansGrid.AllowUserToDeleteRows = false;
      this.plansGrid.AllowUserToOrderColumns = true;
      this.plansGrid.AllowUserToResizeRows = false;
      this.plansGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.plansGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
      this.plansGrid.Location = new System.Drawing.Point(6, 32);
      this.plansGrid.Name = "plansGrid";
      this.plansGrid.ReadOnly = true;
      this.plansGrid.Size = new System.Drawing.Size(944, 315);
      this.plansGrid.TabIndex = 5;
      // 
      // tabControl1
      // 
      this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.tabControl1.Controls.Add(this.tabPage3);
      this.tabControl1.Controls.Add(this.tabPage2);
      this.tabControl1.Controls.Add(this.tabPage1);
      this.tabControl1.Location = new System.Drawing.Point(12, 12);
      this.tabControl1.Name = "tabControl1";
      this.tabControl1.SelectedIndex = 0;
      this.tabControl1.Size = new System.Drawing.Size(984, 417);
      this.tabControl1.TabIndex = 3;
      // 
      // tabPage2
      // 
      this.tabPage2.Controls.Add(this.label7);
      this.tabPage2.Controls.Add(this.tbCashflowForecast);
      this.tabPage2.Controls.Add(this.cashFlowGrid);
      this.tabPage2.Location = new System.Drawing.Point(4, 22);
      this.tabPage2.Name = "tabPage2";
      this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
      this.tabPage2.Size = new System.Drawing.Size(976, 391);
      this.tabPage2.TabIndex = 3;
      this.tabPage2.Text = "Cashflow";
      this.tabPage2.UseVisualStyleBackColor = true;
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.Location = new System.Drawing.Point(6, 9);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(83, 13);
      this.label7.TabIndex = 9;
      this.label7.Text = "Months forecast";
      // 
      // tbCashflowForecast
      // 
      this.tbCashflowForecast.Location = new System.Drawing.Point(95, 6);
      this.tbCashflowForecast.Maximum = new decimal(new int[] {
            36,
            0,
            0,
            0});
      this.tbCashflowForecast.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.tbCashflowForecast.Name = "tbCashflowForecast";
      this.tbCashflowForecast.Size = new System.Drawing.Size(120, 20);
      this.tbCashflowForecast.TabIndex = 8;
      this.tbCashflowForecast.Value = new decimal(new int[] {
            6,
            0,
            0,
            0});
      this.tbCashflowForecast.ValueChanged += new System.EventHandler(this.DoUpdate);
      // 
      // cashFlowGrid
      // 
      this.cashFlowGrid.AllowUserToAddRows = false;
      this.cashFlowGrid.AllowUserToDeleteRows = false;
      this.cashFlowGrid.AllowUserToOrderColumns = true;
      this.cashFlowGrid.AllowUserToResizeRows = false;
      this.cashFlowGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.cashFlowGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
      this.cashFlowGrid.Location = new System.Drawing.Point(6, 32);
      this.cashFlowGrid.Name = "cashFlowGrid";
      this.cashFlowGrid.ReadOnly = true;
      this.cashFlowGrid.Size = new System.Drawing.Size(964, 353);
      this.cashFlowGrid.TabIndex = 4;
      // 
      // btnMaxPlan
      // 
      this.btnMaxPlan.Location = new System.Drawing.Point(6, 6);
      this.btnMaxPlan.Name = "btnMaxPlan";
      this.btnMaxPlan.Size = new System.Drawing.Size(100, 20);
      this.btnMaxPlan.TabIndex = 6;
      this.btnMaxPlan.Text = "Max!";
      this.btnMaxPlan.UseVisualStyleBackColor = true;
      this.btnMaxPlan.Click += new System.EventHandler(this.btnMaxPlan_Click);
      // 
      // Form1
      // 
      this.AllowDrop = true;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
      this.ClientSize = new System.Drawing.Size(1008, 441);
      this.Controls.Add(this.tabControl1);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "Form1";
      this.Text = "Big Spender";
      this.Load += new System.EventHandler(this.Form1_Load);
      this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
      this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
      this.tabPage3.ResumeLayout(false);
      this.tabPage3.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.tbHistory)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.monthGrid)).EndInit();
      this.tabPage1.ResumeLayout(false);
      this.tabControl2.ResumeLayout(false);
      this.tabPage4.ResumeLayout(false);
      this.tabPage4.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.mutationGrid)).EndInit();
      this.tabPage5.ResumeLayout(false);
      this.tabPage5.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.accountGrid)).EndInit();
      this.tabPage6.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.plansGrid)).EndInit();
      this.tabControl1.ResumeLayout(false);
      this.tabPage2.ResumeLayout(false);
      this.tabPage2.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.tbCashflowForecast)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.cashFlowGrid)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TabPage tabPage3;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.NumericUpDown tbHistory;
    private System.Windows.Forms.ComboBox cbDisplay;
    private System.Windows.Forms.DataGridView monthGrid;
    private System.Windows.Forms.TabPage tabPage1;
    private System.Windows.Forms.DataGridView mutationGrid;
    private System.Windows.Forms.TabControl tabControl1;
    private System.Windows.Forms.TabControl tabControl2;
    private System.Windows.Forms.TabPage tabPage4;
    private System.Windows.Forms.TabPage tabPage5;
    private System.Windows.Forms.DataGridView accountGrid;
    private System.Windows.Forms.TextBox tbMutationAccount;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.TextBox tbMutationCategory;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.TabPage tabPage2;
    private System.Windows.Forms.DataGridView cashFlowGrid;
    private System.Windows.Forms.TextBox tbAccountsCategory;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.TextBox tbAccountsAccount;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.NumericUpDown tbCashflowForecast;
    private System.Windows.Forms.TabPage tabPage6;
    private System.Windows.Forms.DataGridView plansGrid;
    private System.Windows.Forms.Button btnMaxPlan;

  }
}

