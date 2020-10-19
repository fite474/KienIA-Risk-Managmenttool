﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RiskManagmentTool.InterfaceLayer.EditWindows;

namespace RiskManagmentTool.InterfaceLayer.ContentWindows
{
    public partial class ContentProjecten : Form
    {
        private int column = 0;
        private int row = 0;

        public ContentProjecten()
        {
            InitializeComponent();
            LoadProjects();
        }

        private void buttonAddNew_Click(object sender, EventArgs e)
        {
            Form editProjecten = new EditProjecten();
            editProjecten.Show();
        }

        private void LoadProjects()
        {


            for (int i = 0; i < 20; i++)
            {
                string projectText = "Rotterdam";
                ProjectItem project = new ProjectItem(projectText)
                {
                    Dock = DockStyle.Fill//,
                    //Margin.;
                    
                };
                tableLayoutPanelProjecten.Controls.Add(project, column, row);
                column++;
                if (column == 3)
                {
                    row++;
                    column = 0;

                }

            }
            

        }
    }
}
