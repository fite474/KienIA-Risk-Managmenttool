namespace RiskManagmentTool.InterfaceLayer.EditWindows
{
    partial class AddTemplate
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
            this.checkedListBoxObjectEigenschappen = new System.Windows.Forms.CheckedListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.checkedListBoxSelectOptions = new System.Windows.Forms.CheckedListBox();
            this.buttonVerifieerKoppeling = new System.Windows.Forms.Button();
            this.buttonKoppelSelectie = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridViewTemplates = new System.Windows.Forms.DataGridView();
            this.panel7 = new System.Windows.Forms.Panel();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.dataGridViewSelectedTemplates = new System.Windows.Forms.DataGridView();
            this.panel6 = new System.Windows.Forms.Panel();
            this.buttonAutoSelect = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.panel4 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.panel8 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button3 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTemplates)).BeginInit();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSelectedTemplates)).BeginInit();
            this.panel6.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.checkedListBoxObjectEigenschappen);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1355, 198);
            this.panel1.TabIndex = 0;
            // 
            // checkedListBoxObjectEigenschappen
            // 
            this.checkedListBoxObjectEigenschappen.Dock = System.Windows.Forms.DockStyle.Right;
            this.checkedListBoxObjectEigenschappen.FormattingEnabled = true;
            this.checkedListBoxObjectEigenschappen.Items.AddRange(new object[] {
            "Brug",
            "Fietspad",
            "120 Km/u weg",
            "Brug open en dicht"});
            this.checkedListBoxObjectEigenschappen.Location = new System.Drawing.Point(915, 0);
            this.checkedListBoxObjectEigenschappen.Name = "checkedListBoxObjectEigenschappen";
            this.checkedListBoxObjectEigenschappen.Size = new System.Drawing.Size(440, 198);
            this.checkedListBoxObjectEigenschappen.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(71, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Object type";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(71, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Object naam";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.checkedListBoxSelectOptions);
            this.panel2.Controls.Add(this.buttonVerifieerKoppeling);
            this.panel2.Controls.Add(this.buttonKoppelSelectie);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(1066, 198);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(289, 499);
            this.panel2.TabIndex = 1;
            // 
            // checkedListBoxSelectOptions
            // 
            this.checkedListBoxSelectOptions.Dock = System.Windows.Forms.DockStyle.Top;
            this.checkedListBoxSelectOptions.FormattingEnabled = true;
            this.checkedListBoxSelectOptions.Items.AddRange(new object[] {
            "Bijvoegen van alle beschrijvingen",
            "Bijvoegen van alle risico waardes",
            "Vereisen van verificatie"});
            this.checkedListBoxSelectOptions.Location = new System.Drawing.Point(0, 27);
            this.checkedListBoxSelectOptions.Name = "checkedListBoxSelectOptions";
            this.checkedListBoxSelectOptions.Size = new System.Drawing.Size(289, 140);
            this.checkedListBoxSelectOptions.TabIndex = 2;
            // 
            // buttonVerifieerKoppeling
            // 
            this.buttonVerifieerKoppeling.Location = new System.Drawing.Point(62, 267);
            this.buttonVerifieerKoppeling.Name = "buttonVerifieerKoppeling";
            this.buttonVerifieerKoppeling.Size = new System.Drawing.Size(122, 44);
            this.buttonVerifieerKoppeling.TabIndex = 1;
            this.buttonVerifieerKoppeling.Text = "Verifiëer koppeling";
            this.buttonVerifieerKoppeling.UseVisualStyleBackColor = true;
            this.buttonVerifieerKoppeling.Click += new System.EventHandler(this.buttonVerifieerKoppeling_Click);
            // 
            // buttonKoppelSelectie
            // 
            this.buttonKoppelSelectie.Location = new System.Drawing.Point(62, 346);
            this.buttonKoppelSelectie.Name = "buttonKoppelSelectie";
            this.buttonKoppelSelectie.Size = new System.Drawing.Size(122, 30);
            this.buttonKoppelSelectie.TabIndex = 0;
            this.buttonKoppelSelectie.Text = "Koppel selectie";
            this.buttonKoppelSelectie.UseVisualStyleBackColor = true;
            this.buttonKoppelSelectie.Click += new System.EventHandler(this.buttonKoppelSelectie_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.label3.Size = new System.Drawing.Size(110, 27);
            this.label3.TabIndex = 3;
            this.label3.Text = "Selecteer opties";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.tabControl1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 198);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1060, 499);
            this.panel3.TabIndex = 2;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1060, 499);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tableLayoutPanel1);
            this.tabPage1.Controls.Add(this.panel6);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1052, 470);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Templates";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tableLayoutPanel1.Controls.Add(this.dataGridViewTemplates, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel7, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.dataGridViewSelectedTemplates, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 89);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1046, 378);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // dataGridViewTemplates
            // 
            this.dataGridViewTemplates.AllowUserToAddRows = false;
            this.dataGridViewTemplates.AllowUserToDeleteRows = false;
            this.dataGridViewTemplates.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTemplates.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewTemplates.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewTemplates.Name = "dataGridViewTemplates";
            this.dataGridViewTemplates.ReadOnly = true;
            this.dataGridViewTemplates.RowTemplate.Height = 24;
            this.dataGridViewTemplates.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewTemplates.Size = new System.Drawing.Size(464, 372);
            this.dataGridViewTemplates.TabIndex = 1;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.button5);
            this.panel7.Controls.Add(this.button4);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(473, 3);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(98, 372);
            this.panel7.TabIndex = 0;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(3, 157);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(92, 47);
            this.button5.TabIndex = 1;
            this.button5.Text = "<-";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(3, 30);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(92, 47);
            this.button4.TabIndex = 0;
            this.button4.Text = "->";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // dataGridViewSelectedTemplates
            // 
            this.dataGridViewSelectedTemplates.AllowUserToAddRows = false;
            this.dataGridViewSelectedTemplates.AllowUserToDeleteRows = false;
            this.dataGridViewSelectedTemplates.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSelectedTemplates.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewSelectedTemplates.Location = new System.Drawing.Point(577, 3);
            this.dataGridViewSelectedTemplates.Name = "dataGridViewSelectedTemplates";
            this.dataGridViewSelectedTemplates.ReadOnly = true;
            this.dataGridViewSelectedTemplates.RowTemplate.Height = 24;
            this.dataGridViewSelectedTemplates.Size = new System.Drawing.Size(466, 372);
            this.dataGridViewSelectedTemplates.TabIndex = 2;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.buttonAutoSelect);
            this.panel6.Controls.Add(this.comboBox1);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(3, 3);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1046, 86);
            this.panel6.TabIndex = 2;
            // 
            // buttonAutoSelect
            // 
            this.buttonAutoSelect.Location = new System.Drawing.Point(446, 27);
            this.buttonAutoSelect.Name = "buttonAutoSelect";
            this.buttonAutoSelect.Size = new System.Drawing.Size(151, 53);
            this.buttonAutoSelect.TabIndex = 0;
            this.buttonAutoSelect.Text = "Auto selectie voor alle eisen";
            this.buttonAutoSelect.UseVisualStyleBackColor = true;
            this.buttonAutoSelect.Click += new System.EventHandler(this.buttonAutoSelect_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Gerelateerde templates",
            "Alle templates"});
            this.comboBox1.Location = new System.Drawing.Point(23, 31);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(165, 24);
            this.comboBox1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.tabControl2);
            this.tabPage2.Controls.Add(this.panel5);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1052, 470);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Overzicht items van geselecteerde templates";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage3);
            this.tabControl2.Controls.Add(this.tabPage5);
            this.tabControl2.Controls.Add(this.tabPage4);
            this.tabControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl2.Location = new System.Drawing.Point(3, 67);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(1046, 371);
            this.tabControl2.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.dataGridView1);
            this.tabPage3.Controls.Add(this.panel8);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1038, 342);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "Volledige issues";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            this.tabPage5.Location = new System.Drawing.Point(4, 25);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(1038, 342);
            this.tabPage5.TabIndex = 2;
            this.tabPage5.Text = "Losse risico\'s";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(4, 25);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(526, 267);
            this.tabPage4.TabIndex = 1;
            this.tabPage4.Text = "Losse maatregelen";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.button2);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 697);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1355, 71);
            this.panel4.TabIndex = 3;
            // 
            // button2
            // 
            this.button2.Dock = System.Windows.Forms.DockStyle.Right;
            this.button2.Location = new System.Drawing.Point(1220, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(135, 71);
            this.button2.TabIndex = 0;
            this.button2.Text = "Done";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.comboBox2);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(3, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1046, 64);
            this.panel5.TabIndex = 1;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(39, 16);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(166, 24);
            this.comboBox2.TabIndex = 0;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.button3);
            this.panel8.Controls.Add(this.button1);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel8.Location = new System.Drawing.Point(904, 3);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(131, 336);
            this.panel8.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(32, 53);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 50);
            this.button1.TabIndex = 0;
            this.button1.Text = "Verifiëer selectie";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(193, 56);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(500, 263);
            this.dataGridView1.TabIndex = 1;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(3, 132);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(113, 99);
            this.button3.TabIndex = 1;
            this.button3.Text = "Selectie niet importeren vanuit template";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // AddTemplate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1355, 768);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel4);
            this.Name = "AddTemplate";
            this.Text = "AddTemplate";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTemplates)).EndInit();
            this.panel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSelectedTemplates)).EndInit();
            this.panel6.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.CheckedListBox checkedListBoxObjectEigenschappen;
        private System.Windows.Forms.Button buttonKoppelSelectie;
        private System.Windows.Forms.Button buttonAutoSelect;
        private System.Windows.Forms.Button buttonVerifieerKoppeling;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView dataGridViewTemplates;
        private System.Windows.Forms.CheckedListBox checkedListBoxSelectOptions;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.DataGridView dataGridViewSelectedTemplates;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Button button3;
    }
}