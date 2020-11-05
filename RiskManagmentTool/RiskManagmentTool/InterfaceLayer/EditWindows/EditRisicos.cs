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

        //private List<string> TypeObjectItems;
        private List<string> GevolgenItems;
        private List<string> GevarenzonesItems;
        private List<string> GevaarTypesItems;
        private List<string> GebruiksfaseItems;
        private List<string> GebruikersItems;
        private List<string> DisciplinesItems;
        private List<string> BedienvormenItems;
        private List<string> TakenItems;


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

        public EditRisicos()
        {
            InitializeComponent();
            LoadData();
            LoadEmptyGevaarData();


        }
        public EditRisicos(string riskBeschrijving,
                            string riskGevolg)
        {
            
            InitializeComponent();
            LoadData();
            //LoadGevaarData();
            LoadEmptyGevaarData();

            textBoxGevGebeurtenis.Text = riskBeschrijving;
            textBoxGevSituatie.Text = riskGevolg;
            //textBoxDiscipline.Text = riskDicipline;
            //textBoxGebruiksfase.Text = riskGebruiksfase;
            //textBoxBedienvorm.Text = riskGebruiker;
            //textBoxRiskGevarenzone.Text = riskGevarenzone;
        }

        private void LoadData()
        {
            keuzeMenus = new KeuzeMenus();
            comunicator = new Datacomunication();

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

        private void LoadGevaarData()
        {
            //GevolgenCheckedItems = new List<int>();
            //GevarenzonesCheckedItems = new List<int>();
            //GevaarTypesCheckedItems = new List<int>();
            //GebruiksfaseCheckedItems = new List<int>();
            //GebruikersCheckedItems = new List<int>();
            //DisciplinesCheckedItems = new List<int>();
            //BedienvormenCheckedItems = new List<int>();
            //TakenCheckedItems = new List<int>();
        }

        //MAG WEG
        private void LoadComboBoxes()
        {
            //TypeObjectItems = keuzeMenus.GetTypeObjectMenu();
            GevolgenItems = keuzeMenus.GetGevolgenMenu();
            GevarenzonesItems = keuzeMenus.GetGevarenzoneMenu();
            GevaarTypesItems = keuzeMenus.GetGevaarTypeMenu();
            GebruiksfaseItems = keuzeMenus.GetGebruikersfasesMenu();
            GebruikersItems = keuzeMenus.GetGebruikersMenu();
            DisciplinesItems = keuzeMenus.GetDisciplinesMenu();
            BedienvormenItems = keuzeMenus.GetBedienvormenMenu();
            TakenItems = keuzeMenus.GetTakenMenu();

            foreach (string menuOption in GevolgenItems)
            {
                comboBoxGevolg.Items.Add(menuOption);
            }

            foreach (string menuOption in GevarenzonesItems)
            {
                comboBoxGevaarlijkeZone.Items.Add(menuOption);
            }

            foreach (string menuOption in GevaarTypesItems)
            {
                comboBoxGevaar.Items.Add(menuOption);
            }

            foreach (string menuOption in GebruiksfaseItems)
            {
                comboBoxGebruiksfase.Items.Add(menuOption);
            }

            foreach (string menuOption in GebruikersItems)
            {
                comboBoxGebruiker.Items.Add(menuOption);
            }

            foreach (string menuOption in DisciplinesItems)
            {
                comboBoxDiscipline.Items.Add(menuOption);
            }

            foreach (string menuOption in BedienvormenItems)
            {
                comboBoxBedienVorm.Items.Add(menuOption);
            }

            foreach (string menuOption in TakenItems)
            {
                comboBoxTaak.Items.Add(menuOption);
            }



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
            int x = 0;
        }



        private void buttonSave_Click(object sender, EventArgs e)
        {
            string gevaarlijkeSituatie = textBoxGevGebeurtenis.Text;
            string gevaarlijkeGebeurtenis = textBoxGevSituatie.Text;
            string discipline = textBoxDiscipline.Text;
            string gebruiksfase = textBoxGebruiksfase.Text;
            string bedienvorm = textBoxBedienvorm.Text;
            string gebruiker = textBoxGebruiker.Text;
            string gevaarlijkeZone = textBoxGevaarlijkeZone.Text;
            string taak = textBoxTaak.Text;
            string gevaar = textBoxGevaar.Text;
            string gevolg = textBoxGevolg.Text;
            comunicator.MakeGevaar(gevaarlijkeSituatie, gevaarlijkeGebeurtenis, discipline, gebruiksfase, bedienvorm, gebruiker, gevaarlijkeZone, taak, gevaar, gevolg);
            this.Close();

        }

        private void comboBoxDiscipline_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBoxDiscipline.Text = comboBoxDiscipline.SelectedItem.ToString();
        }

        private void comboBoxGebruiksfase_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBoxGebruiksfase.Text = comboBoxGebruiksfase.SelectedItem.ToString();
        }

        private void comboBoxBedienVorm_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBoxBedienvorm.Text = comboBoxBedienVorm.SelectedItem.ToString();
        }

        private void comboBoxGebruiker_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBoxGebruiker.Text = comboBoxGebruiker.SelectedItem.ToString();
        }

        private void comboBoxGevaarlijkeZone_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBoxGevaarlijkeZone.Text = comboBoxGevaarlijkeZone.SelectedItem.ToString();
        }

        private void comboBoxTaak_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBoxTaak.Text = comboBoxTaak.SelectedItem.ToString();
        }

        private void comboBoxGevaar_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBoxGevaar.Text = comboBoxGevaar.SelectedItem.ToString();
        }

        private void comboBoxGevolg_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBoxGevolg.Text = comboBoxGevolg.SelectedItem.ToString();
        }




        private void buttonDisciplines_Click(object sender, EventArgs e)
        {
            int indexHelper = 0;
            checkedListBoxOptions.Items.Clear();
            foreach (string menuOption in DisciplinesItems)
            {
                checkedListBoxOptions.Items.Add(menuOption);
                if (DisciplinesCheckedItems.Contains(indexHelper))
                {
                    checkedListBoxOptions.SetItemChecked(indexHelper, true);
                }

                indexHelper++;
            }
            currentTextBox = textBoxDiscipline;
            currentList = DisciplinesCheckedItems;

        }

        private void buttonGebruiksfase_Click(object sender, EventArgs e)
        {
            int indexHelper = 0;
            checkedListBoxOptions.Items.Clear();
            foreach(string menuOption in GebruiksfaseItems)
            {
                checkedListBoxOptions.Items.Add(menuOption);
                if (GebruiksfaseCheckedItems.Contains(indexHelper))
                {
                    checkedListBoxOptions.SetItemChecked(indexHelper, true);
                }

                indexHelper++;
            }
            currentTextBox = textBoxGebruiksfase;
            currentList = GebruiksfaseCheckedItems;
        }

        private void buttonBedienvorm_Click(object sender, EventArgs e)
        {
            int indexHelper = 0;
            checkedListBoxOptions.Items.Clear();
            foreach (string menuOption in BedienvormenItems)
            {
                checkedListBoxOptions.Items.Add(menuOption);
                if (BedienvormenCheckedItems.Contains(indexHelper))
                {
                    checkedListBoxOptions.SetItemChecked(indexHelper, true);
                }

                indexHelper++;
            }
            currentTextBox = textBoxBedienvorm;
            currentList = BedienvormenCheckedItems;
        }

        private void buttonGebruiker_Click(object sender, EventArgs e)
        {
            int indexHelper = 0;
            checkedListBoxOptions.Items.Clear();
            foreach (string menuOption in GebruikersItems)
            {
                checkedListBoxOptions.Items.Add(menuOption);
                if (GebruikersCheckedItems.Contains(indexHelper))
                {
                    checkedListBoxOptions.SetItemChecked(indexHelper, true);
                }

                indexHelper++;
            }
            currentTextBox = textBoxGebruiker;
            currentList = GebruikersCheckedItems;
        }

        private void buttonGevaarlijkeZone_Click(object sender, EventArgs e)
        {
            int indexHelper = 0;
            checkedListBoxOptions.Items.Clear();
            foreach (string menuOption in GevarenzonesItems)
            {
                checkedListBoxOptions.Items.Add(menuOption);
                if (GevarenzonesCheckedItems.Contains(indexHelper))
                {
                    checkedListBoxOptions.SetItemChecked(indexHelper, true);
                }

                indexHelper++;
            }
            currentTextBox = textBoxGevaarlijkeZone;
            currentList = GevarenzonesCheckedItems;
        }

        private void buttonTaak_Click(object sender, EventArgs e)
        {
            int indexHelper = 0;
            checkedListBoxOptions.Items.Clear();
            foreach (string menuOption in TakenItems)
            {
                checkedListBoxOptions.Items.Add(menuOption);
                if (TakenCheckedItems.Contains(indexHelper))
                {
                    checkedListBoxOptions.SetItemChecked(indexHelper, true);
                }

                indexHelper++;
            }
            currentTextBox = textBoxTaak;
            currentList = TakenCheckedItems;
        }

        private void buttonGevaar_Click(object sender, EventArgs e)
        {
            int indexHelper = 0;
            checkedListBoxOptions.Items.Clear();
            foreach (string menuOption in GevaarTypesItems)
            {
                checkedListBoxOptions.Items.Add(menuOption);
                if (GevaarTypesCheckedItems.Contains(indexHelper))
                {
                    checkedListBoxOptions.SetItemChecked(indexHelper, true);
                }

                indexHelper++;
            }
            currentTextBox = textBoxGevaar;
            currentList = GevaarTypesCheckedItems;
        }

        private void buttonGevolg_Click(object sender, EventArgs e)
        {
            int indexHelper = 0;
            checkedListBoxOptions.Items.Clear();
            foreach (string menuOption in GevolgenItems)
            {
                checkedListBoxOptions.Items.Add(menuOption);
                if (GevolgenCheckedItems.Contains(indexHelper))
                {
                    checkedListBoxOptions.SetItemChecked(indexHelper, true);
                }

                indexHelper++;
            }
            currentTextBox = textBoxGevolg;
            currentList = GevolgenCheckedItems;
        }

        private void checkedListBoxOptions_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            this.BeginInvoke((MethodInvoker)(
            () => UpdateText()));
        }

        private void buttonSaveNewGevaar_Click(object sender, EventArgs e)
        {



            string gevaarlijkeSituatie = textBoxGevGebeurtenis.Text;
            string gevaarlijkeGebeurtenis = textBoxGevSituatie.Text;
            string discipline = textBoxDiscipline.Text;
            string gebruiksfase = textBoxGebruiksfase.Text;
            string bedienvorm = textBoxBedienvorm.Text;
            string gebruiker = textBoxGebruiker.Text;
            string gevaarlijkeZone = textBoxGevaarlijkeZone.Text;
            string taak = textBoxTaak.Text;
            string gevaar = textBoxGevaar.Text;
            string gevolg = textBoxGevolg.Text;
            //comunicator.MakeGevaar(gevaarlijkeSituatie, gevaarlijkeGebeurtenis, discipline, gebruiksfase, bedienvorm, gebruiker, gevaarlijkeZone, taak, gevaar, gevolg);
            this.Close();
        }
    }
}
