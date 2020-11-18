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
            this.dataGridViewIssueMaatregelen = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxGevaarID = new System.Windows.Forms.TextBox();
            this.textBoxObjectNaam = new System.Windows.Forms.TextBox();
            this.textBoxIssueID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewIssueMaatregelen)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button1);
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
            // dataGridViewIssueMaatregelen
            // 
            this.dataGridViewIssueMaatregelen.AllowUserToAddRows = false;
            this.dataGridViewIssueMaatregelen.AllowUserToDeleteRows = false;
            this.dataGridViewIssueMaatregelen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewIssueMaatregelen.Location = new System.Drawing.Point(12, 189);
            this.dataGridViewIssueMaatregelen.Name = "dataGridViewIssueMaatregelen";
            this.dataGridViewIssueMaatregelen.ReadOnly = true;
            this.dataGridViewIssueMaatregelen.RowTemplate.Height = 24;
            this.dataGridViewIssueMaatregelen.Size = new System.Drawing.Size(950, 361);
            this.dataGridViewIssueMaatregelen.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(55, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "GevaarID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(58, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Object naam";
            // 
            // textBoxGevaarID
            // 
            this.textBoxGevaarID.Location = new System.Drawing.Point(152, 34);
            this.textBoxGevaarID.Name = "textBoxGevaarID";
            this.textBoxGevaarID.Size = new System.Drawing.Size(100, 22);
            this.textBoxGevaarID.TabIndex = 2;
            // 
            // textBoxObjectNaam
            // 
            this.textBoxObjectNaam.Location = new System.Drawing.Point(152, 91);
            this.textBoxObjectNaam.Name = "textBoxObjectNaam";
            this.textBoxObjectNaam.Size = new System.Drawing.Size(100, 22);
            this.textBoxObjectNaam.TabIndex = 3;
            // 
            // textBoxIssueID
            // 
            this.textBoxIssueID.Location = new System.Drawing.Point(152, 130);
            this.textBoxIssueID.Name = "textBoxIssueID";
            this.textBoxIssueID.Size = new System.Drawing.Size(100, 22);
            this.textBoxIssueID.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(58, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "IssueID";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(595, 63);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(158, 79);
            this.button1.TabIndex = 6;
            this.button1.Text = "Koppel geselecteerde maatregelen";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // AddMaatregelenFromOtherIssue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1039, 593);
            this.Controls.Add(this.dataGridViewIssueMaatregelen);
            this.Controls.Add(this.panel1);
            this.Name = "AddMaatregelenFromOtherIssue";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddMaatregelenFromOtherIssue";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewIssueMaatregelen)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridViewIssueMaatregelen;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxIssueID;
        private System.Windows.Forms.TextBox textBoxObjectNaam;
        private System.Windows.Forms.TextBox textBoxGevaarID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
    }
}