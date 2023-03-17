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



        //this methode works only when adding origin gevaren with the reference -1 as origin
        public List<string> CheckObjectForDubbleGevaren(List<string> itemsToAdd)
        {
            List<string> GekoppeldeGevarenOriginId = comunicator.GetGekoppeldeGevarenOriginFromObjectAsList(CurrentID);

            List<string> resultList = new List<string>();

            foreach (string gevaarID in itemsToAdd)
            {
                if (GekoppeldeGevarenOriginId.Contains(gevaarID))
                {
                    //string currentObjectIssue = comunicator.GetIssueIdByObjectAndGevaarId(CurrentID, gevaarID);

                    string message = "Dit object bevat een issue met hetzelfde gevaar id.\n" +
                        "Het gevaar met id: " + gevaarID + " kan niet worden toegevoegd.";
                    string title = "Reminder Risico waardes";
                    MessageBoxButtons buttons = MessageBoxButtons.OK;
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





        #region old version

        public List<string> CheckObjectForDubbleGevarenUitIssues(List<string> itemsToAdd)
        {

            //items to add zijn de issue id's van t object die je selecteerd

            //pak van deze issues de lijst van origin gevaren


            // uit de lijst van gekoppelde origin gevaren pak je de lijs





            List<string> GekoppeldeGevarenId = comunicator.GetGekoppeldeGevarenOriginFromObjectAsList(CurrentID);


            //deze methode moet anders
           //List<string> gevarenFromSelectedIssues = comunicator.GetGevarenFromIssuesAsList(itemsToAdd);


            List<string> gevarenFromSelectedIssues = comunicator.GetGevarenOriginFromIssuesAsList(itemsToAdd);

            List<string> resultList = new List<string>();
            int currentIndex = 0;
            foreach (string gevaarID in gevarenFromSelectedIssues)
            {
                if (GekoppeldeGevarenId.Contains(gevaarID))
                {
                    string currentObjectIssue = comunicator.GetIssueIdByObjectAndGevaarOriginId(CurrentID, gevaarID);

                    //old
                    //string currentObjectIssue = comunicator.GetIssueIdByObjectAndGevaarId(CurrentID, gevaarID);







                    string issueToAdd = itemsToAdd[currentIndex];
                    WarningAddToObject warningWindow = new WarningAddToObject();
                    warningWindow.MakeWarningOnIssue(CurrentID, currentObjectIssue, issueToAdd, gevaarID);
                    if (warningWindow.ShowDialog() == DialogResult.OK)
                    {
                        // Read the contents of testDialog's TextBox.
                        //string textResult = warningWindow.textBoxInput.Text;
                        addMaatregelen = warningWindow.checkedListBoxWarningSettings.GetItemChecked(0);
                        addBeoordeling = warningWindow.checkedListBoxWarningSettings.GetItemChecked(1);
                        //customAddMaatregelen = warningWindow.checkedListBoxCustomSettings.GetItemChecked(0);
                        //customAddBeoordeling = warningWindow.checkedListBoxCustomSettings.GetItemChecked(1);
                        //HandleAddIssueToObject(gevaarID, addMaatregelen, addBeoordeling, customAddMaatregelen, customAddBeoordeling);
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




        #endregion old version

        public void CheckIssueForDubbleMaatregelenAndAddNewOnes(List<string> itemsToAdd)
        {

            List<string> maatregelenVanIssue = comunicator.GetMaatregelenFromIssuesAsList(CurrentID) ;

            foreach (string maatregelID in itemsToAdd)
            {
                if (maatregelenVanIssue.Contains(maatregelID))
                {
                    string message = "Dit issue bevat al de maatregel met id: " + maatregelID + " \n En kan niet worden toegevoegd.";

                    string title = "Reminder Risico waardes";
                    MessageBoxButtons buttons = MessageBoxButtons.OK;
                    DialogResult result = MessageBox.Show(message, title, buttons);

                    if (result == DialogResult.OK)
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
                    comunicator.AddMaatregelToIssue(CurrentID, maatregelID);
                }
            }
        }



        private void HandleAddIssueToObject(string gevaarID, bool maatregelen, bool beoordeling, bool customMaatregelen, bool customBeoordeling)
        {
            //bool addMaatregelen = checkedListBoxAddSettings.GetItemChecked(0);
            //bool addRisicoBeoordeling = checkedListBoxAddSettings.GetItemChecked(1);
            //bool issueNeedsToVirify = checkedListBoxAddSettings.GetItemChecked(2);

            //foreach (string gevaarToAddID in SelectedObjectIssueId)
            //{
            //comunicator.AddIssueToObject(CurrentID, gevaarID, maatregelen, beoordeling, issueNeedsToVirify);
            //}

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



        //private void AddGevaarToObjectWithSettings(string gevaarID)
        //{

        //    if (addBeoordeling && addMaatregelen)
        //    {
        //        //comunicator.AddFullIssueToObject(CurrentID, gevaarID);
        //    }
        //    else if (addBeoordeling && !addMaatregelen)
        //    {

        //    }
        //    else if(!addBeoordeling && addMaatregelen)
        //    {
        //        int issueID = comunicator.AddGevaarToObject(CurrentID, gevaarID);
        //        string issueIDString = issueID.ToString();
        //        comunicator.AddMaatregelToIssue(issueIDString, "");
        //    }
        //    else
        //    {
        //        comunicator.AddGevaarToObject(CurrentID, gevaarID);
        //    }
        //}



    }
}
