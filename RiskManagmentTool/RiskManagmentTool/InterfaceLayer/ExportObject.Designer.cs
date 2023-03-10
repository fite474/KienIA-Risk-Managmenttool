namespace RiskManagmentTool.InterfaceLayer
{
    partial class ExportObject
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxObjectName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.advancedDataGridViewCompleteBeoordeling = new ADGV.AdvancedDataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.checkedListBoxTemplate = new System.Windows.Forms.CheckedListBox();
            this.buttonConfirmExport = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBoxUserInputFileName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridViewCompleteBeoordeling)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Items.AddRange(new object[] {
            "SIL",
            "PL"});
            this.checkedListBox1.Location = new System.Drawing.Point(43, 40);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(187, 140);
            this.checkedListBox1.TabIndex = 0;
            this.checkedListBox1.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Object naam";
            // 
            // textBoxObjectName
            // 
            this.textBoxObjectName.Location = new System.Drawing.Point(173, 30);
            this.textBoxObjectName.Name = "textBoxObjectName";
            this.textBoxObjectName.ReadOnly = true;
            this.textBoxObjectName.Size = new System.Drawing.Size(241, 22);
            this.textBoxObjectName.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(179, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Controleer export instellingen";
            this.label2.Visible = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1452, 731);
            this.tabControl1.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.advancedDataGridViewCompleteBeoordeling);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1444, 702);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Issues weergave";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // advancedDataGridViewCompleteBeoordeling
            // 
            this.advancedDataGridViewCompleteBeoordeling.AllowUserToAddRows = false;
            this.advancedDataGridViewCompleteBeoordeling.AllowUserToDeleteRows = false;
            this.advancedDataGridViewCompleteBeoordeling.AutoGenerateContextFilters = true;
            this.advancedDataGridViewCompleteBeoordeling.BackgroundColor = System.Drawing.SystemColors.Window;
            this.advancedDataGridViewCompleteBeoordeling.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.advancedDataGridViewCompleteBeoordeling.DateWithTime = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.advancedDataGridViewCompleteBeoordeling.DefaultCellStyle = dataGridViewCellStyle1;
            this.advancedDataGridViewCompleteBeoordeling.Dock = System.Windows.Forms.DockStyle.Fill;
            this.advancedDataGridViewCompleteBeoordeling.Location = new System.Drawing.Point(3, 3);
            this.advancedDataGridViewCompleteBeoordeling.Name = "advancedDataGridViewCompleteBeoordeling";
            this.advancedDataGridViewCompleteBeoordeling.ReadOnly = true;
            this.advancedDataGridViewCompleteBeoordeling.RowHeadersWidth = 51;
            this.advancedDataGridViewCompleteBeoordeling.RowTemplate.Height = 45;
            this.advancedDataGridViewCompleteBeoordeling.Size = new System.Drawing.Size(1438, 696);
            this.advancedDataGridViewCompleteBeoordeling.TabIndex = 1;
            this.advancedDataGridViewCompleteBeoordeling.TimeFilter = false;
            this.advancedDataGridViewCompleteBeoordeling.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.advancedDataGridViewCompleteBeoordeling_DataBindingComplete);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.panel3);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1444, 702);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Export instellingen";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // checkedListBoxTemplate
            // 
            this.checkedListBoxTemplate.Enabled = false;
            this.checkedListBoxTemplate.FormattingEnabled = true;
            this.checkedListBoxTemplate.Items.AddRange(new object[] {
            "KienIA template",
            "RWS template"});
            this.checkedListBoxTemplate.Location = new System.Drawing.Point(420, 10);
            this.checkedListBoxTemplate.Name = "checkedListBoxTemplate";
            this.checkedListBoxTemplate.Size = new System.Drawing.Size(187, 89);
            this.checkedListBoxTemplate.TabIndex = 1;
            this.checkedListBoxTemplate.SelectedValueChanged += new System.EventHandler(this.checkedListBoxTemplate_SelectedValueChanged);
            // 
            // buttonConfirmExport
            // 
            this.buttonConfirmExport.Location = new System.Drawing.Point(1141, 12);
            this.buttonConfirmExport.Name = "buttonConfirmExport";
            this.buttonConfirmExport.Size = new System.Drawing.Size(153, 67);
            this.buttonConfirmExport.TabIndex = 5;
            this.buttonConfirmExport.Text = "Export";
            this.buttonConfirmExport.UseVisualStyleBackColor = true;
            this.buttonConfirmExport.Click += new System.EventHandler(this.buttonConfirmExport_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.checkedListBoxTemplate);
            this.panel1.Controls.Add(this.textBoxUserInputFileName);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.buttonConfirmExport);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.textBoxObjectName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1452, 102);
            this.panel1.TabIndex = 6;
            // 
            // textBoxUserInputFileName
            // 
            this.textBoxUserInputFileName.Location = new System.Drawing.Point(768, 34);
            this.textBoxUserInputFileName.Name = "textBoxUserInputFileName";
            this.textBoxUserInputFileName.Size = new System.Drawing.Size(292, 22);
            this.textBoxUserInputFileName.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(602, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(136, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Bestand opslaan als: ";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tabControl1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 102);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1452, 731);
            this.panel2.TabIndex = 7;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.checkedListBox1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(4, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1798, 870);
            this.panel3.TabIndex = 1;
            // 
            // ExportObject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1452, 833);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "ExportObject";
            this.Text = "ExportObject";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridViewCompleteBeoordeling)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxObjectName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button buttonConfirmExport;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox textBoxUserInputFileName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckedListBox checkedListBoxTemplate;
        private ADGV.AdvancedDataGridView advancedDataGridViewCompleteBeoordeling;
        private System.Windows.Forms.Panel panel3;
    }
}