namespace RiskManagmentTool.InterfaceLayer.ContentWindows
{
    partial class ContentProjecten
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
            this.buttonAddNew = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panelEditProject = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridViewProjecten = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panelEditProject.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProjecten)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonAddNew);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1575, 100);
            this.panel1.TabIndex = 0;
            // 
            // buttonAddNew
            // 
            this.buttonAddNew.Location = new System.Drawing.Point(3, 3);
            this.buttonAddNew.Name = "buttonAddNew";
            this.buttonAddNew.Size = new System.Drawing.Size(281, 91);
            this.buttonAddNew.TabIndex = 1;
            this.buttonAddNew.Text = "Add";
            this.buttonAddNew.UseVisualStyleBackColor = true;
            this.buttonAddNew.Click += new System.EventHandler(this.buttonAddNew_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panelEditProject);
            this.panel2.Controls.Add(this.dataGridViewProjecten);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 100);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1575, 712);
            this.panel2.TabIndex = 1;
            // 
            // panelEditProject
            // 
            this.panelEditProject.Controls.Add(this.label1);
            this.panelEditProject.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEditProject.Location = new System.Drawing.Point(284, 0);
            this.panelEditProject.Name = "panelEditProject";
            this.panelEditProject.Size = new System.Drawing.Size(1291, 712);
            this.panelEditProject.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 139);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(298, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Klik op een project om de objecten te bekijken";
            this.label1.Visible = false;
            // 
            // dataGridViewProjecten
            // 
            this.dataGridViewProjecten.AllowUserToAddRows = false;
            this.dataGridViewProjecten.AllowUserToDeleteRows = false;
            this.dataGridViewProjecten.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewProjecten.Dock = System.Windows.Forms.DockStyle.Left;
            this.dataGridViewProjecten.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewProjecten.Name = "dataGridViewProjecten";
            this.dataGridViewProjecten.ReadOnly = true;
            this.dataGridViewProjecten.RowTemplate.Height = 24;
            this.dataGridViewProjecten.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewProjecten.Size = new System.Drawing.Size(284, 712);
            this.dataGridViewProjecten.TabIndex = 0;
            this.dataGridViewProjecten.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataGridViewProjecten_DataBindingComplete);
            this.dataGridViewProjecten.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dataGridViewProjecten_MouseDoubleClick);
            // 
            // ContentProjecten
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1575, 812);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "ContentProjecten";
            this.Text = "ContentProjecten";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panelEditProject.ResumeLayout(false);
            this.panelEditProject.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProjecten)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button buttonAddNew;
        private System.Windows.Forms.DataGridView dataGridViewProjecten;
        private System.Windows.Forms.Panel panelEditProject;
        private System.Windows.Forms.Label label1;
    }
}