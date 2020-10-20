using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using MultipleScreen.Common;

namespace MultipleScreen.Control
{
    public partial class FormLeadGuide : Form
    {
        #region fields

        private static FormLeadGuide instance;
        private int picIndex;
        private List<Image> picList = new List<Image>();
        private readonly Timer picTimer = new Timer();
        private float X;
        private float Y;

        #endregion

        #region constructors

        public FormLeadGuide()
        {
            InitializeComponent();
        }

        #endregion

        #region events

        public event Util.ClickDelegateHander ClickEvent;

        #endregion

        #region properties

        public static FormLeadGuide Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new FormLeadGuide();
                    instance.ResizeSetup();
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

        public void ResizeSetup()
        {
            previousLbl.Location = new Point(585, 199);
            previousLbl.Size = new Size(183, 50);
            nextLbl.Location = new Point(585, 306);
            nextLbl.Size = new Size(183, 50);
            backLbl.Location = new Point(696, 406);
            backLbl.Size = new Size(92, 38);
        }

        private void backLbl_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FormLeadGuide_Load(object sender, EventArgs e)
        {
            LeadGuidePictureShow();
            Win32.AnimateWindow(Handle, 1000, Win32.AW_VER_POSITIVE);
        }

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

                var files = dir.GetFiles("*.jpg")
                               .ToList();

                files.AddRange(dir.GetFiles("*.jpeg")
                                  .ToList());

                files.AddRange(dir.GetFiles("*.png")
                                  .ToList());

                files.AddRange(dir.GetFiles("*.bmp")
                                  .ToList());

                files.AddRange(dir.GetFiles("*.gif")
                                  .ToList());

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
            catch { }
        }

        #endregion
    }
}
