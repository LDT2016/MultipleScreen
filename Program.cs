using System;
using System.Windows.Forms;
using MultipleScreen.Common;

namespace MultipleScreen
{
    static class Program
    {
        #region methods

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            DependentFiles.LoadResourceDll(); // 载入资源dll文件
            Application.Run(new LocationBase());
        }

        #endregion
    }
}
