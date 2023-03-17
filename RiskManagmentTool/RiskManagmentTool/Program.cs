using System;
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


            //for release
            //try
            //{
            //    Application.Run(new MainWindow());
            //}
            //catch (Exception err)
            //{
            //    MessageBox.Show("Fatal error! Your last action could NOT be completed :( , contact support if the crash presists: \n\n" +
            //        "The following error occured:"+ err.ToString() +
            //        "\n\n Error code: main program has crashed", Fatal error in main system);
            //    //throw;
            //}




            //for debug coding
            Application.Run(new MainWindow());
        }
    }
}
