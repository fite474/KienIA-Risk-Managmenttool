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
using RiskManagmentTool.InterfaceLayer.InitWindows;
using RiskManagmentTool.InterfaceLayer.EditWindows;

namespace RiskManagmentTool.InterfaceLayer.ContentWindows
{
    public partial class ContentTemplates : Form
    {
        private Datacomunication comunicator;
        public ContentTemplates()
        {
            InitializeComponent();
            comunicator = new Datacomunication();
            //LoadData();
        }

        //private void LoadData()
        //{
        //    dataGridViewTemplates.DataSource = comunicator.GetTemplateTable();

        //}

        private void buttonAddNew_Click(object sender, EventArgs e)
        {
            //Form initTemplate = new InitTemplate();
            //initTemplate.Show();
            //Form editTemplate = new EditTemplates();
            //editTemplate.Show();
        }

        private void dataGridViewTemplates_DoubleClick(object sender, EventArgs e)
        {
            //try
            //{
            //    string templateId = dataGridViewTemplates.SelectedRows[0].Cells[0].Value.ToString();
            //    //string ObjectType = dataGridViewGekoppeldeIssues.SelectedRows[0].Cells[1].Value.ToString();
            //    //string ObjectBeschrijving = dataGridViewGekoppeldeIssues.SelectedRows[0].Cells[2].Value.ToString();

            //    //Form editTemplates = new EditTemplates(templateId);
            //    //editTemplates.Show();
            //}
            //catch (Exception err)
            //{

            //    Console.WriteLine(err);
            //}

            
        }

        private void dataGridViewTemplates_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            Cursor.Current = Cursors.Default;
            dataGridViewTemplates.ClearSelection();
        }
    }
}
