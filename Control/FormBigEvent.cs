using System;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using MultipleScreen.Common;

namespace MultipleScreen.Control
{
    public partial class FormBigEvent : Form
    {
        #region fields

        private static FormBigEvent instance;

        #endregion

        #region constructors

        public FormBigEvent()
        {
            InitializeComponent();
        }

        #endregion

        #region events

        public event Util.ClickDelegateHander ClickEvent;

        #endregion

        #region properties

        public static FormBigEvent Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new FormBigEvent();
                    if (Screen.AllScreens.Length > 1)
                    {
                        instance.ResizeSetupRelease();
                    }
                    else
                    {
                        instance.ResizeSetup();
                    }

                    instance.TaxPubliclyThumbnailSetup();
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
            ClientSize = new Size(800, 450);

            // 
            // eventThumbnail5
            // 
            eventThumbnail5.Location = new Point(112, 229);
            eventThumbnail5.Size = new Size(64, 107);

            // 
            // eventInfo5
            // 
            eventInfo5.Font = new Font("Microsoft Sans Serif", 5.5F, FontStyle.Bold, GraphicsUnit.Point, 134);
            eventInfo5.Location = new Point(79, 350);
            eventInfo5.Size = new Size(120, 9);

            // 
            // eventThumbnail6
            // 
            eventThumbnail6.Location = new Point(244, 229);
            eventThumbnail6.Size = new Size(64, 107);

            // 
            // eventInfo6
            // 
            eventInfo6.Font = new Font("Microsoft Sans Serif", 5.5F, FontStyle.Bold, GraphicsUnit.Point, 134);
            eventInfo6.Location = new Point(213, 350);
            eventInfo6.Size = new Size(120, 9);

            // 
            // eventThumbnail7
            // 
            eventThumbnail7.Location = new Point(376, 229);
            eventThumbnail7.Size = new Size(64, 107);

            // 
            // eventInfo7
            // 
            eventInfo7.Font = new Font("Microsoft Sans Serif", 5.5F, FontStyle.Bold, GraphicsUnit.Point, 134);
            eventInfo7.Location = new Point(346, 350);
            eventInfo7.Size = new Size(120, 9);

            // 
            // eventThumbnail8
            // 
            eventThumbnail8.Location = new Point(507, 229);
            eventThumbnail8.Size = new Size(64, 107);

            // 
            // eventThumbnail9
            // 
            eventThumbnail9.Location = new Point(639, 229);
            eventThumbnail9.Size = new Size(64, 107);

            // 
            // eventInfo8
            // 
            eventInfo8.Font = new Font("Microsoft Sans Serif", 5.5F, FontStyle.Bold, GraphicsUnit.Point, 134);
            eventInfo8.Location = new Point(475, 350);
            eventInfo8.Size = new Size(120, 9);

            // 
            // eventInfo9
            // 
            eventInfo9.Font = new Font("Microsoft Sans Serif", 5.5F, FontStyle.Bold, GraphicsUnit.Point, 134);
            eventInfo9.Location = new Point(608, 350);
            eventInfo9.Size = new Size(120, 9);

            // 
            // eventThumbnail0
            // 
            eventThumbnail0.Location = new Point(112, 84);
            eventThumbnail0.Size = new Size(64, 107);

            // 
            // eventThumbnail1
            // 
            eventThumbnail1.Location = new Point(244, 84);
            eventThumbnail1.Size = new Size(64, 107);

            // 
            // eventThumbnail3
            // 
            eventThumbnail3.Location = new Point(507, 84);
            eventThumbnail3.Size = new Size(64, 107);

            // 
            // eventThumbnail2
            // 
            eventThumbnail2.Location = new Point(376, 84);
            eventThumbnail2.Size = new Size(64, 107);

            // 
            // eventThumbnail4
            // 
            eventThumbnail4.Location = new Point(639, 84);
            eventThumbnail4.Size = new Size(64, 107);

            // 
            // eventInfo0
            // 
            eventInfo0.Font = new Font("Microsoft Sans Serif", 5.5F, FontStyle.Bold, GraphicsUnit.Point, 134);
            eventInfo0.Location = new Point(79, 205);
            eventInfo0.Size = new Size(120, 9);

