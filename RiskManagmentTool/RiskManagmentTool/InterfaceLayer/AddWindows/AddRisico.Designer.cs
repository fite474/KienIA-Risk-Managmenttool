namespace RiskManagmentTool.InterfaceLayer.AddWindows
{
    partial class AddRisico
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel6 = new System.Windows.Forms.Panel();
            this.advancedDataGridViewLosseItems = new ADGV.AdvancedDataGridView();
            this.panel5 = new System.Windows.Forms.Panel();
            this.buttonAddSingleItems = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.advancedDataGridViewTemplateViewIssues = new ADGV.AdvancedDataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonCreateNewTemplate = new System.Windows.Forms.Button();
            this.buttonAddFromTemplateIssues = new System.Windows.Forms.Button();
            this.comboBoxViewTemplate = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.advancedDataGridViewObjectView = new ADGV.AdvancedDataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.buttonAddFromObject = new System.Windows.Forms.Button();
            this.comboBoxViewObjectNaam = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxObjectNaam = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxDiscipline = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.checkedListBoxAddSettings = new System.Windows.Forms.CheckedListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.buttonCreateNewGevaar = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridViewLosseItems)).BeginInit();
            this.panel5.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridViewTemplateViewIssues)).BeginInit();
            this.panel1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridViewObjectView)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1782, 778);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel6);
            this.tabPage1.Controls.Add(this.panel5);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1774, 749);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Alle risico\'s";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.advancedDataGridViewLosseItems);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(3, 111);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1768, 635);
            this.panel6.TabIndex = 4;
            // 
            // advancedDataGridViewLosseItems
            // 
            this.advancedDataGridViewLosseItems.AllowUserToAddRows = false;
            this.advancedDataGridViewLosseItems.AllowUserToDeleteRows = false;
            this.advancedDataGridViewLosseItems.AutoGenerateContextFilters = true;
            this.advancedDataGridViewLosseItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.advancedDataGridViewLosseItems.DateWithTime = false;
            this.advancedDataGridViewLosseItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.advancedDataGridViewLosseItems.Location = new System.Drawing.Point(0, 0);
            this.advancedDataGridViewLosseItems.Name = "advancedDataGridViewLosseItems";
            this.advancedDataGridViewLosseItems.ReadOnly = true;
            this.advancedDataGridViewLosseItems.RowTemplate.Height = 24;
            this.advancedDataGridViewLosseItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.advancedDataGridViewLosseItems.Size = new System.Drawing.Size(1768, 635);
            this.advancedDataGridViewLosseItems.TabIndex = 2;
            this.advancedDataGridViewLosseItems.TimeFilter = false;
            this.advancedDataGridViewLosseItems.SortStringChanged += new System.EventHandler(this.advancedDataGridViewLosseItems_SortStringChanged);
            this.advancedDataGridViewLosseItems.FilterStringChanged += new System.EventHandler(this.advancedDataGridViewLosseItems_FilterStringChanged);
            this.advancedDataGridViewLosseItems.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.advancedDataGridViewLosseItems_DataBindingComplete);
            this.advancedDataGridViewLosseItems.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.advancedDataGridViewLosseItems_MouseDoubleClick);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.buttonAddSingleItems);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(3, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1768, 108);
            this.panel5.TabIndex = 3;
            // 
            // buttonAddSingleItems
            // 
            this.buttonAddSingleItems.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonAddSingleItems.Location = new System.Drawing.Point(0, 0);
            this.buttonAddSingleItems.Name = "buttonAddSingleItems";
            this.buttonAddSingleItems.Size = new System.Drawing.Size(255, 108);
            this.buttonAddSingleItems.TabIndex = 1;
            this.buttonAddSingleItems.Text = "Koppel geselecteerde gevaren";
            this.buttonAddSingleItems.UseVisualStyleBackColor = true;
            this.buttonAddSingleItems.Click += new System.EventHandler(this.buttonAddSingleItems_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.advancedDataGridViewTemplateViewIssues);
            this.tabPage2.Controls.Add(this.panel1);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1774, 749);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Items uit templates";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // advancedDataGridViewTemplateViewIssues
            // 
            this.advancedDataGridViewTemplateViewIssues.AllowUserToAddRows = false;
            this.advancedDataGridViewTemplateViewIssues.AllowUserToDeleteRows = false;
            this.advancedDataGridViewTemplateViewIssues.AutoGenerateContextFilters = true;
            this.advancedDataGridViewTemplateViewIssues.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.advancedDataGridViewTemplateViewIssues.DateWithTime = false;
            this.advancedDataGridViewTemplateViewIssues.Location = new System.Drawing.Point(33, 92);
            this.advancedDataGridViewTemplateViewIssues.Name = "advancedDataGridViewTemplateViewIssues";
            this.advancedDataGridViewTemplateViewIssues.ReadOnly = true;
            this.advancedDataGridViewTemplateViewIssues.RowTemplate.Height = 24;
            this.advancedDataGridViewTemplateViewIssues.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.advancedDataGridViewTemplateViewIssues.Size = new System.Drawing.Size(974, 400);
            this.advancedDataGridViewTemplateViewIssues.TabIndex = 1;
            this.advancedDataGridViewTemplateViewIssues.TimeFilter = false;
            this.advancedDataGridViewTemplateViewIssues.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.advancedDataGridViewTemplateViewIssues_MouseDoubleClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonCreateNewTemplate);
            this.panel1.Controls.Add(this.buttonAddFromTemplateIssues);
            this.panel1.Controls.Add(this.comboBoxViewTemplate);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1768, 63);
            this.panel1.TabIndex = 0;
            // 
            // buttonCreateNewTemplate
            // 
            this.buttonCreateNewTemplate.Location = new System.Drawing.Point(360, 14);
            this.buttonCreateNewTemplate.Name = "buttonCreateNewTemplate";
            this.buttonCreateNewTemplate.Size = new System.Drawing.Size(163, 33);
            this.buttonCreateNewTemplate.TabIndex = 3;
            this.buttonCreateNewTemplate.Text = "Maak nieuw template";
            this.buttonCreateNewTemplate.UseVisualStyleBackColor = true;
            this.buttonCreateNewTemplate.Click += new System.EventHandler(this.buttonCreateNewTemplate_Click);
            // 
            // buttonAddFromTemplateIssues
            // 
            this.buttonAddFromTemplateIssues.Location = new System.Drawing.Point(892, 14);
            this.buttonAddFromTemplateIssues.Name = "buttonAddFromTemplateIssues";
            this.buttonAddFromTemplateIssues.Size = new System.Drawing.Size(181, 43);
            this.buttonAddFromTemplateIssues.TabIndex = 2;
            this.buttonAddFromTemplateIssues.Text = "Koppel geselecteerde gevaren";
            this.buttonAddFromTemplateIssues.UseVisualStyleBackColor = true;
            this.buttonAddFromTemplateIssues.Click += new System.EventHandler(this.buttonAddFromTemplateIssues_Click);
            // 
            // comboBoxViewTemplate
            // 
            this.comboBoxViewTemplate.FormattingEnabled = true;
            this.comboBoxViewTemplate.Location = new System.Drawing.Point(141, 14);
            this.comboBoxViewTemplate.Name = "comboBoxViewTemplate";
            this.comboBoxViewTemplate.Size = new System.Drawing.Size(185, 24);
            this.comboBoxViewTemplate.TabIndex = 1;
            this.comboBoxViewTemplate.SelectedIndexChanged += new System.EventHandler(this.comboBoxViewTemplate_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(106, 17);
            this.label6.TabIndex = 0;
            this.label6.Text = "Template naam";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.advancedDataGridViewObjectView);
            this.tabPage3.Controls.Add(this.panel3);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1774, 749);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Uit andere objecten selecteren";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // advancedDataGridViewObjectView
            // 
            this.advancedDataGridViewObjectView.AllowUserToAddRows = false;
            this.advancedDataGridViewObjectView.AllowUserToDeleteRows = false;
            this.advancedDataGridViewObjectView.AutoGenerateContextFilters = true;
            this.advancedDataGridViewObjectView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.advancedDataGridViewObjectView.DateWithTime = false;
            this.advancedDataGridViewObjectView.Location = new System.Drawing.Point(23, 93);
            this.advancedDataGridViewObjectView.Name = "advancedDataGridViewObjectView";
            this.advancedDataGridViewObjectView.ReadOnly = true;
            this.advancedDataGridViewObjectView.RowTemplate.Height = 24;
            this.advancedDataGridViewObjectView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.advancedDataGridViewObjectView.Size = new System.Drawing.Size(1161, 459);
            this.advancedDataGridViewObjectView.TabIndex = 2;
            this.advancedDataGridViewObjectView.TimeFilter = false;
            this.advancedDataGridViewObjectView.SortStringChanged += new System.EventHandler(this.advancedDataGridViewObjectView_SortStringChanged);
            this.advancedDataGridViewObjectView.FilterStringChanged += new System.EventHandler(this.advancedDataGridViewObjectView_FilterStringChanged);
            this.advancedDataGridViewObjectView.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.advancedDataGridViewObjectView_DataBindingComplete);
            this.advancedDataGridViewObjectView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.advancedDataGridViewObjectView_MouseDoubleClick);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.buttonAddFromObject);
            this.panel3.Controls.Add(this.comboBoxViewObjectNaam);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1774, 75);
            this.panel3.TabIndex = 0;
            // 
            // buttonAddFromObject
            // 
            this.buttonAddFromObject.Location = new System.Drawing.Point(787, 11);
            this.buttonAddFromObject.Name = "buttonAddFromObject";
            this.buttonAddFromObject.Size = new System.Drawing.Size(159, 52);
            this.buttonAddFromObject.TabIndex = 2;
            this.buttonAddFromObject.Text = "Koppel geselecteerde gevaren";
            this.buttonAddFromObject.UseVisualStyleBackColor = true;
            this.buttonAddFromObject.Click += new System.EventHandler(this.buttonAddFromObject_Click);
            // 
            // comboBoxViewObjectNaam
            // 
            this.comboBoxViewObjectNaam.FormattingEnabled = true;
            this.comboBoxViewObjectNaam.Location = new System.Drawing.Point(133, 14);
            this.comboBoxViewObjectNaam.Name = "comboBoxViewObjectNaam";
            this.comboBoxViewObjectNaam.Size = new System.Drawing.Size(195, 24);
            this.comboBoxViewObjectNaam.TabIndex = 1;
            this.comboBoxViewObjectNaam.SelectedIndexChanged += new System.EventHandler(this.comboBoxViewObjectNaam_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(5, 14);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(88, 17);
            this.label8.TabIndex = 0;
            this.label8.Text = "Object naam";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(74, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Object naam";
            // 
            // textBoxObjectNaam
            // 
            this.textBoxObjectNaam.Location = new System.Drawing.Point(244, 31);
            this.textBoxObjectNaam.Name = "textBoxObjectNaam";
            this.textBoxObjectNaam.ReadOnly = true;
            this.textBoxObjectNaam.Size = new System.Drawing.Size(298, 22);
            this.textBoxObjectNaam.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(74, 134);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Filter op discipline";
            this.label2.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(74, 166);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(146, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Van toepassing voor: ";
            this.label4.Visible = false;
            // 
            // comboBoxDiscipline
            // 
            this.comboBoxDiscipline.FormattingEnabled = true;
            this.comboBoxDiscipline.Location = new System.Drawing.Point(244, 134);
            this.comboBoxDiscipline.Name = "comboBoxDiscipline";
            this.comboBoxDiscipline.Size = new System.Drawing.Size(298, 24);
            this.comboBoxDiscipline.TabIndex = 8;
            this.comboBoxDiscipline.Visible = false;
            this.comboBoxDiscipline.SelectedIndexChanged += new System.EventHandler(this.comboBoxDiscipline_SelectedIndexChanged);
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(244, 166);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(298, 24);
            this.comboBox2.TabIndex = 9;
            this.comboBox2.Visible = false;
            // 
            // checkedListBoxAddSettings
            // 
            this.checkedListBoxAddSettings.CheckOnClick = true;
            this.checkedListBoxAddSettings.FormattingEnabled = true;
            this.checkedListBoxAddSettings.Items.AddRange(new object[] {
            "Gekoppelde maatregelen overnemen(waar mogelijk)",
            "Bijbehorende risicobeoordeling overnemen(waar mogelijk)",
            "Overgenomen items als \"Nog te verifieren\" overnemen"});
            this.checkedListBoxAddSettings.Location = new System.Drawing.Point(673, 31);
            this.checkedListBoxAddSettings.Name = "checkedListBoxAddSettings";
            this.checkedListBoxAddSettings.Size = new System.Drawing.Size(431, 208);
            this.checkedListBoxAddSettings.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(74, 106);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(133, 17);
            this.label5.TabIndex = 14;
            this.label5.Text = "Gebeurtenis bevat: ";
            this.label5.Visible = false;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(244, 101);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(298, 22);
            this.textBox3.TabIndex = 15;
            this.textBox3.Visible = false;
            // 
            // buttonCreateNewGevaar
            // 
            this.buttonCreateNewGevaar.Location = new System.Drawing.Point(1333, 166);
            this.buttonCreateNewGevaar.Name = "buttonCreateNewGevaar";
            this.buttonCreateNewGevaar.Size = new System.Drawing.Size(124, 48);
            this.buttonCreateNewGevaar.TabIndex = 16;
            this.buttonCreateNewGevaar.Text = "Maak nieuw gevaar aan";
            this.buttonCreateNewGevaar.UseVisualStyleBackColor = true;
            this.buttonCreateNewGevaar.Click += new System.EventHandler(this.buttonCreateNewGevaar_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.textBoxObjectNaam);
            this.panel2.Controls.Add(this.buttonCreateNewGevaar);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.textBox3);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.comboBoxDiscipline);
            this.panel2.Controls.Add(this.checkedListBoxAddSettings);
            this.panel2.Controls.Add(this.comboBox2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1782, 277);
            this.panel2.TabIndex = 17;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.tabControl1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 277);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1782, 778);
            this.panel4.TabIndex = 3;
            // 
            // AddRisico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1782, 1055);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.MinimumSize = new System.Drawing.Size(1000, 1028);
            this.Name = "AddRisico";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddRisico";
            this.Load += new System.EventHandler(this.AddRisico_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridViewLosseItems)).EndInit();
            this.panel5.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridViewTemplateViewIssues)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridViewObjectView)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxObjectNaam;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxDiscipline;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.CheckedListBox checkedListBoxAddSettings;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.ComboBox comboBoxViewTemplate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button buttonCreateNewGevaar;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ComboBox comboBoxViewObjectNaam;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button buttonAddSingleItems;
        private System.Windows.Forms.Button buttonAddFromTemplateIssues;
        private System.Windows.Forms.Button buttonAddFromObject;
        private System.Windows.Forms.Button buttonCreateNewTemplate;
        private ADGV.AdvancedDataGridView advancedDataGridViewLosseItems;
        private ADGV.AdvancedDataGridView advancedDataGridViewTemplateViewIssues;
        private ADGV.AdvancedDataGridView advancedDataGridViewObjectView;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
    }
}