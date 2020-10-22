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
            var displayModeSetting = ConfigurationManager.AppSettings["DisplayMode"];
            int.TryParse(displayModeSetting, out var displayMode);

            var screens = Screen.AllScreens;
            var f0 = FormDisplay.Instance;
            var f1 = FormMain.Instance;
            var formlist = new List<Form>
                           {
                               f0,
                               f1
                           };

            if (displayMode > 0)
            {
                formlist.Reverse();
            }

            if (screens.Length > 1 && formlist.Count <= screens.Length)
            {
                for (var i = 0; i < formlist.Count; i++)
                {
                    var f = formlist[i];
                    f.FormBorderStyle = FormBorderStyle.None;
                    f.ClientSize = new Size(1920, 1080);
                    f.WindowState = FormWindowState.Normal;
                    f.StartPosition = FormStartPosition.Manual;

                    f.Location = new Point(screens[i]
                                           .Bounds.Left,
                                           screens[i]
                                               .Bounds.Top);
                }

                f0.ResizeSetupRelease();
                f1.ResizeSetupRelease();
            }

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
