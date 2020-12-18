namespace RiskManagmentTool.InterfaceLayer.EditWindows
{
    partial class EditSettings
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
            this.buttonSave = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.checkedListBoxExcelSettings = new System.Windows.Forms.CheckedListBox();
            this.label8 = new System.Windows.Forms.Label();
            this.checkedListBoxRisicograaf = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxProjectNaam = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonSave);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 350);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 100);
            this.panel1.TabIndex = 0;
            // 
            // buttonSave
            // 
            this.buttonSave.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonSave.Location = new System.Drawing.Point(628, 0);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(172, 100);
            this.buttonSave.TabIndex = 0;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(250, 129);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(160, 17);
            this.label9.TabIndex = 11;
            this.label9.Text = "Export Excel instellingen";
            // 
            // checkedListBoxExcelSettings
            // 
            this.checkedListBoxExcelSettings.CheckOnClick = true;
            this.checkedListBoxExcelSettings.FormattingEnabled = true;
            this.checkedListBoxExcelSettings.Items.AddRange(new object[] {
            "volghorde 1",
            "Layout opmaak 1",
            "Layout opmaak 2"});
            this.checkedListBoxExcelSettings.Location = new System.Drawing.Point(247, 152);
            this.checkedListBoxExcelSettings.Name = "checkedListBoxExcelSettings";
            this.checkedListBoxExcelSettings.Size = new System.Drawing.Size(185, 106);
            this.checkedListBoxExcelSettings.TabIndex = 10;
            this.checkedListBoxExcelSettings.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBoxExcelSettings_ItemCheck);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(30, 129);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 17);
            this.label8.TabIndex = 9;
            this.label8.Text = "Risicograaf";
            // 
            // checkedListBoxRisicograaf
            // 
            this.checkedListBoxRisicograaf.CheckOnClick = true;
            this.checkedListBoxRisicograaf.FormattingEnabled = true;
            this.checkedListBoxRisicograaf.Items.AddRange(new object[] {
            "SIL",
            "PL"});
            this.checkedListBoxRisicograaf.Location = new System.Drawing.Point(34, 152);
            this.checkedListBoxRisicograaf.Name = "checkedListBoxRisicograaf";
            this.checkedListBoxRisicograaf.Size = new System.Drawing.Size(185, 106);
            this.checkedListBoxRisicograaf.TabIndex = 8;
            this.checkedListBoxRisicograaf.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBoxRisicograaf_ItemCheck);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 17);
            this.label1.TabIndex = 12;
            this.label1.Text = "Project naam: ";
            // 
            // textBoxProjectNaam
            // 
            this.textBoxProjectNaam.Location = new System.Drawing.Point(169, 22);
            this.textBoxProjectNaam.Name = "textBoxProjectNaam";
            this.textBoxProjectNaam.Size = new System.Drawing.Size(190, 22);
            this.textBoxProjectNaam.TabIndex = 14;
            // 
            // EditSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBoxProjectNaam);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.checkedListBoxExcelSettings);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.checkedListBoxRisicograaf);
            this.Controls.Add(this.panel1);
            this.Name = "EditSettings";
            this.Text = "EditSettings";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckedListBox checkedListBoxExcelSettings;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckedListBox checkedListBoxRisicograaf;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxProjectNaam;
    }
}