namespace RiskManagmentTool.InterfaceLayer.DeleteWindows
{
    partial class DeleteGevaren
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
            this.dataGridViewGekoppeldeGevaren = new System.Windows.Forms.DataGridView();
            this.buttonDeleteSelection = new System.Windows.Forms.Button();
            this.textBoxSelectedItems = new System.Windows.Forms.TextBox();
            this.textBoxObjectNaam = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGekoppeldeGevaren)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(118, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Object naam";
            // 
            // dataGridViewGekoppeldeGevaren
            // 
            this.dataGridViewGekoppeldeGevaren.AllowUserToAddRows = false;
            this.dataGridViewGekoppeldeGevaren.AllowUserToDeleteRows = false;
            this.dataGridViewGekoppeldeGevaren.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridViewGekoppeldeGevaren.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewGekoppeldeGevaren.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewGekoppeldeGevaren.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewGekoppeldeGevaren.Name = "dataGridViewGekoppeldeGevaren";
            this.dataGridViewGekoppeldeGevaren.ReadOnly = true;
            this.dataGridViewGekoppeldeGevaren.RowHeadersWidth = 51;
            this.dataGridViewGekoppeldeGevaren.RowTemplate.Height = 24;
            this.dataGridViewGekoppeldeGevaren.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewGekoppeldeGevaren.Size = new System.Drawing.Size(1137, 525);
            this.dataGridViewGekoppeldeGevaren.TabIndex = 2;
            this.dataGridViewGekoppeldeGevaren.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataGridViewGekoppeldeGevaren_DataBindingComplete);
            this.dataGridViewGekoppeldeGevaren.SelectionChanged += new System.EventHandler(this.dataGridViewGekoppeldeGevaren_SelectionChanged);
            // 
            // buttonDeleteSelection
            // 
            this.buttonDeleteSelection.Location = new System.Drawing.Point(662, 93);
            this.buttonDeleteSelection.Name = "buttonDeleteSelection";
            this.buttonDeleteSelection.Size = new System.Drawing.Size(284, 44);
            this.buttonDeleteSelection.TabIndex = 3;
            this.buttonDeleteSelection.Text = "Verwijder selectie";
            this.buttonDeleteSelection.UseVisualStyleBackColor = true;
            this.buttonDeleteSelection.Click += new System.EventHandler(this.buttonDeleteSelection_Click);
            // 
            // textBoxSelectedItems
            // 
            this.textBoxSelectedItems.Location = new System.Drawing.Point(121, 115);
            this.textBoxSelectedItems.Name = "textBoxSelectedItems";
            this.textBoxSelectedItems.Size = new System.Drawing.Size(417, 22);
            this.textBoxSelectedItems.TabIndex = 4;
            // 
            // textBoxObjectNaam
            // 
            this.textBoxObjectNaam.Location = new System.Drawing.Point(280, 12);
            this.textBoxObjectNaam.Name = "textBoxObjectNaam";
            this.textBoxObjectNaam.ReadOnly = true;
            this.textBoxObjectNaam.Size = new System.Drawing.Size(192, 22);
            this.textBoxObjectNaam.TabIndex = 5;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textBoxSelectedItems);
            this.panel1.Controls.Add(this.buttonDeleteSelection);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 604);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1137, 217);
            this.panel1.TabIndex = 7;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.textBoxObjectNaam);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1137, 79);
            this.panel2.TabIndex = 8;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dataGridViewGekoppeldeGevaren);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 79);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1137, 525);
            this.panel3.TabIndex = 9;
            // 
            // DeleteGevaren
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1137, 821);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "DeleteGevaren";
            this.Text = "DeleteGevaren";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGekoppeldeGevaren)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridViewGekoppeldeGevaren;
        private System.Windows.Forms.Button buttonDeleteSelection;
        private System.Windows.Forms.TextBox textBoxSelectedItems;
        private System.Windows.Forms.TextBox textBoxObjectNaam;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
    }
}