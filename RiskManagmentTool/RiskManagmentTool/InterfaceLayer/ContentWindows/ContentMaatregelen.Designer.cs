namespace RiskManagmentTool.InterfaceLayer.ContentWindows
{
    partial class ContentMaatregelen
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
            this.buttonAddNew = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.advancedDataGridViewMaatregelen = new ADGV.AdvancedDataGridView();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridViewMaatregelen)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonAddNew);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1575, 100);
            this.panel1.TabIndex = 0;
            // 
            // buttonAddNew
            // 
            this.buttonAddNew.Location = new System.Drawing.Point(3, 3);
            this.buttonAddNew.Name = "buttonAddNew";
            this.buttonAddNew.Size = new System.Drawing.Size(281, 91);
            this.buttonAddNew.TabIndex = 1;
            this.buttonAddNew.Text = "Maak nieuwe maatregel aan";
            this.buttonAddNew.UseVisualStyleBackColor = true;
            this.buttonAddNew.Click += new System.EventHandler(this.buttonAddNew_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.advancedDataGridViewMaatregelen);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 100);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1575, 712);
            this.panel2.TabIndex = 1;
            // 
            // advancedDataGridViewMaatregelen
            // 
            this.advancedDataGridViewMaatregelen.AllowUserToAddRows = false;
            this.advancedDataGridViewMaatregelen.AllowUserToDeleteRows = false;
            this.advancedDataGridViewMaatregelen.AutoGenerateContextFilters = true;
            this.advancedDataGridViewMaatregelen.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.advancedDataGridViewMaatregelen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.advancedDataGridViewMaatregelen.DateWithTime = false;
            this.advancedDataGridViewMaatregelen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.advancedDataGridViewMaatregelen.Location = new System.Drawing.Point(0, 0);
            this.advancedDataGridViewMaatregelen.Name = "advancedDataGridViewMaatregelen";
            this.advancedDataGridViewMaatregelen.ReadOnly = true;
            this.advancedDataGridViewMaatregelen.RowTemplate.Height = 24;
            this.advancedDataGridViewMaatregelen.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.advancedDataGridViewMaatregelen.Size = new System.Drawing.Size(1575, 712);
            this.advancedDataGridViewMaatregelen.TabIndex = 1;
            this.advancedDataGridViewMaatregelen.TimeFilter = false;
            this.advancedDataGridViewMaatregelen.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.advancedDataGridViewMaatregelen_DataBindingComplete);
            this.advancedDataGridViewMaatregelen.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.advancedDataGridViewMaatregelen_MouseDoubleClick);
            // 
            // ContentMaatregelen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1575, 812);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "ContentMaatregelen";
            this.Text = "ContentMaatregelen";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridViewMaatregelen)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button buttonAddNew;
        private ADGV.AdvancedDataGridView advancedDataGridViewMaatregelen;
    }
}