using RiskManagmentTool.LogicLayer;
using System;
using System.Windows.Forms;

namespace RiskManagmentTool.InterfaceLayer.EditWindows
{
    public partial class EditText : Form
    {
        public EditText(MenuTableName menuTableName)
        {
            InitializeComponent();
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
