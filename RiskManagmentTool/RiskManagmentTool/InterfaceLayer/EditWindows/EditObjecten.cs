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

        private int RisicograafSetting; //0 = SIL 1 = pl
        private bool HasImage;

        private BindingSource objectIssuesDataTable;

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


            LoadMenus();
            this.ObjectNaam = objectNaam;
            this.ObjectID = objectID;
            textBoxProjectNaam.Text = projectNaam;
            textBoxObjectNaam.Text = ObjectNaam;
            textBoxOmschrijving.Text = objectOmschrijving;
            comboBoxObjectType.SelectedIndex = comboBoxObjectType.FindStringExact(objectType);
            LoadDataGridViewCheckBoxes();
            LoadData();
            SetObjectSettings();
            SetObjectImage();
            LoadNotes();
            comboBoxFilterIssues.SelectedIndex = 0;
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
            DataGridViewCheckBoxColumn CheckboxColumn = new DataGridViewCheckBoxColumn();
            CheckBox chk = new CheckBox();
            CheckboxColumn.Width = 20;
            CheckboxColumn.HeaderText = "";
            CheckboxColumn.TrueValue = true;
            CheckboxColumn.FalseValue = false;
            advancedDataGridViewGekoppeldeIssues.Columns.Add(CheckboxColumn);
            advancedDataGridViewGekoppeldeIssues.DisableFilter(CheckboxColumn);
        }

        private void LoadData()
        {
            objectIssuesDataTable = comunicator.GetObjectIssues(ObjectID);
            advancedDataGridViewGekoppeldeIssues.DataSource = objectIssuesDataTable;


            //comboBoxFilterIssues.SelectedIndex = 0;
            SetVisualInstellingen();
        }

        private void LoadNotes()
        {
            string objectNotes = comunicator.GetObjectNotes(ObjectID);
            textBoxObjectNotes.Text = objectNotes;

        }

        private void SetObjectSettings()
        {
    
            List<string> objectSettings = comunicator.GetObjectSettings(ObjectID);
            string risicograaf = objectSettings[0];
            if (risicograaf.Equals("0"))
            {
                RisicograafSetting = 0;
            }
            else if (risicograaf.Equals("1"))
            {
                RisicograafSetting = 1;
            }

            checkedListBoxRisicograaf.SetItemChecked(RisicograafSetting, true);
        }

        private void SetObjectImage()
        {
            HasImage = false;
            //get object image(ObjectID)
            string filePath = comunicator.GetObjectImage(ObjectID);//@"C:\Users\mauri\Documents\1AVANS\Stage\1 Stage Bestanden\Pieter_de_Hooghbrug.jpg";
            try
            {
                pictureBoxObjectFoto.Image = new Bitmap(filePath);
                pictureBoxObjectFoto.SizeMode = PictureBoxSizeMode.StretchImage;
                HasImage = true;
            }
            catch (Exception e)
            {

                Console.WriteLine($"The file was not found: '{e}'");
            }

        }


        private void SetVisualInstellingen()
        {
            comboBoxVisualSettings.SelectedIndex = 1;
            //comboBoxFilterIssues.SelectedIndex = 0;
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
            foreach (DataGridViewRow row in advancedDataGridViewGekoppeldeIssues.Rows)
            {
                advancedDataGridViewGekoppeldeIssues.Rows[rowIndex].DefaultCellStyle.BackColor = Color.White;
                rowIndex++;
            }

            switch (comboBoxVisualSettings.SelectedIndex)
            {
                case 0:
                    {
                        //LoadData();
                        IssuesState = comunicator.GetObjectIssuesStates(ObjectID);

                        rowIndex = 0;
                        foreach (DataGridViewRow row in advancedDataGridViewGekoppeldeIssues.Rows)
                        {
                            string issueId = row.Cells[viewsColumnNames.IssueIDColumn].Value.ToString();
                            IssuesState.TryGetValue(issueId, out string issueState);
                            if (issueState.Equals("0"))
                            {
                                advancedDataGridViewGekoppeldeIssues.Rows[rowIndex].DefaultCellStyle.BackColor = Color.Red;
                                //IssuesToVerify.Add(dataGridViewGekoppeldeIssues.Rows[rowIndex].Cells[viewsColumnNames.IssueIDColumn].Value.ToString());
                            }
                            else if (issueState.Equals("1"))
                            {
                                advancedDataGridViewGekoppeldeIssues.Rows[rowIndex].DefaultCellStyle.BackColor = Color.White;
                                //row.Cells[0].Value = true;
                            }

                            rowIndex++;
                        }
                    }
                    break;
                case 1:
                    {
                        IssuesRiskValue = comunicator.GetObjectIssuesRiskValue(ObjectID);

                        rowIndex = 0;
                        foreach (DataGridViewRow row in advancedDataGridViewGekoppeldeIssues.Rows)
                        {
                            string issueId = row.Cells[viewsColumnNames.IssueIDColumn].Value.ToString();
                            IssuesRiskValue.TryGetValue(issueId, out string issueRiskValue);
                            Console.WriteLine(issueRiskValue);
                            if (issueRiskValue.Equals("0"))
                            {
                                advancedDataGridViewGekoppeldeIssues.Rows[rowIndex].DefaultCellStyle.BackColor = Color.DarkGray;

                            }
                            else if (issueRiskValue.Equals("1"))
                            {
                                advancedDataGridViewGekoppeldeIssues.Rows[rowIndex].DefaultCellStyle.BackColor = Color.Green;
                            }
                            else if (issueRiskValue.Equals("10"))
                            {
                                advancedDataGridViewGekoppeldeIssues.Rows[rowIndex].DefaultCellStyle.BackColor = Color.Yellow;
                            }
                            else if (issueRiskValue.Equals("100"))
                            {
                                advancedDataGridViewGekoppeldeIssues.Rows[rowIndex].DefaultCellStyle.BackColor = Color.Red;//Color.Orange;
                            }
                            else if (issueRiskValue.Equals("1000"))
                            {
                                advancedDataGridViewGekoppeldeIssues.Rows[rowIndex].DefaultCellStyle.BackColor = Color.DarkGray;//Color.Red;
                            }
                            else
                            {
                                advancedDataGridViewGekoppeldeIssues.Rows[rowIndex].DefaultCellStyle.BackColor = Color.Gray;
                            }

                            rowIndex++;
                        }
                    }
                    break;
                case 2:
                    {
                        //foreach (DataGridViewRow row in dataGridViewGekoppeldeIssues.Rows)
                        //{
                        //    dataGridViewGekoppeldeIssues.Rows[rowIndex].DefaultCellStyle.BackColor = Color.White;
                        //    rowIndex++;
                        //}

                    }
                    break;


            }

        }


        private void ShowDataWithFiltering()
        {
            LoadData();
            switch (comboBoxFilterIssues.SelectedIndex)
            {
                case 0://0 = alles
                    {
                        this.objectIssuesDataTable.RemoveFilter();
                        this.objectIssuesDataTable.RemoveSort();
                        LoadData();
                    }
                    break;
                case 1:// 1 = onopgelost
                    {
                        this.objectIssuesDataTable.RemoveFilter();
                        this.objectIssuesDataTable.RemoveSort();
                        int rowIndex = 0;
                        var toBeDeleted = new List<DataGridViewRow>();

                        foreach (DataGridViewRow row in advancedDataGridViewGekoppeldeIssues.Rows)
                        {
                            string issueId = row.Cells[viewsColumnNames.IssueIDColumn].Value.ToString();
                            IssuesRiskValue.TryGetValue(issueId, out string issueRiskValue);
                            Console.WriteLine(issueRiskValue);
                            //string issueId = row.Cells[viewsColumnNames.IssueIDColumn].Value.ToString();
                            //Dictionary<string, int> IssuesMaatregelen = comunicator.GetObjectIssuesMaatregelenCount(ObjectID);//new Dictionary<string, int>();
                            //IssuesMaatregelen.TryGetValue(issueId, out int maatregelCount);
                            if (issueRiskValue.Equals("1") || issueRiskValue.Equals("10"))
                            {
                                toBeDeleted.Add(row);
                            }
                            //else
                            //{

                            //}
                            //else if (issueState.Equals("1"))
                            //{
                            //    dataGridViewGekoppeldeIssues.Rows[rowIndex].DefaultCellStyle.BackColor = Color.White;
                            //    row.Cells[0].Value = true;
                            //}

                            rowIndex++;
                        }
                        toBeDeleted.ForEach(d => advancedDataGridViewGekoppeldeIssues.Rows.Remove(d));
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
                        this.objectIssuesDataTable.RemoveFilter();
                        this.objectIssuesDataTable.RemoveSort();
                        int rowIndex = 0;
                        var toBeDeleted = new List<DataGridViewRow>();

                        foreach (DataGridViewRow row in advancedDataGridViewGekoppeldeIssues.Rows)
                        {
                            string issueId = row.Cells[viewsColumnNames.IssueIDColumn].Value.ToString();
                            Dictionary<string, int> IssuesMaatregelen = comunicator.GetObjectIssuesMaatregelenCount(ObjectID);//new Dictionary<string, int>();
                            IssuesMaatregelen.TryGetValue(issueId, out int maatregelCount);
                            if (maatregelCount > 0)
                            {
                                toBeDeleted.Add(row);
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
                        toBeDeleted.ForEach(d => advancedDataGridViewGekoppeldeIssues.Rows.Remove(d));

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




        private void buttonAddRisico_Click(object sender, EventArgs e)
        {
            
            Form addRisico = new AddRisico(ObjectNaam, ObjectID);
            addRisico.ShowDialog();
            LoadData();
        }

        private void buttonDeleteGevaren_Click(object sender, EventArgs e)
        {
            Form deleteRisico = new DeleteGevaren(ObjectNaam, ObjectID);
            deleteRisico.ShowDialog();
            LoadData();

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
                if (HasImage)
                {
                    comunicator.UpdateImageToObject(ObjectID, imageFilePath);
                }
                else
                {
                    comunicator.AddImageToObject(ObjectID, imageFilePath);
                }
                
                
            }
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

        private void advancedDataGridViewGekoppeldeIssues_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            IssuesToVerify = new List<string>();
            for (int i = 0; i < (advancedDataGridViewGekoppeldeIssues.ColumnCount - 1); i++)
            {
                advancedDataGridViewGekoppeldeIssues.AutoResizeColumn((i + 1), DataGridViewAutoSizeColumnMode.AllCells);
                if (advancedDataGridViewGekoppeldeIssues.Columns[i + 1].Width > 400)
                {
                    advancedDataGridViewGekoppeldeIssues.Columns[i + 1].Width = 400;
                }
            }

            advancedDataGridViewGekoppeldeIssues.ClearSelection();


            IssuesState = comunicator.GetObjectIssuesStates(ObjectID);

            int rowIndex = 0;
            foreach (DataGridViewRow row in advancedDataGridViewGekoppeldeIssues.Rows)
            {
                string issueId = row.Cells[viewsColumnNames.IssueIDColumn].Value.ToString();
                IssuesState.TryGetValue(issueId, out string issueState);
                if (issueState.Equals("0"))
                {
                    row.Cells[0].Value = false;
                    IssuesToVerify.Add(advancedDataGridViewGekoppeldeIssues.Rows[rowIndex].Cells[viewsColumnNames.IssueIDColumn].Value.ToString());
                }
                else if (issueState.Equals("1"))
                {
                    row.Cells[0].Value = true;
                }

                rowIndex++;
            }
            Cursor.Current = Cursors.Default;
            textBoxIssuesToVerify.Text = IssuesToVerify.Count.ToString();
            SetVisualInstellingen();
            //advancedDataGridViewGekoppeldeIssues.ClearSelection();
        }

        private void advancedDataGridViewGekoppeldeIssues_FilterStringChanged(object sender, EventArgs e)
        {
            this.objectIssuesDataTable.Filter = this.advancedDataGridViewGekoppeldeIssues.FilterString;
        }

        private void advancedDataGridViewGekoppeldeIssues_SortStringChanged(object sender, EventArgs e)
        {
            this.objectIssuesDataTable.Sort = this.advancedDataGridViewGekoppeldeIssues.SortString;
        }

        private void EditObjecten_Load(object sender, EventArgs e)
        {

        }

        private void advancedDataGridViewGekoppeldeIssues_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                string issueId = advancedDataGridViewGekoppeldeIssues.SelectedRows[0].Cells[viewsColumnNames.IssueIDColumn].Value.ToString();//[0].Value.ToString();
                string situatie = advancedDataGridViewGekoppeldeIssues.SelectedRows[0].Cells[viewsColumnNames.GevaarlijkeSituatieColumn].Value.ToString();
                string gebeurtenis = advancedDataGridViewGekoppeldeIssues.SelectedRows[0].Cells[viewsColumnNames.GevaarlijkeGebeurtenisColumn].Value.ToString();

                string discipline = advancedDataGridViewGekoppeldeIssues.SelectedRows[0].Cells[viewsColumnNames.GevaarDisciplineColumn].Value.ToString();
                string gevaar = advancedDataGridViewGekoppeldeIssues.SelectedRows[0].Cells[viewsColumnNames.GevaarGevaarTypeColumn].Value.ToString();

                string init_Risico = "";
                string init_Risico_Beschrijving = "";
                string rest_Risico = "";
                string rest_Risico_Beschrijving = "";



                Form issueMaatregelen = new IssueMaatregelen(ObjectNaam, ObjectID, issueId,
                                                             discipline, gevaar, situatie, gebeurtenis,
                                                             init_Risico, init_Risico_Beschrijving,
                                                             rest_Risico, rest_Risico_Beschrijving);
                issueMaatregelen.ShowDialog();
                //ShowDataWithFiltering();
                LoadData();
            }
            catch (Exception err)
            {

                Console.WriteLine(err);
            }
            
        }

        private void buttonClearDGVFilter_Click(object sender, EventArgs e)
        {
            this.objectIssuesDataTable.RemoveFilter();
            this.objectIssuesDataTable.RemoveSort();
        }

        private void buttonSaveObjectNotes_Click(object sender, EventArgs e)
        {
            string objectNotes = textBoxObjectNotes.Text;
            comunicator.UpdateObjectNotes(ObjectID, objectNotes);

            LoadNotes();
        }
    }
}
