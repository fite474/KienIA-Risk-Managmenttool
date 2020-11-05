using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RiskManagmentTool.InterfaceLayer.WarningWindows;

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


        public List<string> CheckObjectForDubbleGevarenUitIssues(List<string> itemsToAdd)
        {
            List<string> GekoppeldeGevarenId = comunicator.GetGekoppeldeGevarenFromObjectAsList(CurrentID);
            List<string> gevarenFromSelectedIssues = comunicator.GetGevarenFromIssuesAsList(itemsToAdd);

            List<string> resultList = new List<string>();
            int currentIndex = 0;
            foreach (string gevaarID in gevarenFromSelectedIssues)
            {
                if (GekoppeldeGevarenId.Contains(gevaarID))
                {
                    string currentObjectIssue = comunicator.GetIssueIdByObjectAndGevaarId(CurrentID, gevaarID);
                    string issueToAdd = itemsToAdd[currentIndex];
                    WarningAddToObject warningWindow = new WarningAddToObject();
                    warningWindow.MakeWarningOnIssue(CurrentID, currentObjectIssue, issueToAdd, gevaarID);
                    if (warningWindow.ShowDialog() == DialogResult.OK)
                    {
                        // Read the contents of testDialog's TextBox.
                        //string textResult = warningWindow.textBoxInput.Text;


                    }
                    else
                    {
                        //this.txtResult.Text = "Cancelled";
                    }
                    warningWindow.Dispose();

                }
                else
                {
                    resultList.Add(gevaarID);
                }
                currentIndex++;
            }
            return resultList;
        }

        public List<string> CheckObjectForDubbleGevaren(List<string> itemsToAdd)
        {
            List<string> GekoppeldeGevarenId = comunicator.GetGekoppeldeGevarenFromObjectAsList(CurrentID);
            List<string> resultList = new List<string>();
            //int currentIndex = 0;
            foreach (string gevaarID in itemsToAdd)
            {
                if (GekoppeldeGevarenId.Contains(gevaarID))
                {
                    string currentObjectIssue = comunicator.GetIssueIdByObjectAndGevaarId(CurrentID, gevaarID);

                    string message = "Dit object bevat een issue met hetzelfde gevaar id.\n" +
                        "Het gevaar met id: " + gevaarID + " kan niet worden toegevoegd.";
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
                else
                {
                    resultList.Add(gevaarID);
                }

            }
            return resultList;
        }

        public void CheckIssueForDubbleMaatregelen(List<string> itemsToAdd)
        {

            List<string> maatregelenVanIssue = comunicator.GetMaatregelenFromIssuesAsList(CurrentID) ;

            foreach (string maatregelID in itemsToAdd)
            {
                if (maatregelenVanIssue.Contains(maatregelID))
                {

                    Form warningWindow = new WarningAddToObject();
                    warningWindow.ShowDialog();
                    //SelectedTemplateIssueId.Remove()
                    //string message = "Dit object bevat een issue met hetzelfde gevaar id.\n" +
                    //    "Wilt u alleen de maatregelen en risicobeoordeling \n" +
                    //    "overnemen en bij het bijbehorende issue updaten?";
                    //string title = "Reminder Risico waardes";
                    //MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    //DialogResult result = MessageBox.Show(message, title, buttons);
                    //if (result == DialogResult.Yes)
                    //{
                    //    //this.Close();
                    //}
                    //else
                    //{
                    //    // Do something  
                    //}
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
