using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using MultipleScreen.Common;

namespace MultipleScreen
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
            DependentFiles.LoadResourceDll();       // 载入资源dll文件
            Application.Run(new LocationBase());
        }
    }
}
