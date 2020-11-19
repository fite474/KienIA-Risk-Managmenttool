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
    public partial class ShowGevaarUsage : Form
    {
        private Datacomunication comunicator;

        private string GevaarID;

        public ShowGevaarUsage(string gevaarId)
        {
            InitializeComponent();
            comunicator = new Datacomunication();
            GevaarID = gevaarId;
            LoadData();
        }

        private void LoadData()
        {
            dataGridViewGevaarUsage.DataSource = comunicator.GetAllIssuesWithGevaarID(GevaarID);
            
            



        }
    }
}
