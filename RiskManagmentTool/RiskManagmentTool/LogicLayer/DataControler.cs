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
        private bool addMaatregelen;
        private bool addBeoordeling;
        private bool customAddMaatregelen;
        private bool customAddBeoordeling;

        private readonly string CurrentID;

        public DataControler(string idToCheck)
        {

            comunicator = new Datacomunication();
            CurrentID = idToCheck;


            addMaatregelen = true;
            addBeoordeling = true;
        }

        private void HandleAddIssueToObject(string issueID, bool maatregelen, bool beoordeling, bool customMaatregelen, bool customBeoordeling)
        {


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
                        addMaatregelen = warningWindow.checkedListBoxWarningSettings.GetItemChecked(0);
                        addBeoordeling = warningWindow.checkedListBoxWarningSettings.GetItemChecked(1);
                        customAddMaatregelen = warningWindow.checkedListBoxCustomSettings.GetItemChecked(0);
                        customAddBeoordeling = warningWindow.checkedListBoxCustomSettings.GetItemChecked(1);
                        HandleAddIssueToObject(gevaarID, addMaatregelen, addBeoordeling, customAddMaatregelen, customAddBeoordeling);
                    }
                    else
                    {
                        //this.txtResult.Text = "Cancelled";
                    }
                    warningWindow.Dispose();

                }
                else
                {
                    resultList.Add(itemsToAdd[currentIndex]);//resultList.Add(gevaarID);
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

                    WarningAddToObject warningWindow = new WarningAddToObject();
                    //warningWindow.ShowDialog();
                    //SelectedTemplateIssueId.Remove()
                    //string message = "Dit object bevat een issue met hetzelfde gevaar id.\n" +
                    //    "Wilt u alleen de maatregelen en risicobeoordeling \n" +
                    //    "overnemen en bij het bijbehorende issue updaten?";
                    //string title = "Reminder Risico waardes";
                    //MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    //DialogResult result = MessageBox.Show(message, title, buttons);
                    if (warningWindow.ShowDialog() == DialogResult.OK)
                    {
                        //this.Close();
                    }
                    else
                    {
                        // Do something  
                    }
                    warningWindow.Dispose();
                }
                else
                {
                    comunicator.AddMaatregelToIssue(CurrentID, maatregelID);
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



        private void AddGevaarToObjectWithSettings(string gevaarID)
        {

            if (addBeoordeling && addMaatregelen)
            {
                //comunicator.AddFullIssueToObject(CurrentID, gevaarID);
            }
            else if (addBeoordeling && !addMaatregelen)
            {

            }
            else if(!addBeoordeling && addMaatregelen)
            {
                int issueID = comunicator.AddGevaarToObject(CurrentID, gevaarID);
                string issueIDString = issueID.ToString();
                comunicator.AddMaatregelToIssue(issueIDString, "");
            }
            else
            {
                comunicator.AddGevaarToObject(CurrentID, gevaarID);
            }
        }



    }
}
