using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace TouchCore.Project
{
    /// <summary>
    /// 模拟类
    /// </summary>
    public static class Imitate
    {
        /// <summary>
        /// 等待系统反应的时间(单位:毫秒)
        /// </summary>
        private static readonly int WAITTIME = 100;

        /// <summary>
        /// 模拟按键
        /// </summary>
        public sealed class KeyBoard 
        {
            /// <summary>
            /// 释放按键
            /// </summary>
            const int KEYEVENTF_KEYUP = 0x2;

            /// <summary>
            /// 虚拟按钮
            /// </summary>
            /// <param name="bVk">定义一个虚拟键码。键码值必须在1～254之间</param>
            /// <param name="bScan">定义该键的硬件扫描码</param>
            /// <param name="dwFlags">定义函数操作的各个方面的一个标志位集。应用程序可使用如下一些预定义常数的组合设置标志位</param>
            /// <param name="dwExtraInfo">定义与击键相关的附加的32位值</param>
            [DllImport("user32.dll")]
            private static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, int dwExtraInfo);

            /// <summary>
            /// 按下按钮
            /// </summary>
            /// <param name="ButtonKey"></param>
            public static void PressButton(byte ButtonValueKey)
            {
                keybd_event(ButtonValueKey, 0, 0, 0);//按下按键
                Thread.Sleep(WAITTIME);//延时一下,防止系统无法识别
                keybd_event(ButtonValueKey, 0, KEYEVENTF_KEYUP, 0);
            }

            /// <summary>
            /// 按下按钮
            /// </summary>
            /// <param name="ButtonValueKey"></param>
            public static void PressButton(int ButtonValueKey)
            {
                if (ButtonValueKey>255||ButtonValueKey<0)
                {
                    return;
                }
                PressButton((byte)ButtonValueKey);
            }

            /// <summary>
            /// 按下组合按钮
            /// </summary>
            /// <param name="Button1"></param>
            /// <param name="Button2"></param>
            public static void PressButton(params byte[] ButtonValueKeys)
            {
                for (int i = 0; i < ButtonValueKeys.Length; i++)
                {
                    keybd_event(ButtonValueKeys[i], 0, 0, 0);
                }
                Thread.Sleep(WAITTIME);
                for (int i = 0; i < ButtonValueKeys.Length; i++)
                {
                    keybd_event(ButtonValueKeys[i], 0, KEYEVENTF_KEYUP, 0);
                }
            }

            /// <summary>
            /// 按下按键(直接查找字典)
            /// </summary>
            /// <param name="keyName"></param>
            public static void PressButton(string keyName)
            {
                var key = (KeyCodeDict)Enum.Parse(typeof(KeyCodeDict), keyName);
                PressButton((byte)key);
            }

            /// <summary>
            /// 连续按下对应按钮
            /// </summary>
            /// <param name="Value"></param>
            public static string PressValue(string Value)
            {
                var keyValue = Encoding.ASCII.GetBytes(Value);//无法识别的字符直接转化成问号
                for (int i = 0; i < keyValue.Length; i++)
                {
                    var key = keyValue[i];
                    switch (key)
                    {
                        case 43:
                            PressButton((byte)KeyCodeDict.OEM_PLUS);
                            break;
                        case 48:
                        case 49:
                        case 50:
                        case 51:
                        case 52:
                        case 53:
                        case 54:
                        case 55:
                        case 56:
                        case 57:
                            PressButton(key);
                            break;
                        case 65:
                        case 66:
                        case 67:
                        case 68:
                        case 69:
                        case 70:
                        case 71:
                        case 72:
                        case 73:
                        case 74:
                        case 75:
                        case 76:
                        case 77:
                        case 78:
                        case 79:
                        case 80:
                        case 81:
                        case 82:
                        case 83:
                        case 84:
                        case 85:
                        case 86:
                        case 87:
                        case 88:
                        case 89:
                        case 90:
                            PressButton((byte)KeyCodeDict.LShift, key);
                            break;
                        case 97:
                        case 98:
                        case 99:
                        case 100:
                        case 101:
                        case 102:
                        case 103:
                        case 104:
                        case 105:
                        case 106:
                        case 107:
                        case 108:
                        case 109:
                        case 110:
                        case 111:
                        case 112:
                        case 113:
                        case 114:
                        case 115:
                        case 116:
                        case 117:
                        case 118:
                        case 119:
                        case 120:
                        case 121:
                        case 122:
                            PressButton((byte)(key&0xdf));
                            break;
                        default:
                            break;
                    }
                }
                return "";
            }

            /// <summary>
            /// 按下按键
            /// (不会自动弹起)
            /// </summary>
            /// <param name="ButtonValueKey"></param>
            /// <returns></returns>
            public static void OnKeyDown(byte ButtonValueKey)
            {
                keybd_event(ButtonValueKey, 0, 0, 0);
            }

            /// <summary>
            /// 松开按键
            /// </summary>
            /// <param name="ButtonValueKey"></param>
            public static void OnKeyUp(byte ButtonValueKey)
            {
                keybd_event(ButtonValueKey, 0, KEYEVENTF_KEYUP, 0);
            }

            ///// <summary>
            ///// 键位目录
            ///// </summary>
            //public Dictionary<string, byte> KeyCodeDict = new Dictionary<string, byte> {
            //    { "mouseLeftButton",1 },
            //    {"mouseRightButton",2 },
            //    {"Cancel",3 },
            //};

            /// <summary>
            /// 键位目录
            /// </summary>
            public enum KeyCodeDict
            {
                /// <summary>
                /// 空按键
                /// </summary>
                None = 0,
                /// <summary>
                /// 鼠标左键
                /// </summary>
                MouseLeftButton = 1,
                /// <summary>
                /// 鼠标右键
                /// </summary>
                MouseRightButton = 2,
                Cancel = 3,
                /// <summary>
                /// 鼠标中键
                /// </summary>
                MouseMiddleButton = 4,
                /// <summary>
                /// 删除
                /// </summary>
                BackSpace = 8,
                Tab = 9,
                Clear = 12,
                Enter = 13,
                Shift = 16,
                Ctrl = 17,
                Alt = 18,
                Pause = 19,
                CapsLock = 20,
                Esc = 27,
                Space = 32,
                PageUp = 33,
                PageDown = 34,
                End = 35,
                Home = 36,
                LeftArrow = 37,
                UpArrow=38,
                RightArrow=39,
                DownArrow=40,
                Select=41,
                Print=42,
                Execute=43,
                Snapshot=44,
                Insert=45,
                Delete=46,
                Help=47,

                Key0,
                Key1,
                Key2,
                Key3,
                Key4,
                Key5,
                Key6,
                Key7,
                Key8,
                Key9,

                KeyA=65,
                KeyB,
                KeyC,
                KeyD,
                KeyE,
                KeyF,
                KeyG,
                KeyH,
                KeyI,
                KeyJ,
                KeyK,
                KeyL,
                KeyM,
                KeyN,
                KeyO,
                KeyP,
                KeyQ,
                KeyR,
                KeyS,
                KeyT,
                KeyU,
                KeyV,
                KeyW,
                KeyX,
                KeyY,
                KeyZ,

                LWin,
                RWin,
                Apps,
                Sleep=95,

                Keypad0,
                Keypad1,
                Keypad2,
                Keypad3,
                Keypad4,
                Keypad5,
                Keypad6,
                Keypad7,
                Keypad8,
                Keypad9,
                /// <summary>
                /// 小键盘星号
                /// </summary>
                KeypadStar,
                /// <summary>
                /// 小键盘加号
                /// </summary>
                KeypadAdd,
                /// <summary>
                /// 小键盘回车
                /// </summary>
                KeypadEnter,
                /// <summary>
                /// 小键盘减号
                /// </summary>
                KeypadSub,
                /// <summary>
                /// 小键盘点号
                /// </summary>
                KeypadPoint,
                /// <summary>
                /// 小键盘除号
                /// </summary>
                KeypadDiv,

                F1,
                F2,
                F3,
                F4,
                F5,
                F6,
                F7,
                F8,
                F9,
                F10,
                F11,
                F12,


                #region 不常见的

                F13,
                F14,
                F15,
                F16,
                F17,
                F18,
                F19,
                F20,
                F21,
                F22,
                F23,
                F24, 

                #endregion

                NumLock=144,
                Scroll,

                LShift=160,
                RShift,
                LCtrl,
                RCtrl,
                LMenu,
                RMenu,

                VolumeMute = 173,
                VolumeDown,
                VolumeUp,

                /// <summary>
                /// ;:
                /// </summary>
                OEM_1 = 186,
                /// <summary>
                /// =+
                /// </summary>
                OEM_PLUS,
                OEM_COMMA,
                /// <summary>
                /// -_
                /// </summary>
                OEM_MINUS,
                OEM_PERIOD,
                /// <summary>
                /// /?
                /// </summary>
                OEM_2,
                /// <summary>
                /// `~
                /// </summary>
                OEM_3,
                /// <summary>
                /// [{
                /// </summary>
                OEM_4 = 219,
                /// <summary>
                /// \|
                /// </summary>
                OEM_5,
                /// <summary>
                /// ]}
                /// </summary>
                OEM_6,
                /// <summary>
                /// '"
                /// </summary>
                OEM_7,
                OEM_8,

            }
        }

        /// <summary>
        /// 模拟鼠标
        /// </summary>
        public sealed class Mouse
        {
            [DllImport("user32.dll")]
            static extern bool SetCursorPos(int x, int y);

            [DllImport("user32.dll")]
            static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);

            /// <summary>
            /// 模拟鼠标左键按下
            /// </summary>
            private static readonly int MOUSEEVENTF_LEFTDOWN = 0x0002;
            /// <summary>
            /// 模拟鼠标移动
            /// </summary>
            private static readonly int MOUSEEVENTF_MOVE = 0x0001;
            /// <summary>
            /// 模拟鼠标左键抬起
            /// </summary>
            private static readonly int MOUSEEVENTF_LEFTUP = 0x0004;
            /// <summary>
            /// 鼠标绝对位置
            /// </summary>
            private static readonly int MOUSEEVENTF_ABSOLUTE = 0x8000;
            /// <summary>
            /// 模拟鼠标右键按下
            /// </summary>
            private static readonly int MOUSEEVENTF_RIGHTDOWN = 0x0008;
            /// <summary>
            /// 模拟鼠标右键抬起
            /// </summary>
            private static readonly int MOUSEEVENTF_RIGHTUP = 0x0010;
            /// <summary>
            /// 模拟鼠标中键按下
            /// </summary>
            private static readonly int MOUSEEVENTF_MIDDLEDOWN = 0x0020;
            /// <summary>
            /// 模拟鼠标中键抬起
            /// </summary>
            private static readonly int MOUSEEVENTF_MIDDLEUP = 0x0040;

            /// <summary>
            /// 真实桌面大小
            /// </summary>
            private static readonly Size DESKTOP = ImageProcessing.DESKTOP;
            
            #region 绝对鼠标移动操作
            /// <summary>
            /// 绝对鼠标按下
            /// </summary>
            /// <param name="x"></param>
            /// <param name="y"></param>
            public static void AbsoluteMouseDown(int x, int y, MouseButton button)
            {
                switch (button)
                {
                    case MouseButton.MouseLeft:
                        mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_ABSOLUTE, x * 65535 / DESKTOP.Width, y * 65535 / DESKTOP.Height, 0, 0);//点击    
                        break;
                    case MouseButton.MouseMiddle:
                        mouse_event(MOUSEEVENTF_MIDDLEDOWN | MOUSEEVENTF_ABSOLUTE, x * 65535 / DESKTOP.Width, y * 65535 / DESKTOP.Height, 0, 0);//点击    
                        break;
                    case MouseButton.MouseRight:
                        mouse_event(MOUSEEVENTF_RIGHTDOWN | MOUSEEVENTF_ABSOLUTE, x * 65535 / DESKTOP.Width, y * 65535 / DESKTOP.Height, 0, 0);//点击    
                        break;
                    default:
                        break;
                }
            }

            /// <summary>
            /// 绝对鼠标移动
            /// </summary>
            /// <param name="x"></param>
            /// <param name="y"></param>
            public static void AbsoluteMouseMove(int x, int y)
            {
                mouse_event(MOUSEEVENTF_MOVE | MOUSEEVENTF_ABSOLUTE, x * 65535 / DESKTOP.Width, y * 65535 / DESKTOP.Height, 0, 0);//移动到需要点击的位置           
            }

            /// <summary>
            /// 绝对鼠标抬起
            /// </summary>
            /// <param name="x"></param>
            /// <param name="y"></param>
            public static void AbsoluteMouseUp(int x, int y, MouseButton button)
            {
                switch (button)
                {
                    case MouseButton.MouseLeft:
                        mouse_event(MOUSEEVENTF_LEFTUP | MOUSEEVENTF_ABSOLUTE, x * 65535 / DESKTOP.Width, y * 65535 / DESKTOP.Height, 0, 0);//抬起
                        break;
                    case MouseButton.MouseMiddle:
                        mouse_event(MOUSEEVENTF_MIDDLEUP | MOUSEEVENTF_ABSOLUTE, x * 65535 / DESKTOP.Width, y * 65535 / DESKTOP.Height, 0, 0);//抬起
                        break;
                    case MouseButton.MouseRight:
                        mouse_event(MOUSEEVENTF_RIGHTUP | MOUSEEVENTF_ABSOLUTE, x * 65535 / DESKTOP.Width, y * 65535 / DESKTOP.Height, 0, 0);//抬起
                        break;
                    default:
                        break;
                }
            }

            /// <summary>
            /// 绝对鼠标点击
            /// </summary>
            /// <param name="x"></param>
            /// <param name="y"></param>
            /// <param name="button"></param>
            public static void AbsoluteMousePress(int x,int y,MouseButton button)
            {
                AbsoluteMouseMove(x, y);
                AbsoluteMouseDown(x, y, button);
                Thread.Sleep(WAITTIME);
                AbsoluteMouseUp(x, y, button);
            }

            /// <summary>
            /// 绝对鼠标多次点击
            /// </summary>
            /// <param name="x"></param>
            /// <param name="y"></param>
            /// <param name="button"></param>
            public static void AbsoluteMouseMorePress(int x,int y,MouseButton button,int times=2)
            {
                AbsoluteMouseMove(x, y);
                AbsoluteMouseDown(x, y, button);
                Thread.Sleep(WAITTIME);
                AbsoluteMouseUp(x, y, button);
                for (int i = 1; i < times; i++)
                {
                    //多次点击
                    Thread.Sleep(WAITTIME);
                    AbsoluteMouseDown(x, y, button);
                    Thread.Sleep(WAITTIME);
                    AbsoluteMouseUp(x, y, button);
                }
            }

            /// <summary>
            /// 绝对鼠标拖动
            /// </summary>
            public static void AbsoluteMousePress(int x1,int y1,int x2,int y2)
            {
                AbsoluteMouseMove(x1, y1);
                AbsoluteMouseDown(x1, y1, MouseButton.MouseLeft);
                Thread.Sleep(WAITTIME);
                AbsoluteMouseMove(x2, y2);
                AbsoluteMouseUp(x2, y2, MouseButton.MouseLeft);
            }

            /// <summary>
            /// 绝对鼠标拖动
            /// </summary>
            /// <param name="p1"></param>
            /// <param name="p2"></param>
            public static void AbsoluteMousePress(Size p1,Size p2)
            {
                AbsoluteMousePress(p1.Width, p1.Height, p2.Width, p2.Height);
            }

            #endregion
            #region 相对鼠标移动操作(对应与鼠标当前位置)
            /// <summary>
            /// 相对鼠标移动
            /// </summary>
            /// <param name="x"></param>
            /// <param name="y"></param>
            public static void RelativeMouseMove(int x, int y)
            {
                mouse_event(MOUSEEVENTF_MOVE, x, y, 0, 0); //移动    
            }

            /// <summary>
            /// 相对鼠标按下
            /// </summary>
            /// <param name="x"></param>
            /// <param name="y"></param>
            /// <param name="button"></param>
            public static void RelativeMouseDown(int x, int y, MouseButton button)
            {
                switch (button)
                {
                    case MouseButton.MouseLeft:
                        mouse_event(MOUSEEVENTF_LEFTDOWN, x, y, 0, 0);//点击   
                        break;
                    case MouseButton.MouseMiddle:
                        mouse_event(MOUSEEVENTF_MIDDLEDOWN, x, y, 0, 0);//点击   
                        break;
                    case MouseButton.MouseRight:
                        mouse_event(MOUSEEVENTF_RIGHTDOWN, x, y, 0, 0);//点击   
                        break;
                    default:
                        break;
                }
            }

            /// <summary>
            /// 相对鼠标按下
            /// </summary>
            /// <param name="x"></param>
            /// <param name="y"></param>
            /// <param name="button"></param>
            public static void RelativeMouseUp(int x, int y, MouseButton button)
            {
                switch (button)
                {
                    case MouseButton.MouseLeft:
                        mouse_event(MOUSEEVENTF_LEFTUP, x, y, 0, 0);//抬起
                        break;
                    case MouseButton.MouseMiddle:
                        mouse_event(MOUSEEVENTF_MIDDLEUP, x, y, 0, 0);//抬起
                        break;
                    case MouseButton.MouseRight:
                        mouse_event(MOUSEEVENTF_RIGHTUP, x, y, 0, 0);//抬起
                        break;
                    default:
                        break;
                }
            }

            /// <summary>
            /// 相对鼠标点击
            /// </summary>
            /// <param name="x"></param>
            /// <param name="y"></param>
            /// <param name="button"></param>
            public static void RelativeMousePress(int x, int y, MouseButton button)
            {
                RelativeMouseMove(x, y);
                RelativeMouseDown(x, y, button);
                Thread.Sleep(WAITTIME);
                RelativeMouseUp(x, y, button);
            }

            /// <summary>
            /// 相对鼠标点击
            /// </summary>
            /// <param name="x"></param>
            /// <param name="y"></param>
            /// <param name="button"></param>
            public static void RelativeMouseMorePress(int x, int y, MouseButton button,int times=2)
            {
                RelativeMouseMove(x, y);
                RelativeMouseDown(x, y, button);
                Thread.Sleep(WAITTIME);
                RelativeMouseUp(x, y, button);
                for (int i = 1; i < times; i++)
                {
                    //多次点击
                    Thread.Sleep(WAITTIME);
                    RelativeMouseDown(x, y, button);
                    Thread.Sleep(WAITTIME);
                    RelativeMouseUp(x, y, button);
                }
            }

            #endregion
            /// <summary>
            /// 鼠标按键
            /// </summary>
            public enum MouseButton
            {
                /// <summary>
                /// 不按按键
                /// </summary>
                None=-1,
                /// <summary>
                /// 鼠标左键
                /// </summary>
                MouseLeft,
                /// <summary>
                /// 鼠标中键
                /// </summary>
                MouseMiddle,
                /// <summary>
                /// 鼠标右键
                /// </summary>
                MouseRight,
            }
        }

        /// <summary>
        /// 转为字典
        /// </summary>
        /// <param name="dict"></param>
        /// <returns></returns>
        public static Dictionary<string,byte> ToDict(this KeyBoard.KeyCodeDict dic)
        {
            return Enum.GetValues(typeof(KeyBoard.KeyCodeDict)).Cast<KeyBoard.KeyCodeDict>().ToDictionary(t => t.ToString(), t => (byte)t);
        }
    }
}
