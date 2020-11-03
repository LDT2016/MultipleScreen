using System;
using System.Drawing;
using System.Windows.Forms;
using MultipleScreen.Common;
using MultipleScreen.Display;

namespace MultipleScreen.Control
{
    public partial class FormMain : Form
    {
        private Form subForm = null;
        #region fields

        private static FormMain instance;

        #endregion

        #region constructors

        public FormMain()
        {
            InitializeComponent();
        }

        #endregion

        #region events

        public event Util.ClickDelegateHander ClickEvent;

        #endregion

        #region properties

        public static FormMain Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new FormMain();
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

        private void closeLbl_Click(object sender, EventArgs e)
        {
            notifyIcon1.Dispose();
            FormDisplay.Instance.Close();
            Instance.Close();
            Application.Exit();
        }

        private void command_Click(object sender, EventArgs e)
        {
            int.TryParse(((Label)sender).AccessibleName, out var cmd);

            //领导批示
            if (cmd == 2)
            {
                ShowDialogProcess(FormLeadGuide.Instance);
            }
            //税收宣传
            else if (cmd == 4)
            {
                ShowDialogProcess(FormTaxPublicity.Instance);
            }
            //区局十大事件
            else if (cmd == 5)
            {
                ShowDialogProcess(FormBigEvent.Instance);
            }
            //区局内网
            else if (cmd == 6)
            {
                ShowDialogProcess(FormNetInner.Instance);
            }
            else
            {
                ClickEvent?.Invoke(new Notify
                {
                    Command = cmd
                });
            }
        }

        private void ShowDialogProcess(Form frm)
        {
            CloseDialogTimerReset();
            subForm = frm;
            if (frm.ShowDialog() == DialogResult.Abort)
            {
                CloseDialogTimerStop();
            }
        }

        #region CloseDialogTimer

        private Timer _closeDialogTimer = new Timer();
        public void CloseDialogTimerReset()
        {
            _closeDialogTimer = new Timer();
            instance._closeDialogTimer.Stop();
            instance._closeDialogTimer.Interval = 5 * 60 * 1000;
            instance._closeDialogTimer.Tick += CloseDialogTimer_Tick;
            instance._closeDialogTimer.Start();
        }

        private void CloseDialogTimer_Tick(object sender, EventArgs e)
        {
            subForm?.Close();
        }

        private void CloseDialogTimerStop()
        {
            subForm = null;
            instance._closeDialogTimer.Stop();
        }

        #endregion
        public void ResizeSetup()
        {
            ClientSize = new Size(800, 450);
            var labelSize = new Size(152, 132);

            ctrlLbl0.Location = new Point(87, 92);
            ctrlLbl1.Location = new Point(310, 92);
            ctrlLbl2.Location = new Point(533, 92);
            ctrlLbl3.Location = new Point(21, 261);
            ctrlLbl4.Location = new Point(219, 248);
            ctrlLbl5.Location = new Point(415, 248);
            ctrlLbl6.Location = new Point(612, 248);
            ctrlLbl0.Size = ctrlLbl1.Size = ctrlLbl2.Size = ctrlLbl3.Size = ctrlLbl4.Size = ctrlLbl5.Size = ctrlLbl6.Size = labelSize;
        }
        public void ResizeSetupRelease()
        {
            ClientSize = new Size(1920, 1080);
            var labelSize = new Size(359, 319);
            ctrlLbl0.Location = new Point(210, 215);
            ctrlLbl1.Location = new Point(741, 215);
            ctrlLbl2.Location = new Point(1283, 215);
            ctrlLbl3.Location = new Point(50, 619);
            ctrlLbl4.Location = new Point(530, 586);
            ctrlLbl5.Location = new Point(999, 586);
            ctrlLbl6.Location = new Point(1469, 586);
            ctrlLbl0.Size = ctrlLbl1.Size = ctrlLbl2.Size = ctrlLbl3.Size = ctrlLbl4.Size = ctrlLbl5.Size = ctrlLbl6.Size = labelSize;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            notifyIcon1.Dispose();
            FormDisplay.Instance.Close();
            Instance.Close();
            Application.Exit();
        }

        #endregion

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
