using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RiskManagmentTool.InterfaceLayer.EditWindows;

namespace RiskManagmentTool.InterfaceLayer.InitWindows
{
    public partial class InitObject : Form
    {
        public InitObject()
        {
            InitializeComponent();
        }

        private void buttonCreateObject_Click(object sender, EventArgs e)
        {
            Form editObject = new EditObjecten();
            editObject.Show();
            this.Close();
        }
    }
}
