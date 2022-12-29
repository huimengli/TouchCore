using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TouchCore
{
    public partial class Main : Form
    {
        /// <summary>
        /// 摇杆大小
        /// </summary>
        private const int ROCKER_WEIGHT = 300;

        /// <summary>
        /// 修改模式
        /// </summary>
        private bool changeMod = false;

        /// <summary>
        /// 修改模式
        /// </summary>
        public bool ChangeMod
        {
            get
            {
                return changeMod;
            }
            set
            {
                changeMod = value;
                this.NewButton.Visible = value;
            }
        }

        /// <summary>
        /// 左摇杆按下
        /// </summary>
        private bool leftRockerDown = false;

        /// <summary>
        /// 左摇杆按下
        /// </summary>
        public bool LeftRockerDown
        {
            get
            {
                return leftRockerDown;
            }
            set
            {
                leftRockerDown = value;
                if (value)
                {

                }
                else
                {
                    RockerButton.Location = new Point(
                        Rocker.Location.X + ROCKER_WEIGHT / 2,
                        Rocker.Location.Y + ROCKER_WEIGHT / 2
                    );
                }
            }
        }

        /// <summary>
        /// 左摇杆起始点
        /// </summary>
        public Point LeftRockerPoint;

        /// <summary>
        /// 按键按下
        /// </summary>
        const int KEYEVENTF_KEYDOWN = 0;
        /// <summary>
        /// 按键弹起
        /// </summary>
        const int KEYEVENTF_KEYUP = 2;

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

            //设置状态
            this.ChangeMod = false;
        }

        //不让程序显示在alt+tab视窗窗体中
        protected override CreateParams CreateParams
        {
            get
            {
                const int WS_EX_APPWINDOW = 0x40000;
                const int WS_EX_TOOLWINDOW = 0x80;
                const int WS_EX_NOTACTIVATED = 0x08000000;
                CreateParams cp = base.CreateParams;
                cp.ExStyle &= (~WS_EX_APPWINDOW);    // 不显示在TaskBar
                cp.ExStyle |= WS_EX_TOOLWINDOW;      // 不显示在Alt+Tab
                cp.ExStyle |= WS_EX_NOTACTIVATED;      // 不允许被激活
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

        /// <summary>
        /// 关闭按钮函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// 修改按钮函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            this.Opacity = 1;
            this.ChangeMod = true;
        }

        /// <summary>
        /// 鼠标按下函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MouseDownFunction(object sender,MouseEventArgs e)
        {
            if (ChangeMod == false)
            {
                var button = (Button)sender;
                Console.WriteLine(button.Text);
                byte keyValue = Encoding.ASCII.GetBytes(button.Text)[0];
                keybd_event(keyValue, 0, KEYEVENTF_KEYDOWN, 0);//按键按下 
            }
        }

        /// <summary>
        /// 鼠标按下函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MouseUpFunction(object sender,MouseEventArgs e)
        {
            if (ChangeMod == false)
            {
                var button = (Button)sender;
                Console.WriteLine(button.Text);
                byte keyValue = Encoding.ASCII.GetBytes(button.Text)[0];
                keybd_event(keyValue, 0, KEYEVENTF_KEYUP, 0);//按键弹起 
            }
        }

        /// <summary>
        /// 键盘模拟事件
        /// </summary>
        /// <param name="bVk"></param>
        /// <param name="bScan"></param>
        /// <param name="dwFlags"></param>
        /// <param name="dwExtraInfo"></param>
        [DllImport("user32.dll", EntryPoint = "keybd_event", SetLastError = true)]
        public static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, uint dwExtraInfo);

        /// <summary>
        /// 左摇杆鼠标按下事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LeftRockerMouseDown(object sender,MouseEventArgs e)
        {
            LeftRockerDown = true;
            LeftRockerPoint = new Point(
                Rocker.Location.X + ROCKER_WEIGHT / 2,
                Rocker.Location.Y + ROCKER_WEIGHT / 2
            );
        }

        /// <summary>
        /// 左摇杆鼠标移动事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LeftRockerMouseMove(object sender,MouseEventArgs e)
        {
            if (LeftRockerDown)
            {
                var nowPoint = new Point(e.X,e.Y);
                this.RockerButton.Location = nowPoint;
            }
        }

        /// <summary>
        /// 左摇杆鼠标抬起事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LeftRockerMouseUp(object sender,MouseEventArgs e)
        {
            LeftRockerDown = false;
        }
    }
}
