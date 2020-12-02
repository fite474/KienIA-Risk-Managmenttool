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
            this.dataGridViewMaatregelen = new System.Windows.Forms.DataGridView();
            this.advancedDataGridView1 = new ADGV.AdvancedDataGridView();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMaatregelen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridView1)).BeginInit();
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
            this.buttonAddNew.Text = "Add";
            this.buttonAddNew.UseVisualStyleBackColor = true;
            this.buttonAddNew.Click += new System.EventHandler(this.buttonAddNew_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.advancedDataGridView1);
            this.panel2.Controls.Add(this.dataGridViewMaatregelen);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 100);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1575, 712);
            this.panel2.TabIndex = 1;
            // 
            // dataGridViewMaatregelen
            // 
            this.dataGridViewMaatregelen.AllowUserToAddRows = false;
            this.dataGridViewMaatregelen.AllowUserToDeleteRows = false;
            this.dataGridViewMaatregelen.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewMaatregelen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMaatregelen.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridViewMaatregelen.Location = new System.Drawing.Point(0, 617);
            this.dataGridViewMaatregelen.Name = "dataGridViewMaatregelen";
            this.dataGridViewMaatregelen.ReadOnly = true;
            this.dataGridViewMaatregelen.RowTemplate.Height = 24;
            this.dataGridViewMaatregelen.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewMaatregelen.Size = new System.Drawing.Size(1575, 95);
            this.dataGridViewMaatregelen.TabIndex = 0;
            this.dataGridViewMaatregelen.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataGridViewMaatregelen_DataBindingComplete);
            this.dataGridViewMaatregelen.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dataGridViewMaatregelen_MouseDoubleClick);
            // 
            // advancedDataGridView1
            // 
            this.advancedDataGridView1.AllowUserToAddRows = false;
            this.advancedDataGridView1.AllowUserToDeleteRows = false;
            this.advancedDataGridView1.AutoGenerateContextFilters = true;
            this.advancedDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.advancedDataGridView1.DateWithTime = false;
            this.advancedDataGridView1.Location = new System.Drawing.Point(114, 209);
            this.advancedDataGridView1.Name = "advancedDataGridView1";
            this.advancedDataGridView1.ReadOnly = true;
            this.advancedDataGridView1.RowTemplate.Height = 24;
            this.advancedDataGridView1.Size = new System.Drawing.Size(240, 150);
            this.advancedDataGridView1.TabIndex = 1;
            this.advancedDataGridView1.TimeFilter = false;
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
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMaatregelen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dataGridViewMaatregelen;
        private System.Windows.Forms.Button buttonAddNew;
        private ADGV.AdvancedDataGridView advancedDataGridView1;
    }
}