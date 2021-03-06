﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiskManagmentTool.LogicLayer.Objects
{
    class IssueObject
    {
        public string IssueId { get; set; }
        public string IssueBeschrijving { get; set; }
        public string IssueGevolg { get; set; }
        public string IssueDicipline { get; set; }
        public string IssueGebruiksfase { get; set; }
        public string IssueGebruiker { get; set; }
        public string IssueGevarenzone { get; set; }
        public string IssueSeverity { get; set; }
        public string IssueFrequency { get; set; }
        public string IssueProbability { get; set; }
        public string IssueAvoidance { get; set; }
        public VerificatieStatus Verificatie { get; set; }
       // public List<int> items to verificate

    }
}
