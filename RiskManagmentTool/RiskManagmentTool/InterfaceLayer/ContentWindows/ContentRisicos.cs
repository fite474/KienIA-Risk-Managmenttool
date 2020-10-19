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
    public partial class ContentRisicos : Form
    {
        private Datacomunication comunicator;
        public ContentRisicos()
        {
            InitializeComponent();
            comunicator = new Datacomunication();
            LoadData();

        }

        private void buttonAddNew_Click(object sender, EventArgs e)
        {
            Form editRisicosForm = new EditRisicos();

            editRisicosForm.Show();
        }

        private void LoadData()
        {
            dataGridViewRisicos.DataSource = comunicator.getRisicoTable();

        }
    }
}
