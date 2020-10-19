using System;
using System.Drawing;
using System.Windows.Forms;
using MultipleScreen.Common;
using MultipleScreen.Display;

namespace MultipleScreen.Control
{
    public partial class FormMain : Form
    {
        #region delegates

        #endregion

        #region fields

        private static FormMain instance;

        #endregion

        #region constructors

        public FormMain()
        {
            InitializeComponent();
        }

        #endregion

        #region events

        public event Util.ClickDelegateHander ClickEvent;

        #endregion

        #region properties

        public static FormMain Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new FormMain();
                }

                return instance;
            }
        }

        /// <summary>
        /// 图片做背景 闪屏问题
        /// </summary>
        protected override CreateParams CreateParams
        {
            get
            {
                var cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;

                return cp;
            }
        }

        #endregion

        #region methods
        private float X;
        private float Y;

        private void Form_Resize(object sender, EventArgs e)
        {
            var newx = Width / X;
            var newy = Height / Y;
            SetControl(newx, newy, this);
            //Text = "窗体尺寸：" + Width + " X " + Height;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            //label1的字体样式设置
            //this.label1.ForeColor = System.Drawing.Color.Black;
            //this.label1.Font = new System.Drawing.Font("黑体", 23F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            //base.OnResize(e);
            //int x = (int)(0.5 * (this.Width - label1.Width));
            //int y = label1.Location.Y;
            //label1.Location = new System.Drawing.Point(x, y);

            //控件根据窗体的大小变化而变化，等比例放大缩小
            Resize += Form_Resize;
            X = Width;
            Y = Height;
            SetTag(this);
            Form_Resize(new object(), new EventArgs());
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

        #endregion

        private void closeLbl_Click(object sender, EventArgs e)
        {
            FormDisplay.Instance.Close();
            Instance.Close();
            Application.Exit();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FormDisplay.Instance.Close();
            Instance.Close();
            Application.Exit();
        }

        private void command_Click(object sender, EventArgs e)
        {
            int.TryParse(((Label)sender).AccessibleName, out var cmd);
            //领导批示
            if (cmd == 2)
            {
#if !DEBUG
                    FormLeadGuide.Instance.StartPosition = FormStartPosition.CenterScreen;
                    FormLeadGuide.Instance.FormBorderStyle = FormBorderStyle.None;
                    FormLeadGuide.Instance.ClientSize = new Size(1920, 1080);
                    FormLeadGuide.Instance.WindowState = FormWindowState.Maximized;
#endif

                FormLeadGuide.Instance.ShowDialog();

            }
            //税收宣传
            else if (cmd == 4)
            {
#if !DEBUG
                    FormTaxPublicity.Instance.StartPosition = FormStartPosition.CenterScreen;
                    FormTaxPublicity.Instance.FormBorderStyle = FormBorderStyle.None;
                    FormTaxPublicity.Instance.ClientSize = new Size(1920, 1080);
                    FormTaxPublicity.Instance.WindowState = FormWindowState.Maximized;
#endif

                FormTaxPublicity.Instance.ShowDialog();

            }
            else
            {
                ClickEvent?.Invoke(new Notify
                                   {
                                       Command = cmd
                });

            }
        }
    }
}
