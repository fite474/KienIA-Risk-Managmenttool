namespace RiskManagmentTool.InterfaceLayer.AddWindows
{
    partial class AddMaatregelenFromOtherIssue
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonAddSelection = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxIssueID = new System.Windows.Forms.TextBox();
            this.textBoxObjectNaam = new System.Windows.Forms.TextBox();
            this.textBoxGevaarID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.advancedDataGridViewIssueMaatregelen = new ADGV.AdvancedDataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridViewIssueMaatregelen)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonAddSelection);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.textBoxIssueID);
            this.panel1.Controls.Add(this.textBoxObjectNaam);
            this.panel1.Controls.Add(this.textBoxGevaarID);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1039, 183);
            this.panel1.TabIndex = 0;
            // 
            // buttonAddSelection
            // 
            this.buttonAddSelection.Location = new System.Drawing.Point(595, 63);
            this.buttonAddSelection.Name = "buttonAddSelection";
            this.buttonAddSelection.Size = new System.Drawing.Size(158, 79);
            this.buttonAddSelection.TabIndex = 6;
            this.buttonAddSelection.Text = "Koppel geselecteerde maatregelen";
            this.buttonAddSelection.UseVisualStyleBackColor = true;
            this.buttonAddSelection.Click += new System.EventHandler(this.buttonAddSelection_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(58, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Risico ID";
            // 
            // textBoxIssueID
            // 
            this.textBoxIssueID.Location = new System.Drawing.Point(155, 130);
            this.textBoxIssueID.Name = "textBoxIssueID";
            this.textBoxIssueID.ReadOnly = true;
            this.textBoxIssueID.Size = new System.Drawing.Size(100, 22);
            this.textBoxIssueID.TabIndex = 4;
            // 
            // textBoxObjectNaam
            // 
            this.textBoxObjectNaam.Location = new System.Drawing.Point(155, 30);
            this.textBoxObjectNaam.Name = "textBoxObjectNaam";
            this.textBoxObjectNaam.ReadOnly = true;
            this.textBoxObjectNaam.Size = new System.Drawing.Size(207, 22);
            this.textBoxObjectNaam.TabIndex = 3;
            // 
            // textBoxGevaarID
            // 
            this.textBoxGevaarID.Location = new System.Drawing.Point(905, 82);
            this.textBoxGevaarID.Name = "textBoxGevaarID";
            this.textBoxGevaarID.ReadOnly = true;
            this.textBoxGevaarID.Size = new System.Drawing.Size(100, 22);
            this.textBoxGevaarID.TabIndex = 2;
            this.textBoxGevaarID.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(58, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Object naam";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(808, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Gevaar ID";
            this.label1.Visible = false;
            // 
            // advancedDataGridViewIssueMaatregelen
            // 
            this.advancedDataGridViewIssueMaatregelen.AllowUserToAddRows = false;
            this.advancedDataGridViewIssueMaatregelen.AllowUserToDeleteRows = false;
            this.advancedDataGridViewIssueMaatregelen.AutoGenerateContextFilters = true;
            this.advancedDataGridViewIssueMaatregelen.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.advancedDataGridViewIssueMaatregelen.BackgroundColor = System.Drawing.SystemColors.Window;
            this.advancedDataGridViewIssueMaatregelen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.advancedDataGridViewIssueMaatregelen.DateWithTime = false;
            this.advancedDataGridViewIssueMaatregelen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.advancedDataGridViewIssueMaatregelen.Location = new System.Drawing.Point(0, 183);
            this.advancedDataGridViewIssueMaatregelen.Name = "advancedDataGridViewIssueMaatregelen";
            this.advancedDataGridViewIssueMaatregelen.ReadOnly = true;
            this.advancedDataGridViewIssueMaatregelen.RowHeadersWidth = 51;
            this.advancedDataGridViewIssueMaatregelen.RowTemplate.Height = 24;
            this.advancedDataGridViewIssueMaatregelen.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.advancedDataGridViewIssueMaatregelen.Size = new System.Drawing.Size(1039, 410);
            this.advancedDataGridViewIssueMaatregelen.TabIndex = 2;
            this.advancedDataGridViewIssueMaatregelen.TimeFilter = false;
            this.advancedDataGridViewIssueMaatregelen.SortStringChanged += new System.EventHandler(this.advancedDataGridViewIssueMaatregelen_SortStringChanged);
            this.advancedDataGridViewIssueMaatregelen.FilterStringChanged += new System.EventHandler(this.advancedDataGridViewIssueMaatregelen_FilterStringChanged);
            // 
            // AddMaatregelenFromOtherIssue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1039, 593);
            this.Controls.Add(this.advancedDataGridViewIssueMaatregelen);
            this.Controls.Add(this.panel1);
            this.Name = "AddMaatregelenFromOtherIssue";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddMaatregelenFromOtherRisk";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridViewIssueMaatregelen)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxIssueID;
        private System.Windows.Forms.TextBox textBoxObjectNaam;
        private System.Windows.Forms.TextBox textBoxGevaarID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonAddSelection;
        private ADGV.AdvancedDataGridView advancedDataGridViewIssueMaatregelen;
    }
}