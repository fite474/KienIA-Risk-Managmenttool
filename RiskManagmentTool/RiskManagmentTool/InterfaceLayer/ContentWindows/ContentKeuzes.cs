using System;
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
    public partial class ContentKeuzes : Form
    {

        private int column = 0;
        private int row = 0;
        public ContentKeuzes()
        {
            InitializeComponent();
            LoadKeuzes();
        }

        private void LoadKeuzes()
        {


            for (int i = 0; i < 20; i++)
            {
                //string projectText = "Rotterdam";
                KeuzesItem keuzesItem = new KeuzesItem()
                {
                    Dock = DockStyle.Fill//,
                                         //Margin.;

                };
                tableLayoutPanelKeuzes.Controls.Add(keuzesItem, column, row);
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
