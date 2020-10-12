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
        public MainWindow()
        {
            InitializeComponent();


            objectBuilder = new ObjectBuilder();
            Testing();
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