            // 
            // eventInfo1
            // 
            eventInfo1.Font = new Font("Microsoft Sans Serif", 5.5F, FontStyle.Bold, GraphicsUnit.Point, 134);
            eventInfo1.Location = new Point(213, 205);
            eventInfo1.Size = new Size(120, 9);

            // 
            // eventInfo3
            // 
            eventInfo3.Font = new Font("Microsoft Sans Serif", 5.5F, FontStyle.Bold, GraphicsUnit.Point, 134);
            eventInfo3.Location = new Point(475, 205);
            eventInfo3.Size = new Size(120, 9);

            // 
            // eventInfo2
            // 
            eventInfo2.Font = new Font("Microsoft Sans Serif", 5.5F, FontStyle.Bold, GraphicsUnit.Point, 134);
            eventInfo2.Location = new Point(346, 205);
            eventInfo2.Size = new Size(120, 9);

            // 
            // eventInfo4
            // 
            eventInfo4.Font = new Font("Microsoft Sans Serif", 5.5F, FontStyle.Bold, GraphicsUnit.Point, 134);
            eventInfo4.Location = new Point(608, 205);
            eventInfo4.Size = new Size(120, 9);

            // 
            // backLbl
            // 
            backLbl.Location = new Point(696, 409);
            backLbl.Size = new Size(92, 38);
        }

        public void ResizeSetupRelease()
        {
            instance.Location = FormMain.Instance.Location;
            instance.ClientSize = new Size(1920, 1080);
            instance.FormBorderStyle = FormBorderStyle.None;
            instance.StartPosition = FormStartPosition.Manual;

            // 
            // backLbl
            // 
            backLbl.Location = new Point(1665, 990);
            backLbl.Size = new Size(215, 82);

            // 
            // eventThumbnail5
            // 
            eventThumbnail5.Location = new Point(273, 544);
            eventThumbnail5.Size = new Size(140, 240);

            // 
            // eventInfo5
            // 
            eventInfo5.Font = new Font("Microsoft Sans Serif", 15F, FontStyle.Bold, GraphicsUnit.Point, 134);
            eventInfo5.Location = new Point(216, 824);
            eventInfo5.Size = new Size(250, 25);

            // 
            // eventThumbnail6
            // 
            eventThumbnail6.Location = new Point(587, 544);
            eventThumbnail6.Size = new Size(145, 240);

            // 
            // eventInfo6
            // 
            eventInfo6.Font = new Font("Microsoft Sans Serif", 15F, FontStyle.Bold, GraphicsUnit.Point, 134);
            eventInfo6.Location = new Point(539, 824);
            eventInfo6.Size = new Size(250, 25);

            // 
            // eventThumbnail7
            // 
            eventThumbnail7.Location = new Point(907, 544);
            eventThumbnail7.Size = new Size(145, 240);

            // 
            // eventInfo7
            // 
            eventInfo7.Font = new Font("Microsoft Sans Serif", 15F, FontStyle.Bold, GraphicsUnit.Point, 134);
            eventInfo7.Location = new Point(864, 824);
            eventInfo7.Size = new Size(250, 25);

            // 
            // eventThumbnail8
            // 
            eventThumbnail8.Location = new Point(1222, 544);
            eventThumbnail8.Size = new Size(145, 240);

            // 
            // eventThumbnail9
            // 
            eventThumbnail9.Location = new Point(1542, 544);
            eventThumbnail9.Size = new Size(145, 240);

            // 
            // eventInfo8
            // 
            eventInfo8.Font = new Font("Microsoft Sans Serif", 15F, FontStyle.Bold, GraphicsUnit.Point, 134);
            eventInfo8.Location = new Point(1174, 824);
            eventInfo8.Size = new Size(250, 25);

            // 
            // eventInfo9
            // 
            eventInfo9.Font = new Font("Microsoft Sans Serif", 15F, FontStyle.Bold, GraphicsUnit.Point, 134);
            eventInfo9.Location = new Point(1502, 824);
            eventInfo9.Size = new Size(250, 25);

            // 
            // eventThumbnail0
            // 
            eventThumbnail0.Location = new Point(268, 173);
            eventThumbnail0.Size = new Size(145, 240);

            // 
            // eventThumbnail1
            // 
            eventThumbnail1.Location = new Point(587, 173);
            eventThumbnail1.Size = new Size(145, 240);

            // 
            // eventThumbnail3
            // 
            eventThumbnail3.Location = new Point(1222, 173);
            eventThumbnail3.Size = new Size(145, 240);

            // 
            // eventThumbnail2
            // 
            eventThumbnail2.Location = new Point(907, 173);
            eventThumbnail2.Size = new Size(145, 240);

            // 
            // eventThumbnail4
            // 
            eventThumbnail4.Location = new Point(1542, 173);
            eventThumbnail4.Size = new Size(145, 240);

            // 
            // eventInfo0
            // 
            eventInfo0.Font = new Font("Microsoft Sans Serif", 15F, FontStyle.Bold, GraphicsUnit.Point, 134);
            eventInfo0.Location = new Point(216, 450);
            eventInfo0.Size = new Size(250, 25);

            // 
            // eventInfo1
            // 
            eventInfo1.Font = new Font("Microsoft Sans Serif", 15F, FontStyle.Bold, GraphicsUnit.Point, 134);
            eventInfo1.Location = new Point(539, 450);
            eventInfo1.Size = new Size(250, 25);

            // 
            // eventInfo3
            // 
            eventInfo3.Font = new Font("Microsoft Sans Serif", 15F, FontStyle.Bold, GraphicsUnit.Point, 134);
            eventInfo3.Location = new Point(864, 450);
            eventInfo3.Size = new Size(250, 25);

            // 
            // eventInfo2
            // 
            eventInfo2.Font = new Font("Microsoft Sans Serif", 15F, FontStyle.Bold, GraphicsUnit.Point, 134);
            eventInfo2.Location = new Point(1502, 450);
            eventInfo2.Size = new Size(250, 25);

            // 
            // eventInfo4
            // 
            eventInfo4.Font = new Font("Microsoft Sans Serif", 15F, FontStyle.Bold, GraphicsUnit.Point, 134);
            eventInfo4.Location = new Point(1174, 450);
            eventInfo4.Size = new Size(250, 25);
        }

