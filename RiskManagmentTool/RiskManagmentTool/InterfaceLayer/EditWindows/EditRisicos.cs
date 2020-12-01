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
using RiskManagmentTool.InterfaceLayer.WeergeefWindows;

namespace RiskManagmentTool.InterfaceLayer.EditWindows
{
    public partial class EditRisicos : Form
    {
        private Datacomunication comunicator;
        private KeuzeMenus keuzeMenus;
        private MenuTableName MenuTableName;
        private string menuTitle;
        private DeleteControler deleteControler;

        #region dictonaries
        private Dictionary<int, string> GevolgenItems_DBIndex;
        private Dictionary<int, string> GevarenzonesItems_DBIndex;
        private Dictionary<int, string> GevaarTypesItems_DBIndex;
        private Dictionary<int, string> GebruiksfaseItems_DBIndex;
        private Dictionary<int, string> GebruikersItems_DBIndex;
        private Dictionary<int, string> DisciplinesItems_DBIndex;
        private Dictionary<int, string> BedienvormenItems_DBIndex;
        private Dictionary<int, string> TakenItems_DBIndex;

        private Dictionary<int, string> CurrentMenuToAddTo;


        private Dictionary<int, int> GevolgenCheckedItems;
        private Dictionary<int, int> GevarenzonesCheckedItems;
        private Dictionary<int, int> GevaarTypesCheckedItems;
        private Dictionary<int, int> GebruiksfaseCheckedItems;
        private Dictionary<int, int> GebruikersCheckedItems;
        private Dictionary<int, int> DisciplinesCheckedItems;
        private Dictionary<int, int> BedienvormenCheckedItems;
        private Dictionary<int, int> TakenCheckedItems;

        private Dictionary<int, int> currentList;
        #endregion dictionaries


        private TextBox currentTextBox;

        private string situatieInitString;
        private string gebeurtenisInitString;

        private bool isNewGevaar;

        private string editGevaarID;

        public EditRisicos()
        {
            InitializeComponent();
            isNewGevaar = true;
            situatieInitString = "";
            gebeurtenisInitString = "";
            editGevaarID = "-1";
            LoadData();
            LoadEmptyGevaarData();


        }

        public EditRisicos(string gevaarID)
        {
            
            InitializeComponent();
            isNewGevaar = false;
            //situatieInitString = "";
            //gebeurtenisInitString = "";

            editGevaarID = gevaarID;
            LoadData();
            LoadGevaarData(gevaarID);

            //LoadEmptyGevaarData();

            //textBoxGevGebeurtenis.Text = riskBeschrijving;
            //textBoxGevSituatie.Text = riskGevolg;
            //textBoxDiscipline.Text = riskDicipline;
            //textBoxGebruiksfase.Text = riskGebruiksfase;
            //textBoxBedienvorm.Text = riskGebruiker;
            //textBoxRiskGevarenzone.Text = riskGevarenzone;
        }

        private void LoadData()
        {
            
            comunicator = new Datacomunication();
            deleteControler = new DeleteControler();
            CurrentMenuToAddTo = new Dictionary<int, string>();
            LoadMenus();


        }

        private void LoadMenus()
        {
            keuzeMenus = new KeuzeMenus();
            GevolgenItems_DBIndex = keuzeMenus.GetGevolgenMenu();
            GevarenzonesItems_DBIndex = keuzeMenus.GetGevarenzoneMenu();
            GevaarTypesItems_DBIndex = keuzeMenus.GetGevaarTypeMenu();
            GebruiksfaseItems_DBIndex = keuzeMenus.GetGebruikersfasesMenu();
            GebruikersItems_DBIndex = keuzeMenus.GetGebruikersMenu();
            DisciplinesItems_DBIndex = keuzeMenus.GetDisciplinesMenu();
            BedienvormenItems_DBIndex = keuzeMenus.GetBedienvormenMenu();
            TakenItems_DBIndex = keuzeMenus.GetTakenMenu();
        }

        private void LoadEmptyGevaarData()
        {
            GevolgenCheckedItems = new Dictionary<int, int>();
            GevarenzonesCheckedItems = new Dictionary<int, int>();
            GevaarTypesCheckedItems = new Dictionary<int, int>();
            GebruiksfaseCheckedItems = new Dictionary<int, int>();
            GebruikersCheckedItems = new Dictionary<int, int>();
            DisciplinesCheckedItems = new Dictionary<int, int>();
            BedienvormenCheckedItems = new Dictionary<int, int>();
            TakenCheckedItems = new Dictionary<int, int>();

        }

