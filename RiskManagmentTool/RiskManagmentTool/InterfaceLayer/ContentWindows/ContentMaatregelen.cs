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
using RiskManagmentTool.LogicLayer.Objects;
using RiskManagmentTool.LogicLayer.Objects.Core;
using RiskManagmentTool.InterfaceLayer.EditWindows;


namespace RiskManagmentTool.InterfaceLayer.ContentWindows
{
    public partial class ContentMaatregelen : Form
    {
        private Datacomunication comunicator;

        private BindingSource maatregelenData;

        public ContentMaatregelen()
        {
            InitializeComponent();
            comunicator = new Datacomunication();
            RefreshTable();
        }

        private void RefreshTable()
        {
            maatregelenData = comunicator.GetMaatregelTable();
            advancedDataGridViewMaatregelen.DataSource = maatregelenData;
        }

        private void buttonAddNew_Click(object sender, EventArgs e)
        {
            Form editMaatregelen = new EditMaatregelen();
            editMaatregelen.ShowDialog();
            RefreshTable();
        }

        private void advancedDataGridViewMaatregelen_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                string maatregelId = advancedDataGridViewMaatregelen.SelectedRows[0].Cells[0].Value.ToString();
                string maatregelNaam = advancedDataGridViewMaatregelen.SelectedRows[0].Cells[1].Value.ToString();

                Form editMaatregelen = new EditMaatregelen(maatregelId, maatregelNaam);//, maatregelCategory, maatregelNorm);

                editMaatregelen.ShowDialog();
                RefreshTable();
            }
            catch (Exception err )
            {

                Console.WriteLine(err);
            }

        }

        private void advancedDataGridViewMaatregelen_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            advancedDataGridViewMaatregelen.ClearSelection();
            Cursor.Current = Cursors.Default;
        }
    }
}
