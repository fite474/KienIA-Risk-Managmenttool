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
            this.panelTopBar = new System.Windows.Forms.Panel();
            this.labelObjectNaam = new System.Windows.Forms.Label();
            this.tableLayoutPanelKeuzes = new System.Windows.Forms.TableLayoutPanel();
            this.buttonNext = new System.Windows.Forms.Button();
            this.labelUitlegPagina = new System.Windows.Forms.Label();
            this.labelObjectSelectie = new System.Windows.Forms.Label();
            this.comboBoxObjectName = new System.Windows.Forms.ComboBox();
            this.panelTopBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTopBar
            // 
            this.panelTopBar.Controls.Add(this.comboBoxObjectName);
            this.panelTopBar.Controls.Add(this.labelObjectSelectie);
            this.panelTopBar.Controls.Add(this.labelUitlegPagina);
            this.panelTopBar.Controls.Add(this.buttonNext);
            this.panelTopBar.Controls.Add(this.labelObjectNaam);
            this.panelTopBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTopBar.Location = new System.Drawing.Point(0, 0);
            this.panelTopBar.Name = "panelTopBar";
            this.panelTopBar.Size = new System.Drawing.Size(1574, 142);
            this.panelTopBar.TabIndex = 0;
            // 
            // labelObjectNaam
            // 
            this.labelObjectNaam.AutoSize = true;
            this.labelObjectNaam.Location = new System.Drawing.Point(12, 68);
            this.labelObjectNaam.Name = "labelObjectNaam";
            this.labelObjectNaam.Size = new System.Drawing.Size(120, 21);
            this.labelObjectNaam.TabIndex = 1;
            this.labelObjectNaam.Text = "Object naam: ";
            this.labelObjectNaam.Visible = false;
            // 
            // tableLayoutPanelKeuzes
            // 
            this.tableLayoutPanelKeuzes.AutoScroll = true;
            this.tableLayoutPanelKeuzes.ColumnCount = 4;
            this.tableLayoutPanelKeuzes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.00062F));
            this.tableLayoutPanelKeuzes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.00063F));
            this.tableLayoutPanelKeuzes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.00063F));
            this.tableLayoutPanelKeuzes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.99812F));
            this.tableLayoutPanelKeuzes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelKeuzes.Location = new System.Drawing.Point(0, 142);
            this.tableLayoutPanelKeuzes.Name = "tableLayoutPanelKeuzes";
            this.tableLayoutPanelKeuzes.RowCount = 2;
            this.tableLayoutPanelKeuzes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelKeuzes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 49.99999F));
            this.tableLayoutPanelKeuzes.Size = new System.Drawing.Size(1574, 688);
            this.tableLayoutPanelKeuzes.TabIndex = 1;
            // 
            // buttonNext
            // 
            this.buttonNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonNext.Location = new System.Drawing.Point(1354, 55);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(208, 67);
            this.buttonNext.TabIndex = 2;
            this.buttonNext.Text = "Next";
            this.buttonNext.UseVisualStyleBackColor = true;
            this.buttonNext.Click += new System.EventHandler(this.buttonNext_Click);
            // 
            // labelUitlegPagina
            // 
            this.labelUitlegPagina.AutoSize = true;
            this.labelUitlegPagina.Location = new System.Drawing.Point(12, 23);
            this.labelUitlegPagina.Name = "labelUitlegPagina";
            this.labelUitlegPagina.Size = new System.Drawing.Size(108, 17);
            this.labelUitlegPagina.TabIndex = 3;
            this.labelUitlegPagina.Text = "*UITLEG TEXT*";
            this.labelUitlegPagina.Visible = false;
            // 
            // labelObjectSelectie
            // 
            this.labelObjectSelectie.AutoSize = true;
            this.labelObjectSelectie.Location = new System.Drawing.Point(542, 43);
            this.labelObjectSelectie.Name = "labelObjectSelectie";
            this.labelObjectSelectie.Size = new System.Drawing.Size(151, 21);
            this.labelObjectSelectie.TabIndex = 4;
            this.labelObjectSelectie.Text = "Menu opties voor:";
            // 
            // comboBoxObjectName
            // 
            this.comboBoxObjectName.FormattingEnabled = true;
            this.comboBoxObjectName.Location = new System.Drawing.Point(701, 42);
            this.comboBoxObjectName.Name = "comboBoxObjectName";
            this.comboBoxObjectName.Size = new System.Drawing.Size(190, 24);
            this.comboBoxObjectName.TabIndex = 5;
            this.comboBoxObjectName.SelectedIndexChanged += new System.EventHandler(this.comboBoxObjectName_SelectedIndexChanged);
            // 
            // ContentKeuzes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1574, 830);
            this.Controls.Add(this.tableLayoutPanelKeuzes);
            this.Controls.Add(this.panelTopBar);
            this.Name = "ContentKeuzes";
            this.Text = "ContentKeuzes";
            this.panelTopBar.ResumeLayout(false);
            this.panelTopBar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTopBar;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelKeuzes;
        private System.Windows.Forms.Label labelObjectNaam;
        private System.Windows.Forms.Button buttonNext;
        private System.Windows.Forms.Label labelUitlegPagina;
        private System.Windows.Forms.ComboBox comboBoxObjectName;
        private System.Windows.Forms.Label labelObjectSelectie;
    }
}