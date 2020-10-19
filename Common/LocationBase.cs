using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MultipleScreen.Common
{
    public class LocationBase : ApplicationContext
    {

        private void OnFormClose(object sendr, EventArgs e)
        {

            if (Application.OpenForms.Count == 0)
            {
                ExitThread();
            }
        }

        public LocationBase()
        {
            var screens = Screen.AllScreens;
            var f0 = FormDisplay.Instance;
            var f1 = FormControl.Instance;

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
                    //f.WindowState = FormWindowState.Maximized;

                    f.Location = new Point(screens[i]
                                           .Bounds.Left,
                                           screens[i]
                                               .Bounds.Top);
                }
            }

            foreach (var f in formlist)
            {
                f.Show();
            }
        }

    }
}
