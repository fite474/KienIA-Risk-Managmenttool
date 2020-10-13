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

namespace RiskManagmentTool.InterfaceLayer.ContentWindows
{
    public partial class ContentMaatregelen : Form
    {
        public ContentMaatregelen()
        {
            InitializeComponent();
        }


        private void CreateIssue()
        {
            Item issue = new Item
            {
                ItemType = ItemType.Issue,
                ItemData = new IssueObject
                {
                    IssueId = "",
                    IssueBeschrijving = "",
                    IssueGevolg = "",
                    IssueDicipline = "",
                    IssueGebruiksfase = "",
                    IssueGebruiker = "",
                    IssueGevarenzone = "",
                    IssueSeverity = "",
                    IssueFrequency = "",
                    IssueProbability = "",
                    IssueAvoidance = "",
                    Verificatie = VerificatieStatus.Volledig
                }
            };
        }
    }
}
