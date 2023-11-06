using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.CompilerServices;
using System.IO;

namespace TouchCore.Project
{
    class Item
    {
#if DEBUG
        public static void Log(string text,
                [CallerFilePath] string file = "",
                [CallerMemberName] string member = "",
                [CallerLineNumber] int line = 0)
        {
            Console.WriteLine("{0}({1})[{2}]: {3}", Path.GetFileName(file), member, line, text);
        }
#else
        public static void Log(string text,
                string file = "",
                string member = "",
                int line = 0)
        {
            Console.WriteLine(text);
        }
#endif


    }
}
