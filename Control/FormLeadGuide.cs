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
    public partial class FormLeadGuide : FormBase
    {
        #region fields

        private static FormLeadGuide instance;
        private int picIndex;
        private List<FileInfo> picInfoList = new List<FileInfo>();

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

                    if (Screen.AllScreens.Length > 1)
                    {
                        instance.ResizeSetupRelease();
                    }
                    else
                    {
                        instance.ResizeSetup();
                    }

                    instance.LeadGuidePictureShow();
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

        public override void CloseForm()
        {
            FormMain.Instance.CloseDialogTimerStop();
            instance.Close();
        }

        public void ResizeSetup()
        {
            instance.ClientSize = new Size(800, 450);

            instance.backLbl.Location = new Point(696, 406);
            instance.backLbl.Size = new Size(92, 38);
            instance.previousLbl.Location = new Point(585, 199);
            instance.previousLbl.Size = new Size(183, 50);
            instance.nextLbl.Location = new Point(585, 306);
            instance.nextLbl.Size = new Size(183, 50);
            instance.PicPanel.Location = new Point(22, 69);
            instance.PicPanel.Size = new Size(504, 318);
        }

        public void ResizeSetupRelease()
        {
            instance.Location = FormMain.Instance.Location;
            instance.ClientSize = new Size(1920, 1080);
            instance.FormBorderStyle = FormBorderStyle.None;
            instance.StartPosition = FormStartPosition.Manual;
            instance.backLbl.Location = new Point(1670, 990);
            instance.backLbl.Size = new Size(238, 99);
            instance.previousLbl.Location = new Point(1402, 472);
            instance.previousLbl.Size = new Size(430, 113);
            instance.nextLbl.Location = new Point(1402, 727);
            instance.nextLbl.Size = new Size(430, 116);
            instance.PicPanel.Location = new Point(57, 167);
            instance.PicPanel.Size = new Size(1201, 745);
        }

        private void backLbl_Click(object sender, EventArgs e)
        {
            CloseForm();
        }

        private void FormLeadGuide_Click(object sender, EventArgs e)
        {
            FormMain.Instance.CloseDialogTimerReset();
        }

        private void FormLeadGuide_Load(object sender, EventArgs e)
        {
            //Win32.AnimateWindow(Handle, 1000, Win32.AW_VER_POSITIVE);
            instance.picIndex = 0;
            instance.ShowPictures();
        }

        private void LeadGuidePictureShow()
        {
            var leadGuidePicFolder = ConfigurationManager.AppSettings["LeadGuide"];
            var leadGuidePic = $@"{Application.StartupPath}\pictures\{leadGuidePicFolder}";

            #region show pictures

            instance.picIndex = 0;

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
                picInfoList = fileList;

                //foreach (var file in fileList)
                //{
                //    if (File.Exists(file.FullName))
                //    {
                //        var image = Image.FromStream(new MemoryStream(File.ReadAllBytes(file.FullName)));
                //        picList.Add(image);
                //    }
                //}

                instance.ShowPictures();
            }

            #endregion
        }

        private void nextLbl_Click(object sender, EventArgs e)
        {
            picIndex += 1;

            if (picIndex >= picInfoList.Count)
            {
                picIndex = 0;
            }

            instance.ShowPictures();
        }

        private void PicPanel_Click(object sender, EventArgs e)
        {
            FormMain.Instance.CloseDialogTimerReset();
        }

        private void previousLbl_Click(object sender, EventArgs e)
        {
            picIndex -= 1;

            if (picIndex < 0)
            {
                picIndex = picInfoList.Count - 1;
            }

            instance.ShowPictures();
        }

        private void ShowPictures()
        {
            try
            {
                if (picInfoList.Count == 0)
                {
                    return;
                }

                var picInfo = picInfoList[picIndex];

                if (File.Exists(picInfo.FullName))
                {
                    var currentGirl = Image.FromStream(new MemoryStream(File.ReadAllBytes(picInfo.FullName)));
                    instance.PicPanel.BackgroundImage = currentGirl;

                    ClickEvent?.Invoke(new Notify
                                       {
                                           Command = 2,
                                           ImageUrl = currentGirl
                                       });
                }

                FormMain.Instance.CloseDialogTimerReset();
            }
            catch { }
        }

        #endregion
    }
}
