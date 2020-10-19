namespace RiskManagmentTool.InterfaceLayer.ContentWindows
{
    partial class ContentKeuzes
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
            this.tableLayoutPanelKeuzes = new System.Windows.Forms.TableLayoutPanel();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1575, 81);
            this.panel1.TabIndex = 0;
            // 
            // tableLayoutPanelKeuzes
            // 
            this.tableLayoutPanelKeuzes.ColumnCount = 3;
            this.tableLayoutPanelKeuzes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanelKeuzes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanelKeuzes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanelKeuzes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelKeuzes.Location = new System.Drawing.Point(0, 81);
            this.tableLayoutPanelKeuzes.Name = "tableLayoutPanelKeuzes";
            this.tableLayoutPanelKeuzes.RowCount = 2;
            this.tableLayoutPanelKeuzes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.00001F));
            this.tableLayoutPanelKeuzes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelKeuzes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelKeuzes.Size = new System.Drawing.Size(1575, 731);
            this.tableLayoutPanelKeuzes.TabIndex = 1;
            // 
            // ContentKeuzes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1575, 812);
            this.Controls.Add(this.tableLayoutPanelKeuzes);
            this.Controls.Add(this.panel1);
            this.Name = "ContentKeuzes";
            this.Text = "ContentKeuzes";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelKeuzes;
    }
}