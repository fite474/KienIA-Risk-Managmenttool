﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RiskManagmentTool.InterfaceLayer.ContentWindows
{
    public partial class ContentHelp : Form
    {
        public ContentHelp()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            textBoxGuide.Text = "Welkom bij de KienIA Risk Management Tool";

        }
    }
}