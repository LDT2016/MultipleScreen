using System;
using System.Collections.Generic;
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
            var screens = Screen.AllScreens;
            var f0 = FormDisplay.Instance;
            f0.PicPanel.Dock = DockStyle.Fill;
            f0.Browser.Dock = DockStyle.Fill;
            f0.Player.Visible = false;
            f0.PicPanel.Visible = false;
            f0.Browser.Visible = false;
            var f1 = FormMain.Instance;
            var formlist = new List<Form>
                           {
                               f0,
                               f1
                           };

            if (screens.Length > 1 && formlist.Count == screens.Length)
            {

                for (var i = 0; i < formlist.Count; i++)
                {
                    var f = formlist[i];
                    f.StartPosition = FormStartPosition.CenterScreen;
                    f.FormBorderStyle = FormBorderStyle.None;
                    f.ClientSize = new Size(1920, 1080);
                    //f.WindowState = FormWindowState.Maximized;
                    
                    f.Location = new Point(screens[i]
                                           .Bounds.Left,
                                           screens[i]
                                               .Bounds.Top);
                }
                f0.Player.Size = new Size(1920, 1080);
                f0.Player.Dock = DockStyle.Fill;
                f0.Player.Location = new Point(0, 0);
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
