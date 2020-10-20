using System;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using AxWMPLib;
using MultipleScreen.Common;

namespace MultipleScreen.Control
{
    public partial class FormTaxPublicity : Form
    {
        #region fields

        private static FormTaxPublicity instance;

        #endregion

        #region constructors

        public FormTaxPublicity()
        {
            InitializeComponent();
        }

        #endregion

        #region events

        public event Util.ClickDelegateHander ClickEvent;

        #endregion

        #region properties

        public static FormTaxPublicity Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new FormTaxPublicity();
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
            var LabelX = 69;
            var LabelWidth = 163;
            var LabelXGap = 78;
            var LabelY = 79;
            var LabelHeight = 144;
            var LabelYGap = 25;

            //taxPublicly0Lbl.Location = new Point(184, 102);
            //taxPublicly0Lbl.Size = new Size(108, 56);
            //taxPublicly1Lbl.Location = new Point(350, 102);
            //taxPublicly1Lbl.Size = new Size(108, 56);
            //taxPublicly2Lbl.Location = new Point(514, 102);
            //taxPublicly2Lbl.Size = new Size(108, 56);

            //taxPublicly3Lbl.Location = new Point(112, 227);
            //taxPublicly3Lbl.Size = new Size(63, 109);
            //taxPublicly4Lbl.Location = new Point(243, 227);
            //taxPublicly4Lbl.Size = new Size(63, 109);
            //taxPublicly5Lbl.Location = new Point(377, 227);
            //taxPublicly5Lbl.Size = new Size(63, 109);
            //taxPublicly6Lbl.Location = new Point(507, 227);
            //taxPublicly6Lbl.Size = new Size(63, 109);
            //taxPublicly7Lbl.Location = new Point(640, 227);
            //taxPublicly7Lbl.Size = new Size(63, 109);

            //backLbl.Location = new Point(696, 409);
            //backLbl.Size = new Size(92, 38);

            thumbnailPlayer0.Location = new Point(184, 102);
            thumbnailPlayer0.Size = new Size(108, 56);

            foreach (var ctrl in Controls)
            {
                if (ctrl is AxWindowsMediaPlayer thumbPlay)
                {
                    if (thumbPlay.Name.IndexOf("thumbnailPlayer", StringComparison.Ordinal) > -1)
                    {
                        var cmd = thumbPlay.Name.Replace("thumbnailPlayer", string.Empty);
                        thumbPlay.uiMode = "none";
                        thumbPlay.Enabled = true;
                        thumbPlay.currentPlaylist.clear();
                        thumbPlay.PlayStateChange += ThumbPlay_PlayStateChange;
                        thumbPlay.ClickEvent += ThumbPlay_ClickEvent;
                        var taxPublicityFolder = ConfigurationManager.AppSettings["TaxPublicityFolder"];
                        var taxPublicityVideoName = ConfigurationManager.AppSettings["TaxPublicityVideo_" + cmd];
                        var taxPublicityVideoFullName = $@"{Application.StartupPath}\videos\{taxPublicityFolder}\{taxPublicityVideoName}";

                        if (File.Exists(taxPublicityVideoFullName))
                        {
                            thumbPlay.Tag = taxPublicityVideoFullName;
                            thumbPlay.currentPlaylist.appendItem(thumbPlay.newMedia(taxPublicityVideoFullName));
                            thumbPlay.Ctlcontrols.play();
                        }
                    }
                }
                if (ctrl is Label lbl)
                {
                    if (lbl.Name.IndexOf("thumbnailLabel", StringComparison.Ordinal) > -1)
                    {
                        var cmd = lbl.Name.Replace("thumbnailLabel", string.Empty);
                        var taxPublicityText = ConfigurationManager.AppSettings["TaxPublicityText_" + cmd];

                        if (!string.IsNullOrEmpty(taxPublicityText))
                        {
                            lbl.Text = taxPublicityText;
                        }
                    }
                }
            }
        }

        private void ThumbPlay_ClickEvent(object sender, _WMPOCXEvents_ClickEvent e)
        {
            var thumbPlay = (AxWindowsMediaPlayer)sender;
            var sourceURL = thumbPlay.Tag.ToString();
            ClickEvent?.Invoke(new Notify
            {
                Command = 4,
                VideoUrl = sourceURL
            });
        }

        private void ThumbPlay_PlayStateChange(object sender, _WMPOCXEvents_PlayStateChangeEvent e)
        {
            var thumbPlay = (AxWindowsMediaPlayer)sender;
            if ((int)thumbPlay.playState == 3)
            {
                //停顿2秒钟再重新播放
                Thread.Sleep(100);

                //重新播放  
                ((AxWindowsMediaPlayer)sender).Ctlcontrols.pause();
            }
        }


        private void backLbl_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FormTaxPublicity_Load(object sender, EventArgs e)
        {
            Win32.AnimateWindow(Handle, 1000, Win32.AW_VER_POSITIVE);
        }

        private void taxPublicly_Click(object sender, EventArgs e)
        {
            int.TryParse(((Label)sender).AccessibleName, out var cmd);

            var taxPublicityFolder = ConfigurationManager.AppSettings["TaxPublicityFolder"];
            var taxPublicityVideoName = ConfigurationManager.AppSettings["TaxPublicityVideo_" + cmd];
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

        #endregion
    }
}
