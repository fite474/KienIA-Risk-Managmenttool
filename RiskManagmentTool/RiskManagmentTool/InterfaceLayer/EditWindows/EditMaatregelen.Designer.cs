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
            this.buttonDeleteMaatregel = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.buttonAddMenuOption = new System.Windows.Forms.Button();
            this.checkedListBoxOptions = new System.Windows.Forms.CheckedListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxMaatregelOmschrijving = new System.Windows.Forms.TextBox();
            this.textBoxDocumentNummer = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 69);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Maatregel naam";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 311);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Maatregel Norm";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 408);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Maatregel categorie";
            // 
            // textBoxMaatregelNaam
            // 
            this.textBoxMaatregelNaam.Location = new System.Drawing.Point(149, 69);
            this.textBoxMaatregelNaam.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxMaatregelNaam.Multiline = true;
            this.textBoxMaatregelNaam.Name = "textBoxMaatregelNaam";
            this.textBoxMaatregelNaam.Size = new System.Drawing.Size(268, 47);
            this.textBoxMaatregelNaam.TabIndex = 5;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(643, 4);
            this.buttonSave.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(140, 46);
            this.buttonSave.TabIndex = 9;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonSave);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 533);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(864, 59);
            this.panel1.TabIndex = 11;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.textBoxDocumentNummer);
            this.panel2.Controls.Add(this.textBoxMaatregelOmschrijving);
            this.panel2.Controls.Add(this.label4);
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
            this.panel2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(562, 533);
            this.panel2.TabIndex = 12;
            // 
            // buttonCategorie
            // 
            this.buttonCategorie.Location = new System.Drawing.Point(441, 403);
            this.buttonCategorie.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonCategorie.Name = "buttonCategorie";
            this.buttonCategorie.Size = new System.Drawing.Size(66, 28);
            this.buttonCategorie.TabIndex = 9;
            this.buttonCategorie.Text = "Categorie";
            this.buttonCategorie.UseVisualStyleBackColor = true;
            this.buttonCategorie.Click += new System.EventHandler(this.buttonCategorie_Click);
            // 
            // buttonNorm
            // 
            this.buttonNorm.Location = new System.Drawing.Point(441, 311);
            this.buttonNorm.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonNorm.Name = "buttonNorm";
            this.buttonNorm.Size = new System.Drawing.Size(66, 28);
            this.buttonNorm.TabIndex = 8;
            this.buttonNorm.Text = "Norm";
            this.buttonNorm.UseVisualStyleBackColor = true;
            this.buttonNorm.Click += new System.EventHandler(this.buttonNorm_Click);
            // 
            // textBoxMaatregelCategorie
            // 
            this.textBoxMaatregelCategorie.Location = new System.Drawing.Point(149, 404);
            this.textBoxMaatregelCategorie.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxMaatregelCategorie.Multiline = true;
            this.textBoxMaatregelCategorie.Name = "textBoxMaatregelCategorie";
            this.textBoxMaatregelCategorie.ReadOnly = true;
            this.textBoxMaatregelCategorie.Size = new System.Drawing.Size(268, 39);
            this.textBoxMaatregelCategorie.TabIndex = 7;
            // 
            // textBoxMaatregelNorm
            // 
            this.textBoxMaatregelNorm.Location = new System.Drawing.Point(149, 311);
            this.textBoxMaatregelNorm.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxMaatregelNorm.Multiline = true;
            this.textBoxMaatregelNorm.Name = "textBoxMaatregelNorm";
            this.textBoxMaatregelNorm.ReadOnly = true;
            this.textBoxMaatregelNorm.Size = new System.Drawing.Size(268, 48);
            this.textBoxMaatregelNorm.TabIndex = 6;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.buttonDeleteMaatregel);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(562, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(302, 533);
            this.panel3.TabIndex = 13;
            // 
            // buttonDeleteMaatregel
            // 
            this.buttonDeleteMaatregel.Location = new System.Drawing.Point(119, 26);
            this.buttonDeleteMaatregel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonDeleteMaatregel.Name = "buttonDeleteMaatregel";
            this.buttonDeleteMaatregel.Size = new System.Drawing.Size(102, 41);
            this.buttonDeleteMaatregel.TabIndex = 1;
            this.buttonDeleteMaatregel.Text = "Verwijder deze maatregel";
            this.buttonDeleteMaatregel.UseVisualStyleBackColor = true;
            this.buttonDeleteMaatregel.Click += new System.EventHandler(this.buttonDeleteMaatregel_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.buttonAddMenuOption);
            this.panel4.Controls.Add(this.checkedListBoxOptions);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 104);
            this.panel4.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(302, 429);
            this.panel4.TabIndex = 0;
            // 
            // buttonAddMenuOption
            // 
            this.buttonAddMenuOption.Location = new System.Drawing.Point(0, 16);
            this.buttonAddMenuOption.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonAddMenuOption.Name = "buttonAddMenuOption";
            this.buttonAddMenuOption.Size = new System.Drawing.Size(122, 37);
            this.buttonAddMenuOption.TabIndex = 1;
            this.buttonAddMenuOption.Text = "Voeg keuze optie toe";
            this.buttonAddMenuOption.UseVisualStyleBackColor = true;
            this.buttonAddMenuOption.Click += new System.EventHandler(this.buttonAddMenuOption_Click);
            // 
            // checkedListBoxOptions
            // 
            this.checkedListBoxOptions.CheckOnClick = true;
            this.checkedListBoxOptions.FormattingEnabled = true;
            this.checkedListBoxOptions.Location = new System.Drawing.Point(2, 69);
            this.checkedListBoxOptions.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.checkedListBoxOptions.Name = "checkedListBoxOptions";
            this.checkedListBoxOptions.Size = new System.Drawing.Size(289, 259);
            this.checkedListBoxOptions.TabIndex = 0;
            this.checkedListBoxOptions.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBoxOptions_ItemCheck);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 180);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Maatregel omschrijving";
            // 
            // textBoxMaatregelOmschrijving
            // 
            this.textBoxMaatregelOmschrijving.Location = new System.Drawing.Point(149, 177);
            this.textBoxMaatregelOmschrijving.Multiline = true;
            this.textBoxMaatregelOmschrijving.Name = "textBoxMaatregelOmschrijving";
            this.textBoxMaatregelOmschrijving.Size = new System.Drawing.Size(268, 83);
            this.textBoxMaatregelOmschrijving.TabIndex = 11;
            this.textBoxMaatregelOmschrijving.Text = "Not implemented yet";
            // 
            // textBoxDocumentNummer
            // 
            this.textBoxDocumentNummer.Location = new System.Drawing.Point(149, 477);
            this.textBoxDocumentNummer.Name = "textBoxDocumentNummer";
            this.textBoxDocumentNummer.Size = new System.Drawing.Size(268, 20);
            this.textBoxDocumentNummer.TabIndex = 12;
            this.textBoxDocumentNummer.Text = "Not implemented yet";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 484);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Document nummer";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(441, 69);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(77, 47);
            this.button1.TabIndex = 14;
            this.button1.Text = "Soort maatregel";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // EditMaatregelen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(864, 592);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "EditMaatregelen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Maatregelen ";
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
        private System.Windows.Forms.Button buttonDeleteMaatregel;
        private System.Windows.Forms.TextBox textBoxMaatregelOmschrijving;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxDocumentNummer;
    }
}