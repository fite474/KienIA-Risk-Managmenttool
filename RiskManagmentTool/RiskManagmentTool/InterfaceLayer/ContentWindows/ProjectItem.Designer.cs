namespace RiskManagmentTool.InterfaceLayer.ContentWindows
{
    partial class ProjectItem
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonOpenProject = new System.Windows.Forms.Button();
            this.labelProjectNaam = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.listBoxGekoppeldeObjecten = new System.Windows.Forms.ListBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonOpenProject
            // 
            this.buttonOpenProject.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOpenProject.Location = new System.Drawing.Point(30, 227);
            this.buttonOpenProject.Margin = new System.Windows.Forms.Padding(30, 3, 30, 3);
            this.buttonOpenProject.Name = "buttonOpenProject";
            this.buttonOpenProject.Size = new System.Drawing.Size(249, 50);
            this.buttonOpenProject.TabIndex = 0;
            this.buttonOpenProject.Text = "Open Project";
            this.buttonOpenProject.UseVisualStyleBackColor = true;
            this.buttonOpenProject.Click += new System.EventHandler(this.buttonOpenProject_Click);
            // 
            // labelProjectNaam
            // 
            this.labelProjectNaam.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelProjectNaam.AutoSize = true;
            this.labelProjectNaam.Location = new System.Drawing.Point(3, 42);
            this.labelProjectNaam.Name = "labelProjectNaam";
            this.labelProjectNaam.Size = new System.Drawing.Size(303, 17);
            this.labelProjectNaam.TabIndex = 1;
            this.labelProjectNaam.Text = "Project: asdda";
            this.labelProjectNaam.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.labelProjectNaam, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonOpenProject, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.listBoxGekoppeldeObjecten, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(309, 303);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // listBoxGekoppeldeObjecten
            // 
            this.listBoxGekoppeldeObjecten.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxGekoppeldeObjecten.FormattingEnabled = true;
            this.listBoxGekoppeldeObjecten.ItemHeight = 16;
            this.listBoxGekoppeldeObjecten.Location = new System.Drawing.Point(30, 104);
            this.listBoxGekoppeldeObjecten.Margin = new System.Windows.Forms.Padding(30, 3, 30, 3);
            this.listBoxGekoppeldeObjecten.MultiColumn = true;
            this.listBoxGekoppeldeObjecten.Name = "listBoxGekoppeldeObjecten";
            this.listBoxGekoppeldeObjecten.Size = new System.Drawing.Size(249, 95);
            this.listBoxGekoppeldeObjecten.TabIndex = 2;
            this.listBoxGekoppeldeObjecten.SelectedIndexChanged += new System.EventHandler(this.listBoxGekoppeldeObjecten_SelectedIndexChanged);
            // 
            // ProjectItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ProjectItem";
            this.Size = new System.Drawing.Size(315, 309);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonOpenProject;
        private System.Windows.Forms.Label labelProjectNaam;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ListBox listBoxGekoppeldeObjecten;
    }
}
