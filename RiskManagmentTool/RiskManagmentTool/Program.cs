using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using RiskManagmentTool.InterfaceLayer;

namespace RiskManagmentTool
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 


        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                Application.Run(new MainWindow());
            }
            catch (Exception err)
            {
                MessageBox.Show("Fatal error, contact support if the crash presists: \n" + err.ToString());
                //throw;
            }


        }
    }
}
