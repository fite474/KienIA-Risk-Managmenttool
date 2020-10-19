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
            this.buttonRedirect = new System.Windows.Forms.Button();
            this.buttonMaatregelen = new System.Windows.Forms.Button();
            this.buttonRisicos = new System.Windows.Forms.Button();
            this.buttonTemplates = new System.Windows.Forms.Button();
            this.buttonObjecten = new System.Windows.Forms.Button();
            this.buttonProjecten = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonMenu = new System.Windows.Forms.Button();
            this.panelContent = new System.Windows.Forms.Panel();
            this.buttonKeuzes = new System.Windows.Forms.Button();
            this.panelMenu.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(151)))), ((int)(((byte)(25)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(200, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1592, 78);
            this.panel1.TabIndex = 0;
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(33)))), ((int)(((byte)(90)))));
            this.panelMenu.Controls.Add(this.buttonKeuzes);
            this.panelMenu.Controls.Add(this.buttonRedirect);
            this.panelMenu.Controls.Add(this.buttonMaatregelen);
            this.panelMenu.Controls.Add(this.buttonRisicos);
            this.panelMenu.Controls.Add(this.buttonTemplates);
            this.panelMenu.Controls.Add(this.buttonObjecten);
            this.panelMenu.Controls.Add(this.buttonProjecten);
            this.panelMenu.Controls.Add(this.panel2);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Margin = new System.Windows.Forms.Padding(4);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(200, 937);
            this.panelMenu.TabIndex = 1;
            // 
            // buttonRedirect
            // 
            this.buttonRedirect.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonRedirect.Location = new System.Drawing.Point(0, 468);
            this.buttonRedirect.Margin = new System.Windows.Forms.Padding(4);
            this.buttonRedirect.Name = "buttonRedirect";
            this.buttonRedirect.Size = new System.Drawing.Size(200, 78);
            this.buttonRedirect.TabIndex = 6;
            this.buttonRedirect.Text = "Zoeken";
            this.buttonRedirect.UseVisualStyleBackColor = true;
            this.buttonRedirect.Click += new System.EventHandler(this.buttonRedirect_Click);
            // 
            // buttonMaatregelen
            // 
            this.buttonMaatregelen.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonMaatregelen.Location = new System.Drawing.Point(0, 390);
            this.buttonMaatregelen.Margin = new System.Windows.Forms.Padding(4);
            this.buttonMaatregelen.Name = "buttonMaatregelen";
            this.buttonMaatregelen.Size = new System.Drawing.Size(200, 78);
            this.buttonMaatregelen.TabIndex = 4;
            this.buttonMaatregelen.Text = "Maatregelen lijst";
            this.buttonMaatregelen.UseVisualStyleBackColor = true;
            this.buttonMaatregelen.Click += new System.EventHandler(this.buttonMaatregelen_Click);
            // 
            // buttonRisicos
            // 
            this.buttonRisicos.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonRisicos.Location = new System.Drawing.Point(0, 312);
            this.buttonRisicos.Margin = new System.Windows.Forms.Padding(4);
            this.buttonRisicos.Name = "buttonRisicos";
            this.buttonRisicos.Size = new System.Drawing.Size(200, 78);
            this.buttonRisicos.TabIndex = 3;
            this.buttonRisicos.Text = "Risico lijst";
            this.buttonRisicos.UseVisualStyleBackColor = true;
            this.buttonRisicos.Click += new System.EventHandler(this.buttonRisicos_Click);
            // 
            // buttonTemplates
            // 
            this.buttonTemplates.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonTemplates.Location = new System.Drawing.Point(0, 234);
            this.buttonTemplates.Margin = new System.Windows.Forms.Padding(4);
            this.buttonTemplates.Name = "buttonTemplates";
            this.buttonTemplates.Size = new System.Drawing.Size(200, 78);
            this.buttonTemplates.TabIndex = 2;
            this.buttonTemplates.Text = "templates";
            this.buttonTemplates.UseVisualStyleBackColor = true;
            this.buttonTemplates.Click += new System.EventHandler(this.buttonTemplates_Click);
            // 
            // buttonObjecten
            // 
            this.buttonObjecten.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonObjecten.Location = new System.Drawing.Point(0, 156);
            this.buttonObjecten.Margin = new System.Windows.Forms.Padding(4);
            this.buttonObjecten.Name = "buttonObjecten";
            this.buttonObjecten.Size = new System.Drawing.Size(200, 78);
            this.buttonObjecten.TabIndex = 1;
            this.buttonObjecten.Text = "objecten";
            this.buttonObjecten.UseVisualStyleBackColor = true;
            this.buttonObjecten.Click += new System.EventHandler(this.buttonObjecten_Click);
            // 
            // buttonProjecten
            // 
            this.buttonProjecten.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonProjecten.Location = new System.Drawing.Point(0, 78);
            this.buttonProjecten.Margin = new System.Windows.Forms.Padding(4);
            this.buttonProjecten.Name = "buttonProjecten";
            this.buttonProjecten.Size = new System.Drawing.Size(200, 78);
            this.buttonProjecten.TabIndex = 0;
            this.buttonProjecten.Text = "projecten";
            this.buttonProjecten.UseVisualStyleBackColor = true;
            this.buttonProjecten.Click += new System.EventHandler(this.buttonProjecten_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.buttonMenu);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 78);
            this.panel2.TabIndex = 5;
            // 
            // buttonMenu
            // 
            this.buttonMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonMenu.Location = new System.Drawing.Point(0, 0);
            this.buttonMenu.Name = "buttonMenu";
            this.buttonMenu.Size = new System.Drawing.Size(200, 78);
            this.buttonMenu.TabIndex = 0;
            this.buttonMenu.Text = "show / hide menu bar\r\n\r\n";
            this.buttonMenu.UseVisualStyleBackColor = true;
            this.buttonMenu.Click += new System.EventHandler(this.buttonMenu_Click);
            // 
            // panelContent
            // 
            this.panelContent.AutoScroll = true;
            this.panelContent.Location = new System.Drawing.Point(200, 78);
            this.panelContent.Margin = new System.Windows.Forms.Padding(4);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(1592, 859);
            this.panelContent.TabIndex = 2;
            // 
            // buttonKeuzes
            // 
            this.buttonKeuzes.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonKeuzes.Location = new System.Drawing.Point(0, 546);
            this.buttonKeuzes.Margin = new System.Windows.Forms.Padding(4);
            this.buttonKeuzes.Name = "buttonKeuzes";
            this.buttonKeuzes.Size = new System.Drawing.Size(200, 78);
            this.buttonKeuzes.TabIndex = 7;
            this.buttonKeuzes.Text = "Keuze Opties";
            this.buttonKeuzes.UseVisualStyleBackColor = true;
            this.buttonKeuzes.Click += new System.EventHandler(this.buttonKeuzes_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1792, 937);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelMenu);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MinimumSize = new System.Drawing.Size(500, 300);
            this.Name = "MainWindow";
            this.Text = "MainWindow";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panelMenu.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
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
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button buttonMenu;
        private System.Windows.Forms.Button buttonRedirect;
        private System.Windows.Forms.Button buttonKeuzes;
    }
}