﻿namespace RiskManagmentTool.InterfaceLayer.AddWindows
{
    partial class AddMaatregel
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxIssueID = new System.Windows.Forms.TextBox();
            this.textBoxSituatie = new System.Windows.Forms.TextBox();
            this.textBoxGebeurtenis = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.advancedDataGridViewMaatregelen = new ADGV.AdvancedDataGridView();
            this.panel5 = new System.Windows.Forms.Panel();
            this.buttonKoppelSelectedMaatregelen = new System.Windows.Forms.Button();
            this.buttonCreateNewMaatregel = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dataGridViewTemplateMaatregelen = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.comboBoxWeergaveTemplate = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.dataGridViewObjectIssues = new System.Windows.Forms.DataGridView();
            this.panel4 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.comboBoxObjectenWeergave = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.textBoxGevaarType = new System.Windows.Forms.TextBox();
            this.textBoxDiscipline = new System.Windows.Forms.TextBox();
            this.textBoxGevaarID = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridViewMaatregelen)).BeginInit();
            this.panel5.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTemplateMaatregelen)).BeginInit();
            this.panel1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewObjectIssues)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Risico Id";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(49, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Discipline";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(49, 134);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Gevaar";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(49, 168);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Situatie";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(49, 216);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "Gebeurtenis";
            // 
            // textBoxIssueID
            // 
            this.textBoxIssueID.Location = new System.Drawing.Point(172, 15);
            this.textBoxIssueID.Name = "textBoxIssueID";
            this.textBoxIssueID.ReadOnly = true;
            this.textBoxIssueID.Size = new System.Drawing.Size(190, 22);
            this.textBoxIssueID.TabIndex = 6;
            // 
            // textBoxSituatie
            // 
            this.textBoxSituatie.Location = new System.Drawing.Point(172, 159);
            this.textBoxSituatie.Multiline = true;
            this.textBoxSituatie.Name = "textBoxSituatie";
            this.textBoxSituatie.ReadOnly = true;
            this.textBoxSituatie.Size = new System.Drawing.Size(965, 51);
            this.textBoxSituatie.TabIndex = 9;
            // 
            // textBoxGebeurtenis
            // 
            this.textBoxGebeurtenis.Location = new System.Drawing.Point(172, 216);
            this.textBoxGebeurtenis.Multiline = true;
            this.textBoxGebeurtenis.Name = "textBoxGebeurtenis";
            this.textBoxGebeurtenis.ReadOnly = true;
            this.textBoxGebeurtenis.Size = new System.Drawing.Size(965, 48);
            this.textBoxGebeurtenis.TabIndex = 10;
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
            this.tabControl1.Size = new System.Drawing.Size(1368, 486);
            this.tabControl1.TabIndex = 18;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.advancedDataGridViewMaatregelen);
            this.tabPage1.Controls.Add(this.panel5);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1360, 457);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Maatregelen";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // advancedDataGridViewMaatregelen
            // 
            this.advancedDataGridViewMaatregelen.AllowUserToAddRows = false;
            this.advancedDataGridViewMaatregelen.AllowUserToDeleteRows = false;
            this.advancedDataGridViewMaatregelen.AutoGenerateContextFilters = true;
            this.advancedDataGridViewMaatregelen.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.advancedDataGridViewMaatregelen.BackgroundColor = System.Drawing.SystemColors.Window;
            this.advancedDataGridViewMaatregelen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.advancedDataGridViewMaatregelen.DateWithTime = false;
            this.advancedDataGridViewMaatregelen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.advancedDataGridViewMaatregelen.Location = new System.Drawing.Point(3, 79);
            this.advancedDataGridViewMaatregelen.Name = "advancedDataGridViewMaatregelen";
            this.advancedDataGridViewMaatregelen.ReadOnly = true;
            this.advancedDataGridViewMaatregelen.RowHeadersWidth = 51;
            this.advancedDataGridViewMaatregelen.RowTemplate.Height = 24;
            this.advancedDataGridViewMaatregelen.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.advancedDataGridViewMaatregelen.Size = new System.Drawing.Size(1354, 375);
            this.advancedDataGridViewMaatregelen.TabIndex = 23;
            this.advancedDataGridViewMaatregelen.TimeFilter = false;
            this.advancedDataGridViewMaatregelen.SortStringChanged += new System.EventHandler(this.advancedDataGridViewMaatregelen_SortStringChanged);
            this.advancedDataGridViewMaatregelen.FilterStringChanged += new System.EventHandler(this.advancedDataGridViewMaatregelen_FilterStringChanged);
            this.advancedDataGridViewMaatregelen.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.advancedDataGridViewMaatregelen_DataBindingComplete);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.buttonKoppelSelectedMaatregelen);
            this.panel5.Controls.Add(this.buttonCreateNewMaatregel);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(3, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1354, 76);
            this.panel5.TabIndex = 22;
            // 
            // buttonKoppelSelectedMaatregelen
            // 
            this.buttonKoppelSelectedMaatregelen.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonKoppelSelectedMaatregelen.Location = new System.Drawing.Point(0, 0);
            this.buttonKoppelSelectedMaatregelen.Name = "buttonKoppelSelectedMaatregelen";
            this.buttonKoppelSelectedMaatregelen.Size = new System.Drawing.Size(179, 76);
            this.buttonKoppelSelectedMaatregelen.TabIndex = 21;
            this.buttonKoppelSelectedMaatregelen.Text = "Koppel geselecteerde maatregelen";
            this.buttonKoppelSelectedMaatregelen.UseVisualStyleBackColor = true;
            this.buttonKoppelSelectedMaatregelen.Click += new System.EventHandler(this.buttonKoppelSelectedMaatregelen_Click);
            // 
            // buttonCreateNewMaatregel
            // 
            this.buttonCreateNewMaatregel.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonCreateNewMaatregel.Location = new System.Drawing.Point(1193, 0);
            this.buttonCreateNewMaatregel.Name = "buttonCreateNewMaatregel";
            this.buttonCreateNewMaatregel.Size = new System.Drawing.Size(161, 76);
            this.buttonCreateNewMaatregel.TabIndex = 22;
            this.buttonCreateNewMaatregel.Text = "Maak nieuwe maatregel aan";
            this.buttonCreateNewMaatregel.UseVisualStyleBackColor = true;
            this.buttonCreateNewMaatregel.Click += new System.EventHandler(this.buttonCreateNewMaatregel_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dataGridViewTemplateMaatregelen);
            this.tabPage2.Controls.Add(this.panel1);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1325, 422);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Selecteer uit templates";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dataGridViewTemplateMaatregelen
            // 
            this.dataGridViewTemplateMaatregelen.AllowUserToAddRows = false;
            this.dataGridViewTemplateMaatregelen.AllowUserToDeleteRows = false;
            this.dataGridViewTemplateMaatregelen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTemplateMaatregelen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewTemplateMaatregelen.Location = new System.Drawing.Point(3, 79);
            this.dataGridViewTemplateMaatregelen.Name = "dataGridViewTemplateMaatregelen";
            this.dataGridViewTemplateMaatregelen.ReadOnly = true;
            this.dataGridViewTemplateMaatregelen.RowHeadersWidth = 51;
            this.dataGridViewTemplateMaatregelen.RowTemplate.Height = 24;
            this.dataGridViewTemplateMaatregelen.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewTemplateMaatregelen.Size = new System.Drawing.Size(1319, 340);
            this.dataGridViewTemplateMaatregelen.TabIndex = 0;
            this.dataGridViewTemplateMaatregelen.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dataGridViewTemplateMaatregelen_MouseDoubleClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.comboBoxWeergaveTemplate);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1319, 76);
            this.panel1.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(238, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 16);
            this.label6.TabIndex = 23;
            this.label6.Text = "Werkt niet";
            // 
            // button2
            // 
            this.button2.Dock = System.Windows.Forms.DockStyle.Left;
            this.button2.Location = new System.Drawing.Point(0, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(179, 76);
            this.button2.TabIndex = 22;
            this.button2.Text = "Koppel geselecteerde maatregelen";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // comboBoxWeergaveTemplate
            // 
            this.comboBoxWeergaveTemplate.FormattingEnabled = true;
            this.comboBoxWeergaveTemplate.Location = new System.Drawing.Point(627, 27);
            this.comboBoxWeergaveTemplate.Name = "comboBoxWeergaveTemplate";
            this.comboBoxWeergaveTemplate.Size = new System.Drawing.Size(192, 24);
            this.comboBoxWeergaveTemplate.TabIndex = 1;
            this.comboBoxWeergaveTemplate.SelectedIndexChanged += new System.EventHandler(this.comboBoxWeergaveTemplate_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(525, 27);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(71, 16);
            this.label9.TabIndex = 0;
            this.label9.Text = "Template: ";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.dataGridViewObjectIssues);
            this.tabPage3.Controls.Add(this.panel4);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1325, 422);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Selecteer uit risico\'s van andere objecten";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // dataGridViewObjectIssues
            // 
            this.dataGridViewObjectIssues.AllowUserToAddRows = false;
            this.dataGridViewObjectIssues.AllowUserToDeleteRows = false;
            this.dataGridViewObjectIssues.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewObjectIssues.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewObjectIssues.Location = new System.Drawing.Point(3, 79);
            this.dataGridViewObjectIssues.Name = "dataGridViewObjectIssues";
            this.dataGridViewObjectIssues.ReadOnly = true;
            this.dataGridViewObjectIssues.RowHeadersWidth = 51;
            this.dataGridViewObjectIssues.RowTemplate.Height = 24;
            this.dataGridViewObjectIssues.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewObjectIssues.Size = new System.Drawing.Size(1319, 340);
            this.dataGridViewObjectIssues.TabIndex = 1;
            this.dataGridViewObjectIssues.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataGridViewObjectIssues_DataBindingComplete);
            this.dataGridViewObjectIssues.DoubleClick += new System.EventHandler(this.dataGridViewObjectIssues_DoubleClick);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.button3);
            this.panel4.Controls.Add(this.comboBoxObjectenWeergave);
            this.panel4.Controls.Add(this.label12);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(3, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1319, 76);
            this.panel4.TabIndex = 0;
            // 
            // button3
            // 
            this.button3.Dock = System.Windows.Forms.DockStyle.Left;
            this.button3.Location = new System.Drawing.Point(0, 0);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(179, 76);
            this.button3.TabIndex = 22;
            this.button3.Text = "Koppel geselecteerde maatregelen";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Visible = false;
            // 
            // comboBoxObjectenWeergave
            // 
            this.comboBoxObjectenWeergave.FormattingEnabled = true;
            this.comboBoxObjectenWeergave.Location = new System.Drawing.Point(627, 27);
            this.comboBoxObjectenWeergave.Name = "comboBoxObjectenWeergave";
            this.comboBoxObjectenWeergave.Size = new System.Drawing.Size(192, 24);
            this.comboBoxObjectenWeergave.TabIndex = 1;
            this.comboBoxObjectenWeergave.Visible = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(527, 27);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(52, 16);
            this.label12.TabIndex = 0;
            this.label12.Text = "Object: ";
            this.label12.Visible = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.textBoxGevaarType);
            this.panel2.Controls.Add(this.textBoxDiscipline);
            this.panel2.Controls.Add(this.textBoxGevaarID);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.textBoxSituatie);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.textBoxIssueID);
            this.panel2.Controls.Add(this.textBoxGebeurtenis);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1368, 286);
            this.panel2.TabIndex = 23;
            // 
            // textBoxGevaarType
            // 
            this.textBoxGevaarType.Location = new System.Drawing.Point(172, 131);
            this.textBoxGevaarType.Name = "textBoxGevaarType";
            this.textBoxGevaarType.ReadOnly = true;
            this.textBoxGevaarType.Size = new System.Drawing.Size(499, 22);
            this.textBoxGevaarType.TabIndex = 27;
            // 
            // textBoxDiscipline
            // 
            this.textBoxDiscipline.Location = new System.Drawing.Point(172, 93);
            this.textBoxDiscipline.Name = "textBoxDiscipline";
            this.textBoxDiscipline.ReadOnly = true;
            this.textBoxDiscipline.Size = new System.Drawing.Size(499, 22);
            this.textBoxDiscipline.TabIndex = 26;
            // 
            // textBoxGevaarID
            // 
            this.textBoxGevaarID.Location = new System.Drawing.Point(172, 56);
            this.textBoxGevaarID.Name = "textBoxGevaarID";
            this.textBoxGevaarID.ReadOnly = true;
            this.textBoxGevaarID.Size = new System.Drawing.Size(190, 22);
            this.textBoxGevaarID.TabIndex = 25;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(46, 56);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(68, 16);
            this.label10.TabIndex = 24;
            this.label10.Text = "GevaarID:";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.tabControl1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 286);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1368, 486);
            this.panel3.TabIndex = 24;
            // 
            // AddMaatregel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1368, 772);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Name = "AddMaatregel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddMaatregel";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridViewMaatregelen)).EndInit();
            this.panel5.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTemplateMaatregelen)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewObjectIssues)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxIssueID;
        private System.Windows.Forms.TextBox textBoxSituatie;
        private System.Windows.Forms.TextBox textBoxGebeurtenis;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dataGridViewTemplateMaatregelen;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox comboBoxWeergaveTemplate;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button buttonKoppelSelectedMaatregelen;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button buttonCreateNewMaatregel;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ComboBox comboBoxObjectenWeergave;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DataGridView dataGridViewObjectIssues;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox textBoxGevaarID;
        private System.Windows.Forms.Label label10;
        private ADGV.AdvancedDataGridView advancedDataGridViewMaatregelen;
        private System.Windows.Forms.TextBox textBoxGevaarType;
        private System.Windows.Forms.TextBox textBoxDiscipline;
        private System.Windows.Forms.Label label6;
    }
}