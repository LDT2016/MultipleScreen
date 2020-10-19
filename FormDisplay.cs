using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Forms;
using MultipleScreen.Common;

namespace MultipleScreen
{
    public partial class FormDisplay : Form
    {
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


        private static FormDisplay instance;
        public static FormDisplay Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new FormDisplay();
                    FormControl.Instance.ClickEvent += FormDisplay_ClickEvent;
                }
                return instance;
            }
        }

        public FormDisplay()
        {
            InitializeComponent();
        }

        private static void FormDisplay_ClickEvent(Notify message)
        {

        }

        private void Player_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
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
            if ((int)Player.playState == 1)
            {
                //停顿2秒钟再重新播放  
                System.Threading.Thread.Sleep(2000);
                //重新播放  
                Player.Ctlcontrols.play();

                //Player.URL = url;
                //Player.currentPlaylist = Player.currentPlaylist;

            }

        }


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

    }
}
