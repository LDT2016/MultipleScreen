using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using MultipleScreen.Common;

namespace MultipleScreen.Control
{
    public partial class FormLeadGuide : Form
    {
        public event Util.ClickDelegateHander ClickEvent;

        #region fields

        private static FormLeadGuide instance;
        private float X;
        private float Y;

        #endregion

        #region constructors

        public FormLeadGuide()
        {
            InitializeComponent();
        }

        #endregion

        #region properties

        public static FormLeadGuide Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new FormLeadGuide();
                }

                return instance;
            }
        }

        #endregion

        #region methods

        private void backLbl_Click(object sender, EventArgs e) { Close(); }

        private void Form1_Resize(object sender, EventArgs e)
        {
            var newx = Width / X;
            var newy = Height / Y;
            SetControl(newx, newy, this);

            //Text = "窗体尺寸：" + Width + " X " + Height;
        }

        private void FormLeadGuide_Load(object sender, EventArgs e)
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
            LeadGuidePictureShow();
            Win32.AnimateWindow(Handle, 1000, Win32.AW_VER_POSITIVE);
        }

        private void nextLbl_Click(object sender, EventArgs e)
        {
            picIndex += 1;
            if (picIndex >= picList.Count)
            {
                picIndex = 0;
            }
            instance.ShowPictures();
        }
        private void previousLbl_Click(object sender, EventArgs e)
        {
            picIndex -= 1;
            if (picIndex < 0)
            {
                picIndex = picList.Count - 1;
            }
            instance.ShowPictures();
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

        #region show pictures

        private List<Image> picList = new List<Image>();
        private Timer picTimer = new Timer();
        private int picIndex = 0;

        private void LeadGuidePictureShow()
        {
            var leadGuidePicFolder = ConfigurationManager.AppSettings["LeadGuide"];
            var leadGuidePic = $@"{Application.StartupPath}\pictures\{leadGuidePicFolder}";

            #region show pictures

            instance.picIndex = 0;
            instance.picList = new List<Image>();
            if (Directory.Exists(leadGuidePic))
            {
                //show pictures
                var dir = new DirectoryInfo(leadGuidePic);
                var files = dir.GetFiles("*.jpg").ToList();
                files.AddRange(dir.GetFiles("*.jpeg").ToList());
                files.AddRange(dir.GetFiles("*.png").ToList());
                files.AddRange(dir.GetFiles("*.bmp").ToList());
                files.AddRange(dir.GetFiles("*.gif").ToList());

                var fileList = files.OrderBy(x =>
                                         {
                                             int.TryParse(x.Name, out var intName);

                                             return intName;
                                         })
                                .ToList();

                foreach (var file in fileList)
                {
                    if (File.Exists(file.FullName))
                    {
                        var image = Image.FromStream(new MemoryStream(File.ReadAllBytes(file.FullName)));
                        picList.Add(image);
                    }
                }

                instance.ShowPictures();
            }

            #endregion
        }

        private void ShowPictures()
        {
            try
            {
                if (picList.Count == 0)
                {
                    return;
                }
                instance.picTimer.Enabled = false;

                var currentGirl = picList[picIndex];
                instance.PicPanel.BackgroundImage = currentGirl;
                instance.picTimer.Enabled = true;
                ClickEvent?.Invoke(new Notify
                {
                    Command = 2,
                    ImageUrl = currentGirl
                });

            }
            catch
            {
            }
        }

        #endregion

    }
}
