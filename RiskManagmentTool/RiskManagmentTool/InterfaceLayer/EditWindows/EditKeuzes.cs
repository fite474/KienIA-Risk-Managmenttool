﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RiskManagmentTool.LogicLayer;

namespace RiskManagmentTool.InterfaceLayer.EditWindows
{
    public partial class EditKeuzes : Form
    {
        private string MenuName;
        private Dictionary<int, string> MenuOptions;
        private Datacomunication comunicator;
        KeuzeMenus keuzeMenus;
        private MenuTableName MenuTableName;
        private DeleteControler deleteControler;

        public EditKeuzes(MenuTableName menuTableName, Dictionary<int, string> options, string menuName)
        {
            InitializeComponent();
            keuzeMenus = new KeuzeMenus();
            comunicator = new Datacomunication();
            deleteControler = new DeleteControler();
            MenuTableName = menuTableName;
            MenuName = menuName;
            MenuOptions = options;
            LoadData();
        }

        private void LoadData()
        {
            switch (MenuTableName)
            {
                case MenuTableName.ObjectTypes:
                    //MenuOptions = keuzeMenus.GetTypeObjectMenu();
                    break;
                case MenuTableName.Gevolgen:
                    break;
                case MenuTableName.Gevarenzones:
                    break;
                case MenuTableName.GevaarTypes:
                    break;
                case MenuTableName.Gebruiksfases:
                    break;
                case MenuTableName.Gebruikers:
                    break;
                case MenuTableName.Disciplines:
                    break;
                case MenuTableName.Bedienvormen:
                    break;
                default:
                    break;
            }
            textBoxMenuName.Text = MenuName;

            foreach (KeyValuePair<int, string> kvp in MenuOptions)
            {
                listBoxMenuOptions.Items.Add(kvp.Value);
            }
        }

        private void buttonDone_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonAddOption_Click(object sender, EventArgs e)
        {
            EditText editText = new EditText();
            if (editText.ShowDialog(this) == DialogResult.OK)
            {
                // Read the contents of testDialog's TextBox.
                string textResult = editText.textBoxInput.Text;
                listBoxMenuOptions.Items.Add(textResult);
                AddInput(textResult);
            }
            else
            {
                
            }
            editText.Dispose();
            
        }

        private void AddInput(string input)
        {
            comunicator.AddToMenu(MenuTableName, input);
            keuzeMenus.ReloadAllLists(); 
        }

        private void EditInput(int dbIndex, string input)
        {
            comunicator.EditToMenu(MenuTableName, dbIndex, input);
            keuzeMenus.ReloadAllLists();
        }

        private void buttonDeleteOption_Click(object sender, EventArgs e)
        {
            if (listBoxMenuOptions.SelectedItems.Count == 1)
            {
                string selectedOption = listBoxMenuOptions.SelectedItem.ToString();
                if (deleteControler.DeleteKeuzeItemFromDatabase(MenuTableName, selectedOption))
                {
                    listBoxMenuOptions.Items.Remove(selectedOption);
                }
            }
            else
            {
                string message = "selecteer een optie";
                string title = "Verwijder keuze optie";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result = MessageBox.Show(message, title, buttons);
            }
            
        }

        private void buttonEditOption_Click(object sender, EventArgs e)
        {
            int itemDB_ID = -1;
            foreach (KeyValuePair<int, string> kvp in MenuOptions)
            {
                if (kvp.Value.Equals(listBoxMenuOptions.SelectedItem.ToString()))
                {
                    itemDB_ID = kvp.Key;
                }
            }


            EditText editText = new EditText();
            editText.textBoxInput.Text = listBoxMenuOptions.SelectedItem.ToString();
            if (editText.ShowDialog(this) == DialogResult.OK)
            {
                // Read the contents of testDialog's TextBox.
                string textResult = editText.textBoxInput.Text;
                listBoxMenuOptions.Items.Add(textResult);
                EditInput(itemDB_ID, textResult);
            }
            else
            {
                //this.txtResult.Text = "Cancelled";
            }
            editText.Dispose();
            
        }
    }
}
