namespace RiskManagmentTool.InterfaceLayer.InitWindows
{
    partial class InitTemplate
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
            this.buttonCreateTemplate = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxTemplateNaam = new System.Windows.Forms.TextBox();
            this.comboBoxTemplateType = new System.Windows.Forms.ComboBox();
            this.comboBoxTemplateToepassing = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // buttonCreateTemplate
            // 
            this.buttonCreateTemplate.Location = new System.Drawing.Point(622, 359);
            this.buttonCreateTemplate.Name = "buttonCreateTemplate";
            this.buttonCreateTemplate.Size = new System.Drawing.Size(116, 59);
            this.buttonCreateTemplate.TabIndex = 0;
            this.buttonCreateTemplate.Text = "Maak template aan";
            this.buttonCreateTemplate.UseVisualStyleBackColor = true;
            this.buttonCreateTemplate.Click += new System.EventHandler(this.buttonCreateTemplate_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(82, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Template naam";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(85, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Template type";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(88, 164);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(138, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Van toepassing voor";
            // 
            // textBoxTemplateNaam
            // 
            this.textBoxTemplateNaam.Location = new System.Drawing.Point(256, 65);
            this.textBoxTemplateNaam.Name = "textBoxTemplateNaam";
            this.textBoxTemplateNaam.Size = new System.Drawing.Size(234, 22);
            this.textBoxTemplateNaam.TabIndex = 4;
            // 
            // comboBoxTemplateType
            // 
            this.comboBoxTemplateType.FormattingEnabled = true;
            this.comboBoxTemplateType.Location = new System.Drawing.Point(256, 105);
            this.comboBoxTemplateType.Name = "comboBoxTemplateType";
            this.comboBoxTemplateType.Size = new System.Drawing.Size(234, 24);
            this.comboBoxTemplateType.TabIndex = 5;
            // 
            // comboBoxTemplateToepassing
            // 
            this.comboBoxTemplateToepassing.FormattingEnabled = true;
            this.comboBoxTemplateToepassing.Location = new System.Drawing.Point(256, 155);
            this.comboBoxTemplateToepassing.Name = "comboBoxTemplateToepassing";
            this.comboBoxTemplateToepassing.Size = new System.Drawing.Size(234, 24);
            this.comboBoxTemplateToepassing.TabIndex = 6;
            // 
            // InitTemplate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.comboBoxTemplateToepassing);
            this.Controls.Add(this.comboBoxTemplateType);
            this.Controls.Add(this.textBoxTemplateNaam);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonCreateTemplate);
            this.Name = "InitTemplate";
            this.Text = "InitTemplate";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCreateTemplate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxTemplateNaam;
        private System.Windows.Forms.ComboBox comboBoxTemplateType;
        private System.Windows.Forms.ComboBox comboBoxTemplateToepassing;
    }
}