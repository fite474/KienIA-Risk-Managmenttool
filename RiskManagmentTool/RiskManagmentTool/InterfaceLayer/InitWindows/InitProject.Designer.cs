namespace RiskManagmentTool.InterfaceLayer.InitWindows
{
    partial class InitProject
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
            this.buttonCreateProject = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxProjectNaam = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonCreateProject
            // 
            this.buttonCreateProject.Location = new System.Drawing.Point(541, 354);
            this.buttonCreateProject.Name = "buttonCreateProject";
            this.buttonCreateProject.Size = new System.Drawing.Size(128, 54);
            this.buttonCreateProject.TabIndex = 0;
            this.buttonCreateProject.Text = "Maak project aan";
            this.buttonCreateProject.UseVisualStyleBackColor = true;
            this.buttonCreateProject.Click += new System.EventHandler(this.buttonCreateProject_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(102, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Project naam: ";
            // 
            // textBoxProjectNaam
            // 
            this.textBoxProjectNaam.Location = new System.Drawing.Point(207, 77);
            this.textBoxProjectNaam.Name = "textBoxProjectNaam";
            this.textBoxProjectNaam.Size = new System.Drawing.Size(175, 22);
            this.textBoxProjectNaam.TabIndex = 2;
            // 
            // InitProject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBoxProjectNaam);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonCreateProject);
            this.Name = "InitProject";
            this.Text = "InitProject";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCreateProject;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxProjectNaam;
    }
}