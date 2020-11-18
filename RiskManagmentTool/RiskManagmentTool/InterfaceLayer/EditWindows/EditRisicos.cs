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

namespace RiskManagmentTool.InterfaceLayer.EditWindows
{
    public partial class EditRisicos : Form
    {
        private Datacomunication comunicator;
        private KeuzeMenus keuzeMenus;
        private MenuTableName MenuTableName;
        private string menuTitle;

        //private List<string> TypeObjectItems;
        private List<string> GevolgenItems;
        private List<string> GevarenzonesItems;
        private List<string> GevaarTypesItems;
        private List<string> GebruiksfaseItems;
        private List<string> GebruikersItems;
        private List<string> DisciplinesItems;
        private List<string> BedienvormenItems;
        private List<string> TakenItems;

        private Dictionary<string, int> GevolgenItems_DBIndex;
        private Dictionary<string, int> GevarenzonesItems_DBIndex;
        private Dictionary<string, int> GevaarTypesItems_DBIndex;
        private Dictionary<string, int> GebruiksfaseItems_DBIndex;
        private Dictionary<string, int> GebruikersItems_DBIndex;
        private Dictionary<string, int> DisciplinesItems_DBIndex;
        private Dictionary<string, int> BedienvormenItems_DBIndex;
        private Dictionary<string, int> TakenItems_DBIndex;




        private List<string> CurrentMenuToAddTo;


        private List<int> GevolgenCheckedItems;
        private List<int> GevarenzonesCheckedItems;
        private List<int> GevaarTypesCheckedItems;
        private List<int> GebruiksfaseCheckedItems;
        private List<int> GebruikersCheckedItems;
        private List<int> DisciplinesCheckedItems;
        private List<int> BedienvormenCheckedItems;
        private List<int> TakenCheckedItems;




        private TextBox currentTextBox;
        private List<int> currentList;

        private bool isNewGevaar;

        private string editGevaarID;

        public EditRisicos()
        {
            InitializeComponent();
            isNewGevaar = true;
            LoadData();
            LoadEmptyGevaarData();


        }
        public EditRisicos(string gevaarID)//string riskBeschrijving,
                            //string riskGevolg)
        {
            
            InitializeComponent();
            isNewGevaar = false;
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
            keuzeMenus = new KeuzeMenus();
            comunicator = new Datacomunication();
            CurrentMenuToAddTo = new List<string>();

            GevolgenItems = keuzeMenus.GetGevolgenMenu();
            GevarenzonesItems = keuzeMenus.GetGevarenzoneMenu();
            GevaarTypesItems = keuzeMenus.GetGevaarTypeMenu();
            GebruiksfaseItems = keuzeMenus.GetGebruikersfasesMenu();
            GebruikersItems = keuzeMenus.GetGebruikersMenu();
            DisciplinesItems = keuzeMenus.GetDisciplinesMenu();
            BedienvormenItems = keuzeMenus.GetBedienvormenMenu();
            TakenItems = keuzeMenus.GetTakenMenu();

        }

        private void LoadEmptyGevaarData()
        {
            GevolgenCheckedItems = new List<int>();
            GevarenzonesCheckedItems = new List<int>();
            GevaarTypesCheckedItems = new List<int>();
            GebruiksfaseCheckedItems = new List<int>();
            GebruikersCheckedItems = new List<int>();
            DisciplinesCheckedItems = new List<int>();
            BedienvormenCheckedItems = new List<int>();
            TakenCheckedItems = new List<int>();

        }

        private void LoadGevaarData(string gevaarID)
        {
            GevolgenCheckedItems = comunicator.GetGevaar_Gevolg(gevaarID);

            GevarenzonesCheckedItems = comunicator.GetGevaar_GevaarlijkeZone(gevaarID);
            GevaarTypesCheckedItems = comunicator.GetGevaar_GevaarType(gevaarID);
            GebruiksfaseCheckedItems = comunicator.GetGevaar_Gebruiksfase(gevaarID);
            GebruikersCheckedItems = comunicator.GetGevaar_Gebruiker(gevaarID);
            DisciplinesCheckedItems = comunicator.GetGevaar_Disciplines(gevaarID);

            BedienvormenCheckedItems = comunicator.GetGevaar_Bedienvorm(gevaarID);
            TakenCheckedItems = comunicator.GetGevaar_Taak(gevaarID);
        }



