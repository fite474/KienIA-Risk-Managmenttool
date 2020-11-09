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
using RiskManagmentTool.InterfaceLayer.AddWindows;
using RiskManagmentTool.InterfaceLayer.DeleteWindows;

namespace RiskManagmentTool.InterfaceLayer.EditWindows
{
    public partial class EditObjecten : Form
    {
        private Datacomunication comunicator;
        private string ObjectNaam;
        private string ObjectID;
        private KeuzeMenus keuzeMenus;

        //private List<string> GekoppeldeGevarenId;
        //private List<string> GekoppeldeIssuesId;


        public EditObjecten()
        {
            InitializeComponent();
            SetInstellingen();
        }
        public EditObjecten(string objectID,
                            string projectNaam,
                            string objectNaam,
                            string objectType,
                            string objectOmschrijving)
        {

            InitializeComponent();
            comunicator = new Datacomunication();
            keuzeMenus = new KeuzeMenus();
            LoadMenus();
            this.ObjectNaam = objectNaam;
            this.ObjectID = objectID;
            textBoxProjectNaam.Text = projectNaam;
            textBoxObjectNaam.Text = ObjectNaam;
            textBoxOmschrijving.Text = objectOmschrijving;
            comboBoxObjectType.SelectedIndex = comboBoxObjectType.FindStringExact(objectType);
            
            LoadData();
            SetInstellingen();

            //textBoxDiscipline.Text = riskDiscipline;
            //textBoxGebruiksfase.Text = riskGebruiksfase;
            //textBoxBedienvorm.Text = riskGebruiker;
            //textBoxRiskGevarenzone.Text = riskGevarenzone;
        }

        private void LoadMenus()
        {
            List<string> typeObjectList = keuzeMenus.GetTypeObjectMenu();
            foreach (string typeString in typeObjectList)
            {
                comboBoxObjectType.Items.Add(typeString);
            }
        }

        private void LoadData()
        {

           // GekoppeldeGevarenId = comunicator.GetGekoppeldeGevarenFromObjectAsList(ObjectID);
            //GekoppeldeIssuesId = comunicator.GetGekoppeldeIssuesFromObjectAsList(ObjectID);
        //dataGridViewGekoppeldeIssues.DataSource = comunicator.GetObjectIssues(ObjectID);
        //
            dataGridViewGekoppeldeIssues.DataSource = comunicator.GetObjectIssues(ObjectID);
            
            

        }

        private void SetObjectImage()
        {
            //get object image(ObjectID)

        }


        private void SetInstellingen()
        {

            //KeuzeMenus instellingen = new KeuzeMenus();
            List<CheckedListBox> menuBox = keuzeMenus.GetKeuzeMenus();
            for (int i = 0; i < menuBox.Count; i++)
            {
                
                
                tabPage3.Controls.Add(menuBox[i]);
            }
            
            
        }

        private void buttonIssuesOplossen_Click(object sender, EventArgs e)
        {
            //Form issueMaatregelen = new IssueMaatregelen();
            //issueMaatregelen.Show();
        }

        private void buttonAddTemplate_Click(object sender, EventArgs e)
        {
            
            Form addTemplate = new AddTemplate();
            addTemplate.Show();
        }

        private void dataGridViewGekoppeldeIssues_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            string issueId = dataGridViewGekoppeldeIssues.SelectedRows[0].Cells[0].Value.ToString();
            string situatie = dataGridViewGekoppeldeIssues.SelectedRows[0].Cells[1].Value.ToString();
            string gebeurtenis = dataGridViewGekoppeldeIssues.SelectedRows[0].Cells[2].Value.ToString();

            string discipline = dataGridViewGekoppeldeIssues.SelectedRows[0].Cells[3].Value.ToString();
            string gevaar = dataGridViewGekoppeldeIssues.SelectedRows[0].Cells[9].Value.ToString();

            string init_Risico = "";
            string init_Risico_Beschrijving = "";
            string rest_Risico = "";
            string rest_Risico_Beschrijving = "";



            Form issueMaatregelen = new IssueMaatregelen(ObjectNaam, ObjectID ,issueId, 
                                                         discipline, gevaar, situatie, gebeurtenis,
                                                         init_Risico, init_Risico_Beschrijving,
                                                         rest_Risico, rest_Risico_Beschrijving);
            issueMaatregelen.Show();



        }

        private void buttonAddRisico_Click(object sender, EventArgs e)
        {
            Form addRisico = new AddRisico(ObjectNaam, ObjectID);
            addRisico.ShowDialog();
            LoadData();
        }

        private void buttonExport_Click(object sender, EventArgs e)
        {
            //Form exportObject = new ExportObject(comunicator.GetObjectIssues(ObjectID));
            //exportObject.Show();
        }

        private void buttonDeleteGevaren_Click(object sender, EventArgs e)
        {
            Form deleteRisico = new DeleteGevaren(ObjectNaam, ObjectID);
            deleteRisico.Show();

        }

        private void buttonShow_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridViewGekoppeldeIssues.Rows.Count; i++)
            {
                dataGridViewGekoppeldeIssues.Rows[i].DefaultCellStyle.BackColor = Color.Red;
            }
        }

        private void pictureBoxObjectFoto_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            // image filters  
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                // display image in picture box  
                pictureBoxObjectFoto.Image = new Bitmap(open.FileName);
                pictureBoxObjectFoto.SizeMode = PictureBoxSizeMode.StretchImage;
                // image file path  
                textBox1.Text = open.FileName;
            }
        }

        private void dataGridViewGekoppeldeIssues_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            for (int i = 0; i < (dataGridViewGekoppeldeIssues.ColumnCount - 1); i++)
            {
                dataGridViewGekoppeldeIssues.AutoResizeColumn((i+1), DataGridViewAutoSizeColumnMode.AllCells);
                if (dataGridViewGekoppeldeIssues.Columns[i + 1].Width > 400)
                {
                    dataGridViewGekoppeldeIssues.Columns[i + 1].Width = 400;
                }
            }

            dataGridViewGekoppeldeIssues.ClearSelection();
            for (int i = 0; i < dataGridViewGekoppeldeIssues.Rows.Count; i++)
            {
                if (i % 2 == 0)
                {
                    dataGridViewGekoppeldeIssues.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                }
                
            }
        }
    }
}
