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

namespace RiskManagmentTool.InterfaceLayer.EditWindows
{
    public partial class EditKeuzes : Form
    {
        private string MenuName;
        private List<string> MenuOptions;
        private Datacomunication comunicator;
        public EditKeuzes(string menuName, List<string> options)
        {
            InitializeComponent();
            comunicator = new Datacomunication();
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
                comunicator.AddToMenu(MenuName, textResult);
                listBoxMenuOptions.Items.Add(textResult);
            }
            else
            {
                //this.txtResult.Text = "Cancelled";
            }
            editText.Dispose();
            //editText.ShowDialog();
        }
    }
}
