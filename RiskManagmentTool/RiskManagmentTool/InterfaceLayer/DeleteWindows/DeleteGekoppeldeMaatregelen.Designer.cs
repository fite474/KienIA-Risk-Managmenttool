namespace RiskManagmentTool.InterfaceLayer.DeleteWindows
{
    partial class DeleteGekoppeldeMaatregelen
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
            this.textBoxIssueID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridViewIssueMaatregelen = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.textBoxSelectedItems = new System.Windows.Forms.TextBox();
            this.buttonDeleteSelection = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewIssueMaatregelen)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textBoxIssueID);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(983, 100);
            this.panel1.TabIndex = 0;
            // 
            // textBoxIssueID
            // 
            this.textBoxIssueID.Location = new System.Drawing.Point(192, 32);
            this.textBoxIssueID.Name = "textBoxIssueID";
            this.textBoxIssueID.ReadOnly = true;
            this.textBoxIssueID.Size = new System.Drawing.Size(100, 22);
            this.textBoxIssueID.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(86, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Risico ID: ";
            // 
            // dataGridViewIssueMaatregelen
            // 
            this.dataGridViewIssueMaatregelen.AllowUserToAddRows = false;
            this.dataGridViewIssueMaatregelen.AllowUserToDeleteRows = false;
            this.dataGridViewIssueMaatregelen.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewIssueMaatregelen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewIssueMaatregelen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewIssueMaatregelen.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewIssueMaatregelen.Name = "dataGridViewIssueMaatregelen";
            this.dataGridViewIssueMaatregelen.ReadOnly = true;
            this.dataGridViewIssueMaatregelen.RowHeadersWidth = 51;
            this.dataGridViewIssueMaatregelen.RowTemplate.Height = 24;
            this.dataGridViewIssueMaatregelen.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewIssueMaatregelen.Size = new System.Drawing.Size(983, 377);
            this.dataGridViewIssueMaatregelen.TabIndex = 1;
            this.dataGridViewIssueMaatregelen.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataGridViewIssueMaatregelen_DataBindingComplete);
            this.dataGridViewIssueMaatregelen.SelectionChanged += new System.EventHandler(this.dataGridViewIssueMaatregelen_SelectionChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.textBoxSelectedItems);
            this.panel2.Controls.Add(this.buttonDeleteSelection);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 477);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(983, 113);
            this.panel2.TabIndex = 8;
            // 
            // textBoxSelectedItems
            // 
            this.textBoxSelectedItems.Location = new System.Drawing.Point(70, 46);
            this.textBoxSelectedItems.Name = "textBoxSelectedItems";
            this.textBoxSelectedItems.Size = new System.Drawing.Size(417, 22);
            this.textBoxSelectedItems.TabIndex = 4;
            // 
            // buttonDeleteSelection
            // 
            this.buttonDeleteSelection.Location = new System.Drawing.Point(611, 35);
            this.buttonDeleteSelection.Name = "buttonDeleteSelection";
            this.buttonDeleteSelection.Size = new System.Drawing.Size(284, 44);
            this.buttonDeleteSelection.TabIndex = 3;
            this.buttonDeleteSelection.Text = "Verwijder selectie";
            this.buttonDeleteSelection.UseVisualStyleBackColor = true;
            this.buttonDeleteSelection.Click += new System.EventHandler(this.buttonDeleteSelection_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dataGridViewIssueMaatregelen);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 100);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(983, 377);
            this.panel3.TabIndex = 9;
            // 
            // DeleteGekoppeldeMaatregelen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(983, 590);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "DeleteGekoppeldeMaatregelen";
            this.Text = "DeleteGekoppeldeMaatregelen";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewIssueMaatregelen)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridViewIssueMaatregelen;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox textBoxSelectedItems;
        private System.Windows.Forms.Button buttonDeleteSelection;
        private System.Windows.Forms.TextBox textBoxIssueID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
    }
}