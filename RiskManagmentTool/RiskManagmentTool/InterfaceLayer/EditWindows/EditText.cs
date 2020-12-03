using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RiskManagmentTool.InterfaceLayer.EditWindows
{
    public partial class EditText : Form
    {
        public EditText()
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
