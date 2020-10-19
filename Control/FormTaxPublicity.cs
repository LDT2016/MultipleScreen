using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MultipleScreen.Common;

namespace MultipleScreen.Control
{
    public partial class FormTaxPublicity : Form
    {
        public event Util.ClickDelegateHander ClickEvent;
        private float X;
        private float Y;
        private static FormTaxPublicity instance;
        public static FormTaxPublicity Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new FormTaxPublicity();
                }

                return instance;
            }
        }

        public FormTaxPublicity()
        {
            InitializeComponent();
        }


        private void Form1_Resize(object sender, EventArgs e)
        {
            var newx = Width / X;
            var newy = Height / Y;
            SetControl(newx, newy, this);

            //Text = "窗体尺寸：" + Width + " X " + Height;
        }

        private void FormTaxPublicity_Load(object sender, EventArgs e)
        {
            //label1的字体样式设置
            //this.label1.ForeColor = System.Drawing.Color.Black;
            //this.label1.Font = new System.Drawing.Font("黑体", 23F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            //base.OnResize(e);
            //int x = (int)(0.5 * (this.Width - label1.Width));
            //int y = label1.Location.Y;
            //label1.Location = new System.Drawing.Point(x, y);

            //控件根据窗体的大小变化而变化，等比例放大缩小
            Resize += Form1_Resize;
            X = Width;
            Y = Height;
            SetTag(this);
            Form1_Resize(new object(), new EventArgs());
            Win32.AnimateWindow(Handle, 1000, Win32.AW_VER_POSITIVE);
        }

        private void SetControl(float newx, float newy, System.Windows.Forms.Control cons)
        {
            foreach (System.Windows.Forms.Control con in cons.Controls)
            {
                var mytag = con.Tag.ToString()
                               .Split(':');
                var a = Convert.ToSingle(mytag[0]) * newx;
                con.Width = (int)a;
                a = Convert.ToSingle(mytag[1]) * newy;
                con.Height = (int)a;
                a = Convert.ToSingle(mytag[2]) * newx;
                con.Left = (int)a;
                a = Convert.ToSingle(mytag[3]) * newy;
                con.Top = (int)a;
                var currentsize = Convert.ToSingle(mytag[4]) * Math.Min(newx, newy);
                con.Font = new Font(con.Font.Name, currentsize, con.Font.Style, con.Font.Unit);

                if (con.Controls.Count > 0)
                {
                    SetControl(newx, newy, con);
                }
            }
        }

        private void SetTag(System.Windows.Forms.Control cons)
        {
            foreach (System.Windows.Forms.Control con in cons.Controls)
            {
                con.Tag = con.Width + ":" + con.Height + ":" + con.Left + ":" + con.Top + ":" + con.Font.Size;

                if (con.Controls.Count > 0)
                {
                    SetTag(con);
                }
            }
        }

        private void taxPublicly_Click(object sender, EventArgs e)
        {
            int.TryParse(((Label)sender).AccessibleName, out var cmd);

            var taxPublicityFolder = ConfigurationManager.AppSettings["TaxPublicityFolder"];
            var taxPublicityVideoName = ConfigurationManager.AppSettings["TaxPublicityVideo_"+ cmd];
            var taxPublicityVideoFullName = $@"{Application.StartupPath}\videos\{taxPublicityFolder}\{taxPublicityVideoName}";

            if (File.Exists(taxPublicityVideoFullName))
            {
                ClickEvent?.Invoke(new Notify
                                   {
                                       Command = 4,
                                       VideoUrl = taxPublicityVideoFullName
                                   });
            }
        }

        private void backLbl_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
