using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RiskManagmentTool.InterfaceLayer.WeergeefWindows;

namespace RiskManagmentTool.LogicLayer
{
    class DeleteControler
    {
        private Datacomunication comunicator;
        public DeleteControler()
        {
            comunicator = new Datacomunication();

        }

        public void DeleteGevaarFromDatabase(string gevaarID)
        {
            DataTable gevarenData = comunicator.GetGevarenUsage(gevaarID);
            int indexHelper = 0;
            foreach (DataRow row in gevarenData.Rows)
            {
                string dataIssueID = gevarenData.Rows[indexHelper].Field<int?>(0).ToString();
                string dataGevaarID = gevarenData.Rows[indexHelper].Field<int?>(1).ToString();
                Console.WriteLine("issue: "+dataIssueID);
                Console.WriteLine("gevaar: "+dataGevaarID);
                indexHelper++;
            }

            if (indexHelper == 0)
            {
                string message = "Weet u zeker dat u dit gevaar wilt verwijderen?";
                string title = "Reminder Risico waardes";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, title, buttons);

                if (result == DialogResult.Yes)
                {
                    comunicator.DeleteGevaar(gevaarID);
                }
                else
                {

                }
                Console.WriteLine("veilig om te verwijderen ");
            }
            else
            {
                string message = "Dit gevaar is in gebruik bij een issue";
                string title = "Reminder Risico waardes";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result = MessageBox.Show(message, title, buttons);

                if (result == DialogResult.Yes)
                {
                    //this.Close();
                }
                else
                {

                }
            }

            //string c = gevarenData.Rows[0].Field<int?>(3).ToString();
            //string d = gevarenData.Rows[0].Field<int?>(4).ToString();

        }

