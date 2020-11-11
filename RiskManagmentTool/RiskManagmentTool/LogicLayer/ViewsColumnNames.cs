using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiskManagmentTool.LogicLayer
{
    class ViewsColumnNames
    {
        //Start issues View
        public string IssueIDColumn { get; set; }

        //End issues View


        //Start gevaren view
        public string GevaarIDColumn { get; set; }
        public string GevaarlijkeSituatieColumn { get; set; }
        public string GevaarlijkeGebeurtenisColumn { get; set; }
        public string GevaarDisciplineColumn { get; set; }
        public string GevaarGebruiksfaseColumn { get; set; }
        public string GevaarBedienvormColumn { get; set; }
        public string GevaarGebruikerColumn { get; set; }
        public string GevaarGevaarlijkeZoneColumn { get; set; }
        public string GevaarTaakActieColumn { get; set; }
        public string GevaarGevaarTypeColumn { get; set; }
        public string GevaarGevolgColumn { get; set; }

        //End gevaren view

        //Start Projecten View
        public string ProjectIdColumn { get; set; }
        public string ProjectNaamColumn { get; set; }
        //End Projecten View

        //Start Objecten View
        public string ObjectIDColumn { get; set; }
        public string ObjectNaamColumn { get; set; }
        public string ObjectTypeColumn { get; set; }
        public string ObjectOmschrijvingColumn { get; set; }
        //End Objecten View

        //Start Templates view
        public string TemplateIDColumn { get; set; }
        public string TemplateNaamColumn { get; set; }
        public string TemplateTypeColumn { get; set; }
        public string TemplateOmschrijvingColumn { get; set; }
        //End Templates view

        //Start maatregelen view
        public string MaatregelIDColumn { get; set; }
        public string MaatregelNaamColumn { get; set; }
        public string MaatregelCategoryColumn { get; set; }
        public string MaatregelNormColumn { get; set; }
        //End maatregelen view


        public ViewsColumnNames()
        {
            LoadData();
        }

        private void LoadData()
        {
            //Start issues View
            IssueIDColumn = "IssueID";

            //End issues View


            //Start gevaren view
            GevaarIDColumn = "GevaarID";
            GevaarlijkeSituatieColumn = "GevaarlijkeSituatie";
            GevaarlijkeGebeurtenisColumn = "GevaarlijkeGebeurtenis";
            GevaarDisciplineColumn = "Discipline";
            GevaarGebruiksfaseColumn = "Gebruiksfase";
            GevaarBedienvormColumn = "Bedienvorm";
            GevaarGebruikerColumn = "Gebruiker";
            GevaarGevaarlijkeZoneColumn = "GevaarlijkeZone";
            GevaarTaakActieColumn = "Taak_Actie";
            GevaarGevaarTypeColumn = "Gevaar";
            GevaarGevolgColumn = "Gevolg";

            //End gevaren view

            //Start Projecten View
            ProjectIdColumn = "ProjectID";
            ProjectNaamColumn = "ProjectNaam";
            //End Projecten View

            //Start Objecten View
            ObjectIDColumn = "ObjectID";
            ObjectNaamColumn = "ObjectNaam";
            ObjectTypeColumn = "ObjectType";
            ObjectOmschrijvingColumn = "ObjectOmschrijving";
            //End Objecten View

            //Start Templates view
            TemplateIDColumn = "TemplateID";
            TemplateNaamColumn = "TemplateNaam";
            TemplateTypeColumn = "TemplateType";
            TemplateOmschrijvingColumn = "TemplateOmschrijving";
            //End Templates view

            //Start maatregelen view
            MaatregelIDColumn = "MaatregelID";
            MaatregelNaamColumn = "MaatregelNaam";
            MaatregelCategoryColumn = "MaatregelCategory";
            MaatregelNormColumn = "MaatregelNorm";
            //End maatregelen view



        }
    }
}
