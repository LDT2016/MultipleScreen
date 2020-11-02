using System;
using System.Windows.Forms;

namespace MultipleScreen.Control
{
    public partial class WebBrowserControl : WebBrowser
    {
        #region delegates

        public delegate void NewWindowSelfEventHandler(ref bool cancel, string bstrUrl);

        #endregion

        #region constructors

        public WebBrowserControl()
        {
            InitializeComponent();
        }

        #endregion

        #region events

        //发布NewWindow3事件
        public event NewWindowSelfEventHandler NewWindowSelf;

        #endregion

        #region methods

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);

            if (ActiveXInstance != null)
            {
                var browser = ActiveXInstance as SHDocVw.WebBrowser;
                browser.NewWindow3 += WebBrowser_NewWindow3;
            }
        }

        private void WebBrowser_NewWindow3(ref object ppDisp, ref bool cancel, uint dwFlags, string bstrUrlContext, string bstrUrl)
        {
            var handler = NewWindowSelf;
            handler?.Invoke(ref cancel, bstrUrl);
        }

        #endregion
    }
}