        public void DeleteMaatregelFromDatabase(string maatregelID)
        {
            DataTable maatregelData = comunicator.GetMaatregelenUsage(maatregelID);
            int indexHelper = 0;
            foreach (DataRow row in maatregelData.Rows)
            {
                string dataIssueID = maatregelData.Rows[indexHelper].Field<int?>(0).ToString();
                string dataMaatregelID = maatregelData.Rows[indexHelper].Field<int?>(1).ToString();
                Console.WriteLine("issue: " + dataIssueID);
                Console.WriteLine("maatregel: " + dataMaatregelID);
                indexHelper++;
            }

            if (indexHelper == 0)
            {
                string message = "Weet u zeker dat u deze maatregel wilt verwijderen?";
                string title = "Reminder Risico waardes";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, title, buttons);

                if (result == DialogResult.Yes)
                {
                    comunicator.DeleteGevaar(maatregelID);
                }
                else
                {

                }
                Console.WriteLine("veilig om te verwijderen ");
            }
            else
            {
                string message = "Dit gevaar is in gebruik bij een issue";
                string title = "Reminder Risico waardes";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result = MessageBox.Show(message, title, buttons);

                if (result == DialogResult.Yes)
                {
                    //this.Close();
                }
                else
                {

                }
            }

        }

        public bool DeleteKeuzeItemFromDatabase(MenuTableName menuTableName, string optionToDelete)
        {
            bool deleteConfirm = false;
            switch (menuTableName)
            {
                case MenuTableName.ObjectTypes:
                    deleteConfirm = CheckObjectTypeUsage(menuTableName, optionToDelete);
                    break;
                case MenuTableName.Gevolgen:
                    deleteConfirm = CheckGevarenCollomenUsage(menuTableName, optionToDelete);
                    break;
                case MenuTableName.Gevarenzones:
                    deleteConfirm = CheckGevarenCollomenUsage(menuTableName, optionToDelete);
                    break;
                case MenuTableName.GevaarTypes:
                    deleteConfirm = CheckGevarenCollomenUsage(menuTableName, optionToDelete);
                    break;
                case MenuTableName.Gebruiksfases:
                    deleteConfirm = CheckGevarenCollomenUsage(menuTableName, optionToDelete);
                    break;
                case MenuTableName.Gebruikers:
                    deleteConfirm = CheckGevarenCollomenUsage(menuTableName, optionToDelete);
                    break;
                case MenuTableName.Disciplines:
                    deleteConfirm = CheckGevarenCollomenUsage(menuTableName, optionToDelete);
                    break;
                case MenuTableName.Bedienvormen:
                    deleteConfirm = CheckGevarenCollomenUsage(menuTableName, optionToDelete);
                    break;
                case MenuTableName.Taken:
                    deleteConfirm = CheckGevarenCollomenUsage(menuTableName, optionToDelete);
                    break;
                case MenuTableName.Normen:
                    //databaseCommunication.AddToNormenMenu(inputText);
                    break;
                case MenuTableName.Categories:
                    //databaseCommunication.AddToCategoriesMenu(inputText);
                    break;
                case MenuTableName.TemplateTypes:
                    //databaseCommunication.AddToTemplateTypes(inputText);
                    break;
                case MenuTableName.TemplateToepassing:
                    //databaseCommunication.AddToTemplateToepassingen(inputText);
                    break;
                default:
                    break;
            }
            return deleteConfirm;
        }

        #region check keuze item usage

        private bool CheckObjectTypeUsage(MenuTableName menuTableName, string optionToAdd)
        {
            bool deleteConfirm = false;
            DataTable objectTypeData = comunicator.CheckUsageFromMenu(menuTableName, optionToAdd);
            int indexHelper = 0;
            foreach (DataRow row in objectTypeData.Rows)
            {
                string objectnaam = objectTypeData.Rows[indexHelper].Field<string>(0).ToString();
                string item = objectTypeData.Rows[indexHelper].Field<string>(1).ToString();
                Console.WriteLine("Objectnaam:  " + objectnaam);
                Console.WriteLine("Item: " + item);
                indexHelper++;
            }

            if (indexHelper == 0)
            {
                string message = "Weet u zeker dat u dit item wilt verwijderen?";
                string title = "Reminder Risico waardes";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, title, buttons);

                if (result == DialogResult.Yes)
                {
                    comunicator.DeleteFromMenu(menuTableName, optionToAdd);
                    deleteConfirm = true;
                }
                else
                {

                }
                Console.WriteLine("veilig om te verwijderen ");
            }
            else
            {
                string message = "Dit item is in gebruik bij een object";
                string title = "Reminder Risico waardes";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result = MessageBox.Show(message, title, buttons);

            }
            return deleteConfirm;
        }
        //gevolgen, gevarenzone, type, fase, gebruiker, discipline, gebruikvorm, taak,  MAATREGELEN norm, category, TEMPLATES
        private bool CheckGevarenCollomenUsage(MenuTableName menuTableName, string optionToAdd)
        {
            bool deleteConfirm = false;
            DataTable gevolgenData = comunicator.CheckUsageFromMenu(menuTableName, optionToAdd);
            int indexHelper = 0;

            List<string> ItemUsageIDs = new List<string>();

            foreach (DataRow row in gevolgenData.Rows)
            {
                ItemUsageIDs.Add(gevolgenData.Rows[indexHelper].Field<int?>(0).ToString());
                //string objectnaam = gevolgenData.Rows[indexHelper].Field<string>(0).ToString();
                //string item = gevolgenData.Rows[indexHelper].Field<string>(1).ToString();
                //Console.WriteLine("Objectnaam:  " + objectnaam);
                //Console.WriteLine("Item: " + item);
                indexHelper++;
            }

            if (indexHelper == 0)
            {
                string message = "Weet u zeker dat u dit item wilt verwijderen?";
                string title = "Reminder Risico waardes";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, title, buttons);

                if (result == DialogResult.Yes)
                {
                    comunicator.DeleteFromMenu(menuTableName, optionToAdd);
                    deleteConfirm = true;
                }
                else
                {

                }
                Console.WriteLine("veilig om te verwijderen ");
            }
            else
            {
                ShowMenuItemUsage showMenuItemUsage = new ShowMenuItemUsage(ItemUsageIDs, menuTableName, optionToAdd);
                if (showMenuItemUsage.ShowDialog() == DialogResult.OK)
                {
                    deleteConfirm = true;

                }


            }
            return deleteConfirm;
        }

       


        #endregion check keuze item usage

    }
}
