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
            dataGridViewObjecten.DataSource = comunicator.GetObjectenTable();

        }

        private void dataGridViewObjecten_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string temp = "1";
            string projectNaam = dataGridViewObjecten.SelectedRows[0].Cells[0].Value.ToString();
            string objectNaam = dataGridViewObjecten.SelectedRows[0].Cells[1].Value.ToString();
            string objectType = "";//dataGridViewObjecten.SelectedRows[0].Cells[2].Value.ToString();
            string objectBeschrijving = "";//dataGridViewObjecten.SelectedRows[0].Cells[3].Value.ToString();

            Form editObjecten = new EditObjecten(temp, projectNaam,
                                                 objectNaam,
                                                 objectType,
                                                 objectBeschrijving);

            editObjecten.Show();



        }

        private void buttonAddNew_Click(object sender, EventArgs e)
        {

            //Form editObject = new EditObjecten();
            //editObject.Show();
        }
    }
}
