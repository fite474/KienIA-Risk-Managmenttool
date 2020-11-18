namespace RiskManagmentTool.InterfaceLayer.EditWindows
{
    partial class EditKeuzes
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
            this.listBoxMenuOptions = new System.Windows.Forms.ListBox();
            this.buttonAddOption = new System.Windows.Forms.Button();
            this.buttonDeleteOption = new System.Windows.Forms.Button();
            this.buttonDone = new System.Windows.Forms.Button();
            this.buttonEditOption = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxMenuName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // listBoxMenuOptions
            // 
            this.listBoxMenuOptions.FormattingEnabled = true;
            this.listBoxMenuOptions.ItemHeight = 16;
            this.listBoxMenuOptions.Location = new System.Drawing.Point(111, 86);
            this.listBoxMenuOptions.Name = "listBoxMenuOptions";
            this.listBoxMenuOptions.Size = new System.Drawing.Size(266, 196);
            this.listBoxMenuOptions.TabIndex = 0;
            // 
            // buttonAddOption
            // 
            this.buttonAddOption.Location = new System.Drawing.Point(111, 313);
            this.buttonAddOption.Name = "buttonAddOption";
            this.buttonAddOption.Size = new System.Drawing.Size(75, 23);
            this.buttonAddOption.TabIndex = 1;
            this.buttonAddOption.Text = "Add";
            this.buttonAddOption.UseVisualStyleBackColor = true;
            this.buttonAddOption.Click += new System.EventHandler(this.buttonAddOption_Click);
            // 
            // buttonDeleteOption
            // 
            this.buttonDeleteOption.Location = new System.Drawing.Point(204, 313);
            this.buttonDeleteOption.Name = "buttonDeleteOption";
            this.buttonDeleteOption.Size = new System.Drawing.Size(75, 23);
            this.buttonDeleteOption.TabIndex = 2;
            this.buttonDeleteOption.Text = "Delete";
            this.buttonDeleteOption.UseVisualStyleBackColor = true;
            // 
            // buttonDone
            // 
            this.buttonDone.Location = new System.Drawing.Point(455, 385);
            this.buttonDone.Name = "buttonDone";
            this.buttonDone.Size = new System.Drawing.Size(75, 23);
            this.buttonDone.TabIndex = 3;
            this.buttonDone.Text = "Done";
            this.buttonDone.UseVisualStyleBackColor = true;
            this.buttonDone.Click += new System.EventHandler(this.buttonDone_Click);
            // 
            // buttonEditOption
            // 
            this.buttonEditOption.Location = new System.Drawing.Point(302, 313);
            this.buttonEditOption.Name = "buttonEditOption";
            this.buttonEditOption.Size = new System.Drawing.Size(75, 23);
            this.buttonEditOption.TabIndex = 4;
            this.buttonEditOption.Text = "Edit text";
            this.buttonEditOption.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Menu: ";
            // 
            // textBoxMenuName
            // 
            this.textBoxMenuName.Location = new System.Drawing.Point(111, 34);
            this.textBoxMenuName.Name = "textBoxMenuName";
            this.textBoxMenuName.ReadOnly = true;
            this.textBoxMenuName.Size = new System.Drawing.Size(207, 22);
            this.textBoxMenuName.TabIndex = 6;
            // 
            // EditKeuzes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 427);
            this.Controls.Add(this.textBoxMenuName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonEditOption);
            this.Controls.Add(this.buttonDone);
            this.Controls.Add(this.buttonDeleteOption);
            this.Controls.Add(this.buttonAddOption);
            this.Controls.Add(this.listBoxMenuOptions);
            this.Name = "EditKeuzes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EditKeuzes";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxMenuOptions;
        private System.Windows.Forms.Button buttonAddOption;
        private System.Windows.Forms.Button buttonDeleteOption;
        private System.Windows.Forms.Button buttonDone;
        private System.Windows.Forms.Button buttonEditOption;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxMenuName;
    }
}