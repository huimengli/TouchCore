using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TouchCore.Project
{
    class Item
    {
        #region 外来代码

        /// <summary>
        /// 该方法可以获取设备的硬件信息，可以通过第二个参数nIndex来指定要查询的具体信息。例如我们要用到的以像素为单位的桌面高度DESKTOPVERTRES。
        /// </summary>
        /// <param name="hdc"></param>
        /// <param name="nIndex"></param>
        /// <returns></returns>
        [DllImport("gdi32.dll", EntryPoint = "GetDeviceCaps", SetLastError = true)]
        public static extern int GetDeviceCaps(IntPtr hdc, int nIndex);


        enum DeviceCap
        {
            VERTRES = 10,
            PHYSICALWIDTH = 110,
            SCALINGFACTORX = 114,
            DESKTOPVERTRES = 117,

            // http://pinvoke.net/default.aspx/gdi32/GetDeviceCaps.html
        }

        /// <summary>
        /// 获取缩放比例
        /// </summary>
        /// <returns></returns>
        private static double GetScreenScalingFactor()
        {
            var g = Graphics.FromHwnd(IntPtr.Zero);
            IntPtr desktop = g.GetHdc();
            var physicalScreenHeight = GetDeviceCaps(desktop, (int)DeviceCap.DESKTOPVERTRES);

            var screenScalingFactor = (double)physicalScreenHeight / Screen.PrimaryScreen.Bounds.Height;//SystemParameters.PrimaryScreenHeight;

            return screenScalingFactor;
        }

        /// <summary>
        /// 获取截图
        /// </summary>
        /// <param name="scaling"></param>
        /// <returns></returns>
        private static Bitmap TakingScreenshotEx1(double scaling = 1)
        {
            Rectangle bounds = Screen.GetBounds(Point.Empty);
            var width = (int)(bounds.Width * scaling);
            var height = (int)(bounds.Height * scaling);
            Bitmap bitmap = new Bitmap(width, height);

            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.CopyFromScreen(Point.Empty, Point.Empty, new Size { Width = width, Height = height });
            }

            return bitmap;
        }

        #endregion
    }
}
