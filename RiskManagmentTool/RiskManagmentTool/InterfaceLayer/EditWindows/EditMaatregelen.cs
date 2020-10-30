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
    public partial class EditMaatregelen : Form
    {

        private Datacomunication comunicator;
        private KeuzeMenus keuzeMenus;
        public EditMaatregelen()
        {
            InitializeComponent();
            comunicator = new Datacomunication();
            keuzeMenus = new KeuzeMenus();
            LoadMenus();
        }


        private void LoadMenus()
        {
            List<string> maatregelNormList = keuzeMenus.GetMaatregelNormMenu();
            foreach (string normString in maatregelNormList)
            {
                comboBoxMaatregelNorm.Items.Add(normString);
            }

            List<string> maatregelCategoryList = keuzeMenus.GetMaatregelCategoryMenu();
            foreach (string categoryString in maatregelCategoryList)
            {
                comboBoxMaatregelCategory.Items.Add(categoryString);
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            string maatregelNaam = textBoxMaatregelNaam.Text;
            string maatregelNorm = comboBoxMaatregelNorm.SelectedItem.ToString();
            string maatregelCategory = comboBoxMaatregelCategory.SelectedItem.ToString();
            comunicator.MakeMaatregel(maatregelNaam, maatregelNorm, maatregelCategory);
            this.Close();
        }
    }
}
