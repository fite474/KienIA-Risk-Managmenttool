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
using RiskManagmentTool.InterfaceLayer.EditWindows;

namespace RiskManagmentTool.InterfaceLayer.AddWindows
{
    public partial class AddRisico : Form
    {
        private Datacomunication comunicator;
        private string ObjectNaam;
        private string ObjectID;
        private KeuzeMenus keuzeMenus;
        private List<string> SelectedGevarenId;
        //public AddRisico()
        //{
        //    InitializeComponent();
        //    comunicator = new Datacomunication();
        //    LoadData();
        //}
        public AddRisico(string objectNaam, string objectID)
        {
            InitializeComponent();
            comunicator = new Datacomunication();
            keuzeMenus = KeuzeMenus.GetInstance();
            SelectedGevarenId = new List<string>();
            this.ObjectNaam = objectNaam;
            this.ObjectID = objectID;
            LoadData();
        }

        private void LoadData()
        {
            dataGridViewRisicos.DataSource = comunicator.GetGevarenTable();
            textBoxObjectNaam.Text = ObjectNaam;
            List<string> disciplinesList = keuzeMenus.GetDisciplinesMenu();
            foreach (string typeString in disciplinesList)
            {
                comboBoxDiscipline.Items.Add(typeString);
            }

        }

        private void buttonVoegSelectieToe_Click(object sender, EventArgs e)
        {
            //for list selectie id, datacom . add gevaar to object
            foreach (string gevaarId in SelectedGevarenId)
            {
                comunicator.AddGevaarToObject(ObjectID, gevaarId);
            }
            this.Close();
        }

        private void buttonCreateNewGevaar_Click(object sender, EventArgs e)
        {
            Form editRisicosForm = new EditRisicos();
            editRisicosForm.ShowDialog();
            dataGridViewRisicos.DataSource = comunicator.GetGevarenTable();
        }

        private void dataGridViewRisicos_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            string gevaarID = dataGridViewRisicos.SelectedRows[0].Cells[0].Value.ToString();
            //foreach (string selected in SelectedGevarenId)
            //{
                if (!SelectedGevarenId.Contains(gevaarID))
                {
                    SelectedGevarenId.Add(gevaarID);
                    textBoxSelectedItems.Text += gevaarID + ", ";
                }
           // }
            


            //list int selectie id's add gevaar id


            //Form editProjecten = new EditProjecten(projectNaam);//,

            //editProjecten.Show();



        }


    }
}
