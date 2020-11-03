using System;
using System.Configuration;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using MultipleScreen.Common;

namespace MultipleScreen.Control
{
    public partial class FormNetInner : Form
    {
        #region fields

        private static FormNetInner instance;
        private readonly Timer CaptureTimer = new Timer();

        #endregion

        #region constructors

        public FormNetInner()
        {
            InitializeComponent();
        }

        #endregion

        #region events

        public event Util.ClickDelegateHander ClickEvent;

        #endregion

        #region properties

        public static FormNetInner Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new FormNetInner();

                    if (Screen.AllScreens.Length > 1)
                    {
                        instance.ResizeSetupRelease();
                    }
                    else
                    {
                        instance.ResizeSetup();
                    }

                    instance.NetInnerSetup();
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

        public static Bitmap ScreenshotControlIntPtr(IntPtr hWnd)
        {
            var hscrdc = GetWindowDC(hWnd);
            var windowRect = new Rectangle();
            GetWindowRect(hWnd, ref windowRect);
            var width = Math.Abs(windowRect.X - windowRect.Width);
            var height = Math.Abs(windowRect.Y - windowRect.Height);
            var hbitmap = CreateCompatibleBitmap(hscrdc, width, height);
            var hmemdc = CreateCompatibleDC(hscrdc);
            SelectObject(hmemdc, hbitmap);
            PrintWindow(hWnd, hmemdc, 0);
            var bmp = Image.FromHbitmap(hbitmap);
            DeleteDC(hscrdc);
            DeleteDC(hmemdc);

            return bmp;
        }

        public void NetInnerSetup()
        {
            instance.Browser.DocumentCompleted += webBrowser_DocumentCompleted; // 增加网页加载完成事件处理函数
            instance.Browser.NewWindowSelf += Browser_NewWindowSelf;
            CaptureTimer.Interval = 2000;
            CaptureTimer.Tick += CaptureTimer_Tick;
        }

        private void Browser_NewWindowSelf(ref bool cancel, string bstrUrl)
        {
            cancel = true;
            Browser.Navigate(bstrUrl);
        }

        public void ResizeSetup()
        {
            ClientSize = new Size(800, 450);

            panel1.Location = new Point(12, 62);
            panel1.Size = new Size(784, 325);

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

            panel1.Location = new Point(0, 125);
            panel1.Size = new Size(1920, 850);
        }

        [DllImport("gdi32.dll")]
        private static extern IntPtr CreateCompatibleBitmap(IntPtr hdc, int nWidth, int nHeight);

        [DllImport("gdi32.dll")]
        private static extern IntPtr CreateCompatibleDC(IntPtr hdc);

        [DllImport("gdi32.dll")]
        private static extern int DeleteDC(IntPtr hdc);

        [DllImport("user32.dll")]
        private static extern IntPtr GetWindowDC(IntPtr hwnd);

        [DllImport("user32.dll")]
        private static extern IntPtr GetWindowRect(IntPtr hWnd, ref Rectangle rect);

        [DllImport("user32.dll")]
        private static extern bool PrintWindow(IntPtr hwnd, IntPtr hdcBlt, int nFlags);

        [DllImport("gdi32.dll")]
        private static extern IntPtr SelectObject(IntPtr hdc, IntPtr hgdiobj);

        private void backLbl_Click(object sender, EventArgs e)
        {
            CaptureTimerReset();
            instance.Close();
        }

        private void CaptureTimer_Tick(object sender, EventArgs e)
        {
            if (instance.Browser.Document != null)
            {
                if (instance.Browser.Document.Body != null)
                {
                    var bitmap1 = ScreenshotControlIntPtr(Browser.Handle);
                    ClickEvent?.Invoke(new Notify
                    {
                        Command = 2,
                        ImageUrl = bitmap1
                    });
                }
            }
        }

        private void CaptureTimerReset()
        {
            instance.CaptureTimer.Stop();

            var regionalNetworkUrl = ConfigurationManager.AppSettings["RegionalNetworkUrl"];
            instance.Browser.Navigate(regionalNetworkUrl);

            ClickEvent?.Invoke(new Notify
                               {
                                   Command = -1
                               });
        }

        private void FormBigEvent_Click(object sender, EventArgs e)
        {
        }

        private void FormBigEvent_Load(object sender, EventArgs e)
        {
            //Win32.AnimateWindow(Handle, 1000, Win32.AW_VER_POSITIVE);
            var regionalNetworkUrl = ConfigurationManager.AppSettings["RegionalNetworkUrl"];
            instance.Browser.Navigate(regionalNetworkUrl);
        }

        /// <summary>
        /// 网页加载完成事件处理函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void webBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            CaptureTimer.Start();
        }

        #endregion

        private void Browser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            FormMain.Instance.CloseDialogTimerReset();

            //将所有的链接的目标，指向本窗体
            foreach (HtmlElement archor in this.Browser.Document.Links)
            {
                archor.SetAttribute("target", "_self");
            }

            //将所有的FORM的提交目标，指向本窗体
            foreach (HtmlElement form in this.Browser.Document.Forms)
            {
                form.SetAttribute("target", "_self");
            }
        }
    }
}
