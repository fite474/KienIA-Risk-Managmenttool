namespace RiskManagmentTool.InterfaceLayer.WarningWindows
{
    partial class WarningAddToObject
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
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCompare = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.textBoxSituatie = new System.Windows.Forms.TextBox();
            this.textBoxGebeurtenis = new System.Windows.Forms.TextBox();
            this.textBoxObjectIssueId = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.labelWarningMessage = new System.Windows.Forms.Label();
            this.dataGridViewMaatregelenCurrentIssue = new System.Windows.Forms.DataGridView();
            this.dataGridViewMaatregelenNewIssue = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxGevaarId = new System.Windows.Forms.TextBox();
            this.textBoxIssueToAddID = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.buttonOnlySelectedMaatregelen = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.checkedListBoxWarningSettings = new System.Windows.Forms.CheckedListBox();
            this.checkedListBoxCustomSettings = new System.Windows.Forms.CheckedListBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMaatregelenCurrentIssue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMaatregelenNewIssue)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(194, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "ID van issue die je overneemt";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(0, 47);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 17);
            this.label5.TabIndex = 4;
            this.label5.Text = "Maatregelen";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonOK);
            this.panel1.Controls.Add(this.buttonCompare);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 835);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1474, 96);
            this.panel1.TabIndex = 6;
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(1145, 15);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(144, 59);
            this.buttonOK.TabIndex = 23;
            this.buttonOK.Text = "Done";
            this.buttonOK.UseVisualStyleBackColor = true;
            // 
            // buttonCompare
            // 
            this.buttonCompare.Location = new System.Drawing.Point(572, 25);
            this.buttonCompare.Name = "buttonCompare";
            this.buttonCompare.Size = new System.Drawing.Size(164, 49);
            this.buttonCompare.TabIndex = 22;
            this.buttonCompare.Text = "Vergelijk Risicobeoordeling";
            this.buttonCompare.UseVisualStyleBackColor = true;
            this.buttonCompare.Click += new System.EventHandler(this.buttonCompare_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(35, 55);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 17);
            this.label9.TabIndex = 9;
            this.label9.Text = "Situatie";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(35, 121);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(86, 17);
            this.label10.TabIndex = 10;
            this.label10.Text = "Gebeurtenis";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(2, 6);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(106, 17);
            this.label11.TabIndex = 11;
            this.label11.Text = "Huidig issue ID:";
            // 
            // textBoxSituatie
            // 
            this.textBoxSituatie.Location = new System.Drawing.Point(168, 55);
            this.textBoxSituatie.Multiline = true;
            this.textBoxSituatie.Name = "textBoxSituatie";
            this.textBoxSituatie.ReadOnly = true;
            this.textBoxSituatie.Size = new System.Drawing.Size(566, 51);
            this.textBoxSituatie.TabIndex = 12;
            // 
            // textBoxGebeurtenis
            // 
            this.textBoxGebeurtenis.Location = new System.Drawing.Point(168, 121);
            this.textBoxGebeurtenis.Multiline = true;
            this.textBoxGebeurtenis.Name = "textBoxGebeurtenis";
            this.textBoxGebeurtenis.ReadOnly = true;
            this.textBoxGebeurtenis.Size = new System.Drawing.Size(567, 71);
            this.textBoxGebeurtenis.TabIndex = 13;
            // 
            // textBoxObjectIssueId
            // 
            this.textBoxObjectIssueId.Location = new System.Drawing.Point(128, 3);
            this.textBoxObjectIssueId.Name = "textBoxObjectIssueId";
            this.textBoxObjectIssueId.Size = new System.Drawing.Size(212, 22);
            this.textBoxObjectIssueId.TabIndex = 14;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.labelWarningMessage);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1474, 76);
            this.panel2.TabIndex = 17;
            // 
            // labelWarningMessage
            // 
            this.labelWarningMessage.AutoSize = true;
            this.labelWarningMessage.Location = new System.Drawing.Point(105, 25);
            this.labelWarningMessage.Name = "labelWarningMessage";
            this.labelWarningMessage.Size = new System.Drawing.Size(73, 17);
            this.labelWarningMessage.TabIndex = 0;
            this.labelWarningMessage.Text = "Message: ";
            // 
            // dataGridViewMaatregelenCurrentIssue
            // 
            this.dataGridViewMaatregelenCurrentIssue.AllowUserToAddRows = false;
            this.dataGridViewMaatregelenCurrentIssue.AllowUserToDeleteRows = false;
            this.dataGridViewMaatregelenCurrentIssue.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMaatregelenCurrentIssue.Location = new System.Drawing.Point(3, 143);
            this.dataGridViewMaatregelenCurrentIssue.Name = "dataGridViewMaatregelenCurrentIssue";
            this.dataGridViewMaatregelenCurrentIssue.ReadOnly = true;
            this.dataGridViewMaatregelenCurrentIssue.RowTemplate.Height = 24;
            this.dataGridViewMaatregelenCurrentIssue.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewMaatregelenCurrentIssue.Size = new System.Drawing.Size(704, 298);
            this.dataGridViewMaatregelenCurrentIssue.TabIndex = 18;
            this.dataGridViewMaatregelenCurrentIssue.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataGridViewMaatregelenCurrentIssue_DataBindingComplete);
            // 
            // dataGridViewMaatregelenNewIssue
            // 
            this.dataGridViewMaatregelenNewIssue.AllowUserToAddRows = false;
            this.dataGridViewMaatregelenNewIssue.AllowUserToDeleteRows = false;
            this.dataGridViewMaatregelenNewIssue.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMaatregelenNewIssue.Location = new System.Drawing.Point(3, 143);
            this.dataGridViewMaatregelenNewIssue.Name = "dataGridViewMaatregelenNewIssue";
            this.dataGridViewMaatregelenNewIssue.ReadOnly = true;
            this.dataGridViewMaatregelenNewIssue.RowTemplate.Height = 24;
            this.dataGridViewMaatregelenNewIssue.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewMaatregelenNewIssue.Size = new System.Drawing.Size(692, 298);
            this.dataGridViewMaatregelenNewIssue.TabIndex = 19;
            this.dataGridViewMaatregelenNewIssue.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataGridViewMaatregelenNewIssue_DataBindingComplete);
            this.dataGridViewMaatregelenNewIssue.SelectionChanged += new System.EventHandler(this.dataGridViewMaatregelenNewIssue_SelectionChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(35, 13);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 17);
            this.label7.TabIndex = 20;
            this.label7.Text = "GevaarID: ";
            // 
            // textBoxGevaarId
            // 
            this.textBoxGevaarId.Location = new System.Drawing.Point(168, 13);
            this.textBoxGevaarId.Name = "textBoxGevaarId";
            this.textBoxGevaarId.ReadOnly = true;
            this.textBoxGevaarId.Size = new System.Drawing.Size(566, 22);
            this.textBoxGevaarId.TabIndex = 21;
            // 
            // textBoxIssueToAddID
            // 
            this.textBoxIssueToAddID.Location = new System.Drawing.Point(233, 3);
            this.textBoxIssueToAddID.Name = "textBoxIssueToAddID";
            this.textBoxIssueToAddID.Size = new System.Drawing.Size(228, 22);
            this.textBoxIssueToAddID.TabIndex = 23;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panel3, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel4, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 336);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1474, 499);
            this.tableLayoutPanel1.TabIndex = 24;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.buttonOnlySelectedMaatregelen);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.textBoxIssueToAddID);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.dataGridViewMaatregelenNewIssue);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(740, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(731, 493);
            this.panel3.TabIndex = 0;
            // 
            // buttonOnlySelectedMaatregelen
            // 
            this.buttonOnlySelectedMaatregelen.Location = new System.Drawing.Point(493, 6);
            this.buttonOnlySelectedMaatregelen.Name = "buttonOnlySelectedMaatregelen";
            this.buttonOnlySelectedMaatregelen.Size = new System.Drawing.Size(202, 55);
            this.buttonOnlySelectedMaatregelen.TabIndex = 24;
            this.buttonOnlySelectedMaatregelen.Text = "Geselecteerde maatregelen overnemen";
            this.buttonOnlySelectedMaatregelen.UseVisualStyleBackColor = true;
            this.buttonOnlySelectedMaatregelen.Click += new System.EventHandler(this.buttonOnlySelectedMaatregelen_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.dataGridViewMaatregelenCurrentIssue);
            this.panel4.Controls.Add(this.textBoxObjectIssueId);
            this.panel4.Controls.Add(this.label11);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(3, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(731, 493);
            this.panel4.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 17);
            this.label1.TabIndex = 19;
            this.label1.Text = "Maatregelen";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.checkedListBoxCustomSettings);
            this.panel5.Controls.Add(this.checkedListBoxWarningSettings);
            this.panel5.Controls.Add(this.textBoxGevaarId);
            this.panel5.Controls.Add(this.label7);
            this.panel5.Controls.Add(this.textBoxSituatie);
            this.panel5.Controls.Add(this.label9);
            this.panel5.Controls.Add(this.textBoxGebeurtenis);
            this.panel5.Controls.Add(this.label10);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 76);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1474, 260);
            this.panel5.TabIndex = 25;
            // 
            // checkedListBoxWarningSettings
            // 
            this.checkedListBoxWarningSettings.FormattingEnabled = true;
            this.checkedListBoxWarningSettings.Items.AddRange(new object[] {
            "Neem maatregelen over",
            "Neem risicobeoordeling over",
            "Vereisen van verificatie"});
            this.checkedListBoxWarningSettings.Location = new System.Drawing.Point(811, 6);
            this.checkedListBoxWarningSettings.Name = "checkedListBoxWarningSettings";
            this.checkedListBoxWarningSettings.Size = new System.Drawing.Size(335, 157);
            this.checkedListBoxWarningSettings.TabIndex = 22;
            this.checkedListBoxWarningSettings.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBoxWarningSettings_ItemCheck);
            // 
            // checkedListBoxCustomSettings
            // 
            this.checkedListBoxCustomSettings.FormattingEnabled = true;
            this.checkedListBoxCustomSettings.Items.AddRange(new object[] {
            "Aangepaste selectie maatregelen",
            "Aangepaste risicobeoordeling"});
            this.checkedListBoxCustomSettings.Location = new System.Drawing.Point(1191, 6);
            this.checkedListBoxCustomSettings.Name = "checkedListBoxCustomSettings";
            this.checkedListBoxCustomSettings.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.checkedListBoxCustomSettings.Size = new System.Drawing.Size(244, 106);
            this.checkedListBoxCustomSettings.TabIndex = 23;
            // 
            // WarningAddToObject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1474, 931);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "WarningAddToObject";
            this.Text = "WarningAddToObject";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMaatregelenCurrentIssue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMaatregelenNewIssue)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBoxSituatie;
        private System.Windows.Forms.TextBox textBoxGebeurtenis;
        private System.Windows.Forms.TextBox textBoxObjectIssueId;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label labelWarningMessage;
        private System.Windows.Forms.DataGridView dataGridViewMaatregelenCurrentIssue;
        private System.Windows.Forms.DataGridView dataGridViewMaatregelenNewIssue;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxGevaarId;
        private System.Windows.Forms.Button buttonCompare;
        private System.Windows.Forms.TextBox textBoxIssueToAddID;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button buttonOnlySelectedMaatregelen;
        private System.Windows.Forms.Button buttonOK;
        public System.Windows.Forms.CheckedListBox checkedListBoxWarningSettings;
        public System.Windows.Forms.CheckedListBox checkedListBoxCustomSettings;
    }
}