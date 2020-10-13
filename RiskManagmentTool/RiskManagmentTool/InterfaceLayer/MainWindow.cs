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

namespace RiskManagmentTool.InterfaceLayer
{
    public partial class MainWindow : Form
    {
        private ObjectBuilder objectBuilder;
        private Form activeForm;

        public MainWindow()
        {
            InitializeComponent();


            objectBuilder = new ObjectBuilder();
            Testing();
        }


        private void OpenContentWindow(Form contentForm, object btnSender)
        {
            if (activeForm != null)
            {
                activeForm.Close();
                //activeForm.SendToBack();
            }
            activeForm = contentForm;
            contentForm.TopLevel = false;
            contentForm.FormBorderStyle = FormBorderStyle.None;
            contentForm.Dock = DockStyle.Fill;
            //this.panelContentWindow.Controls.Add(contentForm);
            //this.panelContentWindow.Tag = contentForm;
            contentForm.BringToFront();
            contentForm.Show();
            //lblTitle.Text = contentForm.Text;


        }

        private void Testing()
        {
            Class1 testBla = new Class1();
            string riskIDTest = testBla.GetRiskId();
            Console.WriteLine(riskIDTest);
            RisicoObject newObject = new RisicoObject();
            newObject =  objectBuilder.BuildRisico("1", "1", "1", "1", "1", "1", "1");
            int x = 0;

        }
    }
}
