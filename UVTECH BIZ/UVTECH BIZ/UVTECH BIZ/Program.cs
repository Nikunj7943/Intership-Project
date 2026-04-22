using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UVTECH_BIZ
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        //[STAThread]        //[STAThread]

        public static clsGlobal gblVer = new clsGlobal();
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmlogin());
        }
    }
}
