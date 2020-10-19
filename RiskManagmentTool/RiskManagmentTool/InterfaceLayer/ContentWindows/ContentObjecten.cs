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
using RiskManagmentTool.LogicLayer;

namespace RiskManagmentTool.InterfaceLayer.ContentWindows
{
    public partial class ContentObjecten : Form
    {
        private Datacomunication comunicator;
        public ContentObjecten()
        {
            InitializeComponent();
            comunicator = new Datacomunication();
            LoadData();
        }

        private void LoadData()
        {
            dataGridViewObjecten.DataSource = comunicator.getObjectenTable();

        }

        private void buttonAddNew_Click(object sender, EventArgs e)
        {

            Form editObject = new EditObjecten();
            editObject.Show();
        }
    }
}
