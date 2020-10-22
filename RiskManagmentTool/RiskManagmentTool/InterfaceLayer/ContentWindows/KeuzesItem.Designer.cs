namespace RiskManagmentTool.InterfaceLayer.ContentWindows
{
    partial class KeuzesItem
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonEditKeuzes = new System.Windows.Forms.Button();
            this.listBoxMenuOptions = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBoxMenuName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.buttonEditKeuzes, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.listBoxMenuOptions, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(318, 360);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // buttonEditKeuzes
            // 
            this.buttonEditKeuzes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonEditKeuzes.Location = new System.Drawing.Point(30, 297);
            this.buttonEditKeuzes.Margin = new System.Windows.Forms.Padding(30, 3, 30, 3);
            this.buttonEditKeuzes.Name = "buttonEditKeuzes";
            this.buttonEditKeuzes.Size = new System.Drawing.Size(258, 53);
            this.buttonEditKeuzes.TabIndex = 1;
            this.buttonEditKeuzes.Text = "Edit keuze opties";
            this.buttonEditKeuzes.UseVisualStyleBackColor = true;
            this.buttonEditKeuzes.Click += new System.EventHandler(this.buttonEditKeuzes_Click);
            // 
            // listBoxMenuOptions
            // 
            this.listBoxMenuOptions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxMenuOptions.FormattingEnabled = true;
            this.listBoxMenuOptions.ItemHeight = 16;
            this.listBoxMenuOptions.Location = new System.Drawing.Point(30, 75);
            this.listBoxMenuOptions.Margin = new System.Windows.Forms.Padding(30, 3, 30, 3);
            this.listBoxMenuOptions.Name = "listBoxMenuOptions";
            this.listBoxMenuOptions.Size = new System.Drawing.Size(258, 196);
            this.listBoxMenuOptions.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textBoxMenuName);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(312, 66);
            this.panel1.TabIndex = 3;
            // 
            // textBoxMenuName
            // 
            this.textBoxMenuName.Location = new System.Drawing.Point(95, 24);
            this.textBoxMenuName.Name = "textBoxMenuName";
            this.textBoxMenuName.ReadOnly = true;
            this.textBoxMenuName.Size = new System.Drawing.Size(190, 22);
            this.textBoxMenuName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Menu: ";
            // 
            // KeuzesItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "KeuzesItem";
            this.Size = new System.Drawing.Size(318, 360);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button buttonEditKeuzes;
        private System.Windows.Forms.ListBox listBoxMenuOptions;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBoxMenuName;
        private System.Windows.Forms.Label label1;
    }
}
