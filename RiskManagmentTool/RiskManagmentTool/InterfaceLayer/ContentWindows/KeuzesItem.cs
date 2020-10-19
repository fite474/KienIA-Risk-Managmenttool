using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RiskManagmentTool.InterfaceLayer.EditWindows;

namespace RiskManagmentTool.InterfaceLayer.ContentWindows
{
    public partial class KeuzesItem : UserControl
    {
        public KeuzesItem()
        {
            InitializeComponent();
        }

        private void buttonEditKeuzes_Click(object sender, EventArgs e)
        {
            Form editKeuzes = new EditKeuzes();
            editKeuzes.Show();

        }
    }
}