        private void LoadGevaarData(string gevaarID)
        {
            DataTable risicoBeoordelingData = comunicator.GetGevaar_Situatie_gebeurtenis(gevaarID);
            
            textBoxGevSituatie.Text = risicoBeoordelingData.Rows[0].Field<string>(1).ToString();
            textBoxGevGebeurtenis.Text = risicoBeoordelingData.Rows[0].Field<string>(2).ToString();


            GevolgenCheckedItems = comunicator.GetGevaar_Gevolg(gevaarID);
            GevarenzonesCheckedItems = comunicator.GetGevaar_GevaarlijkeZone(gevaarID);
            GevaarTypesCheckedItems = comunicator.GetGevaar_GevaarType(gevaarID);
            GebruiksfaseCheckedItems = comunicator.GetGevaar_Gebruiksfase(gevaarID);
            GebruikersCheckedItems = comunicator.GetGevaar_Gebruiker(gevaarID);
            DisciplinesCheckedItems = comunicator.GetGevaar_Disciplines(gevaarID);

            BedienvormenCheckedItems = comunicator.GetGevaar_Bedienvorm(gevaarID);
            TakenCheckedItems = comunicator.GetGevaar_Taak(gevaarID);

            situatieInitString = textBoxGevSituatie.Text;
            gebeurtenisInitString = textBoxGevGebeurtenis.Text;


        }



        private void UpdateText()
        {

            List<int> itemDBIDList = new List<int>();
            foreach (KeyValuePair<int, string> kvpChecked in CurrentMenuToAddTo)
            {
                itemDBIDList.Add(kvpChecked.Key);
            }


            string checkedItems = string.Empty;
            currentList.Clear();
            foreach (object Item in checkedListBoxOptions.CheckedItems)
            {
                int checkboxIndex = checkedListBoxOptions.Items.IndexOf(Item);
                int itemDBID = itemDBIDList[checkboxIndex];
                checkedItems += Item.ToString() + ";  ";
                currentList.Add(checkboxIndex, itemDBID);
            }

            if (currentTextBox != null)
            {
                currentTextBox.Text = checkedItems;
            }

            //if (currentList != null)
            //{
            //    currentList.Add(1);
            //}

        }



        private void buttonSave_Click(object sender, EventArgs e)
        {
            string gevaarlijkeSituatie = textBoxGevGebeurtenis.Text;
            string gevaarlijkeGebeurtenis = textBoxGevSituatie.Text;

            if (isNewGevaar)
            {
                comunicator.InitMakeGevaar(gevaarlijkeSituatie, gevaarlijkeGebeurtenis,
                DisciplinesCheckedItems, GebruiksfaseCheckedItems,
                BedienvormenCheckedItems, GebruikersCheckedItems,
                GevarenzonesCheckedItems, TakenCheckedItems,
                GevaarTypesCheckedItems, GevolgenCheckedItems);
            }
            else if (!isNewGevaar)
            {
                int gevaarIDToUpdate = int.Parse(editGevaarID);
                comunicator.UpdateGevaarData(gevaarIDToUpdate, DisciplinesCheckedItems, GebruiksfaseCheckedItems,
                BedienvormenCheckedItems, GebruikersCheckedItems,
                GevarenzonesCheckedItems, TakenCheckedItems,
                GevaarTypesCheckedItems, GevolgenCheckedItems);

                if (textBoxGevSituatie.Text != situatieInitString)
                {
                    comunicator.UpdateGevaarSituatie(gevaarIDToUpdate, textBoxGevSituatie.Text);
                }
                if (textBoxGevGebeurtenis.Text != gebeurtenisInitString)
                {
                    comunicator.UpdateGevaarGebeurtenis(gevaarIDToUpdate, textBoxGevGebeurtenis.Text);
                }
            }



            this.Close();

            //string gevaarlijkeSituatie = textBoxGevGebeurtenis.Text;
            //string gevaarlijkeGebeurtenis = textBoxGevSituatie.Text;
            //string discipline = textBoxDiscipline.Text;
            //string gebruiksfase = textBoxGebruiksfase.Text;
            //string bedienvorm = textBoxBedienvorm.Text;
            //string gebruiker = textBoxGebruiker.Text;
            //string gevaarlijkeZone = textBoxGevaarlijkeZone.Text;
            //string taak = textBoxTaak.Text;
            //string gevaar = textBoxGevaar.Text;
            //string gevolg = textBoxGevolg.Text;
            //comunicator.MakeGevaar(gevaarlijkeSituatie, gevaarlijkeGebeurtenis, discipline, gebruiksfase, bedienvorm, gebruiker, gevaarlijkeZone, taak, gevaar, gevolg);
            //this.Close();
        }

