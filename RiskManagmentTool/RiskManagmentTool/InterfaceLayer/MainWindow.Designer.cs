namespace RiskManagmentTool.InterfaceLayer
{
    partial class MainWindow
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
            this.panelMenu = new System.Windows.Forms.Panel();
            this.buttonProjecten = new System.Windows.Forms.Button();
            this.buttonObjecten = new System.Windows.Forms.Button();
            this.buttonTemplates = new System.Windows.Forms.Button();
            this.buttonRisicos = new System.Windows.Forms.Button();
            this.buttonMaatregelen = new System.Windows.Forms.Button();
            this.panelContent = new System.Windows.Forms.Panel();
            this.panelMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(151)))), ((int)(((byte)(25)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1344, 63);
            this.panel1.TabIndex = 0;
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(33)))), ((int)(((byte)(90)))));
            this.panelMenu.Controls.Add(this.buttonMaatregelen);
            this.panelMenu.Controls.Add(this.buttonRisicos);
            this.panelMenu.Controls.Add(this.buttonTemplates);
            this.panelMenu.Controls.Add(this.buttonObjecten);
            this.panelMenu.Controls.Add(this.buttonProjecten);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 63);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(149, 698);
            this.panelMenu.TabIndex = 1;
            // 
            // buttonProjecten
            // 
            this.buttonProjecten.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonProjecten.Location = new System.Drawing.Point(0, 0);
            this.buttonProjecten.Name = "buttonProjecten";
            this.buttonProjecten.Size = new System.Drawing.Size(149, 63);
            this.buttonProjecten.TabIndex = 0;
            this.buttonProjecten.Text = "projecten";
            this.buttonProjecten.UseVisualStyleBackColor = true;
            this.buttonProjecten.Click += new System.EventHandler(this.buttonProjecten_Click);
            // 
            // buttonObjecten
            // 
            this.buttonObjecten.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonObjecten.Location = new System.Drawing.Point(0, 63);
            this.buttonObjecten.Name = "buttonObjecten";
            this.buttonObjecten.Size = new System.Drawing.Size(149, 63);
            this.buttonObjecten.TabIndex = 1;
            this.buttonObjecten.Text = "objecten";
            this.buttonObjecten.UseVisualStyleBackColor = true;
            this.buttonObjecten.Click += new System.EventHandler(this.buttonObjecten_Click);
            // 
            // buttonTemplates
            // 
            this.buttonTemplates.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonTemplates.Location = new System.Drawing.Point(0, 126);
            this.buttonTemplates.Name = "buttonTemplates";
            this.buttonTemplates.Size = new System.Drawing.Size(149, 63);
            this.buttonTemplates.TabIndex = 2;
            this.buttonTemplates.Text = "templates";
            this.buttonTemplates.UseVisualStyleBackColor = true;
            this.buttonTemplates.Click += new System.EventHandler(this.buttonTemplates_Click);
            // 
            // buttonRisicos
            // 
            this.buttonRisicos.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonRisicos.Location = new System.Drawing.Point(0, 189);
            this.buttonRisicos.Name = "buttonRisicos";
            this.buttonRisicos.Size = new System.Drawing.Size(149, 63);
            this.buttonRisicos.TabIndex = 3;
            this.buttonRisicos.Text = "Risico lijst";
            this.buttonRisicos.UseVisualStyleBackColor = true;
            this.buttonRisicos.Click += new System.EventHandler(this.buttonRisicos_Click);
            // 
            // buttonMaatregelen
            // 
            this.buttonMaatregelen.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonMaatregelen.Location = new System.Drawing.Point(0, 252);
            this.buttonMaatregelen.Name = "buttonMaatregelen";
            this.buttonMaatregelen.Size = new System.Drawing.Size(149, 63);
            this.buttonMaatregelen.TabIndex = 4;
            this.buttonMaatregelen.Text = "Maatregelen lijst";
            this.buttonMaatregelen.UseVisualStyleBackColor = true;
            this.buttonMaatregelen.Click += new System.EventHandler(this.buttonMaatregelen_Click);
            // 
            // panelContent
            // 
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(149, 63);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(1195, 698);
            this.panelContent.TabIndex = 2;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1344, 761);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelMenu);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "MainWindow";
            this.Text = "MainWindow";
            this.panelMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Button buttonMaatregelen;
        private System.Windows.Forms.Button buttonRisicos;
        private System.Windows.Forms.Button buttonTemplates;
        private System.Windows.Forms.Button buttonObjecten;
        private System.Windows.Forms.Button buttonProjecten;
        private System.Windows.Forms.Panel panelContent;
    }
}