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

namespace RiskManagmentTool.InterfaceLayer.InitWindows
{
    public partial class InitTemplate : Form
    {
        private Datacomunication comunicator;
        private KeuzeMenus keuzeMenus;
        public InitTemplate()
        {
            InitializeComponent();

            buttonCreateTemplate.DialogResult = System.Windows.Forms.DialogResult.OK;

            comunicator = new Datacomunication();
            keuzeMenus = new KeuzeMenus();
            //this.ProjectId = projectId;
            LoadData();
        }

        private void LoadData()
        {
            //textBoxProjectNaam.Text = projectNaam;
            FillCombobox();
        }

        private void FillCombobox()
        {
            //combobox project lijsten
            List<string> templateTypes = keuzeMenus.GetTemplateTypesMenu();
            foreach (string typeString in templateTypes)
            {
                comboBoxTemplateType.Items.Add(typeString);
            }

            List<string> templateToepassingen = keuzeMenus.GetTemplateToepassingenMenu();
            foreach (string typeString in templateToepassingen)
            {
                comboBoxTemplateToepassing.Items.Add(typeString);
            }
        }

        private void buttonCreateTemplate_Click(object sender, EventArgs e)
        {
            
            string templateNaam = textBoxTemplateNaam.Text;
            string templateType = comboBoxTemplateType.SelectedItem.ToString();
            string templateToepassing = comboBoxTemplateToepassing.SelectedItem.ToString();
            comunicator.MakeTemplate(templateNaam, templateType, templateToepassing);

            //Form editObject = new EditObjecten(projectId, projectNaam, objectNaam, objectType, objectOmschrijving);
           // editObject.Show();
            this.Close();
        }




        
    }
}
