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

namespace RiskManagmentTool.InterfaceLayer.AddWindows
{
    public partial class AddRisico : Form
    {
        private Datacomunication comunicator;
        private string ObjectNaam;
        //public AddRisico()
        //{
        //    InitializeComponent();
        //    comunicator = new Datacomunication();
        //    LoadData();
        //}
        public AddRisico(string objectNaam)
        {
            InitializeComponent();
            comunicator = new Datacomunication();
            this.ObjectNaam = objectNaam;
            LoadData();
        }

        private void LoadData()
        {
            dataGridViewRisicos.DataSource = comunicator.GetGevarenTable();
            textBoxObjectNaam.Text = ObjectNaam;

        }

        private void buttonVoegSelectieToe_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}