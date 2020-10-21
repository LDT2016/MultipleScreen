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
                FormLeadGuide.Instance.ShowDialog();
            }
            //税收宣传
            else if (cmd == 4)
            {
                FormTaxPublicity.Instance.ShowDialog();
            }
            //区局十大事件
            else if (cmd == 5)
            {
                FormBigEvent.Instance.ShowDialog();
            }
            else
            {
                ClickEvent?.Invoke(new Notify
                {
                    Command = cmd
                });
            }
        }
        public void ResizeSetup()
        {
            ClientSize = new Size(800, 450);
            var labelSize = new Size(152, 132);

            ctrlLbl0.Location = new Point(87, 92);
            ctrlLbl1.Location = new Point(310, 92);
            ctrlLbl2.Location = new Point(533, 92);
            ctrlLbl3.Location = new Point(27, 248);
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
            ctrlLbl3.Location = new Point(61, 586);
            ctrlLbl4.Location = new Point(530, 586);
            ctrlLbl5.Location = new Point(999, 586);
            ctrlLbl6.Location = new Point(1469, 586);
            ctrlLbl0.Size = ctrlLbl1.Size = ctrlLbl2.Size = ctrlLbl3.Size = ctrlLbl4.Size = ctrlLbl5.Size = ctrlLbl6.Size = labelSize;
        }

        //private void ControlResizeDebug1()
        //{
        //    this.panel1.Size = new System.Drawing.Size(800, 450);

        //    var LabelX = 69;
        //    var LabelWidth = 163;
        //    var LabelXGap = 78;
        //    var LabelY = 79;
        //    var LabelHeight = 144;
        //    var LabelYGap = 25;

        //    var LabelSize = new Size(LabelWidth, LabelHeight);
        //    var LabelLocation0 = new Point(LabelX + LabelWidth * 0 + LabelXGap * 0, LabelY + LabelHeight * 0 + LabelYGap * 0); //69=69+163*0+78*0; 79=79+144*0+25*0;
        //    var LabelLocation1 = new Point(LabelX + LabelWidth * 1 + LabelXGap * 1, LabelY + LabelHeight * 0 + LabelYGap * 0); //310=69+163*1+78*1; 79=79+144*0+25*0;
        //    var LabelLocation2 = new Point(LabelX + LabelWidth * 2 + LabelXGap * 2, LabelY + LabelHeight * 0 + LabelYGap * 0); //555=69+163*2+78*2; 79=79+144*0+25*0;

        //    var LabelLocation3 = new Point(LabelX + LabelWidth * 0 + LabelXGap * 0, LabelY + LabelHeight * 1 + LabelYGap * 1); //69=69+163*0+78*0; 79=79+144*1+25*1;
        //    var LabelLocation4 = new Point(LabelX + LabelWidth * 1 + LabelXGap * 1, LabelY + LabelHeight * 1 + LabelYGap * 1); //310=69+163*1+78*1; 79=79+144*1+25*1;
        //    var LabelLocation5 = new Point(LabelX + LabelWidth * 2 + LabelXGap * 2, LabelY + LabelHeight * 1 + LabelYGap * 1); //310=69+163*2+78*2; 79=79+144*1+25*1;
        //    ctrlLbl0.Size = ctrlLbl1.Size = ctrlLbl2.Size = ctrlLbl3.Size = ctrlLbl4.Size = ctrlLbl6.Size = LabelSize;
        //    ctrlLbl0.Location = LabelLocation0;
        //    ctrlLbl1.Location = LabelLocation1;
        //    ctrlLbl2.Location = LabelLocation2;
        //    ctrlLbl3.Location = LabelLocation3;
        //    ctrlLbl4.Location = LabelLocation4;
        //    ctrlLbl6.Location = LabelLocation5;
        //}

        //private void ControlResizeRelease1()
        //{
        //    var LabelX = 69;
        //    var LabelWidth = 163;
        //    var LabelXGap = 78;
        //    var LabelY = 79;
        //    var LabelHeight = 144;
        //    var LabelYGap = 25;

        //    var LabelSize = new Size(LabelWidth, LabelHeight);
        //    var LabelLocation0 = GetLabelPoint(0, 0);
        //    var LabelLocation1 = GetLabelPoint(1, 0);
        //    var LabelLocation2 = GetLabelPoint(2, 0);

        //    var LabelLocation3 = GetLabelPoint(0, 1);
        //    var LabelLocation4 = GetLabelPoint(1, 1);
        //    var LabelLocation5 = GetLabelPoint(2, 1);
        //    ctrlLbl0.Size = ctrlLbl1.Size = ctrlLbl2.Size = ctrlLbl3.Size = ctrlLbl4.Size = ctrlLbl6.Size = LabelSize;
        //    ctrlLbl0.Location = LabelLocation0;
        //    ctrlLbl1.Location = LabelLocation1;
        //    ctrlLbl2.Location = LabelLocation2;
        //    ctrlLbl3.Location = LabelLocation3;
        //    ctrlLbl4.Location = LabelLocation4;
        //    ctrlLbl6.Location = LabelLocation5;
        //}

        //private Point GetLabelPoint(int lblXIndex, int lblYIndex)
        //{
        //    var LabelX = 69;
        //    var LabelWidth = 163;
        //    var LabelXGap = 78;
        //    var LabelY = 79;
        //    var LabelHeight = 144;
        //    var LabelYGap = 25;
        //    return new Point(LabelX + LabelWidth * lblXIndex + LabelXGap * lblXIndex, LabelY + LabelHeight * lblYIndex + LabelYGap * lblYIndex);
        //}

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
