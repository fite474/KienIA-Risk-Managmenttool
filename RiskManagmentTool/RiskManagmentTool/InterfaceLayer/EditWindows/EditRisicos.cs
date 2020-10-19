using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RiskManagmentTool.InterfaceLayer.EditWindows
{
    public partial class EditRisicos : Form
    {
        public EditRisicos()
        {
            InitializeComponent();


        }
        public EditRisicos(string riskBeschrijving,
                            string riskGevolg)//,
                            //string riskDicipline,
                            //string riskGebruiksfase,
                            //string riskGebruiker,
                            //string riskGevarenzone)
        {
            
            InitializeComponent();

            textBoxGevGebeurtenis.Text = riskBeschrijving;
            textBoxGevSituatie.Text = riskGevolg;
            //textBoxDiscipline.Text = riskDicipline;
            //textBoxGebruiksfase.Text = riskGebruiksfase;
            //textBoxBedienvorm.Text = riskGebruiker;
            //textBoxRiskGevarenzone.Text = riskGevarenzone;
        }


    }
}
