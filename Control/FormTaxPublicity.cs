using System;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using AxWMPLib;
using MultipleScreen.Common;
using Timer = System.Windows.Forms.Timer;

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
            // thumbnailPlayer0
            // 
            thumbnailPlayer0.Location = new Point(187, 99);
            thumbnailPlayer0.Size = new Size(105, 59);

            // 
            // thumbnailLabel0
            // 
            thumbnailLabel0.Location = new Point(168, 167);
            thumbnailLabel0.Size = new Size(140, 9);
            thumbnailLabel0.Font = new Font("Microsoft Sans Serif", 5.5F, FontStyle.Bold, GraphicsUnit.Point, 134);

            // 
            // thumbnailPlayer1
            // 
            thumbnailPlayer1.Location = new Point(353, 99);
            thumbnailPlayer1.Size = new Size(105, 59);

            // 
            // thumbnailLabel1
            // 
            thumbnailLabel1.Location = new Point(334, 167);
            thumbnailLabel1.Size = new Size(140, 9);
            thumbnailLabel1.Font = new Font("Microsoft Sans Serif", 5.5F, FontStyle.Bold, GraphicsUnit.Point, 134);

            // 
            // thumbnailPlayer2
            // 
            thumbnailPlayer2.Location = new Point(519, 99);
            thumbnailPlayer2.Size = new Size(105, 59);

            // 
            // thumbnailLabel2
            // 
            thumbnailLabel2.Font = new Font("Microsoft Sans Serif", 5.5F, FontStyle.Bold, GraphicsUnit.Point, 134);
            thumbnailLabel2.Location = new Point(501, 167);
            thumbnailLabel2.Size = new Size(140, 9);

            // 
            // thumbnailPlayer3
            // 
            thumbnailPlayer3.Location = new Point(112, 229);
            thumbnailPlayer3.Size = new Size(64, 107);

            // 
            // thumbnailLabel3
            // 

            thumbnailLabel3.Font = new Font("Microsoft Sans Serif", 5.5F, FontStyle.Bold, GraphicsUnit.Point, 134);
            thumbnailLabel3.Location = new Point(79, 350);
            thumbnailLabel3.Size = new Size(120, 9);

            // 
            // thumbnailPlayer4
            // 
            thumbnailPlayer4.Location = new Point(244, 229);
            thumbnailPlayer4.Size = new Size(64, 107);

            // 
            // thumbnailLabel4
            // 
            thumbnailLabel4.Font = new Font("Microsoft Sans Serif", 5.5F, FontStyle.Bold, GraphicsUnit.Point, 134);
            thumbnailLabel4.Location = new Point(213, 350);
            thumbnailLabel4.Size = new Size(120, 9);

            // 
            // thumbnailPlayer5
            // 
            thumbnailPlayer5.Location = new Point(376, 229);
            thumbnailPlayer5.Size = new Size(64, 107);

            // 
            // thumbnailLabel5
            // 
            thumbnailLabel5.Font = new Font("Microsoft Sans Serif", 5.5F, FontStyle.Bold, GraphicsUnit.Point, 134);
            thumbnailLabel5.Location = new Point(346, 350);
            thumbnailLabel5.Size = new Size(120, 9);

            // 
            // thumbnailPlayer6
            // 
            thumbnailPlayer6.Location = new Point(507, 229);
            thumbnailPlayer6.Size = new Size(64, 107);

            // 
            // thumbnailLabel6
            // 
            thumbnailLabel6.Font = new Font("Microsoft Sans Serif", 5.5F, FontStyle.Bold, GraphicsUnit.Point, 134);
            thumbnailLabel6.Location = new Point(475, 350);
            thumbnailLabel6.Size = new Size(120, 9);

            // 
            // thumbnailPlayer7
            // 
            thumbnailPlayer7.Location = new Point(639, 229);
            thumbnailPlayer7.Size = new Size(64, 107);

            // 
            // thumbnailLabel7
            // 
            thumbnailLabel7.Font = new Font("Microsoft Sans Serif", 5.5F, FontStyle.Bold, GraphicsUnit.Point, 134);
            thumbnailLabel7.Location = new Point(608, 350);
            thumbnailLabel7.Size = new Size(120, 9);

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
            // thumbnailPlayer0
            // 
            thumbnailPlayer0.Location = new Point(453, 235);
            thumbnailPlayer0.Size = new Size(245, 134);

            // 
            // thumbnailLabel0
            // 
            thumbnailLabel0.Font = new Font("Microsoft Sans Serif", 15F, FontStyle.Bold, GraphicsUnit.Point, 134);
            thumbnailLabel0.Location = new Point(400, 391);
            thumbnailLabel0.Size = new Size(350, 25);

            // 
            // thumbnailPlayer1
            // 
            thumbnailPlayer1.Location = new Point(845, 235);
            thumbnailPlayer1.Size = new Size(251, 134);

            // 
            // thumbnailLabel1
            // 
            thumbnailLabel1.Font = new Font("Microsoft Sans Serif", 15F, FontStyle.Bold);
            thumbnailLabel1.Location = new Point(809, 391);
            thumbnailLabel1.Size = new Size(350, 25);

            // 
            // thumbnailPlayer2
            // 
            thumbnailPlayer2.Location = new Point(1243, 235);
            thumbnailPlayer2.Size = new Size(247, 134);

            // 
            // thumbnailLabel2
            // 
            thumbnailLabel2.Font = new Font("Microsoft Sans Serif", 15F, FontStyle.Bold);
            thumbnailLabel2.Location = new Point(1190, 391);
            thumbnailLabel2.Size = new Size(350, 25);

            // 
            // thumbnailPlayer3
            // 
            thumbnailPlayer3.Location = new Point(273, 544);
            thumbnailPlayer3.Size = new Size(140, 240);

            // 
            // thumbnailLabel3
            // 
            thumbnailLabel3.Font = new Font("Microsoft Sans Serif", 15F, FontStyle.Bold);
            thumbnailLabel3.Location = new Point(216, 824);
            thumbnailLabel3.Size = new Size(250, 25);

            // 
            // thumbnailPlayer4
            // 
            thumbnailPlayer4.Location = new Point(587, 544);
            thumbnailPlayer4.Size = new Size(145, 240);

            // 
            // thumbnailLabel4
            // 
            thumbnailLabel4.Font = new Font("Microsoft Sans Serif", 15F, FontStyle.Bold);
            thumbnailLabel4.Location = new Point(539, 824);
            thumbnailLabel4.Size = new Size(250, 25);

            // 
            // thumbnailPlayer5
            // 
            thumbnailPlayer5.Location = new Point(907, 544);
            thumbnailPlayer5.Size = new Size(145, 240);

            // 
            // thumbnailLabel5
            // 
            thumbnailLabel5.Font = new Font("Microsoft Sans Serif", 15F, FontStyle.Bold);
            thumbnailLabel5.Location = new Point(864, 824);
            thumbnailLabel5.Size = new Size(250, 25);

            // 
            // thumbnailPlayer6
            // 
            thumbnailPlayer6.Location = new Point(1222, 544);
            thumbnailPlayer6.Size = new Size(145, 240);

            // 
            // thumbnailPlayer7
            // 
            thumbnailPlayer7.Location = new Point(1542, 544);
            thumbnailPlayer7.Size = new Size(145, 240);

            // 
            // thumbnailLabel6
            // 
            thumbnailLabel6.Font = new Font("Microsoft Sans Serif", 15F, FontStyle.Bold);
            thumbnailLabel6.Location = new Point(1174, 824);
            thumbnailLabel6.Size = new Size(250, 25);

            // 
            // thumbnailLabel7
            // 
            thumbnailLabel7.Font = new Font("Microsoft Sans Serif", 15F, FontStyle.Bold);
            thumbnailLabel7.Location = new Point(1502, 824);
            thumbnailLabel7.Size = new Size(250, 25);
        }
        public void TaxPubliclyThumbnailSetup()
        {
            foreach (var ctrl in Controls)
            {
                if (ctrl is PictureBox thumbPlay)
                {
                    if (thumbPlay.Name.IndexOf("thumbnailPlayer", StringComparison.Ordinal) > -1)
                    {
                        var cmd = thumbPlay.Name.Replace("thumbnailPlayer", string.Empty);

                        var taxPublicityFolder = ConfigurationManager.AppSettings["TaxPublicityFolder"];
                        var taxPublicityThumbnail = ConfigurationManager.AppSettings["TaxPublicityThumbnail_" + cmd];
                        var taxPublicityVideoName = ConfigurationManager.AppSettings["TaxPublicityVideo_" + cmd];
                        var taxPublicityVideoFullName = $@"{Application.StartupPath}\videos\{taxPublicityFolder}\{taxPublicityVideoName}";
                        var taxPublicityThumbnailFullName = $@"{Application.StartupPath}\videos\{taxPublicityFolder}\{taxPublicityThumbnail}";

                        if (File.Exists(taxPublicityVideoFullName))
                        {

                            thumbPlay.Tag = taxPublicityVideoFullName;
                            thumbPlay.Click += ThumbPlay_Click;
                        }

                        if (File.Exists(taxPublicityThumbnailFullName))
                        {
                            thumbPlay.BackgroundImage = Image.FromStream(new MemoryStream(File.ReadAllBytes(taxPublicityThumbnailFullName)));
                        }
                    }
                }

                if (ctrl is Label lbl)
                {
                    if (lbl.Name.IndexOf("thumbnailLabel", StringComparison.Ordinal) > -1)
                    {
                        lbl.Text = string.Empty;
                        lbl.Click += Lbl_Click;
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

        private void Lbl_Click(object sender, EventArgs e)
        {
            CloseDialogTimerStart();
        }

        private void ThumbPlay_Click(object sender, EventArgs e)
        {
            var thumbPlay = (PictureBox)sender;
            var sourceUrl = thumbPlay.Tag?.ToString();

            ClickEvent?.Invoke(new Notify
            {
                Command = 4,
                VideoUrl = sourceUrl
            });
            CloseDialogTimerStart();
        }

        private void backLbl_Click(object sender, EventArgs e)
        {
            CloseDialogTimerStop();

            Close();
        }

        private void FormTaxPublicity_Load(object sender, EventArgs e)
        {
            //  TaxPubliclyThumbnailSetup();
            //instance.ResizeSetupRelease();
            CloseDialogTimerStart();
        }


        #region CloseDialogTimer

        private Timer CloseDialogTimer = new Timer();
        private void CloseDialogTimerStart()
        {
            instance.CloseDialogTimer.Stop();
            instance.CloseDialogTimer.Interval = 5 * 60 * 1000;
            instance.CloseDialogTimer.Tick += CloseDialogTimer_Tick;
            //instance.CloseDialogTimer.Enabled = true;
            instance.CloseDialogTimer.Start();
        }

        private void CloseDialogTimer_Tick(object sender, EventArgs e)
        {
            CloseDialogTimerStop();

            instance.Close();
        }

        private static void CloseDialogTimerStop()
        {
            instance.CloseDialogTimer.Enabled = false;
            instance.CloseDialogTimer.Stop();
        }

        #endregion

        #endregion

        private void FormTaxPublicity_Click(object sender, EventArgs e)
        {
            CloseDialogTimerStart();

        }
    }
}
