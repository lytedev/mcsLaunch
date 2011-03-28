using System;
using System.Windows.Forms;

namespace mcsLaunch
{
    static class Program
    {
        public static bool MarkedForUpdate = false;
        public static MainForm MainForm;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MainForm = new MainForm(args);
            Application.Run(MainForm);
            if (MarkedForUpdate)
            {
                Updater.UpdateApplication(true);
            }
        }
    }
}
