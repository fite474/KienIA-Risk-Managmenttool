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
using DataGridViewAutoFilter;


namespace RiskManagmentTool.InterfaceLayer.EditWindows
{
    public partial class EditObjecten : Form
    {
        private Datacomunication comunicator;
        private string ObjectNaam;
        private string ObjectID;
        private KeuzeMenus keuzeMenus;
        private ViewsColumnNames viewsColumnNames;

        //private List<string> GekoppeldeGevarenId;
        private List<string> IssuesToVerify;
        private Dictionary<string, string> IssuesState;//List<string> IssuesState;

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
            viewsColumnNames = new ViewsColumnNames();
            
            //string x = viewsColumnNames.IssueBeschrijving;
            LoadMenus();
            this.ObjectNaam = objectNaam;
            this.ObjectID = objectID;
            textBoxProjectNaam.Text = projectNaam;
            textBoxObjectNaam.Text = ObjectNaam;
            textBoxOmschrijving.Text = objectOmschrijving;
            comboBoxObjectType.SelectedIndex = comboBoxObjectType.FindStringExact(objectType);
            
            LoadData();
            SetInstellingen();

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
            IssuesState = comunicator.GetObjectIssuesStates(ObjectID);
            DataGridViewCheckBoxColumn CheckboxColumn = new DataGridViewCheckBoxColumn();
            CheckBox chk = new CheckBox();
            CheckboxColumn.Width = 20;
            CheckboxColumn.HeaderText = "";
            CheckboxColumn.TrueValue = true;
            dataGridViewGekoppeldeIssues.Columns.Add(CheckboxColumn);



            

            dataGridViewGekoppeldeIssues.DataSource = comunicator.GetObjectIssues(ObjectID);

            foreach (DataGridViewColumn col in dataGridViewGekoppeldeIssues.Columns)
            {

                col.HeaderCell = new DataGridViewAutoFilterColumnHeaderCell(col.HeaderCell);
                

            }

        }

        private void SetObjectImage()
        {
            //get object image(ObjectID)

        }


        private void SetInstellingen()
        {
            //List<CheckedListBox> menuBox = keuzeMenus.GetKeuzeMenus();
            //for (int i = 0; i < menuBox.Count; i++)
            //{

            //    tabPage3.Controls.Add(menuBox[i]);
            //}   
        }

        private void ShowDataWithFiltering()
        {
            switch (comboBoxFilterIssues.SelectedIndex)
            {
                case 0://0 = alles
                    {
                        LoadData();
                    }
                    break;
                case 1:// 1 = onopgelost
                    {

                    }
                    break;
                case 2:// 2 = opgelost
                    {

                    }
                    break;
                case 3:// 2 = opgelost
                    {

                    }
                    break;
                case 4:// 4 = maatregelen
                    {
                        int rowIndex = 0;
                        var toBeDeleted = new List<DataGridViewRow>();

                        foreach (DataGridViewRow row in dataGridViewGekoppeldeIssues.Rows)
                        {
                            string issueId = row.Cells[viewsColumnNames.IssueIDColumn].Value.ToString();
                            Dictionary<string, int> IssuesMaatregelen = comunicator.GetObjectIssuesMaatregelenCount(ObjectID);//new Dictionary<string, int>();
                            IssuesMaatregelen.TryGetValue(issueId, out int maatregelCount);
                            if (maatregelCount > 0)
                            {
                                //dataGridViewGekoppeldeIssues.Rows.Remove(row);
                                toBeDeleted.Add(row);

                                //[rowIndex].
                                //dataGridViewGekoppeldeIssues.Rows[rowIndex].DefaultCellStyle.BackColor = Color.Red;
                                //IssuesToVerify.Add(dataGridViewGekoppeldeIssues.Rows[rowIndex].Cells[viewsColumnNames.IssueIDColumn].Value.ToString());
                            }
                            else
                            {
                                Console.WriteLine(maatregelCount.ToString());
                            }
                            //else if (issueState.Equals("1"))
                            //{
                            //    dataGridViewGekoppeldeIssues.Rows[rowIndex].DefaultCellStyle.BackColor = Color.White;
                            //    row.Cells[0].Value = true;
                            //}

                            rowIndex++;
                        }
                        toBeDeleted.ForEach(d => dataGridViewGekoppeldeIssues.Rows.Remove(d));

                        //int x = 0;
                    }
                    break;

            }

        }