        public void TaxPubliclyThumbnailSetup()
        {
            foreach (var ctrl in Controls)
            {
                if (ctrl is PictureBox thumb)
                {
                    if (thumb.Name.IndexOf("eventThumbnail", StringComparison.Ordinal) > -1)
                    {
                        thumb.Click += Thumb_Click;
                        var cmd = thumb.Name.Replace("eventThumbnail", string.Empty);
                        var bigEventFolder = ConfigurationManager.AppSettings["BigEventFolder"];
                        var bigEventPict = ConfigurationManager.AppSettings["BigEventPict_" + cmd];
                        var bigEventPictFullName = $@"{Application.StartupPath}\pictures\{bigEventFolder}\{bigEventPict}";

                        if (File.Exists(bigEventPictFullName))
                        {
                            thumb.BackgroundImage = Image.FromStream(new MemoryStream(File.ReadAllBytes(bigEventPictFullName)));
                        }
                    }
                }

                if (ctrl is Label lbl)
                {
                    if (lbl.Name.IndexOf("eventInfo", StringComparison.Ordinal) > -1)
                    {
                        lbl.Text = string.Empty;
                        lbl.Click += Lbl_Click;
                        var cmd = lbl.Name.Replace("eventInfo", string.Empty);
                        var taxPublicityText = ConfigurationManager.AppSettings["BigEventText_" + cmd];

                        if (!string.IsNullOrEmpty(taxPublicityText))
                        {
                            lbl.Text = taxPublicityText;
                        }
                    }
                }
            }
        }

        private void Lbl_Click(object sender, EventArgs e)
        {
        }

        private void backLbl_Click(object sender, EventArgs e)
        {
            instance.Close();
        }

        private void FormBigEvent_Load(object sender, EventArgs e)
        {
            //Win32.AnimateWindow(Handle, 1000, Win32.AW_VER_POSITIVE);
        }

        private void Thumb_Click(object sender, EventArgs e)
        {
            var thumb = (PictureBox)sender;

            ClickEvent?.Invoke(new Notify
            {
                Command = 5,
                ImageUrl = thumb.BackgroundImage
            });
        }

        #endregion


        private void FormBigEvent_Click(object sender, EventArgs e)
        {
        }
    }
}
