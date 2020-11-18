namespace RiskManagmentTool.InterfaceLayer.EditWindows
{
    partial class EditMaatregelen
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
            this.textBoxMaatregelNaam = new System.Windows.Forms.TextBox();
            this.comboBoxMaatregelCategory = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.comboBoxMaatregelNorm = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(75, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Maatregel naam";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(75, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Maatregel Norm";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(75, 175);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Maatregel categorie";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 431);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "Maatregel type";
            this.label4.Visible = false;
            // 
            // textBoxMaatregelNaam
            // 
            this.textBoxMaatregelNaam.Location = new System.Drawing.Point(294, 48);
            this.textBoxMaatregelNaam.Name = "textBoxMaatregelNaam";
            this.textBoxMaatregelNaam.Size = new System.Drawing.Size(495, 22);
            this.textBoxMaatregelNaam.TabIndex = 5;
            // 
            // comboBoxMaatregelCategory
            // 
            this.comboBoxMaatregelCategory.FormattingEnabled = true;
            this.comboBoxMaatregelCategory.Location = new System.Drawing.Point(294, 166);
            this.comboBoxMaatregelCategory.Name = "comboBoxMaatregelCategory";
            this.comboBoxMaatregelCategory.Size = new System.Drawing.Size(495, 24);
            this.comboBoxMaatregelCategory.TabIndex = 7;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(232, 431);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(196, 24);
            this.comboBox2.TabIndex = 8;
            this.comboBox2.Visible = false;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(597, 324);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(116, 48);
            this.buttonSave.TabIndex = 9;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // comboBoxMaatregelNorm
            // 
            this.comboBoxMaatregelNorm.FormattingEnabled = true;
            this.comboBoxMaatregelNorm.Location = new System.Drawing.Point(294, 104);
            this.comboBoxMaatregelNorm.Name = "comboBoxMaatregelNorm";
            this.comboBoxMaatregelNorm.Size = new System.Drawing.Size(495, 24);
            this.comboBoxMaatregelNorm.TabIndex = 10;
            // 
            // EditMaatregelen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(905, 467);
            this.Controls.Add(this.comboBoxMaatregelNorm);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBoxMaatregelCategory);
            this.Controls.Add(this.textBoxMaatregelNaam);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "EditMaatregelen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EditMaatregelen";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxMaatregelNaam;
        private System.Windows.Forms.ComboBox comboBoxMaatregelCategory;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.ComboBox comboBoxMaatregelNorm;
    }
}