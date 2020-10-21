using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Windows.Forms;
using MultipleScreen.Control;
using MultipleScreen.Display;

namespace MultipleScreen.Common
{
    public class LocationBase : ApplicationContext
    {
        #region constructors

        public LocationBase()
        {
            var dispalyModeSetting = ConfigurationManager.AppSettings["DispalyMode"];
            int.TryParse(dispalyModeSetting, out var dispalyMode);

            var screens = Screen.AllScreens;
            var f0 = FormDisplay.Instance;
            var f1 = FormMain.Instance;
            var formlist = new List<Form>
                           {
                               f0,
                               f1
                           };

            if (dispalyMode > 0)
            {
                formlist.Reverse();
            }
            if (screens.Length > 1 && formlist.Count == screens.Length)
            {

                for (var i = 0; i < formlist.Count; i++)
                {
                    var f = formlist[i];
                    f.StartPosition = FormStartPosition.CenterScreen;
                    f.FormBorderStyle = FormBorderStyle.None;
                    f.ClientSize = new Size(1920, 1080);
                    f.WindowState = FormWindowState.Maximized;
                    
                    f.Location = new Point(screens[i]
                                           .Bounds.Left,
                                           screens[i]
                                               .Bounds.Top);
                }
                f0.ResizeSetupRelease();
                f1.ResizeSetupRelease();
                FormLeadGuide.Instance.StartPosition = FormStartPosition.CenterScreen;
                FormLeadGuide.Instance.FormBorderStyle = FormBorderStyle.None;
                FormLeadGuide.Instance.ClientSize = new Size(1920, 1080);
                FormLeadGuide.Instance.WindowState = FormWindowState.Maximized;
                FormLeadGuide.Instance.ResizeSetupRelease();
                FormTaxPublicity.Instance.StartPosition = FormStartPosition.CenterScreen;
                FormTaxPublicity.Instance.FormBorderStyle = FormBorderStyle.None;
                FormTaxPublicity.Instance.ClientSize = new Size(1920, 1080);
                FormTaxPublicity.Instance.WindowState = FormWindowState.Maximized;
                FormTaxPublicity.Instance.ResizeSetupRelease();
                FormBigEvent.Instance.StartPosition = FormStartPosition.CenterScreen;
                FormBigEvent.Instance.FormBorderStyle = FormBorderStyle.None;
                FormBigEvent.Instance.ClientSize = new Size(1920, 1080);
                FormBigEvent.Instance.WindowState = FormWindowState.Maximized;
                FormBigEvent.Instance.ResizeSetupRelease();
            }

#if DEBUG


                //for (var i = 0; i < formlist.Count; i++)
                //{
                //    var f = formlist[i];
                //    f.StartPosition = FormStartPosition.CenterScreen;
                //    f.FormBorderStyle = FormBorderStyle.None;
                //    f.ClientSize = new Size(1920, 1080);
                //    f.WindowState = FormWindowState.Maximized;
                //}

                //f0.ResizeSetupRelease();
                //f1.ResizeSetupRelease();
                //FormLeadGuide.Instance.StartPosition = FormStartPosition.CenterScreen;
                //FormLeadGuide.Instance.FormBorderStyle = FormBorderStyle.None;
                //FormLeadGuide.Instance.ClientSize = new Size(1920, 1080);
                //FormLeadGuide.Instance.WindowState = FormWindowState.Maximized;
                //FormLeadGuide.Instance.ResizeSetupRelease();
                //FormTaxPublicity.Instance.StartPosition = FormStartPosition.CenterScreen;
                //FormTaxPublicity.Instance.FormBorderStyle = FormBorderStyle.None;
                //FormTaxPublicity.Instance.ClientSize = new Size(1920, 1080);
                //FormTaxPublicity.Instance.WindowState = FormWindowState.Maximized;
                //FormTaxPublicity.Instance.ResizeSetupRelease();
                //FormBigEvent.Instance.StartPosition = FormStartPosition.CenterScreen;
                //FormBigEvent.Instance.FormBorderStyle = FormBorderStyle.None;
                //FormBigEvent.Instance.ClientSize = new Size(1920, 1080);
                //FormBigEvent.Instance.WindowState = FormWindowState.Maximized;
                //FormBigEvent.Instance.ResizeSetupRelease();

#endif

            foreach (var f in formlist)
            {
                f.Show();
            }
        }

        #endregion

        #region methods

        private void OnFormClose(object sendr, EventArgs e)
        {
            if (Application.OpenForms.Count == 0)
            {
                ExitThread();
            }
        }

        #endregion
    }
}
