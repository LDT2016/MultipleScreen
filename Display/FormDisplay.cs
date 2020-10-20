using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using AxWMPLib;
using MultipleScreen.Common;
using MultipleScreen.Control;
using Timer = System.Windows.Forms.Timer;

namespace MultipleScreen.Display
{
    public partial class FormDisplay : Form
    {
        #region fields

        private static FormDisplay instance;

        #endregion

        #region constructors

        public FormDisplay()
        {
            InitializeComponent();
        }

        #endregion

        #region properties

        public static FormDisplay Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new FormDisplay();
                    FormMain.Instance.ClickEvent += FormDisplay_ClickEvent;
                    FormLeadGuide.Instance.ClickEvent += FormDisplay_ClickEvent;
                    FormTaxPublicity.Instance.ClickEvent += FormDisplay_ClickEvent;
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

        public Notify CurrentNotidy { set; get; } = new Notify();

        private static void FormDisplay_ClickEvent(Notify message)
        {
            instance.CurrentNotidy = message;
            switch (message.Command)
            {
                case 0:// "组织架构":
                    {
                        DisplayReset();
                        var orgPicName = ConfigurationManager.AppSettings["Organization"];
                        var orgPicPath = $@"{Application.StartupPath}\pictures\{orgPicName}";

                        if (File.Exists(orgPicPath))
                        {
                            instance.PicPanel.BackgroundImage = Image.FromStream(new MemoryStream(File.ReadAllBytes(orgPicPath)));
                        }

                        instance.PicPanel.Visible = true;
                        break;
                    }
                case 1://"领导关怀":
                    {
                        DisplayReset();
                        instance.LeadShipPictureShow();
                        instance.PicPanel.Visible = true;
                        break;
                    }
                case 2://"领导批示":
                    {
                        DisplayReset();
                        instance.PicPanel.BackgroundImage = message.ImageUrl;
                        instance.PicPanel.Visible = true;
                        break;
                    }
                case 3://"法制示范":
                    {
                        DisplayReset();
                        instance.LegalDemoVideoShow();
                        instance.Player.Visible = true;
                        break;
                    }
                case 4://"税收宣传":
                    {
                        DisplayReset();
                        instance.Player.settings.setMode("loop", true);
                        instance.Player.uiMode = "none";
                        instance.Player.Enabled = false;
                        instance.Player.currentPlaylist.clear();
                        instance.Player.currentPlaylist.appendItem(instance.Player.newMedia(message.VideoUrl));
                        instance.Player.Ctlcontrols.play();
                        instance.Player.Visible = true;
                        break;
                    }
                case 5://"区局十大事件":
                {
                    DisplayReset();
                    instance.PicPanel.BackgroundImage = message.ImageUrl;
                    instance.PicPanel.Visible = true;
                    break;
                }
                case 6://"局间内网":
                {
                    DisplayReset();
                    var regionalNetworkUrl = ConfigurationManager.AppSettings["RegionalNetworkUrl"];
                    instance.Browser.Url = new Uri(regionalNetworkUrl);
                    instance.Browser.Visible = true;
                    break;
                }
            }

        }

        private static void DisplayReset()
        {
            instance.Player.Enabled = false;
            instance.Player.currentPlaylist.clear();
            instance.Player.Ctlcontrols.stop();
            instance.Player.Visible = false;
            instance.PicTimer.Stop();
            instance.PicTimer.Enabled = false;
            instance.PicPanel.Visible = false;
            instance.Browser.Visible = false;
        }

        private void Player_PlayStateChange(object sender, _WMPOCXEvents_PlayStateChangeEvent e)
        {
            /*  0 Undefined Windows Media Player is in an undefined state.(未定义) 
                1 Stopped Playback of the current media item is stopped.(停止) 
                2 Paused Playback of the current media item is paused. When a media item is paused, resuming playback begins from the same location.(停留) 
                3 Playing The current media item is playing.(播放) 
                4 ScanForward The current media item is fast forwarding. 
                5 ScanReverse The current media item is fast rewinding. 
                6 Buffering The current media item is getting additional data from the server.(转换) 
                7 Waiting Connection is established, but the server is not sending data. Waiting for session to begin.(暂停) 
                8 MediaEnded Media item has completed playback. (播放结束) 
                9 Transitioning Preparing new media item. 
                10 Ready Ready to begin playing.(准备就绪) 
                11 Reconnecting Reconnecting to stream.(重新连接) 
            */
            //判断视频是否已停止播放  
            //if ((int)Player.playState == 3)
            //{
            //    //停顿2秒钟再重新播放
            //    Thread.Sleep(100);

            //    //重新播放  
            //    Player.Ctlcontrols.pause();
            //}
        }

        #endregion

        //        #region play videos
        //        Player.settings.setMode("loop", true);  // 将播放列表设置为循环播放 
        //            Player.uiMode = "none";
        //            Player.Enabled = false;
        //            Player.currentPlaylist.clear();
        //            var temppath = $@"{Application.StartupPath}\tempvedios\";
        //            if (!Directory.Exists(temppath))
        //            {
        //                Directory.CreateDirectory(temppath);
        //            }
        //            foreach (var file in new DirectoryInfo(temppath).GetFiles())
        //            {
        //                File.Delete(file.FullName);
        //            }

        //            if (Directory.Exists(videopath))
        //            {
        //                var videoDir = new DirectoryInfo(videopath);
        //var videoFiles = videoDir.GetFiles("*.mp4").ToList();
        //videoFiles.AddRange(videoDir.GetFiles("*.wav").ToList());
        //                videoFiles.AddRange(videoDir.GetFiles("*.avi").ToList());
        //                #region

