using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RiskManagmentTool.LogicLayer
{
    class DataControler
    {
        
        private Datacomunication comunicator;



        private readonly string CurrentID;
        public DataControler(string idToCheck)
        {

            comunicator = new Datacomunication();
            CurrentID = idToCheck;
        }


        public void CheckObjectForDubbleGevarenUitIssues(List<string> itemsToAdd)
        {
            List<string> GekoppeldeGevarenId = comunicator.GetGekoppeldeGevarenFromObjectAsList(CurrentID);
            List<string> gevarenFromSelectedIssues = comunicator.GetGevarenFromIssuesAsList(itemsToAdd);

            foreach (string gevaarID in gevarenFromSelectedIssues)
            {
                if (GekoppeldeGevarenId.Contains(gevaarID))
                {
                    //SelectedTemplateIssueId.Remove()
                    string message = "Dit object bevat een issue met hetzelfde gevaar id.\n" +
                        "Wilt u alleen de maatregelen en risicobeoordeling \n" +
                        "overnemen en bij het bijbehorende issue updaten?";
                    string title = "Reminder Risico waardes";
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult result = MessageBox.Show(message, title, buttons);
                    if (result == DialogResult.Yes)
                    {
                        //this.Close();
                    }
                    else
                    {
                        // Do something  
                    }
                }
            }
        }

        public void CheckObjectForDubbleGevaren(List<string> itemsToAdd)
        {
            List<string> GekoppeldeGevarenId = comunicator.GetGekoppeldeGevarenFromObjectAsList(CurrentID);
            //List<string> gevarenFromSelectedIssues = comunicator.GetGevarenFromIssuesAsList(itemsToAdd);

            foreach (string gevaarID in itemsToAdd)
            {
                if (GekoppeldeGevarenId.Contains(gevaarID))
                {
                    //SelectedTemplateIssueId.Remove()
                    string message = "Dit object bevat een gevaren met hetzelfde gevaar id.\n" +
                        "Wilt u alleen de maatregelen en risicobeoordeling \n" +
                        "overnemen en bij het bijbehorende issue updaten?";
                    string title = "Reminder Risico waardes";
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult result = MessageBox.Show(message, title, buttons);
                    if (result == DialogResult.Yes)
                    {
                        //this.Close();
                    }
                    else
                    {
                        // Do something  
                    }
                }
            }
        }

        public void CheckIssueForDubbleMaatregelen(List<string> itemsToAdd)
        {

            List<string> maatregelenVanIssue = comunicator.GetMaatregelenFromIssuesAsList(CurrentID) ;

            foreach (string maatregelID in itemsToAdd)
            {
                if (maatregelenVanIssue.Contains(maatregelID))
                {
                    //SelectedTemplateIssueId.Remove()
                    string message = "Dit object bevat een issue met hetzelfde gevaar id.\n" +
                        "Wilt u alleen de maatregelen en risicobeoordeling \n" +
                        "overnemen en bij het bijbehorende issue updaten?";
                    string title = "Reminder Risico waardes";
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult result = MessageBox.Show(message, title, buttons);
                    if (result == DialogResult.Yes)
                    {
                        //this.Close();
                    }
                    else
                    {
                        // Do something  
                    }
                }
            }
        }


        public void CheckTemplateForDubbleIssues(List<string> itemsToAdd)
        {

            //foreach (string gevaarID in gevarenFromSelectedIssues)
            //{
            //    if (GekoppeldeGevarenId.Contains(gevaarID))
            //    {
            //        //SelectedTemplateIssueId.Remove()
            //        string message = "Dit object bevat een issue met hetzelfde gevaar id.\n" +
            //            "Wilt u alleen de maatregelen en risicobeoordeling \n" +
            //            "overnemen en bij het bijbehorende issue updaten?";
            //        string title = "Reminder Risico waardes";
            //        MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            //        DialogResult result = MessageBox.Show(message, title, buttons);
            //        if (result == DialogResult.Yes)
            //        {
            //            //this.Close();
            //        }
            //        else
            //        {
            //            // Do something  
            //        }
            //    }
            //}
        }

        public void CheckTemplateForDubbleGevaren(List<string> itemsToAdd)
        {

            //foreach (string gevaarID in gevarenFromSelectedIssues)
            //{
            //    if (GekoppeldeGevarenId.Contains(gevaarID))
            //    {
            //        //SelectedTemplateIssueId.Remove()
            //        string message = "Dit object bevat een issue met hetzelfde gevaar id.\n" +
            //            "Wilt u alleen de maatregelen en risicobeoordeling \n" +
            //            "overnemen en bij het bijbehorende issue updaten?";
            //        string title = "Reminder Risico waardes";
            //        MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            //        DialogResult result = MessageBox.Show(message, title, buttons);
            //        if (result == DialogResult.Yes)
            //        {
            //            //this.Close();
            //        }
            //        else
            //        {
            //            // Do something  
            //        }
            //    }
            //}
        }



    }
}