        private void UpdateText()
        {
            string checkedItems = string.Empty;
            currentList.Clear();
            foreach (object Item in checkedListBoxOptions.CheckedItems)
            {
                checkedItems += Item.ToString() + ";  ";
                currentList.Add(checkedListBoxOptions.Items.IndexOf(Item));
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
                comunicator.InitMakeGevaar2(gevaarlijkeSituatie, gevaarlijkeGebeurtenis,
                DisciplinesCheckedItems, GebruiksfaseCheckedItems,
                BedienvormenCheckedItems, GebruikersCheckedItems,
                GevarenzonesCheckedItems, TakenCheckedItems,
                GevaarTypesCheckedItems, GevolgenCheckedItems);
            }
            else if(!isNewGevaar)
            {
                int gevaarIDToUpdate = int.Parse(editGevaarID);
                comunicator.UpdateGevaarData(gevaarIDToUpdate, DisciplinesCheckedItems, GebruiksfaseCheckedItems,
                BedienvormenCheckedItems, GebruikersCheckedItems,
                GevarenzonesCheckedItems, TakenCheckedItems,
                GevaarTypesCheckedItems, GevolgenCheckedItems);
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

       
        private void ChangeCheckedListBox(List<string> items, List<int> checkedItems)
        {
            int indexHelper = 0;
            checkedListBoxOptions.Items.Clear();
            foreach (string menuOption in items)
            {
                checkedListBoxOptions.Items.Add(menuOption);
                if (checkedItems.Contains(indexHelper))
                {
                    checkedListBoxOptions.SetItemChecked(indexHelper, true);
                }

                indexHelper++;
            }

        }



        private void buttonDisciplines_Click(object sender, EventArgs e)
        {
            ChangeCheckedListBox(DisciplinesItems, DisciplinesCheckedItems);

            MenuTableName = MenuTableName.Disciplines;
            UpdateState();

        }

        private void buttonGebruiksfase_Click(object sender, EventArgs e)
        {
            ChangeCheckedListBox(GebruiksfaseItems, GebruiksfaseCheckedItems);

            MenuTableName = MenuTableName.Gebruiksfases;
            UpdateState();
        }

        private void buttonBedienvorm_Click(object sender, EventArgs e)
        {
            ChangeCheckedListBox(BedienvormenItems, BedienvormenCheckedItems);

            MenuTableName = MenuTableName.Bedienvormen;
            UpdateState();
        }

        private void buttonGebruiker_Click(object sender, EventArgs e)
        {
            ChangeCheckedListBox(GebruikersItems, GebruikersCheckedItems);

            MenuTableName = MenuTableName.Gebruikers;
            UpdateState();
        }

        private void buttonGevaarlijkeZone_Click(object sender, EventArgs e)
        {
            ChangeCheckedListBox(GevarenzonesItems, GevarenzonesCheckedItems);

            MenuTableName = MenuTableName.Gevarenzones;
            UpdateState();
        }

        private void buttonTaak_Click(object sender, EventArgs e)
        {
            ChangeCheckedListBox(TakenItems, TakenCheckedItems);

            MenuTableName = MenuTableName.Taken;
            UpdateState();
        }

        private void buttonGevaar_Click(object sender, EventArgs e)
        {
            ChangeCheckedListBox(GevaarTypesItems, GevaarTypesCheckedItems);

            MenuTableName = MenuTableName.GevaarTypes;
            UpdateState();
        }

        private void buttonGevolg_Click(object sender, EventArgs e)
        {
            ChangeCheckedListBox(GevolgenItems, GevolgenCheckedItems);

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
        }


        private void UpdateState()
        {
            switch (MenuTableName)
            {
                case MenuTableName.Gevolgen:
                    currentTextBox = textBoxGevolg;
                    currentList = GevolgenCheckedItems;
                    CurrentMenuToAddTo = GevolgenItems;
                    menuTitle = "Gevolgen";
                    break;
                case MenuTableName.Gevarenzones:
                    currentTextBox = textBoxGevaarlijkeZone;
                    currentList = GevarenzonesCheckedItems;
                    CurrentMenuToAddTo = GevarenzonesItems;
                    menuTitle = "Gevaren zone";
                    break;
                case MenuTableName.GevaarTypes:
                    currentTextBox = textBoxGevaar;
                    currentList = GevaarTypesCheckedItems;
                    CurrentMenuToAddTo = GevaarTypesItems;
                    menuTitle = "Gevaar type";
                    break;
                case MenuTableName.Gebruiksfases:
                    currentTextBox = textBoxGebruiksfase;
                    currentList = GebruiksfaseCheckedItems;
                    CurrentMenuToAddTo = GebruiksfaseItems;
                    menuTitle = "Gebruiksfase";
                    break;
                case MenuTableName.Gebruikers:
                    currentTextBox = textBoxGebruiker;
                    currentList = GebruikersCheckedItems;
                    CurrentMenuToAddTo = GebruikersItems;
                    menuTitle = "Gebruikers";
                    break;
                case MenuTableName.Disciplines:
                    currentTextBox = textBoxDiscipline;
                    currentList = DisciplinesCheckedItems;
                    CurrentMenuToAddTo = DisciplinesItems;
                    menuTitle = "Discipline";
                    break;
                case MenuTableName.Bedienvormen:
                    currentTextBox = textBoxBedienvorm;
                    currentList = BedienvormenCheckedItems;
                    CurrentMenuToAddTo = BedienvormenItems;
                    menuTitle = "Bedienvorm";
                    break;
                case MenuTableName.Taken:
                    currentTextBox = textBoxTaak;
                    currentList = TakenCheckedItems;
                    CurrentMenuToAddTo = TakenItems;
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



        
    }
}
