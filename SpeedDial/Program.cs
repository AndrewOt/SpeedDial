using System;
using System.Windows.Forms;

namespace SpeedDial
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            using (ProcessIcons pi = new ProcessIcons())
            {
                pi.Display();
                Application.Run();
            }

        }
    }
}
