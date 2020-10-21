using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RiskManagmentTool.InterfaceLayer.EditWindows;

namespace RiskManagmentTool.InterfaceLayer.ContentWindows
{
    public partial class KeuzesItem : UserControl
    {
        private string MenuName;
        private List<string> MenuOptions;
        public KeuzesItem(string menuName, List<string> options)
        {
            InitializeComponent();
            MenuName = menuName;
            MenuOptions = options;
            LoadData();
        }

        private void LoadData()
        {
            textBoxMenuName.Text = MenuName;
            
            foreach (string menuOption in MenuOptions)
            {
                listBoxMenuOptions.Items.Add(menuOption);
                //comboBoxObjectType.Items.Add(typeString);
            }
        }

        private void buttonEditKeuzes_Click(object sender, EventArgs e)
        {
            Form editKeuzes = new EditKeuzes(MenuName, MenuOptions);
            editKeuzes.Show();

        }
    }
}
