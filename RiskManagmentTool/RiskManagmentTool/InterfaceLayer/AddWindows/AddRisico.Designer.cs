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
            this.buttonAddSingleItems = new System.Windows.Forms.Button();
            this.dataGridViewLosseItems = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonAddFromTemplateIssues = new System.Windows.Forms.Button();
            this.comboBoxViewTemplate = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dataGridViewTemplateViewIssues = new System.Windows.Forms.DataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.dataGridViewObjectView = new System.Windows.Forms.DataGridView();
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
            this.buttonVoegSelectieToe = new System.Windows.Forms.Button();
            this.checkedListBoxAddSettings = new System.Windows.Forms.CheckedListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.buttonCreateNewGevaar = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLosseItems)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTemplateViewIssues)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewObjectView)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(19, 263);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1340, 632);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.buttonAddSingleItems);
            this.tabPage1.Controls.Add(this.dataGridViewLosseItems);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1332, 603);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Alle risico\'s";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // buttonAddSingleItems
            // 
            this.buttonAddSingleItems.Location = new System.Drawing.Point(1094, 16);
            this.buttonAddSingleItems.Name = "buttonAddSingleItems";
            this.buttonAddSingleItems.Size = new System.Drawing.Size(104, 43);
            this.buttonAddSingleItems.TabIndex = 1;
            this.buttonAddSingleItems.Text = "Add selection";
            this.buttonAddSingleItems.UseVisualStyleBackColor = true;
            this.buttonAddSingleItems.Click += new System.EventHandler(this.buttonAddSingleItems_Click);
            // 
            // dataGridViewLosseItems
            // 
            this.dataGridViewLosseItems.AllowUserToAddRows = false;
            this.dataGridViewLosseItems.AllowUserToDeleteRows = false;
            this.dataGridViewLosseItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewLosseItems.Location = new System.Drawing.Point(3, 78);
            this.dataGridViewLosseItems.Name = "dataGridViewLosseItems";
            this.dataGridViewLosseItems.ReadOnly = true;
            this.dataGridViewLosseItems.RowTemplate.Height = 24;
            this.dataGridViewLosseItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewLosseItems.Size = new System.Drawing.Size(1195, 456);
            this.dataGridViewLosseItems.TabIndex = 0;
            this.dataGridViewLosseItems.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataGridViewLosseItems_DataBindingComplete);
            this.dataGridViewLosseItems.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dataGridViewRisicos_MouseDoubleClick);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.panel1);
            this.tabPage2.Controls.Add(this.dataGridViewTemplateViewIssues);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1332, 603);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Items uit templates";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonAddFromTemplateIssues);
            this.panel1.Controls.Add(this.comboBoxViewTemplate);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1326, 63);
            this.panel1.TabIndex = 0;
            // 
            // buttonAddFromTemplateIssues
            // 
            this.buttonAddFromTemplateIssues.Location = new System.Drawing.Point(1016, 14);
            this.buttonAddFromTemplateIssues.Name = "buttonAddFromTemplateIssues";
            this.buttonAddFromTemplateIssues.Size = new System.Drawing.Size(104, 43);
            this.buttonAddFromTemplateIssues.TabIndex = 2;
            this.buttonAddFromTemplateIssues.Text = "Add selection";
            this.buttonAddFromTemplateIssues.UseVisualStyleBackColor = true;
            this.buttonAddFromTemplateIssues.Click += new System.EventHandler(this.buttonAddFromTemplateIssues_Click);
            // 
            // comboBoxViewTemplate
            // 
            this.comboBoxViewTemplate.FormattingEnabled = true;
            this.comboBoxViewTemplate.Location = new System.Drawing.Point(141, 16);
            this.comboBoxViewTemplate.Name = "comboBoxViewTemplate";
            this.comboBoxViewTemplate.Size = new System.Drawing.Size(185, 24);
            this.comboBoxViewTemplate.TabIndex = 1;
            this.comboBoxViewTemplate.SelectedIndexChanged += new System.EventHandler(this.comboBoxViewTemplate_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(29, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(106, 17);
            this.label6.TabIndex = 0;
            this.label6.Text = "Template naam";
            // 
            // dataGridViewTemplateViewIssues
            // 
            this.dataGridViewTemplateViewIssues.AllowUserToAddRows = false;
            this.dataGridViewTemplateViewIssues.AllowUserToDeleteRows = false;
            this.dataGridViewTemplateViewIssues.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTemplateViewIssues.Location = new System.Drawing.Point(6, 72);
            this.dataGridViewTemplateViewIssues.Name = "dataGridViewTemplateViewIssues";
            this.dataGridViewTemplateViewIssues.ReadOnly = true;
            this.dataGridViewTemplateViewIssues.RowTemplate.Height = 24;
            this.dataGridViewTemplateViewIssues.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewTemplateViewIssues.Size = new System.Drawing.Size(1070, 491);
            this.dataGridViewTemplateViewIssues.TabIndex = 0;
            this.dataGridViewTemplateViewIssues.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataGridViewTemplateViewIssues_DataBindingComplete);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.dataGridViewObjectView);
            this.tabPage3.Controls.Add(this.panel3);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1332, 603);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Uit andere objecten selecteren";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // dataGridViewObjectView
            // 
            this.dataGridViewObjectView.AllowUserToAddRows = false;
            this.dataGridViewObjectView.AllowUserToDeleteRows = false;
            this.dataGridViewObjectView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewObjectView.Location = new System.Drawing.Point(3, 72);
            this.dataGridViewObjectView.Name = "dataGridViewObjectView";
            this.dataGridViewObjectView.ReadOnly = true;
            this.dataGridViewObjectView.RowTemplate.Height = 24;
            this.dataGridViewObjectView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewObjectView.Size = new System.Drawing.Size(943, 406);
            this.dataGridViewObjectView.TabIndex = 1;
            this.dataGridViewObjectView.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataGridViewObjectView_DataBindingComplete);
            this.dataGridViewObjectView.DoubleClick += new System.EventHandler(this.dataGridViewObjectView_DoubleClick);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.buttonAddFromObject);
            this.panel3.Controls.Add(this.comboBoxViewObjectNaam);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1332, 66);
            this.panel3.TabIndex = 0;
            // 
            // buttonAddFromObject
            // 
            this.buttonAddFromObject.Location = new System.Drawing.Point(812, 11);
            this.buttonAddFromObject.Name = "buttonAddFromObject";
            this.buttonAddFromObject.Size = new System.Drawing.Size(104, 43);
            this.buttonAddFromObject.TabIndex = 2;
            this.buttonAddFromObject.Text = "Add selection";
            this.buttonAddFromObject.UseVisualStyleBackColor = true;
            this.buttonAddFromObject.Click += new System.EventHandler(this.buttonAddFromObject_Click);
            // 
            // comboBoxViewObjectNaam
            // 
            this.comboBoxViewObjectNaam.FormattingEnabled = true;
            this.comboBoxViewObjectNaam.Location = new System.Drawing.Point(133, 11);
            this.comboBoxViewObjectNaam.Name = "comboBoxViewObjectNaam";
            this.comboBoxViewObjectNaam.Size = new System.Drawing.Size(195, 24);
            this.comboBoxViewObjectNaam.TabIndex = 1;
            this.comboBoxViewObjectNaam.SelectedIndexChanged += new System.EventHandler(this.comboBoxViewObjectNaam_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(27, 14);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(88, 17);
            this.label8.TabIndex = 0;
            this.label8.Text = "Object naam";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Object naam";
            // 
            // textBoxObjectNaam
            // 
            this.textBoxObjectNaam.Location = new System.Drawing.Point(186, 19);
            this.textBoxObjectNaam.Name = "textBoxObjectNaam";
            this.textBoxObjectNaam.ReadOnly = true;
            this.textBoxObjectNaam.Size = new System.Drawing.Size(298, 22);
            this.textBoxObjectNaam.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Filter op discipline";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 154);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(146, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Van toepassing voor: ";
            // 
            // comboBoxDiscipline
            // 
            this.comboBoxDiscipline.FormattingEnabled = true;
            this.comboBoxDiscipline.Location = new System.Drawing.Point(186, 122);
            this.comboBoxDiscipline.Name = "comboBoxDiscipline";
            this.comboBoxDiscipline.Size = new System.Drawing.Size(298, 24);
            this.comboBoxDiscipline.TabIndex = 8;
            this.comboBoxDiscipline.SelectedIndexChanged += new System.EventHandler(this.comboBoxDiscipline_SelectedIndexChanged);
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(186, 154);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(298, 24);
            this.comboBox2.TabIndex = 9;
            // 
            // buttonVoegSelectieToe
            // 
            this.buttonVoegSelectieToe.Location = new System.Drawing.Point(509, 995);
            this.buttonVoegSelectieToe.Name = "buttonVoegSelectieToe";
            this.buttonVoegSelectieToe.Size = new System.Drawing.Size(156, 32);
            this.buttonVoegSelectieToe.TabIndex = 10;
            this.buttonVoegSelectieToe.Text = "Voeg selectie toe";
            this.buttonVoegSelectieToe.UseVisualStyleBackColor = true;
            this.buttonVoegSelectieToe.Click += new System.EventHandler(this.buttonVoegSelectieToe_Click);
            // 
            // checkedListBoxAddSettings
            // 
            this.checkedListBoxAddSettings.CheckOnClick = true;
            this.checkedListBoxAddSettings.FormattingEnabled = true;
            this.checkedListBoxAddSettings.Items.AddRange(new object[] {
            "Gekoppelde maatregelen overnemen(waar mogelijk)",
            "Bijbehorende risicobeoordeling overnemen(waar mogelijk)",
            "Overgenomen items als \"Nog te verifieren\" overnemen"});
            this.checkedListBoxAddSettings.Location = new System.Drawing.Point(615, 19);
            this.checkedListBoxAddSettings.Name = "checkedListBoxAddSettings";
            this.checkedListBoxAddSettings.Size = new System.Drawing.Size(431, 208);
            this.checkedListBoxAddSettings.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 94);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(133, 17);
            this.label5.TabIndex = 14;
            this.label5.Text = "Gebeurtenis bevat: ";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(186, 89);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(298, 22);
            this.textBox3.TabIndex = 15;
            // 
            // buttonCreateNewGevaar
            // 
            this.buttonCreateNewGevaar.Location = new System.Drawing.Point(1258, 46);
            this.buttonCreateNewGevaar.Name = "buttonCreateNewGevaar";
            this.buttonCreateNewGevaar.Size = new System.Drawing.Size(124, 48);
            this.buttonCreateNewGevaar.TabIndex = 16;
            this.buttonCreateNewGevaar.Text = "Maak nieuw gevaar aan";
            this.buttonCreateNewGevaar.UseVisualStyleBackColor = true;
            this.buttonCreateNewGevaar.Click += new System.EventHandler(this.buttonCreateNewGevaar_Click);
            // 
            // AddRisico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1782, 1055);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.buttonCreateNewGevaar);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.checkedListBoxAddSettings);
            this.Controls.Add(this.buttonVoegSelectieToe);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBoxDiscipline);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxObjectNaam);
            this.Controls.Add(this.label1);
            this.MinimumSize = new System.Drawing.Size(1000, 1028);
            this.Name = "AddRisico";
            this.Text = "AddRisico";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLosseItems)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTemplateViewIssues)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewObjectView)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxObjectNaam;
        private System.Windows.Forms.DataGridView dataGridViewLosseItems;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxDiscipline;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Button buttonVoegSelectieToe;
        private System.Windows.Forms.CheckedListBox checkedListBoxAddSettings;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.ComboBox comboBoxViewTemplate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button buttonCreateNewGevaar;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridView dataGridViewObjectView;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ComboBox comboBoxViewObjectNaam;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView dataGridViewTemplateViewIssues;
        private System.Windows.Forms.Button buttonAddSingleItems;
        private System.Windows.Forms.Button buttonAddFromTemplateIssues;
        private System.Windows.Forms.Button buttonAddFromObject;
    }
}