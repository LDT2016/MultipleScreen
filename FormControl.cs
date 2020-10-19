using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Forms;

namespace MultipleScreen
{
    public partial class FormControl : Form
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


        private static FormControl instance;
        public static FormControl Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new FormControl();
                }
                return instance;
            }
        }

        public delegate void ClickDelegateHander(Notify message);

        public event ClickDelegateHander ClickEvent;

        public FormControl()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           // ClickEvent?.Invoke(new Notify(){DeviceStatus = ""});
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // ClickEvent?.Invoke(new Notify(){DeviceStatus = ""});
        }

    }
}
