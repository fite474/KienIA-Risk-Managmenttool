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
        //private const int MIN_MENU_SIZE = 50;



        private Color inActiveButtonColor = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");
        private Color activeButtonColor = System.Drawing.ColorTranslator.FromHtml("#DD9719");

        public MainWindow()
        {
            InitializeComponent();
            panelMenu.Width = MAX_MENU_SIZE;
            menuPanelWidth = panelMenu.Width;
            this.SetStyle();
            OpenContentWindow(new ContentProjecten());

        }


        private void SetStyle()
        {
            this.labelAppTitle.Parent = pictureBox1;
            labelAppTitle.BackColor = Color.Transparent;
        }




        public void OpenContentWindow(Form contentForm)
        {
            if (activeForm != null)
            {
                activeForm.Close();
                //activeForm.Hide();
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

        private void HighlightActiveButton(Button currentButton)
        {
            //reset all buttons
            buttonProjecten.BackColor = inActiveButtonColor;
            buttonObjecten.BackColor = inActiveButtonColor;
            buttonRisicos.BackColor = inActiveButtonColor;
            buttonMaatregelen.BackColor = inActiveButtonColor;
            buttonRedirect.BackColor = inActiveButtonColor;
            buttonKeuzes.BackColor = inActiveButtonColor;
            buttonHelp.BackColor = inActiveButtonColor;



            currentButton.BackColor = activeButtonColor;
        }

        

        private void buttonProjecten_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            OpenContentWindow(new ContentProjecten());
            HighlightActiveButton(this.buttonProjecten);
        }

        private void buttonObjecten_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            OpenContentWindow(new ContentObjecten());
            HighlightActiveButton(this.buttonObjecten);

        }

        private void buttonTemplates_Click(object sender, EventArgs e)
        {// OLD
            //Cursor.Current = Cursors.WaitCursor;
            //OpenContentWindow(new ContentTemplates());
        }

        private void buttonRisicos_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            OpenContentWindow(new ContentRisicos());
            HighlightActiveButton(this.buttonRisicos);
        }

        private void buttonMaatregelen_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            OpenContentWindow(new ContentMaatregelen());
            HighlightActiveButton(this.buttonMaatregelen);

        }

        private void buttonRedirect_Click(object sender, EventArgs e)
        {
            OpenContentWindow(new ContentRedirect());
            HighlightActiveButton(this.buttonRedirect);

        }

        private void buttonKeuzes_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            OpenContentWindow(new ContentKeuzes());
            HighlightActiveButton(this.buttonKeuzes);
        }

        private void buttonHelp_Click(object sender, EventArgs e)
        {
            OpenContentWindow(new ContentHelp());
            HighlightActiveButton(this.buttonHelp);
        }



    }
}
