using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RiskManagmentTool.LogicLayer;

namespace RiskManagmentTool.InterfaceLayer.EditWindows
{
    public partial class EditProjecten : Form
    {
        private Datacomunication comunicator;
        public EditProjecten()
        {
            InitializeComponent();
            comunicator = new Datacomunication();
            LoadData();
        }

        private void LoadData()
        {
            dataGridViewGekoppeldeObjecten.DataSource = comunicator.getObjectenTable();

        }

        private void dataGridViewGekoppeldeObjecten_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            string objectNaam = dataGridViewGekoppeldeObjecten.SelectedRows[0].Cells[0].Value.ToString();
            string ObjectType = dataGridViewGekoppeldeObjecten.SelectedRows[0].Cells[1].Value.ToString();
            string ObjectBeschrijving = dataGridViewGekoppeldeObjecten.SelectedRows[0].Cells[2].Value.ToString();

            Form editObjecten = new EditObjecten(objectNaam,
                            ObjectType,
                            ObjectBeschrijving);//,

            editObjecten.Show();



        }
    }
}
