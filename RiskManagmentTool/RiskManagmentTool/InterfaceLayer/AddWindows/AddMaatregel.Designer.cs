namespace RiskManagmentTool.InterfaceLayer.AddWindows
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
            this.dataGridViewMaatregelen = new System.Windows.Forms.DataGridView();
            this.textBoxIssueID = new System.Windows.Forms.TextBox();
            this.textBoxSituatie = new System.Windows.Forms.TextBox();
            this.textBoxGebeurtenis = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBoxMaatregelCategorie = new System.Windows.Forms.ComboBox();
            this.comboBoxToepassingsgebied = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBoxSelectedMaatregelen = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.dataGridViewTemplates = new System.Windows.Forms.DataGridView();
            this.label10 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonKoppelSelectedMaatregelen = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonCreateNewMaatregel = new System.Windows.Forms.Button();
            this.comboBoxGevaar = new System.Windows.Forms.ComboBox();
            this.comboBoxDiscipline = new System.Windows.Forms.ComboBox();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.panel3 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMaatregelen)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTemplates)).BeginInit();
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
            this.label2.Location = new System.Drawing.Point(49, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Discipline";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(49, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Gevaar";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(49, 132);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Situatie";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(49, 180);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 17);
            this.label5.TabIndex = 4;
            this.label5.Text = "Gebeurtenis";
            // 
            // dataGridViewMaatregelen
            // 
            this.dataGridViewMaatregelen.AllowUserToAddRows = false;
            this.dataGridViewMaatregelen.AllowUserToDeleteRows = false;
            this.dataGridViewMaatregelen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMaatregelen.Location = new System.Drawing.Point(8, 70);
            this.dataGridViewMaatregelen.Name = "dataGridViewMaatregelen";
            this.dataGridViewMaatregelen.ReadOnly = true;
            this.dataGridViewMaatregelen.RowTemplate.Height = 24;
            this.dataGridViewMaatregelen.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewMaatregelen.Size = new System.Drawing.Size(830, 302);
            this.dataGridViewMaatregelen.TabIndex = 5;
            this.dataGridViewMaatregelen.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dataGridViewMaatregelen_MouseDoubleClick);
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
            this.textBoxSituatie.Location = new System.Drawing.Point(172, 132);
            this.textBoxSituatie.Multiline = true;
            this.textBoxSituatie.Name = "textBoxSituatie";
            this.textBoxSituatie.Size = new System.Drawing.Size(450, 36);
            this.textBoxSituatie.TabIndex = 9;
            // 
            // textBoxGebeurtenis
            // 
            this.textBoxGebeurtenis.Location = new System.Drawing.Point(172, 174);
            this.textBoxGebeurtenis.Multiline = true;
            this.textBoxGebeurtenis.Name = "textBoxGebeurtenis";
            this.textBoxGebeurtenis.Size = new System.Drawing.Size(450, 37);
            this.textBoxGebeurtenis.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(34, 262);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(134, 17);
            this.label6.TabIndex = 11;
            this.label6.Text = "Maatregel categorie";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(34, 295);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(132, 17);
            this.label7.TabIndex = 12;
            this.label7.Text = "Toepassingsgebied";
            // 
            // comboBoxMaatregelCategorie
            // 
            this.comboBoxMaatregelCategorie.FormattingEnabled = true;
            this.comboBoxMaatregelCategorie.Location = new System.Drawing.Point(221, 262);
            this.comboBoxMaatregelCategorie.Name = "comboBoxMaatregelCategorie";
            this.comboBoxMaatregelCategorie.Size = new System.Drawing.Size(202, 24);
            this.comboBoxMaatregelCategorie.TabIndex = 13;
            // 
            // comboBoxToepassingsgebied
            // 
            this.comboBoxToepassingsgebied.FormattingEnabled = true;
            this.comboBoxToepassingsgebied.Location = new System.Drawing.Point(221, 295);
            this.comboBoxToepassingsgebied.Name = "comboBoxToepassingsgebied";
            this.comboBoxToepassingsgebied.Size = new System.Drawing.Size(202, 24);
            this.comboBoxToepassingsgebied.TabIndex = 14;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(34, 227);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(118, 17);
            this.label8.TabIndex = 15;
            this.label8.Text = "Maatregel bevat: ";
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(221, 227);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(202, 22);
            this.textBox6.TabIndex = 16;
            // 
            // textBoxSelectedMaatregelen
            // 
            this.textBoxSelectedMaatregelen.Location = new System.Drawing.Point(139, 790);
            this.textBoxSelectedMaatregelen.Name = "textBoxSelectedMaatregelen";
            this.textBoxSelectedMaatregelen.Size = new System.Drawing.Size(592, 22);
            this.textBoxSelectedMaatregelen.TabIndex = 17;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 6);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1074, 407);
            this.tabControl1.TabIndex = 18;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dataGridViewMaatregelen);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1066, 378);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Maatregelen";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.panel1);
            this.tabPage2.Controls.Add(this.dataGridViewTemplates);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1066, 378);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Selecteer uit templates";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.comboBox3);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1060, 70);
            this.panel1.TabIndex = 1;
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(120, 21);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(121, 24);
            this.comboBox3.TabIndex = 1;
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
            // dataGridViewTemplates
            // 
            this.dataGridViewTemplates.AllowUserToAddRows = false;
            this.dataGridViewTemplates.AllowUserToDeleteRows = false;
            this.dataGridViewTemplates.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTemplates.Location = new System.Drawing.Point(6, 79);
            this.dataGridViewTemplates.Name = "dataGridViewTemplates";
            this.dataGridViewTemplates.ReadOnly = true;
            this.dataGridViewTemplates.RowTemplate.Height = 24;
            this.dataGridViewTemplates.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewTemplates.Size = new System.Drawing.Size(832, 282);
            this.dataGridViewTemplates.TabIndex = 0;
            this.dataGridViewTemplates.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dataGridViewTemplates_MouseDoubleClick);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(19, 790);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(62, 17);
            this.label10.TabIndex = 19;
            this.label10.Text = "Selectie:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(32, 822);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(152, 30);
            this.button1.TabIndex = 20;
            this.button1.Text = "Wis selectie";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // buttonKoppelSelectedMaatregelen
            // 
            this.buttonKoppelSelectedMaatregelen.Location = new System.Drawing.Point(469, 822);
            this.buttonKoppelSelectedMaatregelen.Name = "buttonKoppelSelectedMaatregelen";
            this.buttonKoppelSelectedMaatregelen.Size = new System.Drawing.Size(248, 30);
            this.buttonKoppelSelectedMaatregelen.TabIndex = 21;
            this.buttonKoppelSelectedMaatregelen.Text = "Koppel geselecteerde maatregelen";
            this.buttonKoppelSelectedMaatregelen.UseVisualStyleBackColor = true;
            this.buttonKoppelSelectedMaatregelen.Click += new System.EventHandler(this.buttonKoppelSelectedMaatregelen_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(215, 821);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(166, 31);
            this.button3.TabIndex = 22;
            this.button3.Text = "Toon selectie als string";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.buttonCreateNewMaatregel);
            this.panel2.Controls.Add(this.comboBoxGevaar);
            this.panel2.Controls.Add(this.comboBoxDiscipline);
            this.panel2.Controls.Add(this.checkedListBox1);
            this.panel2.Controls.Add(this.textBoxSituatie);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.textBoxIssueID);
            this.panel2.Controls.Add(this.textBox6);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.comboBoxToepassingsgebied);
            this.panel2.Controls.Add(this.textBoxGebeurtenis);
            this.panel2.Controls.Add(this.comboBoxMaatregelCategorie);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1113, 349);
            this.panel2.TabIndex = 23;
            // 
            // buttonCreateNewMaatregel
            // 
            this.buttonCreateNewMaatregel.Location = new System.Drawing.Point(743, 247);
            this.buttonCreateNewMaatregel.Name = "buttonCreateNewMaatregel";
            this.buttonCreateNewMaatregel.Size = new System.Drawing.Size(159, 65);
            this.buttonCreateNewMaatregel.TabIndex = 22;
            this.buttonCreateNewMaatregel.Text = "Maak nieuwe maatregel aan";
            this.buttonCreateNewMaatregel.UseVisualStyleBackColor = true;
            this.buttonCreateNewMaatregel.Click += new System.EventHandler(this.buttonCreateNewMaatregel_Click);
            // 
            // comboBoxGevaar
            // 
            this.comboBoxGevaar.FormattingEnabled = true;
            this.comboBoxGevaar.Location = new System.Drawing.Point(172, 98);
            this.comboBoxGevaar.Name = "comboBoxGevaar";
            this.comboBoxGevaar.Size = new System.Drawing.Size(283, 24);
            this.comboBoxGevaar.TabIndex = 21;
            // 
            // comboBoxDiscipline
            // 
            this.comboBoxDiscipline.FormattingEnabled = true;
            this.comboBoxDiscipline.Location = new System.Drawing.Point(172, 60);
            this.comboBoxDiscipline.Name = "comboBoxDiscipline";
            this.comboBoxDiscipline.Size = new System.Drawing.Size(283, 24);
            this.comboBoxDiscipline.TabIndex = 20;
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Items.AddRange(new object[] {
            "Bijvoegen van alle beschrijvingen",
            "Bijvoegen van alle risico waardes",
            "Vereisen van verifiecatie"});
            this.checkedListBox1.Location = new System.Drawing.Point(743, 47);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(255, 174);
            this.checkedListBox1.TabIndex = 19;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.tabControl1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 349);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1113, 416);
            this.panel3.TabIndex = 24;
            // 
            // AddMaatregel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1113, 875);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.buttonKoppelSelectedMaatregelen);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.textBoxSelectedMaatregelen);
            this.Name = "AddMaatregel";
            this.Text = "AddMaatregel";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMaatregelen)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTemplates)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dataGridViewMaatregelen;
        private System.Windows.Forms.TextBox textBoxIssueID;
        private System.Windows.Forms.TextBox textBoxSituatie;
        private System.Windows.Forms.TextBox textBoxGebeurtenis;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBoxMaatregelCategorie;
        private System.Windows.Forms.ComboBox comboBoxToepassingsgebied;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBoxSelectedMaatregelen;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dataGridViewTemplates;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button buttonKoppelSelectedMaatregelen;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.ComboBox comboBoxGevaar;
        private System.Windows.Forms.ComboBox comboBoxDiscipline;
        private System.Windows.Forms.Button buttonCreateNewMaatregel;
    }
}