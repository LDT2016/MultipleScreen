using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MultipleScreen
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


            if (screens.Length > 1)
            {
                foreach (var f in formlist)
                {
                    f.StartPosition = FormStartPosition.CenterScreen;
                    f.WindowState = FormWindowState.Maximized;
                    f.Location = new Point(screens[1].Bounds.Left, screens[1].Bounds.Top);
                }
            }

            foreach (var f in formlist)
            {
                f.Show();
            }
        }

    }
}
