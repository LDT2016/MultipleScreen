using System;
using System.Threading;
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
            System.Threading.Mutex mutex = new System.Threading.Mutex(true, Application.ProductName, out var flag);

            if (flag)
            {

                // 全局异常注册
                var appEvents = new ApplicationEventHandlerClass();
                Application.ThreadException += appEvents.OnThreadException;
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.DoEvents();
                DependentFiles.LoadResourceDll(); // 载入资源dll文件
                Application.Run(new LocationBase());

                mutex.ReleaseMutex();
            }
            else
            {
                Application.Exit();
            }
        }

        #endregion


        // 全局异常处理
        public class ApplicationEventHandlerClass
        {
            #region methods

            public void OnThreadException(object sender, ThreadExceptionEventArgs e)
            {

            }

            #endregion
        }
    }
}