        private void buttonIssuesOplossen_Click(object sender, EventArgs e)
        {
            string situatie = "";//dataGridViewGekoppeldeIssues.SelectedRows[0].Cells[viewsColumnNames.GevaarlijkeSituatieColumn].Value.ToString();
            string gebeurtenis = "";//dataGridViewGekoppeldeIssues.SelectedRows[0].Cells[viewsColumnNames.GevaarlijkeGebeurtenisColumn].Value.ToString();

            string discipline = "";//dataGridViewGekoppeldeIssues.SelectedRows[0].Cells[viewsColumnNames.GevaarDisciplineColumn].Value.ToString();
            string gevaar = "";//dataGridViewGekoppeldeIssues.SelectedRows[0].Cells[viewsColumnNames.GevaarGevaarTypeColumn].Value.ToString();

            string init_Risico = "";
            string init_Risico_Beschrijving = "";
            string rest_Risico = "";
            string rest_Risico_Beschrijving = "";
            foreach (string issueID in IssuesToVerify)
            {
                Form issueMaatregelen = new IssueMaatregelen(ObjectNaam, ObjectID, issueID,
                                                        discipline, gevaar, situatie, gebeurtenis,
                                                        init_Risico, init_Risico_Beschrijving,
                                                        rest_Risico, rest_Risico_Beschrijving);
                issueMaatregelen.ShowDialog();
            }
            LoadData();
            //Form issueMaatregelen = new IssueMaatregelen();
            //issueMaatregelen.Show();
        }

        private void buttonAddTemplate_Click(object sender, EventArgs e)
        {
            
            //Form addTemplate = new AddTemplate();
            //addTemplate.Show();
        }

        private void dataGridViewGekoppeldeIssues_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            
            string issueId = dataGridViewGekoppeldeIssues.SelectedRows[0].Cells[viewsColumnNames.IssueIDColumn].Value.ToString();//[0].Value.ToString();
            string situatie = dataGridViewGekoppeldeIssues.SelectedRows[0].Cells[viewsColumnNames.GevaarlijkeSituatieColumn].Value.ToString();
            string gebeurtenis = dataGridViewGekoppeldeIssues.SelectedRows[0].Cells[viewsColumnNames.GevaarlijkeGebeurtenisColumn].Value.ToString();

            string discipline = dataGridViewGekoppeldeIssues.SelectedRows[0].Cells[viewsColumnNames.GevaarDisciplineColumn].Value.ToString();
            string gevaar = dataGridViewGekoppeldeIssues.SelectedRows[0].Cells[viewsColumnNames.GevaarGevaarTypeColumn].Value.ToString();

            string init_Risico = "";
            string init_Risico_Beschrijving = "";
            string rest_Risico = "";
            string rest_Risico_Beschrijving = "";



            Form issueMaatregelen = new IssueMaatregelen(ObjectNaam, ObjectID ,issueId, 
                                                         discipline, gevaar, situatie, gebeurtenis,
                                                         init_Risico, init_Risico_Beschrijving,
                                                         rest_Risico, rest_Risico_Beschrijving);
            issueMaatregelen.ShowDialog();
            //ShowDataWithFiltering();
            LoadData();


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



        private void pictureBoxObjectFoto_Click(object sender, EventArgs e)
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
            IssuesToVerify = new List<string>();
            for (int i = 0; i < (dataGridViewGekoppeldeIssues.ColumnCount - 1); i++)
            {
                dataGridViewGekoppeldeIssues.AutoResizeColumn((i + 1), DataGridViewAutoSizeColumnMode.AllCells);
                if (dataGridViewGekoppeldeIssues.Columns[i + 1].Width > 400)
                {
                    dataGridViewGekoppeldeIssues.Columns[i + 1].Width = 400;
                }
            }

            dataGridViewGekoppeldeIssues.ClearSelection();






            int rowIndex = 0;
            foreach (DataGridViewRow row in dataGridViewGekoppeldeIssues.Rows)
            {
                string issueId = row.Cells[viewsColumnNames.IssueIDColumn].Value.ToString();
                IssuesState.TryGetValue(issueId, out string issueState);
                if (issueState.Equals("0"))
                {
                    dataGridViewGekoppeldeIssues.Rows[rowIndex].DefaultCellStyle.BackColor = Color.Red;
                    IssuesToVerify.Add(dataGridViewGekoppeldeIssues.Rows[rowIndex].Cells[viewsColumnNames.IssueIDColumn].Value.ToString());
                }
                else if (issueState.Equals("1"))
                {
                    dataGridViewGekoppeldeIssues.Rows[rowIndex].DefaultCellStyle.BackColor = Color.White;
                    row.Cells[0].Value = true;
                }

                rowIndex++;
            }

            textBoxIssuesToVerify.Text = IssuesToVerify.Count.ToString();
        }

        private void buttonExportToExcel_Click(object sender, EventArgs e)
        {
            Form exportObject = new ExportObject(ObjectID);
            exportObject.Show();
        }

        private void comboBoxFilterIssues_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowDataWithFiltering();
        }
    }
}
