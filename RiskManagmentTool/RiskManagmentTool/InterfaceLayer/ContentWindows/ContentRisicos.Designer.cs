namespace RiskManagmentTool.InterfaceLayer.ContentWindows
{
    partial class ContentRisicos
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonAddNew = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.advancedDataGridViewGevaren = new ADGV.AdvancedDataGridView();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridViewGevaren)).BeginInit();
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
            this.buttonAddNew.Text = "Maak nieuw gevaar aan";
            this.buttonAddNew.UseVisualStyleBackColor = true;
            this.buttonAddNew.Click += new System.EventHandler(this.buttonAddNew_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.advancedDataGridViewGevaren);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 100);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1575, 712);
            this.panel2.TabIndex = 1;
            // 
            // advancedDataGridViewGevaren
            // 
            this.advancedDataGridViewGevaren.AllowUserToAddRows = false;
            this.advancedDataGridViewGevaren.AllowUserToDeleteRows = false;
            this.advancedDataGridViewGevaren.AutoGenerateContextFilters = true;
            this.advancedDataGridViewGevaren.BackgroundColor = System.Drawing.SystemColors.Window;
            this.advancedDataGridViewGevaren.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.advancedDataGridViewGevaren.DateWithTime = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.advancedDataGridViewGevaren.DefaultCellStyle = dataGridViewCellStyle1;
            this.advancedDataGridViewGevaren.Dock = System.Windows.Forms.DockStyle.Fill;
            this.advancedDataGridViewGevaren.Location = new System.Drawing.Point(0, 0);
            this.advancedDataGridViewGevaren.Name = "advancedDataGridViewGevaren";
            this.advancedDataGridViewGevaren.ReadOnly = true;
            this.advancedDataGridViewGevaren.RowHeadersWidth = 51;
            this.advancedDataGridViewGevaren.RowTemplate.Height = 40;
            this.advancedDataGridViewGevaren.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.advancedDataGridViewGevaren.Size = new System.Drawing.Size(1575, 712);
            this.advancedDataGridViewGevaren.TabIndex = 1;
            this.advancedDataGridViewGevaren.TimeFilter = false;
            this.advancedDataGridViewGevaren.SortStringChanged += new System.EventHandler(this.advancedDataGridViewGevaren_SortStringChanged);
            this.advancedDataGridViewGevaren.FilterStringChanged += new System.EventHandler(this.advancedDataGridViewGevaren_FilterStringChanged);
            this.advancedDataGridViewGevaren.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.advancedDataGridViewGevaren_DataBindingComplete);
            this.advancedDataGridViewGevaren.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.advancedDataGridViewGevaren_MouseDoubleClick);
            // 
            // ContentRisicos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1575, 812);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "ContentRisicos";
            this.Text = "ContentRisicos";
            this.Load += new System.EventHandler(this.ContentRisicos_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridViewGevaren)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button buttonAddNew;
        private ADGV.AdvancedDataGridView advancedDataGridViewGevaren;
    }
}