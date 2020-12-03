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
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.comboBoxWeergaveTemplate = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.dataGridViewTemplateMaatregelen = new System.Windows.Forms.DataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.dataGridViewObjectIssues = new System.Windows.Forms.DataGridView();
            this.panel4 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.comboBoxObjectenWeergave = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.textBoxGevaarID = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.comboBoxGevaar = new System.Windows.Forms.ComboBox();
            this.comboBoxDiscipline = new System.Windows.Forms.ComboBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridViewMaatregelen)).BeginInit();
            this.panel5.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTemplateMaatregelen)).BeginInit();
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
            this.label1.Size = new System.Drawing.Size(56, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Issue Id";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(49, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Discipline";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(49, 134);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Gevaar";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(49, 168);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Situatie";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(49, 216);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 17);
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
            this.textBoxSituatie.Location = new System.Drawing.Point(172, 168);
            this.textBoxSituatie.Multiline = true;
            this.textBoxSituatie.Name = "textBoxSituatie";
            this.textBoxSituatie.Size = new System.Drawing.Size(450, 36);
            this.textBoxSituatie.TabIndex = 9;
            // 
            // textBoxGebeurtenis
            // 
            this.textBoxGebeurtenis.Location = new System.Drawing.Point(172, 210);
            this.textBoxGebeurtenis.Multiline = true;
            this.textBoxGebeurtenis.Name = "textBoxGebeurtenis";
            this.textBoxGebeurtenis.Size = new System.Drawing.Size(450, 37);
            this.textBoxGebeurtenis.TabIndex = 10;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1090, 662);
            this.tabControl1.TabIndex = 18;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.advancedDataGridViewMaatregelen);
            this.tabPage1.Controls.Add(this.panel5);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1082, 633);
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
            this.advancedDataGridViewMaatregelen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.advancedDataGridViewMaatregelen.DateWithTime = false;
            this.advancedDataGridViewMaatregelen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.advancedDataGridViewMaatregelen.Location = new System.Drawing.Point(3, 103);
            this.advancedDataGridViewMaatregelen.Name = "advancedDataGridViewMaatregelen";
            this.advancedDataGridViewMaatregelen.ReadOnly = true;
            this.advancedDataGridViewMaatregelen.RowTemplate.Height = 24;
            this.advancedDataGridViewMaatregelen.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.advancedDataGridViewMaatregelen.Size = new System.Drawing.Size(1076, 527);
            this.advancedDataGridViewMaatregelen.TabIndex = 23;
            this.advancedDataGridViewMaatregelen.TimeFilter = false;
            this.advancedDataGridViewMaatregelen.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.advancedDataGridViewMaatregelen_DataBindingComplete);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.buttonKoppelSelectedMaatregelen);
            this.panel5.Controls.Add(this.buttonCreateNewMaatregel);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(3, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1076, 100);
            this.panel5.TabIndex = 22;
            // 
            // buttonKoppelSelectedMaatregelen
            // 
            this.buttonKoppelSelectedMaatregelen.Location = new System.Drawing.Point(835, 22);
            this.buttonKoppelSelectedMaatregelen.Name = "buttonKoppelSelectedMaatregelen";
            this.buttonKoppelSelectedMaatregelen.Size = new System.Drawing.Size(179, 55);
            this.buttonKoppelSelectedMaatregelen.TabIndex = 21;
            this.buttonKoppelSelectedMaatregelen.Text = "Koppel geselecteerde maatregelen";
            this.buttonKoppelSelectedMaatregelen.UseVisualStyleBackColor = true;
            this.buttonKoppelSelectedMaatregelen.Click += new System.EventHandler(this.buttonKoppelSelectedMaatregelen_Click);
            // 
            // buttonCreateNewMaatregel
            // 
            this.buttonCreateNewMaatregel.Location = new System.Drawing.Point(17, 17);
            this.buttonCreateNewMaatregel.Name = "buttonCreateNewMaatregel";
            this.buttonCreateNewMaatregel.Size = new System.Drawing.Size(159, 65);
            this.buttonCreateNewMaatregel.TabIndex = 22;
            this.buttonCreateNewMaatregel.Text = "Maak nieuwe maatregel aan";
            this.buttonCreateNewMaatregel.UseVisualStyleBackColor = true;
            this.buttonCreateNewMaatregel.Click += new System.EventHandler(this.buttonCreateNewMaatregel_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.panel1);
            this.tabPage2.Controls.Add(this.dataGridViewTemplateMaatregelen);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1082, 570);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Selecteer uit templates";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.comboBoxWeergaveTemplate);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1076, 70);
            this.panel1.TabIndex = 1;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(800, 5);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(179, 55);
            this.button2.TabIndex = 22;
            this.button2.Text = "Koppel geselecteerde maatregelen";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // comboBoxWeergaveTemplate
            // 
            this.comboBoxWeergaveTemplate.FormattingEnabled = true;
            this.comboBoxWeergaveTemplate.Location = new System.Drawing.Point(120, 21);
            this.comboBoxWeergaveTemplate.Name = "comboBoxWeergaveTemplate";
            this.comboBoxWeergaveTemplate.Size = new System.Drawing.Size(121, 24);
            this.comboBoxWeergaveTemplate.TabIndex = 1;
            this.comboBoxWeergaveTemplate.SelectedIndexChanged += new System.EventHandler(this.comboBoxWeergaveTemplate_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(30, 21);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(75, 17);
            this.label9.TabIndex = 0;
            this.label9.Text = "Template: ";
            // 
            // dataGridViewTemplateMaatregelen
            // 
            this.dataGridViewTemplateMaatregelen.AllowUserToAddRows = false;
            this.dataGridViewTemplateMaatregelen.AllowUserToDeleteRows = false;
            this.dataGridViewTemplateMaatregelen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTemplateMaatregelen.Location = new System.Drawing.Point(6, 79);
            this.dataGridViewTemplateMaatregelen.Name = "dataGridViewTemplateMaatregelen";
            this.dataGridViewTemplateMaatregelen.ReadOnly = true;
            this.dataGridViewTemplateMaatregelen.RowTemplate.Height = 24;
            this.dataGridViewTemplateMaatregelen.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewTemplateMaatregelen.Size = new System.Drawing.Size(832, 282);
            this.dataGridViewTemplateMaatregelen.TabIndex = 0;
            this.dataGridViewTemplateMaatregelen.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dataGridViewTemplateMaatregelen_MouseDoubleClick);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.dataGridViewObjectIssues);
            this.tabPage3.Controls.Add(this.panel4);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1082, 570);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Selecteer uit issues van andere objecten";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // dataGridViewObjectIssues
            // 
            this.dataGridViewObjectIssues.AllowUserToAddRows = false;
            this.dataGridViewObjectIssues.AllowUserToDeleteRows = false;
            this.dataGridViewObjectIssues.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewObjectIssues.Location = new System.Drawing.Point(4, 79);
            this.dataGridViewObjectIssues.Name = "dataGridViewObjectIssues";
            this.dataGridViewObjectIssues.ReadOnly = true;
            this.dataGridViewObjectIssues.RowTemplate.Height = 24;
            this.dataGridViewObjectIssues.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewObjectIssues.Size = new System.Drawing.Size(978, 282);
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
            this.panel4.Size = new System.Drawing.Size(1076, 70);
            this.panel4.TabIndex = 0;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(822, 4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(179, 55);
            this.button3.TabIndex = 22;
            this.button3.Text = "Koppel geselecteerde maatregelen";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Visible = false;
            // 
            // comboBoxObjectenWeergave
            // 
            this.comboBoxObjectenWeergave.FormattingEnabled = true;
            this.comboBoxObjectenWeergave.Location = new System.Drawing.Point(120, 20);
            this.comboBoxObjectenWeergave.Name = "comboBoxObjectenWeergave";
            this.comboBoxObjectenWeergave.Size = new System.Drawing.Size(121, 24);
            this.comboBoxObjectenWeergave.TabIndex = 1;
            this.comboBoxObjectenWeergave.Visible = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(27, 23);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(57, 17);
            this.label12.TabIndex = 0;
            this.label12.Text = "Object: ";
            this.label12.Visible = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.textBoxGevaarID);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.comboBoxGevaar);
            this.panel2.Controls.Add(this.comboBoxDiscipline);
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
            this.panel2.Size = new System.Drawing.Size(1333, 286);
            this.panel2.TabIndex = 23;
            // 
            // textBoxGevaarID
            // 
            this.textBoxGevaarID.Location = new System.Drawing.Point(172, 56);
            this.textBoxGevaarID.Name = "textBoxGevaarID";
            this.textBoxGevaarID.Size = new System.Drawing.Size(190, 22);
            this.textBoxGevaarID.TabIndex = 25;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(46, 56);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(72, 17);
            this.label10.TabIndex = 24;
            this.label10.Text = "GevaarID:";
            // 
            // comboBoxGevaar
            // 
            this.comboBoxGevaar.FormattingEnabled = true;
            this.comboBoxGevaar.Location = new System.Drawing.Point(172, 134);
            this.comboBoxGevaar.Name = "comboBoxGevaar";
            this.comboBoxGevaar.Size = new System.Drawing.Size(283, 24);
            this.comboBoxGevaar.TabIndex = 21;
            // 
            // comboBoxDiscipline
            // 
            this.comboBoxDiscipline.FormattingEnabled = true;
            this.comboBoxDiscipline.Location = new System.Drawing.Point(172, 96);
            this.comboBoxDiscipline.Name = "comboBoxDiscipline";
            this.comboBoxDiscipline.Size = new System.Drawing.Size(283, 24);
            this.comboBoxDiscipline.TabIndex = 20;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.tabControl1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 286);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1333, 662);
            this.panel3.TabIndex = 24;
            // 
            // AddMaatregel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1333, 948);
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
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTemplateMaatregelen)).EndInit();
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
        private System.Windows.Forms.ComboBox comboBoxGevaar;
        private System.Windows.Forms.ComboBox comboBoxDiscipline;
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
    }
}