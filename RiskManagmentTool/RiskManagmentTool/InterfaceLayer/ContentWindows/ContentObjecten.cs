using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RiskManagmentTool.InterfaceLayer.EditWindows;

namespace RiskManagmentTool.InterfaceLayer.ContentWindows
{
    public partial class ContentObjecten : Form
    {
        private Form editObjectenForm;
        private MainWindow mainWindowForm;
        public ContentObjecten(MainWindow mainWindow)
        {
            mainWindowForm = mainWindow;
            InitializeComponent();
        }

        private void buttonAddNew_Click(object sender, EventArgs e)
        {
            editObjectenForm = new EditObjecten();
            mainWindowForm.OpenContentWindow(editObjectenForm);
            //Form editObject = new EditObjecten();
            //editObject.Show();
        }
    }
}
