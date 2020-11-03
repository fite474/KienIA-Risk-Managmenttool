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
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridViewGekoppeldeGevaren = new System.Windows.Forms.DataGridView();
            this.buttonDeleteSelection = new System.Windows.Forms.Button();
            this.textBoxSelectedItems = new System.Windows.Forms.TextBox();
            this.textBoxObjectNaam = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGekoppeldeGevaren)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(81, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Object naam";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(81, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "label2";
            // 
            // dataGridViewGekoppeldeGevaren
            // 
            this.dataGridViewGekoppeldeGevaren.AllowUserToAddRows = false;
            this.dataGridViewGekoppeldeGevaren.AllowUserToDeleteRows = false;
            this.dataGridViewGekoppeldeGevaren.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewGekoppeldeGevaren.Location = new System.Drawing.Point(12, 163);
            this.dataGridViewGekoppeldeGevaren.Name = "dataGridViewGekoppeldeGevaren";
            this.dataGridViewGekoppeldeGevaren.ReadOnly = true;
            this.dataGridViewGekoppeldeGevaren.RowTemplate.Height = 24;
            this.dataGridViewGekoppeldeGevaren.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewGekoppeldeGevaren.Size = new System.Drawing.Size(910, 418);
            this.dataGridViewGekoppeldeGevaren.TabIndex = 2;
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
            this.textBoxObjectNaam.Location = new System.Drawing.Point(246, 62);
            this.textBoxObjectNaam.Name = "textBoxObjectNaam";
            this.textBoxObjectNaam.Size = new System.Drawing.Size(192, 22);
            this.textBoxObjectNaam.TabIndex = 5;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(246, 104);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 22);
            this.textBox3.TabIndex = 6;
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
            // DeleteGevaren
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1137, 821);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBoxObjectNaam);
            this.Controls.Add(this.dataGridViewGekoppeldeGevaren);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "DeleteGevaren";
            this.Text = "DeleteGevaren";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGekoppeldeGevaren)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridViewGekoppeldeGevaren;
        private System.Windows.Forms.Button buttonDeleteSelection;
        private System.Windows.Forms.TextBox textBoxSelectedItems;
        private System.Windows.Forms.TextBox textBoxObjectNaam;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Panel panel1;
    }
}