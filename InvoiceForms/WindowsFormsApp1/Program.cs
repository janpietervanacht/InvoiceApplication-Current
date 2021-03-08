using InvoiceForms.DependencyInfra;
using InvoiceForms.Forms;
using Microsoft.Extensions.Configuration;
using System;
using System.Windows.Forms;

namespace InvoiceForms
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            Application.Run(new FrmMainMenu()); // Doet ook de DI
        }
    }
}
