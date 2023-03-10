namespace RiskManagmentTool.InterfaceLayer.WeergeefWindows
{
    partial class ShowMenuItemUsage
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
            this.dataGridViewItemUsage = new System.Windows.Forms.DataGridView();
            this.buttonProceedDelete = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.textBoxSelectedOption = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewItemUsage)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // dataGridViewItemUsage
            // 
            this.dataGridViewItemUsage.AllowUserToAddRows = false;
            this.dataGridViewItemUsage.AllowUserToDeleteRows = false;
            this.dataGridViewItemUsage.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridViewItemUsage.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewItemUsage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewItemUsage.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewItemUsage.Name = "dataGridViewItemUsage";
            this.dataGridViewItemUsage.ReadOnly = true;
            this.dataGridViewItemUsage.RowHeadersWidth = 51;
            this.dataGridViewItemUsage.RowTemplate.Height = 24;
            this.dataGridViewItemUsage.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewItemUsage.Size = new System.Drawing.Size(1724, 786);
            this.dataGridViewItemUsage.TabIndex = 1;
            this.dataGridViewItemUsage.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataGridViewItemUsage_DataBindingComplete);
            // 
            // buttonProceedDelete
            // 
            this.buttonProceedDelete.Location = new System.Drawing.Point(810, 6);
            this.buttonProceedDelete.Name = "buttonProceedDelete";
            this.buttonProceedDelete.Size = new System.Drawing.Size(175, 56);
            this.buttonProceedDelete.TabIndex = 2;
            this.buttonProceedDelete.Text = "Verwijder deze optie uit alle gevaren";
            this.buttonProceedDelete.UseVisualStyleBackColor = true;
            this.buttonProceedDelete.Click += new System.EventHandler(this.buttonProceedDelete_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(106, 6);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(175, 56);
            this.buttonCancel.TabIndex = 3;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonCancel);
            this.panel1.Controls.Add(this.buttonProceedDelete);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 794);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1379, 100);
            this.panel1.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.textBoxSelectedOption);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1379, 165);
            this.panel2.TabIndex = 5;
            // 
            // textBoxSelectedOption
            // 
            this.textBoxSelectedOption.Location = new System.Drawing.Point(235, 74);
            this.textBoxSelectedOption.Name = "textBoxSelectedOption";
            this.textBoxSelectedOption.Size = new System.Drawing.Size(261, 22);
            this.textBoxSelectedOption.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(170, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Optie die u wilt verwijderen: ";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dataGridViewItemUsage);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 165);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1379, 629);
            this.panel3.TabIndex = 6;
            // 
            // ShowMenuItemUsage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1379, 894);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "ShowMenuItemUsage";
            this.Text = "ShowMenuItemUsage";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewItemUsage)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridViewItemUsage;
        private System.Windows.Forms.Button buttonProceedDelete;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox textBoxSelectedOption;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
    }
}