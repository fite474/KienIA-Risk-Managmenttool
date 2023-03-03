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


        // controle dictonaries for checking changes
        private Dictionary<int, int> GevolgenCheckedItemsAtStart;
        private Dictionary<int, int> GevarenzonesCheckedItemsAtStart;
        private Dictionary<int, int> GevaarTypesCheckedItemsAtStart;
        private Dictionary<int, int> GebruiksfaseCheckedItemsAtStart;
        private Dictionary<int, int> GebruikersCheckedItemsAtStart;
        private Dictionary<int, int> DisciplinesCheckedItemsAtStart;
        private Dictionary<int, int> BedienvormenCheckedItemsAtStart;
        private Dictionary<int, int> TakenCheckedItemsAtStart;

        //end 




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


        private bool listboxActive;

        private string objectId;

        public EditRisicos(string objectId)
        {
            InitializeComponent();
            isNewGevaar = true;
            situatieInitString = "";
            gebeurtenisInitString = "";
            editGevaarID = "-1";
            this.objectId = objectId;
            LoadData();
            LoadEmptyGevaarData();
            buttonDeleteGevaar.Enabled = false;
            buttonKeuzeOption.Enabled = false;
            listboxActive = false;
            LoadSettings();

        }

        public EditRisicos(string gevaarID, string objectId)
        {
            
            InitializeComponent();
            isNewGevaar = false;
            //situatieInitString = "";
            //gebeurtenisInitString = "";

            this.objectId = objectId;
            editGevaarID = gevaarID;
            LoadData();
            LoadGevaarData(gevaarID);
            LoadTextFirstOpen();
            buttonKeuzeOption.Enabled = false;
            listboxActive = false;
            
        }

        private void LoadData()
        {
            

            comunicator = new Datacomunication();
            deleteControler = new DeleteControler();
            CurrentMenuToAddTo = new Dictionary<int, string>();
            LoadMenus();

            textBoxGevaarUsage.Text = comunicator.GetAllIssuesWithGevaarID(editGevaarID).Rows.Count.ToString();
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


            GevolgenCheckedItemsAtStart = comunicator.GetGevaar_Gevolg(gevaarID);
            GevarenzonesCheckedItemsAtStart = comunicator.GetGevaar_GevaarlijkeZone(gevaarID);
            GevaarTypesCheckedItemsAtStart = comunicator.GetGevaar_GevaarType(gevaarID);
            GebruiksfaseCheckedItemsAtStart = comunicator.GetGevaar_Gebruiksfase(gevaarID);
            GebruikersCheckedItemsAtStart = comunicator.GetGevaar_Gebruiker(gevaarID);
            DisciplinesCheckedItemsAtStart = comunicator.GetGevaar_Disciplines(gevaarID);
            BedienvormenCheckedItemsAtStart = comunicator.GetGevaar_Bedienvorm(gevaarID);
            TakenCheckedItemsAtStart = comunicator.GetGevaar_Taak(gevaarID);

            GevolgenCheckedItems = new Dictionary<int, int>(GevolgenCheckedItemsAtStart);
            GevarenzonesCheckedItems = new Dictionary<int, int>(GevarenzonesCheckedItemsAtStart);
            GevaarTypesCheckedItems = new Dictionary<int, int>(GevaarTypesCheckedItemsAtStart);
            GebruiksfaseCheckedItems = new Dictionary<int, int>(GebruiksfaseCheckedItemsAtStart);
            GebruikersCheckedItems = new Dictionary<int, int>(GebruikersCheckedItemsAtStart);
            DisciplinesCheckedItems = new Dictionary<int, int>(DisciplinesCheckedItemsAtStart);
            BedienvormenCheckedItems = new Dictionary<int, int>(BedienvormenCheckedItemsAtStart);
            TakenCheckedItems = new Dictionary<int, int>(TakenCheckedItemsAtStart);



            situatieInitString = textBoxGevSituatie.Text;
            gebeurtenisInitString = textBoxGevGebeurtenis.Text;


        }

        private void LoadSettings()
        {
            if (!objectId.Equals("-1"))
            {
                this.buttonKeuzeOption.Text = "Voeg toe Object specifiek";
            }
            else
            {
                //niet nodig om aan te passen
                //this.buttonAddOption.Text = "Project specifiek";
            }

        }

        private void LoadTextFirstOpen()
        {
            string textToShow = "";
            foreach (KeyValuePair<int, int> kvp in GevolgenCheckedItems)
            {
                GevolgenItems_DBIndex.TryGetValue(kvp.Value, out string text);
                textToShow += text + ";  ";
                    
            }
            textBoxGevolg.Text = textToShow;
            textToShow = "";
            foreach (KeyValuePair<int, int> kvp in GevarenzonesCheckedItems)
            {
                GevarenzonesItems_DBIndex.TryGetValue(kvp.Value, out string text);
                textToShow += text + ";  ";

            }
            textBoxGevaarlijkeZone.Text = textToShow;
            textToShow = "";
            foreach (KeyValuePair<int, int> kvp in GevaarTypesCheckedItems)
            {
                GevaarTypesItems_DBIndex.TryGetValue(kvp.Value, out string text);
                textToShow += text + ";  ";

            }
            textBoxGevaar.Text = textToShow;
            textToShow = "";
            foreach (KeyValuePair<int, int> kvp in GebruiksfaseCheckedItems)
            {
                GebruiksfaseItems_DBIndex.TryGetValue(kvp.Value, out string text);
                textToShow += text + ";  ";

            }
            textBoxGebruiksfase.Text = textToShow;
            textToShow = "";
            foreach (KeyValuePair<int, int> kvp in GebruikersCheckedItems)
            {
                GebruikersItems_DBIndex.TryGetValue(kvp.Value, out string text);
                textToShow += text + ";  ";

            }
            textBoxGebruiker.Text = textToShow;
            textToShow = "";
            foreach (KeyValuePair<int, int> kvp in DisciplinesCheckedItems)
            {
                DisciplinesItems_DBIndex.TryGetValue(kvp.Value, out string text);
                textToShow += text + ";  ";

            }
            textBoxDiscipline.Text = textToShow;
            textToShow = "";
            foreach (KeyValuePair<int, int> kvp in BedienvormenCheckedItems)
            {
                BedienvormenItems_DBIndex.TryGetValue(kvp.Value, out string text);
                textToShow += text + ";  ";

            }
            textBoxBedienvorm.Text = textToShow;
            textToShow = "";
            foreach (KeyValuePair<int, int> kvp in TakenCheckedItems)
            {
                TakenItems_DBIndex.TryGetValue(kvp.Value, out string text);
                textToShow += text + ";  ";

            }
            textBoxTaak.Text = textToShow;
            textToShow = "";
            Cursor.Current = Cursors.Default;
        }


        public void SetReadOnlyMode()
        {
            //buttonBedienvorm.Enabled = false;
            //buttonGebruiker.Enabled = false;
            //buttonDisciplines.Enabled = false;
            //buttonGebruiksfase.Enabled = false;
            //buttonGevaar.Enabled = false;
            //buttonGevaarlijkeZone.Enabled = false;
            //buttonGevolg.Enabled = false;
            //
            
            //buttonTaak.Enabled = false;
            //buttonViewGevaarUsage.Enabled = false;

            textBoxGevSituatie.Enabled = false;
            textBoxGevGebeurtenis.Enabled = false;

            checkedListBoxOptions.Enabled = false;

            buttonKeuzeOption.Enabled = false;
            buttonSave.Enabled = false;
            buttonDeleteGevaar.Enabled = false;
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





        private void CheckUsersChanges(Dictionary<int, int> checkedItemsAtSave, Dictionary<int, int> checkedItemsAtStart, MenuTableName menuTableName)
        {
            int gevaarIDToUpdate = int.Parse(editGevaarID);

            if (checkedItemsAtSave.Count > 0)
            {
                if (checkedItemsAtStart.Count == 0)
                {
                    comunicator.UpdateGevaarDataRemoveNull(gevaarIDToUpdate, menuTableName);
                }

                foreach (KeyValuePair<int, int> kvp in checkedItemsAtSave)
                {
                    if (!checkedItemsAtStart.ContainsValue(kvp.Value))
                    {
                        // add data to gevaar
                        comunicator.UpdateGevaarDataAdd(gevaarIDToUpdate, menuTableName, kvp.Value);
                    }
                }

                foreach (KeyValuePair<int, int> kvp in checkedItemsAtStart)
                {
                    if (!checkedItemsAtSave.ContainsValue(kvp.Value))
                    {
                        // remove data from gevaar
                        comunicator.UpdateGevaarDataDelete(gevaarIDToUpdate, menuTableName, kvp.Value);
                    }
                }
            }
            else if (checkedItemsAtSave.Count == 0 && checkedItemsAtStart.Count != 0)
            {
                comunicator.UpdateGevaarDataInsertNull(gevaarIDToUpdate, menuTableName);
            }
        }

        private void UpdateGevaarDataWithChecks()
        {

            CheckUsersChanges(DisciplinesCheckedItems, DisciplinesCheckedItemsAtStart, MenuTableName.Disciplines);
            CheckUsersChanges(GevolgenCheckedItems, GevolgenCheckedItemsAtStart, MenuTableName.Gevolgen);
            CheckUsersChanges(GevarenzonesCheckedItems, GevarenzonesCheckedItemsAtStart, MenuTableName.Gevarenzones);
            CheckUsersChanges(GevaarTypesCheckedItems, GevaarTypesCheckedItemsAtStart, MenuTableName.GevaarTypes);
            CheckUsersChanges(GebruiksfaseCheckedItems, GebruiksfaseCheckedItemsAtStart, MenuTableName.Gebruiksfases);
            CheckUsersChanges(GebruikersCheckedItems, GebruikersCheckedItemsAtStart, MenuTableName.Gebruikers);
            CheckUsersChanges(BedienvormenCheckedItems, BedienvormenCheckedItemsAtStart, MenuTableName.Bedienvormen);
            CheckUsersChanges(TakenCheckedItems, TakenCheckedItemsAtStart, MenuTableName.Taken);

            int gevaarIDToUpdate = int.Parse(editGevaarID);
            if (textBoxGevSituatie.Text != situatieInitString)
            {
                comunicator.UpdateGevaarSituatie(gevaarIDToUpdate, textBoxGevSituatie.Text);
            }
            if (textBoxGevGebeurtenis.Text != gebeurtenisInitString)
            {
                comunicator.UpdateGevaarGebeurtenis(gevaarIDToUpdate, textBoxGevGebeurtenis.Text);
            }

        }


        private void buttonSave_Click(object sender, EventArgs e)
        {
            string gevaarlijkeSituatie = textBoxGevSituatie.Text;
            string gevaarlijkeGebeurtenis = textBoxGevGebeurtenis.Text;

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
                UpdateGevaarDataWithChecks();
            }



            this.Close();


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



        #region button menu

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

        #endregion button menu

        private void checkedListBoxOptions_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            this.BeginInvoke((MethodInvoker)(
            () => UpdateText()));
            
        }

        private void buttonKeuzeOption_Click(object sender, EventArgs e)
        {
            EditKeuzes editKeuze = new EditKeuzes(MenuTableName, CurrentMenuToAddTo, menuTitle, objectId);
            editKeuze.ShowDialog();

            LoadMenus();
            UpdateState();
            ChangeCheckedListBox(CurrentMenuToAddTo, currentList);
        }


        private void UpdateState()
        {
            if (!listboxActive)
            {
                buttonKeuzeOption.Enabled = true;
                listboxActive = true;
            }

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

            textBoxCurrentMenu.Text = menuTitle;

        }

        private void EditRisicos_Load(object sender, EventArgs e)
        {
            if (!isNewGevaar)
            {

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
            if (deleteControler.DeleteGevaarFromDatabase(editGevaarID))
            {
                this.Close();
            }

        }
    }
}
