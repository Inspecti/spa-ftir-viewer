using System;
using System.Windows.Forms;

namespace spa_ftir_viewer
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (args.Length > 0 && args[0] != null) {
               Application.Run(new MainWindow(args[0]));
            }
            else
            {
                Application.Run(new MainWindow(null));
            }
        }
    }
}
