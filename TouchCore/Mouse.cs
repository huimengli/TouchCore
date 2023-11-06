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
    public partial class Mouse : Form
    {
        public Mouse()
        {
            InitializeComponent();
        }

        private void Mouse_Resize(object sender, EventArgs e)
        {
            LeftMouse.Width = Width / 2 - 2;
            LeftMouse.Height = Height / 4 - 1;
            LeftMouse.Left = 1;
            LeftMouse.Top = Height - LeftMouse.Height - 1;

            RightMouse.Width = LeftMouse.Width;
            RightMouse.Height = LeftMouse.Height;
            RightMouse.Left = Width / 2 + 1;
            RightMouse.Top = Height - RightMouse.Height - 1;

            ExitButton.Width = Height / 15;
            ExitButton.Height = Height / 15;
            ExitButton.Left = Height / 50;
            ExitButton.Top = Height / 50;
            var newSize = Height / 30;
            ExitButton.Font = new Font(ExitButton.Font.FontFamily,newSize,ExitButton.Font.Style);
        }
    }
}
