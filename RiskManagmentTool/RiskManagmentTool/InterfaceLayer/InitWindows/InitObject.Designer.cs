namespace RiskManagmentTool.InterfaceLayer.InitWindows
{
    partial class InitObject
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
            this.textBoxProjectNaam = new System.Windows.Forms.TextBox();
            this.buttonCreateObject = new System.Windows.Forms.Button();
            this.textBoxObjectNaam = new System.Windows.Forms.TextBox();
            this.comboBoxObjectType = new System.Windows.Forms.ComboBox();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.checkedListBox2 = new System.Windows.Forms.CheckedListBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxObjectOmschrijving = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.checkedListBoxRisicograaf = new System.Windows.Forms.CheckedListBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(63, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Project: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(61, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Naam object";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(61, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Type object";
            // 
            // textBoxProjectNaam
            // 
            this.textBoxProjectNaam.Location = new System.Drawing.Point(181, 43);
            this.textBoxProjectNaam.Name = "textBoxProjectNaam";
            this.textBoxProjectNaam.Size = new System.Drawing.Size(243, 22);
            this.textBoxProjectNaam.TabIndex = 3;
            // 
            // buttonCreateObject
            // 
            this.buttonCreateObject.Location = new System.Drawing.Point(484, 334);
            this.buttonCreateObject.Name = "buttonCreateObject";
            this.buttonCreateObject.Size = new System.Drawing.Size(173, 59);
            this.buttonCreateObject.TabIndex = 4;
            this.buttonCreateObject.Text = "Maak object aan";
            this.buttonCreateObject.UseVisualStyleBackColor = true;
            this.buttonCreateObject.Click += new System.EventHandler(this.buttonCreateObject_Click);
            // 
            // textBoxObjectNaam
            // 
            this.textBoxObjectNaam.Location = new System.Drawing.Point(181, 86);
            this.textBoxObjectNaam.Name = "textBoxObjectNaam";
            this.textBoxObjectNaam.Size = new System.Drawing.Size(243, 22);
            this.textBoxObjectNaam.TabIndex = 5;
            // 
            // comboBoxObjectType
            // 
            this.comboBoxObjectType.FormattingEnabled = true;
            this.comboBoxObjectType.Location = new System.Drawing.Point(181, 127);
            this.comboBoxObjectType.Name = "comboBoxObjectType";
            this.comboBoxObjectType.Size = new System.Drawing.Size(243, 24);
            this.comboBoxObjectType.TabIndex = 6;
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Items.AddRange(new object[] {
            "brug kan open",
            "brug heeft fietspad",
            "3",
            "4"});
            this.checkedListBox1.Location = new System.Drawing.Point(6, 37);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(208, 157);
            this.checkedListBox1.TabIndex = 7;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(63, 554);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(570, 62);
            this.tabControl1.TabIndex = 8;
            this.tabControl1.Visible = false;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.checkedListBox2);
            this.tabPage1.Controls.Add(this.checkedListBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(562, 33);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(264, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 17);
            this.label6.TabIndex = 10;
            this.label6.Text = "Snelheid";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 17);
            this.label5.TabIndex = 9;
            this.label5.Text = "Brug type";
            // 
            // checkedListBox2
            // 
            this.checkedListBox2.FormattingEnabled = true;
            this.checkedListBox2.Items.AddRange(new object[] {
            "30",
            "50",
            "60",
            "80",
            "100",
            "120",
            "130"});
            this.checkedListBox2.Location = new System.Drawing.Point(264, 37);
            this.checkedListBox2.Name = "checkedListBox2";
            this.checkedListBox2.Size = new System.Drawing.Size(208, 157);
            this.checkedListBox2.TabIndex = 8;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(574, 29);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(65, 554);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(124, 17);
            this.label4.TabIndex = 9;
            this.label4.Text = "Object instellingen";
            this.label4.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(64, 174);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(93, 17);
            this.label7.TabIndex = 10;
            this.label7.Text = "Omschrijving:";
            // 
            // textBoxObjectOmschrijving
            // 
            this.textBoxObjectOmschrijving.Location = new System.Drawing.Point(181, 174);
            this.textBoxObjectOmschrijving.Multiline = true;
            this.textBoxObjectOmschrijving.Name = "textBoxObjectOmschrijving";
            this.textBoxObjectOmschrijving.Size = new System.Drawing.Size(376, 68);
            this.textBoxObjectOmschrijving.TabIndex = 11;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(60, 264);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 17);
            this.label8.TabIndex = 13;
            this.label8.Text = "Risicograaf";
            // 
            // checkedListBoxRisicograaf
            // 
            this.checkedListBoxRisicograaf.CheckOnClick = true;
            this.checkedListBoxRisicograaf.FormattingEnabled = true;
            this.checkedListBoxRisicograaf.Items.AddRange(new object[] {
            "SIL",
            "PL"});
            this.checkedListBoxRisicograaf.Location = new System.Drawing.Point(64, 287);
            this.checkedListBoxRisicograaf.Name = "checkedListBoxRisicograaf";
            this.checkedListBoxRisicograaf.Size = new System.Drawing.Size(185, 106);
            this.checkedListBoxRisicograaf.TabIndex = 12;
            this.checkedListBoxRisicograaf.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBoxRisicograaf_ItemCheck);
            // 
            // InitObject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(698, 439);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.checkedListBoxRisicograaf);
            this.Controls.Add(this.textBoxObjectOmschrijving);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.comboBoxObjectType);
            this.Controls.Add(this.textBoxObjectNaam);
            this.Controls.Add(this.buttonCreateObject);
            this.Controls.Add(this.textBoxProjectNaam);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "InitObject";
            this.Text = "InitObject";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxProjectNaam;
        private System.Windows.Forms.Button buttonCreateObject;
        private System.Windows.Forms.TextBox textBoxObjectNaam;
        private System.Windows.Forms.ComboBox comboBoxObjectType;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.CheckedListBox checkedListBox2;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxObjectOmschrijving;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckedListBox checkedListBoxRisicograaf;
    }
}