using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TouchCore
{
    public partial class Main : Form
    {
        /// <summary>
        /// 修改模式
        /// </summary>
        public bool ChangeMod = false;

        public Main()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //最大化显示
            this.WindowState = FormWindowState.Maximized;

            //设置窗体透明
            this.Opacity = 0.1;
            //this.BackColor = Color.White;
            //this.TransparencyKey = Color.White;

            //设置窗体置顶
            this.TopMost = true;
        }

        //不让程序显示在alt+tab视窗窗体中
        protected override CreateParams CreateParams
        {
            get
            {
                const int WS_EX_APPWINDOW = 0x40000;
                const int WS_EX_TOOLWINDOW = 0x80;
                CreateParams cp = base.CreateParams;
                cp.ExStyle &= (~WS_EX_APPWINDOW);    // 不显示在TaskBar
                cp.ExStyle |= WS_EX_TOOLWINDOW;      // 不显示在Alt+Tab
                return cp;
            }
        }

        /// <summary>
        /// 时间诱发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Activate();
            this.Focus();
            timer1.Stop();
        }

        /// <summary>
        /// 失去焦点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Main_Deactivate(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            if (ChangeMod == false)
            {
                Close();
            }
            else
            {
                this.Opacity = 0.1;
                this.ChangeMod = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Opacity = 1;
            this.ChangeMod = true;
        }
    }
}