        private void ChangeCheckedListBox(Dictionary<int, string> items, Dictionary<int, int> checkedItems)
        {
            checkedListBoxOptions.Items.Clear();

            List<int> CheckedIndexes = new List<int>();
            foreach (KeyValuePair<int, int> kvpChecked in checkedItems)
            {
                CheckedIndexes.Add(kvpChecked.Value);
            }


            int indexHelper = 0;
            foreach (KeyValuePair<int, string> kvp in items)
            {
                checkedListBoxOptions.Items.Add(kvp.Value);

                if (CheckedIndexes.Contains(kvp.Key))
                {
                    checkedListBoxOptions.SetItemChecked(indexHelper, true);
                }
                indexHelper++;
            }


        }




        //private void ChangeCheckedListBox(List<string> items, List<int> checkedItems)
        //{

        //    int indexHelper = 0;
        //    checkedListBoxOptions.Items.Clear();
        //    foreach (string menuOption in items)
        //    {
        //        checkedListBoxOptions.Items.Add(menuOption);
        //        if (checkedItems.Contains(indexHelper))
        //        {
        //            checkedListBoxOptions.SetItemChecked(indexHelper, true);
        //        }

        //        indexHelper++;
        //    }

        //}



        private void buttonDisciplines_Click(object sender, EventArgs e)
        {
            ChangeCheckedListBox(DisciplinesItems_DBIndex, DisciplinesCheckedItems);

            MenuTableName = MenuTableName.Disciplines;
            UpdateState();

        }

        private void buttonGebruiksfase_Click(object sender, EventArgs e)
        {
            ChangeCheckedListBox(GebruiksfaseItems_DBIndex, GebruiksfaseCheckedItems);

            MenuTableName = MenuTableName.Gebruiksfases;
            UpdateState();
        }

        private void buttonBedienvorm_Click(object sender, EventArgs e)
        {
            ChangeCheckedListBox(BedienvormenItems_DBIndex, BedienvormenCheckedItems);

            MenuTableName = MenuTableName.Bedienvormen;
            UpdateState();
        }

        private void buttonGebruiker_Click(object sender, EventArgs e)
        {
            ChangeCheckedListBox(GebruikersItems_DBIndex, GebruikersCheckedItems);

            MenuTableName = MenuTableName.Gebruikers;
            UpdateState();
        }

        private void buttonGevaarlijkeZone_Click(object sender, EventArgs e)
        {
            ChangeCheckedListBox(GevarenzonesItems_DBIndex, GevarenzonesCheckedItems);

            MenuTableName = MenuTableName.Gevarenzones;
            UpdateState();
        }

        private void buttonTaak_Click(object sender, EventArgs e)
        {
            ChangeCheckedListBox(TakenItems_DBIndex, TakenCheckedItems);

            MenuTableName = MenuTableName.Taken;
            UpdateState();
        }

        private void buttonGevaar_Click(object sender, EventArgs e)
        {

            ChangeCheckedListBox(GevaarTypesItems_DBIndex, GevaarTypesCheckedItems);
            MenuTableName = MenuTableName.GevaarTypes;
            UpdateState();
        }

        private void buttonGevolg_Click(object sender, EventArgs e)
        {
            ChangeCheckedListBox(GevolgenItems_DBIndex, GevolgenCheckedItems);

            MenuTableName = MenuTableName.Gevolgen;
            UpdateState();
        }

        private void checkedListBoxOptions_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            this.BeginInvoke((MethodInvoker)(
            () => UpdateText()));
            
        }

        private void buttonKeuzeOption_Click(object sender, EventArgs e)
        {
            EditKeuzes editKeuze = new EditKeuzes(MenuTableName, CurrentMenuToAddTo, menuTitle);
            editKeuze.ShowDialog();

            LoadMenus();
            UpdateState();
            ChangeCheckedListBox(CurrentMenuToAddTo, currentList);
        }


