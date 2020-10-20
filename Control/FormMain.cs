using System;
using System.Drawing;
using System.Windows.Forms;
using MultipleScreen.Common;
using MultipleScreen.Display;

namespace MultipleScreen.Control
{
    public partial class FormMain : Form
    {
        #region fields

        private const int DEBUG_LABEL_HEIGHT = 144;
        private const int DEBUG_LABEL_WIDTH = 163;
        private const int DEBUG_LABEL_X= 69;
        private const int DEBUG_LABEL_X_GAP = 78;
        private const int DEBUG_LABEL_Y= 79;
        private const int DEBUG_LABEL_Y_GAP = 25;

        private const int RELEASE_LABEL_HEIGHT = 144;
        private const int RELEASE_LABEL_WIDTH = 163;
        private const int RELEASE_LABEL_X = 69;
        private const int RELEASE_LABEL_X_GAP = 78;
        private const int RELEASE_LABEL_Y = 79;
        private const int RELEASE_LABEL_Y_GAP = 25;

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
                    instance.ControlResizeDebug();
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
                FormLeadGuide.Instance.StartPosition = FormStartPosition.CenterScreen;
                FormLeadGuide.Instance.FormBorderStyle = FormBorderStyle.None;
                FormLeadGuide.Instance.ClientSize = new Size(1920, 1080);
                FormLeadGuide.Instance.WindowState = FormWindowState.Maximized;

                FormLeadGuide.Instance.ShowDialog();
            }

            //税收宣传
            else if (cmd == 4)
            {
                FormTaxPublicity.Instance.StartPosition = FormStartPosition.CenterScreen;
                FormTaxPublicity.Instance.FormBorderStyle = FormBorderStyle.None;
                FormTaxPublicity.Instance.ClientSize = new Size(1920, 1080);
                FormTaxPublicity.Instance.WindowState = FormWindowState.Maximized;
                FormTaxPublicity.Instance.ShowDialog();
            }
            else
            {
                ClickEvent?.Invoke(new Notify
                {
                    Command = cmd
                });
            }
        }

        private void ControlResizeDebug()
        {
            var LabelX = 69;
            var LabelWidth = 163;
            var LabelXGap = 78;
            var LabelY = 79;
            var LabelHeight = 144;
            var LabelYGap = 25;

            var LabelSize = new Size(LabelWidth, LabelHeight);
            var LabelLocation0 = new Point(LabelX + LabelWidth * 0 + LabelXGap * 0, LabelY + LabelHeight * 0 + LabelYGap * 0); //69=69+163*0+78*0; 79=79+144*0+25*0;
            var LabelLocation1 = new Point(LabelX + LabelWidth * 1 + LabelXGap * 1, LabelY + LabelHeight * 0 + LabelYGap * 0); //310=69+163*1+78*1; 79=79+144*0+25*0;
            var LabelLocation2 = new Point(LabelX + LabelWidth * 2 + LabelXGap * 2, LabelY + LabelHeight * 0 + LabelYGap * 0); //555=69+163*2+78*2; 79=79+144*0+25*0;

            var LabelLocation3 = new Point(LabelX + LabelWidth * 0 + LabelXGap * 0, LabelY + LabelHeight * 1 + LabelYGap * 1); //69=69+163*0+78*0; 79=79+144*1+25*1;
            var LabelLocation4 = new Point(LabelX + LabelWidth * 1 + LabelXGap * 1, LabelY + LabelHeight * 1 + LabelYGap * 1); //310=69+163*1+78*1; 79=79+144*1+25*1;
            var LabelLocation5 = new Point(LabelX + LabelWidth * 2 + LabelXGap * 2, LabelY + LabelHeight * 1 + LabelYGap * 1); //310=69+163*2+78*2; 79=79+144*1+25*1;
            ctrlLbl0.Size = ctrlLbl1.Size = ctrlLbl2.Size = ctrlLbl3.Size = ctrlLbl4.Size = ctrlLbl5.Size = LabelSize;
            ctrlLbl0.Location = LabelLocation0;
            ctrlLbl1.Location = LabelLocation1;
            ctrlLbl2.Location = LabelLocation2;
            ctrlLbl3.Location = LabelLocation3;
            ctrlLbl4.Location = LabelLocation4;
            ctrlLbl5.Location = LabelLocation5;
        }

        private void ControlResizeRelease()
        {
            var LabelX = 69;
            var LabelWidth = 163;
            var LabelXGap = 78;
            var LabelY = 79;
            var LabelHeight = 144;
            var LabelYGap = 25;

            var LabelSize = new Size(LabelWidth, LabelHeight);
            var LabelLocation0 = GetLabelPoint(0, 0);
            var LabelLocation1 = GetLabelPoint(1, 0);
            var LabelLocation2 = GetLabelPoint(2, 0);

            var LabelLocation3 = GetLabelPoint(0, 1);
            var LabelLocation4 = GetLabelPoint(1, 1);
            var LabelLocation5 = GetLabelPoint(2, 1);
            ctrlLbl0.Size = ctrlLbl1.Size = ctrlLbl2.Size = ctrlLbl3.Size = ctrlLbl4.Size = ctrlLbl5.Size = LabelSize;
            ctrlLbl0.Location = LabelLocation0;
            ctrlLbl1.Location = LabelLocation1;
            ctrlLbl2.Location = LabelLocation2;
            ctrlLbl3.Location = LabelLocation3;
            ctrlLbl4.Location = LabelLocation4;
            ctrlLbl5.Location = LabelLocation5;
        }

        private Point GetLabelPoint(int lblXIndex, int lblYIndex)
        {
            var LabelX = 69;
            var LabelWidth = 163;
            var LabelXGap = 78;
            var LabelY = 79;
            var LabelHeight = 144;
            var LabelYGap = 25;
            return new Point(LabelX + LabelWidth * lblXIndex + LabelXGap * lblXIndex, LabelY + LabelHeight * lblYIndex + LabelYGap * lblYIndex);
        }

        private void FormMain_Load(object sender, EventArgs e) { }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            notifyIcon1.Dispose();
            FormDisplay.Instance.Close();
            Instance.Close();
            Application.Exit();
        }

        #endregion
    }
}
