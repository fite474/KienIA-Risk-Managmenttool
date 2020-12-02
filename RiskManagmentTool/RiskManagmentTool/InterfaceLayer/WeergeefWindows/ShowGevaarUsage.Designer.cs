namespace RiskManagmentTool.InterfaceLayer.WeergeefWindows
{
    partial class ShowGevaarUsage
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
            this.dataGridViewGevaarUsage = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGevaarUsage)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewGevaarUsage
            // 
            this.dataGridViewGevaarUsage.AllowUserToAddRows = false;
            this.dataGridViewGevaarUsage.AllowUserToDeleteRows = false;
            this.dataGridViewGevaarUsage.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewGevaarUsage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewGevaarUsage.Location = new System.Drawing.Point(0, 100);
            this.dataGridViewGevaarUsage.Name = "dataGridViewGevaarUsage";
            this.dataGridViewGevaarUsage.ReadOnly = true;
            this.dataGridViewGevaarUsage.RowTemplate.Height = 24;
            this.dataGridViewGevaarUsage.Size = new System.Drawing.Size(1166, 600);
            this.dataGridViewGevaarUsage.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1166, 100);
            this.panel1.TabIndex = 1;
            // 
            // ShowGevaarUsage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1166, 700);
            this.Controls.Add(this.dataGridViewGevaarUsage);
            this.Controls.Add(this.panel1);
            this.Name = "ShowGevaarUsage";
            this.Text = "ShowGevaarUsage";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGevaarUsage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewGevaarUsage;
        private System.Windows.Forms.Panel panel1;
    }
}