        //                foreach (var file in videoFiles)
        //                {
        //                    if (File.Exists(file.FullName))
        //                    {
        //                        Thread.Sleep(20);
        //                        var savefullname = temppath + DateTime.Now.Ticks + Path.GetExtension(file.FullName);
        //                        var fswrite = new FileStream(savefullname, FileMode.Create);
        //                        var array = File.ReadAllBytes(file.FullName);
        //                        fswrite.Write(array, 0, array.Length);
        //                        fswrite.Close();

        //                        Player.currentPlaylist.appendItem(Player.newMedia(savefullname)); // 将视频逐个添加至播放列表 
        //                    }
        //                }
        //                Player.Ctlcontrols.play();
        //            }

        //            #endregion

        #region video pictures
        private void LegalDemoVideoShow()
        {
            var legalDemoFolder = ConfigurationManager.AppSettings["LegalDemo"];
            var legalDemoPath = $@"{Application.StartupPath}\videos\{legalDemoFolder}";

            #region play videos
            Player.settings.setMode("loop", true);  // 将播放列表设置为循环播放 
            Player.uiMode = "none";
            Player.Enabled = false;
            Player.currentPlaylist.clear();

            if (Directory.Exists(legalDemoPath))
            {
                var videoDir = new DirectoryInfo(legalDemoPath);
                var videoFiles = videoDir.GetFiles("*.mp4").ToList();
                videoFiles.AddRange(videoDir.GetFiles("*.wav").ToList());
                videoFiles.AddRange(videoDir.GetFiles("*.avi").ToList());
                foreach (var file in videoFiles)
                {
                    if (File.Exists(file.FullName))
                    {
                        Player.currentPlaylist.appendItem(Player.newMedia(file.FullName)); // 将视频逐个添加至播放列表
                    }
                }

                Player.Ctlcontrols.play();
            }

            #endregion
        }


        #endregion


        #region show pictures

        [Flags]
        public enum AnimationType
        {
            AW_HOR_POSITIVE = 0x0001,//从左向右显示
            AW_HOR_NEGATIVE = 0x0002,//从右向左显示
            AW_VER_POSITIVE = 0x0004,//从上到下显示
            AW_VER_NEGATIVE = 0x0008,//从下到上显示
            AW_CENTER = 0x0010,//从中间向四周
            AW_HIDE = 0x10000,
            AW_ACTIVATE = 0x20000,//普通显示
            AW_SLIDE = 0x40000,
            AW_BLEND = 0x80000,//透明渐变显示效果
        }

        [DllImport("user32.dll")]
        public static extern bool AnimateWindow(IntPtr hwnd, uint dwTime, AnimationType dwFlags);

        private List<Image> picList = new List<Image>();
        private Timer PicTimer = new Timer();
        private int picIndex = 0;
        private Random random = new Random();
        private AnimationType[] animationTypes = null;

        private void LeadShipPictureShow()
        {
            var leadShipPicFolder = ConfigurationManager.AppSettings["LeadShip"];
            var leadShipPic = $@"{Application.StartupPath}\pictures\{leadShipPicFolder}";
            var leadShipTimerTick = ConfigurationManager.AppSettings["LeadShipTimerTick"];
            int.TryParse(leadShipTimerTick, out var intLeadShipTimerTick);
            #region show pictures

            instance.picIndex = 0;
            instance.picList = new List<Image>();
            if (Directory.Exists(leadShipPic))
            {
                //show pictures
                var dir = new DirectoryInfo(leadShipPic);
                var files = dir.GetFiles("*.jpg").ToList();
                files.AddRange(dir.GetFiles("*.jpeg").ToList());
                files.AddRange(dir.GetFiles("*.png").ToList());
                files.AddRange(dir.GetFiles("*.bmp").ToList());
                files.AddRange(dir.GetFiles("*.gif").ToList());
                foreach (var file in files)
                {
                    if (File.Exists(file.FullName))
                    {
                        var image = Image.FromStream(new MemoryStream(File.ReadAllBytes(file.FullName)));
                        picList.Add(image);
                    }
                }

                instance.PicTimer.Interval = intLeadShipTimerTick > 0
                                                 ? intLeadShipTimerTick * 1000
                                                 : 6000;
                instance.PicTimer.Tick += PicTimerTick;
                instance.PicTimer.Enabled = true;
                instance.ShowPictures();
            }

            #endregion
        }

        private void PicTimerTick(object sender, EventArgs e)
        {
            ShowPictures();
        }

        private void ShowPictures()
        {
            try
            {
                if (picList.Count == 0)
                {
                    return;
                }
                instance.PicTimer.Enabled = false;

                var currentGirl = picList[picIndex++];

                instance.PicPanel.Visible = false;
                instance.PicPanel.BackgroundImage = currentGirl;
                AnimateWindow(instance.PicPanel.Handle, 400, GetRandomAnimationType());

                if (picIndex >= picList.Count)
                {
                    picIndex = 0;
                }
                instance.PicTimer.Enabled = true;

            }
            catch
            {
            }
        }

        private AnimationType GetRandomAnimationType()
        {
            if (animationTypes == null)
            {
                animationTypes = Enum.GetValues(typeof(AnimationType)) as AnimationType[];
            }

            return animationTypes[random.Next(0, animationTypes.Length - 1)];
        }
        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                PicTimer.Enabled = false;
                foreach (var girl in picList)
                {
                    girl.Dispose();
                }
                this.Close();
            }
            base.OnKeyDown(e);
        }
        #endregion

    }
}
