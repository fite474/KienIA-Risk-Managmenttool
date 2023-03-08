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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelAppTitle = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.buttonHelp = new System.Windows.Forms.Button();
            this.buttonKeuzes = new System.Windows.Forms.Button();
            this.buttonRedirect = new System.Windows.Forms.Button();
            this.buttonMaatregelen = new System.Windows.Forms.Button();
            this.buttonRisicos = new System.Windows.Forms.Button();
            this.buttonTemplates = new System.Windows.Forms.Button();
            this.buttonObjecten = new System.Windows.Forms.Button();
            this.buttonProjecten = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panelContent = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(151)))), ((int)(((byte)(25)))));
            this.panel1.Controls.Add(this.labelAppTitle);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(200, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1592, 106);
            this.panel1.TabIndex = 0;
            // 
            // labelAppTitle
            // 
            this.labelAppTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.labelAppTitle.AutoSize = true;
            this.labelAppTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAppTitle.Location = new System.Drawing.Point(466, 31);
            this.labelAppTitle.Name = "labelAppTitle";
            this.labelAppTitle.Size = new System.Drawing.Size(478, 39);
            this.labelAppTitle.TabIndex = 0;
            this.labelAppTitle.Text = "KienIA Risk Management Tool";
            this.labelAppTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1592, 106);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(33)))), ((int)(((byte)(90)))));
            this.panelMenu.Controls.Add(this.buttonHelp);
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
            // buttonHelp
            // 
            this.buttonHelp.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonHelp.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonHelp.Location = new System.Drawing.Point(0, 652);
            this.buttonHelp.Margin = new System.Windows.Forms.Padding(4);
            this.buttonHelp.Name = "buttonHelp";
            this.buttonHelp.Size = new System.Drawing.Size(200, 78);
            this.buttonHelp.TabIndex = 8;
            this.buttonHelp.Text = "Gebruikers handleiding";
            this.buttonHelp.UseVisualStyleBackColor = true;
            this.buttonHelp.Click += new System.EventHandler(this.buttonHelp_Click);
            // 
            // buttonKeuzes
            // 
            this.buttonKeuzes.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonKeuzes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonKeuzes.Location = new System.Drawing.Point(0, 574);
            this.buttonKeuzes.Margin = new System.Windows.Forms.Padding(4);
            this.buttonKeuzes.Name = "buttonKeuzes";
            this.buttonKeuzes.Size = new System.Drawing.Size(200, 78);
            this.buttonKeuzes.TabIndex = 7;
            this.buttonKeuzes.Text = "Keuze Opties";
            this.buttonKeuzes.UseVisualStyleBackColor = true;
            this.buttonKeuzes.Click += new System.EventHandler(this.buttonKeuzes_Click);
            // 
            // buttonRedirect
            // 
            this.buttonRedirect.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonRedirect.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRedirect.Location = new System.Drawing.Point(0, 496);
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
            this.buttonMaatregelen.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonMaatregelen.Location = new System.Drawing.Point(0, 418);
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
            this.buttonRisicos.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRisicos.Location = new System.Drawing.Point(0, 340);
            this.buttonRisicos.Margin = new System.Windows.Forms.Padding(4);
            this.buttonRisicos.Name = "buttonRisicos";
            this.buttonRisicos.Size = new System.Drawing.Size(200, 78);
            this.buttonRisicos.TabIndex = 3;
            this.buttonRisicos.Text = "Gevaren lijst";
            this.buttonRisicos.UseVisualStyleBackColor = true;
            this.buttonRisicos.Click += new System.EventHandler(this.buttonRisicos_Click);
            // 
            // buttonTemplates
            // 
            this.buttonTemplates.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonTemplates.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonTemplates.Location = new System.Drawing.Point(0, 262);
            this.buttonTemplates.Margin = new System.Windows.Forms.Padding(4);
            this.buttonTemplates.Name = "buttonTemplates";
            this.buttonTemplates.Size = new System.Drawing.Size(200, 78);
            this.buttonTemplates.TabIndex = 2;
            this.buttonTemplates.Text = "Templates";
            this.buttonTemplates.UseVisualStyleBackColor = true;
            this.buttonTemplates.Visible = false;
            this.buttonTemplates.Click += new System.EventHandler(this.buttonTemplates_Click);
            // 
            // buttonObjecten
            // 
            this.buttonObjecten.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonObjecten.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonObjecten.Location = new System.Drawing.Point(0, 184);
            this.buttonObjecten.Margin = new System.Windows.Forms.Padding(4);
            this.buttonObjecten.Name = "buttonObjecten";
            this.buttonObjecten.Size = new System.Drawing.Size(200, 78);
            this.buttonObjecten.TabIndex = 1;
            this.buttonObjecten.Text = "Objecten";
            this.buttonObjecten.UseVisualStyleBackColor = true;
            this.buttonObjecten.Click += new System.EventHandler(this.buttonObjecten_Click);
            // 
            // buttonProjecten
            // 
            this.buttonProjecten.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonProjecten.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonProjecten.Location = new System.Drawing.Point(0, 106);
            this.buttonProjecten.Margin = new System.Windows.Forms.Padding(4);
            this.buttonProjecten.Name = "buttonProjecten";
            this.buttonProjecten.Size = new System.Drawing.Size(200, 78);
            this.buttonProjecten.TabIndex = 0;
            this.buttonProjecten.Text = "Projecten";
            this.buttonProjecten.UseVisualStyleBackColor = true;
            this.buttonProjecten.Click += new System.EventHandler(this.buttonProjecten_Click);
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 106);
            this.panel2.TabIndex = 5;
            // 
            // panelContent
            // 
            this.panelContent.AutoScroll = true;
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(200, 106);
            this.panelContent.Margin = new System.Windows.Forms.Padding(4);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(1592, 831);
            this.panelContent.TabIndex = 2;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1792, 937);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MinimumSize = new System.Drawing.Size(500, 300);
            this.Name = "MainWindow";
            this.Text = "KienIA Risk Managment Tool";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
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
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button buttonRedirect;
        private System.Windows.Forms.Button buttonKeuzes;
        private System.Windows.Forms.Label labelAppTitle;
        private System.Windows.Forms.Button buttonHelp;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}