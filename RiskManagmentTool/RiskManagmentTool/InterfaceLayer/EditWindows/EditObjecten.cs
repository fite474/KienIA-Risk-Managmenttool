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
        private ImageHandler ImageHandler;

        //private List<string> GekoppeldeGevarenId;
        private List<string> IssuesToVerify;
        private Dictionary<string, string> IssuesState;
        private Dictionary<string, string> IssuesRiskValue;

        //public EditObjecten()
        //{
        //    InitializeComponent();
        //    SetInstellingen();
        //}

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
            ImageHandler = new ImageHandler();

            //string x = viewsColumnNames.IssueBeschrijving;
            LoadMenus();
            this.ObjectNaam = objectNaam;
            this.ObjectID = objectID;
            textBoxProjectNaam.Text = projectNaam;
            textBoxObjectNaam.Text = ObjectNaam;
            textBoxOmschrijving.Text = objectOmschrijving;
            comboBoxObjectType.SelectedIndex = comboBoxObjectType.FindStringExact(objectType);
            LoadDataGridViewCheckBoxes();
            LoadData();
            //SetInstellingen();
            SetObjectImage();

        }

        private void LoadMenus()
        {
            Dictionary<int, string> typeObjectList = keuzeMenus.GetTypeObjectMenu();
            foreach (KeyValuePair<int, string> kvp in typeObjectList)
            {
                comboBoxObjectType.Items.Add(kvp.Value);
            }
        }

        private void LoadDataGridViewCheckBoxes()
        {
            //
            DataGridViewCheckBoxColumn CheckboxColumn = new DataGridViewCheckBoxColumn();
            CheckBox chk = new CheckBox();
            CheckboxColumn.Width = 20;
            CheckboxColumn.HeaderText = "";
            CheckboxColumn.TrueValue = true;
            dataGridViewGekoppeldeIssues.Columns.Add(CheckboxColumn);
        }

        private void LoadData()
        {
            dataGridViewGekoppeldeIssues.DataSource = comunicator.GetObjectIssues(ObjectID);

            foreach (DataGridViewColumn col in dataGridViewGekoppeldeIssues.Columns)
            {
                col.HeaderCell = new DataGridViewAutoFilterColumnHeaderCell(col.HeaderCell);
            }
            SetVisualInstellingen();
        }

        private void SetObjectImage()
        {
            //get object image(ObjectID)
            string filePath = comunicator.GetObjectImage(ObjectID);//@"C:\Users\mauri\Documents\1AVANS\Stage\1 Stage Bestanden\Pieter_de_Hooghbrug.jpg";
            try
            {
                pictureBoxObjectFoto.Image = new Bitmap(filePath);
                pictureBoxObjectFoto.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            catch (Exception e)
            {

                Console.WriteLine($"The file was not found: '{e}'");
            }

        }


        private void SetVisualInstellingen()
        {
            comboBoxVisualSettings.SelectedIndex = 1;
            ShowDataWithVisualSettings();
            //List<CheckedListBox> menuBox = keuzeMenus.GetKeuzeMenus();
            //for (int i = 0; i < menuBox.Count; i++)
            //{

            //    tabPage3.Controls.Add(menuBox[i]);
            //}   
        }

        private void ShowDataWithVisualSettings()
        {
            int rowIndex = 0;
            foreach (DataGridViewRow row in dataGridViewGekoppeldeIssues.Rows)
            {
                dataGridViewGekoppeldeIssues.Rows[rowIndex].DefaultCellStyle.BackColor = Color.White;
                rowIndex++;
            }

            switch (comboBoxVisualSettings.SelectedIndex)
            {
                case 0://0 = alles
                    {
                        //LoadData();
                        IssuesState = comunicator.GetObjectIssuesStates(ObjectID);

                        rowIndex = 0;
                        foreach (DataGridViewRow row in dataGridViewGekoppeldeIssues.Rows)
                        {
                            string issueId = row.Cells[viewsColumnNames.IssueIDColumn].Value.ToString();
                            IssuesState.TryGetValue(issueId, out string issueState);
                            if (issueState.Equals("0"))
                            {
                                dataGridViewGekoppeldeIssues.Rows[rowIndex].DefaultCellStyle.BackColor = Color.Red;
                                //IssuesToVerify.Add(dataGridViewGekoppeldeIssues.Rows[rowIndex].Cells[viewsColumnNames.IssueIDColumn].Value.ToString());
                            }
                            else if (issueState.Equals("1"))
                            {
                                dataGridViewGekoppeldeIssues.Rows[rowIndex].DefaultCellStyle.BackColor = Color.White;
                                //row.Cells[0].Value = true;
                            }

                            rowIndex++;
                        }
                    }
                    break;
                case 1:// 1 = onopgelost
                    {
                        IssuesRiskValue = comunicator.GetObjectIssuesRiskValue(ObjectID);

                        rowIndex = 0;
                        foreach (DataGridViewRow row in dataGridViewGekoppeldeIssues.Rows)
                        {
                            string issueId = row.Cells[viewsColumnNames.IssueIDColumn].Value.ToString();
                            IssuesRiskValue.TryGetValue(issueId, out string issueRiskValue);
                            Console.WriteLine(issueRiskValue);
                            if (issueRiskValue.Equals("0"))
                            {
                                dataGridViewGekoppeldeIssues.Rows[rowIndex].DefaultCellStyle.BackColor = Color.Red;

                            }
                            else if (issueRiskValue.Equals("1"))
                            {
                                dataGridViewGekoppeldeIssues.Rows[rowIndex].DefaultCellStyle.BackColor = Color.Green;
                            }
                            else if (issueRiskValue.Equals("10"))
                            {
                                dataGridViewGekoppeldeIssues.Rows[rowIndex].DefaultCellStyle.BackColor = Color.Yellow;
                            }
                            else if (issueRiskValue.Equals("100"))
                            {
                                dataGridViewGekoppeldeIssues.Rows[rowIndex].DefaultCellStyle.BackColor = Color.Orange;
                            }
                            else if (issueRiskValue.Equals("1000"))
                            {
                                dataGridViewGekoppeldeIssues.Rows[rowIndex].DefaultCellStyle.BackColor = Color.Red;
                            }
                            else
                            {
                                dataGridViewGekoppeldeIssues.Rows[rowIndex].DefaultCellStyle.BackColor = Color.Gray;
                            }

                            rowIndex++;
                        }
                    }
                    break;


            }

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
                
                string imageFilePath = ImageHandler.ChangeLocation(open.FileName);


                // display image in picture box  
                pictureBoxObjectFoto.Image = new Bitmap(imageFilePath);//open.FileName);
                pictureBoxObjectFoto.SizeMode = PictureBoxSizeMode.StretchImage;
                // image file path 
                comunicator.AddImageToObject(ObjectID, imageFilePath);
                
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




            IssuesState = comunicator.GetObjectIssuesStates(ObjectID);

            int rowIndex = 0;
            foreach (DataGridViewRow row in dataGridViewGekoppeldeIssues.Rows)
            {
                string issueId = row.Cells[viewsColumnNames.IssueIDColumn].Value.ToString();
                IssuesState.TryGetValue(issueId, out string issueState);
                if (issueState.Equals("0"))
                {
                    //dataGridViewGekoppeldeIssues.Rows[rowIndex].DefaultCellStyle.BackColor = Color.Red;
                    IssuesToVerify.Add(dataGridViewGekoppeldeIssues.Rows[rowIndex].Cells[viewsColumnNames.IssueIDColumn].Value.ToString());
                }
                else if (issueState.Equals("1"))
                {
                    //dataGridViewGekoppeldeIssues.Rows[rowIndex].DefaultCellStyle.BackColor = Color.White;
                    row.Cells[0].Value = true;
                }

                rowIndex++;
            }

            textBoxIssuesToVerify.Text = IssuesToVerify.Count.ToString();
            SetVisualInstellingen();
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

        private void comboBoxVisualSettings_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowDataWithVisualSettings();
        }
    }
}
