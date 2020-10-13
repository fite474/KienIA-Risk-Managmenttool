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
using RiskManagmentTool.InterfaceLayer.ContentWindows;

namespace RiskManagmentTool.InterfaceLayer
{
    public partial class MainWindow : Form
    {
        private int menuPanelWidth;
        private Form activeForm;
        private const int MAX_MENU_SIZE = 150;
        private const int MIN_MENU_SIZE = 50;

        public MainWindow()
        {
            
            InitializeComponent();
            panelMenu.Width = MAX_MENU_SIZE;
            menuPanelWidth = panelMenu.Width;
        }


        private void OpenContentWindow(Form contentForm, object btnSender)
        {
            if (activeForm != null)
            {
                activeForm.Close();
                //activeForm.SendToBack();
            }
            activeForm = contentForm;
            contentForm.TopLevel = false;
            contentForm.FormBorderStyle = FormBorderStyle.None;
            contentForm.Dock = DockStyle.Fill;
            this.panelContent.Controls.Add(contentForm);
            this.panelContent.Tag = contentForm;
            contentForm.BringToFront();
            contentForm.Show();
            //lblTitle.Text = contentForm.Text;


        }
        

        private void buttonProjecten_Click(object sender, EventArgs e)
        {

            OpenContentWindow(new ContentProjecten(), sender);
        }

        private void buttonObjecten_Click(object sender, EventArgs e)
        {
            OpenContentWindow(new ContentObjecten(), sender);
        }

        private void buttonTemplates_Click(object sender, EventArgs e)
        {
            OpenContentWindow(new ContentTemplates(), sender);
        }

        private void buttonRisicos_Click(object sender, EventArgs e)
        {
            OpenContentWindow(new ContentRisicos(), sender);
        }

        private void buttonMaatregelen_Click(object sender, EventArgs e)
        {
            OpenContentWindow(new ContentMaatregelen(), sender);
        }


        private void buttonMenu_Click(object sender, EventArgs e)
        {
            Console.WriteLine(panelMenu.Width);

            if (menuPanelWidth == MAX_MENU_SIZE) {
                menuPanelWidth = MIN_MENU_SIZE;
            }
            else if (menuPanelWidth == MIN_MENU_SIZE) {
                menuPanelWidth = MAX_MENU_SIZE;
            }
            else{
                Console.WriteLine("Error Menu Width");
            }

            panelMenu.Width = menuPanelWidth;

        }
    }
}