        private void UpdateState()
        {
            switch (MenuTableName)
            {
                case MenuTableName.Gevolgen:
                    currentTextBox = textBoxGevolg;
                    currentList = GevolgenCheckedItems;
                    CurrentMenuToAddTo = GevolgenItems_DBIndex;
                    menuTitle = "Gevolgen";
                    break;
                case MenuTableName.Gevarenzones:
                    currentTextBox = textBoxGevaarlijkeZone;
                    currentList = GevarenzonesCheckedItems;
                    CurrentMenuToAddTo = GevarenzonesItems_DBIndex;
                    menuTitle = "Gevaren zone";
                    break;
                case MenuTableName.GevaarTypes:
                    currentTextBox = textBoxGevaar;
                    currentList = GevaarTypesCheckedItems;
                    CurrentMenuToAddTo = GevaarTypesItems_DBIndex;
                    menuTitle = "Gevaar type";
                    break;
                case MenuTableName.Gebruiksfases:
                    currentTextBox = textBoxGebruiksfase;
                    currentList = GebruiksfaseCheckedItems;
                    CurrentMenuToAddTo = GebruiksfaseItems_DBIndex;
                    menuTitle = "Gebruiksfase";
                    break;
                case MenuTableName.Gebruikers:
                    currentTextBox = textBoxGebruiker;
                    currentList = GebruikersCheckedItems;
                    CurrentMenuToAddTo = GebruikersItems_DBIndex;
                    menuTitle = "Gebruikers";
                    break;
                case MenuTableName.Disciplines:
                    currentTextBox = textBoxDiscipline;
                    currentList = DisciplinesCheckedItems;
                    CurrentMenuToAddTo = DisciplinesItems_DBIndex;
                    menuTitle = "Discipline";
                    break;
                case MenuTableName.Bedienvormen:
                    currentTextBox = textBoxBedienvorm;
                    currentList = BedienvormenCheckedItems;
                    CurrentMenuToAddTo = BedienvormenItems_DBIndex;
                    menuTitle = "Bedienvorm";
                    break;
                case MenuTableName.Taken:
                    currentTextBox = textBoxTaak;
                    currentList = TakenCheckedItems;
                    CurrentMenuToAddTo = TakenItems_DBIndex;
                    menuTitle = "Taak";
                    break;
                default:
                    break;
            }

        }

        private void EditRisicos_Load(object sender, EventArgs e)
        {
            if (!isNewGevaar)
            {
                //MenuTableName = MenuTableName.Gevolgen;
                //UpdateState();
                //ChangeCheckedListBox(GevolgenItems, GevolgenCheckedItems);

                //MenuTableName = MenuTableName.Disciplines;
                //UpdateState();
                //ChangeCheckedListBox(DisciplinesItems, DisciplinesCheckedItems);

                //MenuTableName = MenuTableName.Bedienvormen;
                //UpdateState();
                //ChangeCheckedListBox(BedienvormenItems, BedienvormenCheckedItems);

                //buttonDisciplines.PerformClick();

                //buttonBedienvorm.PerformClick();
                //buttonGebruiker.PerformClick();
                //buttonGebruiksfase.PerformClick();
                //buttonGevaar.PerformClick();
                //buttonGevaarlijkeZone.PerformClick();
                //buttonGevolg.PerformClick();
                //buttonTaak.PerformClick();
            }
        }

        private void buttonViewGevaarUsage_Click(object sender, EventArgs e)
        {
            if (!isNewGevaar)
            {
                ShowGevaarUsage showGevaarUsage = new ShowGevaarUsage(editGevaarID);
                showGevaarUsage.ShowDialog();
            }
            
        }

        private void buttonDeleteGevaar_Click(object sender, EventArgs e)
        {
            deleteControler.DeleteGevaarFromDatabase(editGevaarID);
            //string message = "Weet u zeker dat u dit gevaar wilt verwijderen?";
            //string title = "Reminder Risico waardes";
            //MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            //DialogResult result = MessageBox.Show(message, title, buttons);

            //if (result == DialogResult.Yes)
            //{
            //    //this.Close();
            //}
            //else
            //{
                
            //}
        }
    }
}
