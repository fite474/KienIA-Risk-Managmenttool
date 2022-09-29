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

namespace RiskManagmentTool.InterfaceLayer.WeergeefWindows
{
    public partial class ShowMenuItemUsage : Form
    {
        Datacomunication comunicator;
        //DataTable ItemData;
        private List<string> ItemUsageIDs;
        private MenuTableName menuTableName;
        private string SelectedItemText;

        public ShowMenuItemUsage(List<string> itemUsageIDs, MenuTableName menuTableName, string selectedItem)
        {
            InitializeComponent();

            ItemUsageIDs = itemUsageIDs;
            this.menuTableName = menuTableName;
            SelectedItemText = selectedItem;
            textBoxSelectedOption.Text = selectedItem;
            //ItemData = dataTable;
            LoadData();
            this.buttonProceedDelete.DialogResult = System.Windows.Forms.DialogResult.OK;
            //dataGridView1.DataSource = dataTable;
        }

        private void LoadData()
        {
            comunicator = new Datacomunication();
            dataGridViewItemUsage.DataSource = comunicator.GetSelectedGevaren(ItemUsageIDs);

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridViewItemUsage_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dataGridViewItemUsage.ClearSelection();
        }

        private void buttonProceedDelete_Click(object sender, EventArgs e)
        {
            comunicator.DeleteUsageAndMenuOption(menuTableName, SelectedItemText);

            //string message = "Weet u zeker dat u dit item wilt verwijderen?";
            //string title = "Reminder Risico waardes";
            //MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            //DialogResult result = MessageBox.Show(message, title, buttons);

            //if (result == DialogResult.Yes)
            //{
            //    comunicator.DeleteUsageAndMenuOption(menuTableName, SelectedItemText);

            //    this.Close();
            //}
            //else
            //{

            //}

        }
    }
}
