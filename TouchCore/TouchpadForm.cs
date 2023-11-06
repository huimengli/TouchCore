using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

public partial class TouchpadForm : Form
{
    [DllImport("user32.dll", SetLastError = true)]
    static extern uint SendInput(uint nInputs, ref INPUT pInputs, int cbSize);

    [StructLayout(LayoutKind.Sequential)]
    struct INPUT
    {
        public uint type;
        public MOUSEKEYBDHARDWAREINPUT mkhi;
    }

    [StructLayout(LayoutKind.Explicit)]
    struct MOUSEKEYBDHARDWAREINPUT
    {
        [FieldOffset(0)]
        public MOUSEINPUT mi;
    }

    [StructLayout(LayoutKind.Sequential)]
    struct MOUSEINPUT
    {
        public int dx;
        public int dy;
        public uint mouseData;
        public uint dwFlags;
        public uint time;
        public IntPtr dwExtraInfo;
    }

    const uint INPUT_MOUSE = 0;
    const uint MOUSEEVENTF_ABSOLUTE = 0x8000;
    const uint MOUSEEVENTF_MOVE = 0x0001;

    // 用于转换鼠标移动距离
    public const int MOUSEEVENTF_VIRTUALDESK = 0x4000;
    public const int SM_CXVIRTUALSCREEN = 78;
    public const int SM_CYVIRTUALSCREEN = 79;
    
    private Panel touchPanel;

    [DllImport("user32.dll")]
    static extern int GetSystemMetrics(int nIndex);

    private int screenWidth = GetSystemMetrics(SM_CXVIRTUALSCREEN);
    private int screenHeight = GetSystemMetrics(SM_CYVIRTUALSCREEN);
   
    private void TouchPanel_MouseDown(object sender, MouseEventArgs e)
    {
        // 可以在这里处理按下的事件，例如模拟鼠标按下
    }

    private void TouchPanel_MouseMove(object sender, MouseEventArgs e)
    {
        // 当用户在 Panel 上移动时，模拟鼠标移动
        if (e.Button == MouseButtons.Left) // 假设按住鼠标左键移动相当于触摸移动
        {
            MoveMouse(e.X, e.Y);
        }
    }

    private void TouchPanel_MouseUp(object sender, MouseEventArgs e)
    {
        // 可以在这里处理抬起的事件，例如模拟鼠标抬起
    }

    private void MoveMouse(int x, int y)
    {
        // 这里你需要将 Panel 中的坐标转换为屏幕坐标
        // 这只是一个简单的比例转换示例
        int screenX = x * SystemInformation.VirtualScreen.Width / touchPanel.Width;
        int screenY = y * SystemInformation.VirtualScreen.Height / touchPanel.Height;

        // 使用 SendInput API 发送移动
        // 这里只是一个简单的调用示例，实际的实现可能需要考虑坐标转换和相对移动
        INPUT input = new INPUT();
        input.type = INPUT_MOUSE;
        input.mkhi.mi.dx = screenX;
        input.mkhi.mi.dy = screenY;
        input.mkhi.mi.dwFlags = MOUSEEVENTF_ABSOLUTE | MOUSEEVENTF_MOVE;

        SendInput(1, ref input, Marshal.SizeOf(input));
    }


    private void PanelTouch_MouseMove(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left) // 假设按住左键移动是触摸移动
        {
            // 转换 panel 上的坐标到屏幕坐标
            float dx = (e.X / (float)touchPanel.Width) * screenWidth;
            float dy = (e.Y / (float)touchPanel.Height) * screenHeight;

            INPUT input = new INPUT();
            input.type = INPUT_MOUSE;
            input.mkhi.mi.dx = (int)dx;
            input.mkhi.mi.dy = (int)dy;
            input.mkhi.mi.dwFlags = MOUSEEVENTF_MOVE | MOUSEEVENTF_VIRTUALDESK;

            SendInput(1, ref input, Marshal.SizeOf(input));
        }
    }

    private void InitializeComponent()
    {
            this.touchPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // touchPanel
            // 
            this.touchPanel.Location = new System.Drawing.Point(13, 13);
            this.touchPanel.Name = "touchPanel";
            this.touchPanel.Size = new System.Drawing.Size(200, 100);
            this.touchPanel.TabIndex = 0;
            // 
            // TouchpadForm
            // 
            this.ClientSize = new System.Drawing.Size(1600, 900);
            this.Controls.Add(this.touchPanel);
            this.Name = "TouchpadForm";
            this.Load += new System.EventHandler(this.TouchpadForm_Load);
            this.ResumeLayout(false);

    }

    private void TouchpadForm_Load(object sender, EventArgs e)
    {
        InitializeComponent();

        touchPanel.Dock = DockStyle.Fill; // 让 Panel 填满窗体
        Controls.Add(touchPanel);

        // 添加事件处理器
        touchPanel.MouseDown += TouchPanel_MouseDown;
        touchPanel.MouseMove += TouchPanel_MouseMove;
        touchPanel.MouseUp += TouchPanel_MouseUp;
    }
}