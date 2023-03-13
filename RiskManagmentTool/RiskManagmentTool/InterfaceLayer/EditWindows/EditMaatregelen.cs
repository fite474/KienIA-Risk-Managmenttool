using System;
using System.Collections.Generic;
using System.Windows.Forms;
using RiskManagmentTool.LogicLayer;

namespace RiskManagmentTool.InterfaceLayer.EditWindows
{
    public partial class EditMaatregelen : Form
    {
        private MenuTableName MenuTableName;
        private string menuTitle;


        private Dictionary<int, string> NormenItems_DBIndex;
        private Dictionary<int, string> CategorieItems_DBIndex;

        private Dictionary<int, string> CurrentMenuToAddTo;


        private Dictionary<int, int> NormenCheckedItems;
        private Dictionary<int, int> CategorieCheckedItems;

        private Dictionary<int, int> currentList;

        private TextBox currentTextBox;

        private Datacomunication comunicator;
        private KeuzeMenus keuzeMenus;
        private DeleteControler deleteControler;


        private bool isNewMaatregel;
        private string editMaatregelID;

        private bool listboxActive;

        private string objectId = "-1"; //TODO make changeable for object specifics

        public EditMaatregelen()
        {
            InitializeComponent();
            isNewMaatregel = true;
            LoadData();
            LoadEmptyMaatregelData();
            LoadMenus();
            buttonAddMenuOption.Enabled = false;
            listboxActive = false;
        }

        public EditMaatregelen(string maatregelID, string maatregelNaam)
            //, string maatregelCategory, string maatregelNorm)
        {
            InitializeComponent();
            isNewMaatregel = false;
            editMaatregelID = maatregelID;
            LoadData();
            LoadMaatregelData(maatregelID);
            LoadMenus();
            LoadTextFirstOpen();
            buttonAddMenuOption.Enabled = false;
            listboxActive = false;

            textBoxMaatregelNaam.Text = maatregelNaam;
        }

        private void LoadData()
        {
            comunicator = new Datacomunication();
            deleteControler = new DeleteControler();

            CurrentMenuToAddTo = new Dictionary<int, string>();

            
            
        }

        private void LoadMenus()
        {
            keuzeMenus = new KeuzeMenus(objectId);
            NormenItems_DBIndex = keuzeMenus.GetMaatregelNormMenu();
            CategorieItems_DBIndex = keuzeMenus.GetMaatregelCategoryMenu();

        }

        private void LoadEmptyMaatregelData()
        {
            NormenCheckedItems = new Dictionary<int, int>();
            CategorieCheckedItems = new Dictionary<int, int>();
        }

        private void LoadMaatregelData(string maatregelID)
        {

            NormenCheckedItems = comunicator.GetMaatregel_Normen(maatregelID);
            CategorieCheckedItems = comunicator.GetMaatregel_Categorie(maatregelID);
            
        }


        private void LoadTextFirstOpen()
        {
            string textToShow = "";
            foreach (KeyValuePair<int, int> kvp in NormenCheckedItems)
            {
                NormenItems_DBIndex.TryGetValue(kvp.Value, out string text);
                textToShow += text + ";  ";

            }
            textBoxMaatregelNorm.Text = textToShow;
            textToShow = "";
            foreach (KeyValuePair<int, int> kvp in CategorieCheckedItems)
            {
                CategorieItems_DBIndex.TryGetValue(kvp.Value, out string text);
                textToShow += text + ";  ";

            }
            textBoxMaatregelCategorie.Text = textToShow;
            Cursor.Current = Cursors.Default;
        }




        public void SetReadOnlyMode()
        {
            textBoxMaatregelNaam.Enabled = false;
 
            checkedListBoxOptions.Enabled = false;
            buttonDeleteMaatregel.Enabled = false;

            buttonSave.Enabled = false;
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

        private bool SavingOK()
        {
            if (textBoxMaatregelNaam.Text.Length > 1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            string maatregelNaam = textBoxMaatregelNaam.Text;
            if (!SavingOK())
            {
                return;
            }

            if (isNewMaatregel)
            {
                comunicator.InitMaatregel(maatregelNaam, NormenCheckedItems, CategorieCheckedItems);

            }
            else if (!isNewMaatregel)
            {
                int maatregelIDToUpdate = int.Parse(editMaatregelID);
                comunicator.UpdateMaatregelData(maatregelIDToUpdate, NormenCheckedItems, CategorieCheckedItems);


            }



            this.Close();


        }

        private void buttonNorm_Click(object sender, EventArgs e)
        {
            ChangeCheckedListBox(NormenItems_DBIndex, NormenCheckedItems);

            MenuTableName = MenuTableName.Normen;
            UpdateState();
        }

        private void buttonCategorie_Click(object sender, EventArgs e)
        {
            ChangeCheckedListBox(CategorieItems_DBIndex, CategorieCheckedItems);

            MenuTableName = MenuTableName.Categories;
            UpdateState();
        }

        private void UpdateState()
        {
            if (!listboxActive)
            {
                buttonAddMenuOption.Enabled = true;
                listboxActive = true;
            }
            switch (MenuTableName)
            {
                case MenuTableName.Normen:
                    currentTextBox = textBoxMaatregelNorm;
                    currentList = NormenCheckedItems;
                    CurrentMenuToAddTo = NormenItems_DBIndex;
                    menuTitle = "Maatregel norm";
                    break;
                case MenuTableName.Categories:
                    currentTextBox = textBoxMaatregelCategorie;
                    currentList = CategorieCheckedItems;
                    CurrentMenuToAddTo = CategorieItems_DBIndex;
                    menuTitle = "Maatregel categorie";
                    break;
                default:
                    break;
            }

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
        }

        private void checkedListBoxOptions_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            this.BeginInvoke((MethodInvoker)(
            () => UpdateText()));
        }

        private void buttonAddMenuOption_Click(object sender, EventArgs e)
        {
            EditKeuzes editKeuze = new EditKeuzes(MenuTableName, CurrentMenuToAddTo, menuTitle, objectId);
            editKeuze.ShowDialog();
            LoadMenus();
            UpdateState();
            ChangeCheckedListBox(CurrentMenuToAddTo, currentList);
        }

        private void buttonDeleteMaatregel_Click(object sender, EventArgs e)
        {
            if(deleteControler.DeleteMaatregelFromDatabase(editMaatregelID))
            {
                this.Close();

            }
        }
    }
}
