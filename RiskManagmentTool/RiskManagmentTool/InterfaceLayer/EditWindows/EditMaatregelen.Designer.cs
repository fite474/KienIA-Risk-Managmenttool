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
            this.textBoxMaatregelNaam = new System.Windows.Forms.TextBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonCategorie = new System.Windows.Forms.Button();
            this.buttonNorm = new System.Windows.Forms.Button();
            this.textBoxMaatregelCategorie = new System.Windows.Forms.TextBox();
            this.textBoxMaatregelNorm = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.buttonAddMenuOption = new System.Windows.Forms.Button();
            this.checkedListBoxOptions = new System.Windows.Forms.CheckedListBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Maatregel naam";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 161);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Maatregel Norm";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 281);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Maatregel categorie";
            // 
            // textBoxMaatregelNaam
            // 
            this.textBoxMaatregelNaam.Location = new System.Drawing.Point(200, 65);
            this.textBoxMaatregelNaam.Multiline = true;
            this.textBoxMaatregelNaam.Name = "textBoxMaatregelNaam";
            this.textBoxMaatregelNaam.Size = new System.Drawing.Size(356, 57);
            this.textBoxMaatregelNaam.TabIndex = 5;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(742, 13);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(116, 48);
            this.buttonSave.TabIndex = 9;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonSave);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 474);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1093, 73);
            this.panel1.TabIndex = 11;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.buttonCategorie);
            this.panel2.Controls.Add(this.buttonNorm);
            this.panel2.Controls.Add(this.textBoxMaatregelCategorie);
            this.panel2.Controls.Add(this.textBoxMaatregelNorm);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.textBoxMaatregelNaam);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(683, 474);
            this.panel2.TabIndex = 12;
            // 
            // buttonCategorie
            // 
            this.buttonCategorie.Location = new System.Drawing.Point(589, 275);
            this.buttonCategorie.Name = "buttonCategorie";
            this.buttonCategorie.Size = new System.Drawing.Size(88, 34);
            this.buttonCategorie.TabIndex = 9;
            this.buttonCategorie.Text = "Categorie";
            this.buttonCategorie.UseVisualStyleBackColor = true;
            this.buttonCategorie.Click += new System.EventHandler(this.buttonCategorie_Click);
            // 
            // buttonNorm
            // 
            this.buttonNorm.Location = new System.Drawing.Point(590, 161);
            this.buttonNorm.Name = "buttonNorm";
            this.buttonNorm.Size = new System.Drawing.Size(88, 34);
            this.buttonNorm.TabIndex = 8;
            this.buttonNorm.Text = "Norm";
            this.buttonNorm.UseVisualStyleBackColor = true;
            this.buttonNorm.Click += new System.EventHandler(this.buttonNorm_Click);
            // 
            // textBoxMaatregelCategorie
            // 
            this.textBoxMaatregelCategorie.Location = new System.Drawing.Point(200, 276);
            this.textBoxMaatregelCategorie.Multiline = true;
            this.textBoxMaatregelCategorie.Name = "textBoxMaatregelCategorie";
            this.textBoxMaatregelCategorie.Size = new System.Drawing.Size(356, 47);
            this.textBoxMaatregelCategorie.TabIndex = 7;
            // 
            // textBoxMaatregelNorm
            // 
            this.textBoxMaatregelNorm.Location = new System.Drawing.Point(200, 161);
            this.textBoxMaatregelNorm.Name = "textBoxMaatregelNorm";
            this.textBoxMaatregelNorm.Size = new System.Drawing.Size(356, 22);
            this.textBoxMaatregelNorm.TabIndex = 6;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(683, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(410, 474);
            this.panel3.TabIndex = 13;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.buttonAddMenuOption);
            this.panel4.Controls.Add(this.checkedListBoxOptions);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 65);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(410, 409);
            this.panel4.TabIndex = 0;
            // 
            // buttonAddMenuOption
            // 
            this.buttonAddMenuOption.Location = new System.Drawing.Point(0, 20);
            this.buttonAddMenuOption.Name = "buttonAddMenuOption";
            this.buttonAddMenuOption.Size = new System.Drawing.Size(162, 46);
            this.buttonAddMenuOption.TabIndex = 1;
            this.buttonAddMenuOption.Text = "Voeg keuze optie toe";
            this.buttonAddMenuOption.UseVisualStyleBackColor = true;
            this.buttonAddMenuOption.Click += new System.EventHandler(this.buttonAddMenuOption_Click);
            // 
            // checkedListBoxOptions
            // 
            this.checkedListBoxOptions.CheckOnClick = true;
            this.checkedListBoxOptions.FormattingEnabled = true;
            this.checkedListBoxOptions.Location = new System.Drawing.Point(3, 85);
            this.checkedListBoxOptions.Name = "checkedListBoxOptions";
            this.checkedListBoxOptions.Size = new System.Drawing.Size(293, 242);
            this.checkedListBoxOptions.TabIndex = 0;
            this.checkedListBoxOptions.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBoxOptions_ItemCheck);
            // 
            // EditMaatregelen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1093, 547);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "EditMaatregelen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EditMaatregelen";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxMaatregelNaam;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox textBoxMaatregelCategorie;
        private System.Windows.Forms.TextBox textBoxMaatregelNorm;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button buttonAddMenuOption;
        private System.Windows.Forms.CheckedListBox checkedListBoxOptions;
        private System.Windows.Forms.Button buttonCategorie;
        private System.Windows.Forms.Button buttonNorm;
    }
}