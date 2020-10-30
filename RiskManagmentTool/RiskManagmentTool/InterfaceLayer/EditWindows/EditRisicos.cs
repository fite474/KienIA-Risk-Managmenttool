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

        public EditRisicos()
        {
            InitializeComponent();
            LoadData();


        }
        public EditRisicos(string riskBeschrijving,
                            string riskGevolg)//,
                            //string riskDicipline,
                            //string riskGebruiksfase,
                            //string riskGebruiker,
                            //string riskGevarenzone)
        {
            
            InitializeComponent();
            LoadData();

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
            LoadComboBoxes();
        }

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
            foreach (object Item in checkedListBoxOptions.CheckedItems)
            {
                checkedItems += Item.ToString();
            }
            //MessageBox.Show(checkedItems);
            textBoxGevolg.Text = checkedItems;

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
            Form addItem = new AddItemToGevaar(MenuTableName.Disciplines, DisciplinesItems, "disciplines");
            addItem.ShowDialog();
        }

        private void buttonGebruiksfase_Click(object sender, EventArgs e)
        {
            checkedListBoxOptions.Items.Clear();
            foreach(string menuOption in GebruiksfaseItems)
            {
                checkedListBoxOptions.Items.Add(menuOption);
            }
            
        }

        private void buttonBedienvorm_Click(object sender, EventArgs e)
        {
            checkedListBoxOptions.Items.Clear();
            foreach (string menuOption in BedienvormenItems)
            {
                checkedListBoxOptions.Items.Add(menuOption);
            }
        }

        private void buttonGebruiker_Click(object sender, EventArgs e)
        {
            checkedListBoxOptions.Items.Clear();
            foreach (string menuOption in GebruikersItems)
            {
                checkedListBoxOptions.Items.Add(menuOption);
            }
        }

        private void checkedListBoxOptions_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            UpdateText();
            //textBoxGevolg.Text += checkedListBoxOptions.SelectedItem.ToString() + ", ";//comboBoxGevolg.SelectedItem.ToString();
        }
    }
}
