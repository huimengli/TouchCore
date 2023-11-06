using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TouchCore.Project
{
    /// <summary>
    /// 重复任务
    /// </summary>
    public class RepeatingTasks
    {
        /// <summary>
        /// 重复执行的命令
        /// </summary>
        private static List<DelayFunction> Intervals = new List<DelayFunction> { };

        /// <summary>
        /// 延时执行的命令
        /// </summary>
        private static List<DelayFunction> Timeouts = new List<DelayFunction> { };

        /// <summary>
        /// 延迟功能头
        /// 
        /// 传入参数
        /// 1.当前时间戳
        /// 2.执行次数
        /// 3.等待时间
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public delegate void DelayFunctionHeader(List<string> args);

        /// <summary>
        /// 延迟功能
        /// </summary>
        public sealed class DelayFunction
        {
            /// <summary>
            /// 延时后执行的功能
            /// </summary>
            public DelayFunctionHeader function;

            /// <summary>
            /// 延时时间(毫秒计数)
            /// </summary>
            public int WaitTime;

            /// <summary>
            /// 执行次数
            /// </summary>
            private int index = 0;

            /// <summary>
            /// 执行次数
            /// </summary>
            public int Index
            {
                get
                {
                    return index;
                }
            }

            /// <summary>
            /// 上次执行的时间戳
            /// </summary>
            private long lastTimeStamp;

            /// <summary>
            /// 上次执行的时间戳
            /// </summary>
            public long LastTimeStamp
            {
                get
                {
                    return lastTimeStamp;
                }
            }

            /// <summary>
            /// 构造函数
            /// </summary>
            /// <param name="function"></param>
            /// <param name="waitTime"></param>
            public DelayFunction(DelayFunctionHeader function, int waitTime)
            {
                this.function = function;
                WaitTime = waitTime;
                lastTimeStamp = DateTime.Now.ToFileTimeUtc();
            }

            /// <summary>
            /// 运行功能
            /// </summary>
            public void play()
            {
                function(new List<string> { DateTime.Now.ToFileTimeUtc().ToString(), index.ToString(), WaitTime.ToString() });
                index++;
                lastTimeStamp = DateTime.Now.ToFileTimeUtc();
            }
        }

        /// <summary>
        /// 时间线程
        /// (用于实现重复功能)
        /// </summary>
        public static Thread ClockThread;

        /// <summary>
        /// 时间戳
        /// (用于实现延时功能)
        /// </summary>
        public static long TimeStamp;

        /// <summary>
        /// 重复执行的功能
        /// </summary>
        public static void ClockThreadFunction()
        {
            while (true)
            {
                var now = DateTime.Now.ToFileTimeUtc();

                //检查重复任务
                foreach (var func in Intervals)
                {
                    if (func != null)
                    {
                        if (func.LastTimeStamp + func.WaitTime * 10000 > now)
                        {
                            func.play();
                        }
                    }
                }

                //检查延时任务
                foreach (var func in Timeouts)
                {
                    if (func != null)
                    {
                        if (func.Index == 0 || func.LastTimeStamp + func.WaitTime * 10000 > now)
                        {
                            func.play();
                        }
                    }
                }

                //更新时间戳
                TimeStamp = now;

                //等待10毫秒
                Thread.Sleep(10);
            }
        }

        /// <summary>
        /// 时间戳功能启动
        /// </summary>
        public static void ClockThreadInit()
        {
            var cts = new ThreadStart(ClockThreadFunction);
            ClockThread = new Thread(cts);
            ClockThread.Start();
            TimeStamp = DateTime.Now.ToFileTimeUtc();
        }

        /// <summary>
        /// 设置重复任务
        /// </summary>
        /// <param name="waitTime">毫秒</param>
        /// <returns></returns>
        public static int SetInterval(DelayFunctionHeader delayFunction, int waitTime)
        {
            var func = new DelayFunction(delayFunction, waitTime);
            var ret = Intervals.Count;
            Intervals.Add(func);
            return ret;
        }

        /// <summary>
        /// 设置延时任务
        /// </summary>
        /// <param name="delayFunction"></param>
        /// <param name="waitTime">毫秒</param>
        /// <returns></returns>
        public static int SetTimeout(DelayFunctionHeader delayFunction, int waitTime)
        {
            var func = new DelayFunction(delayFunction, waitTime);
            var ret = Timeouts.Count;
            Timeouts.Add(func);
            return ret;
        }

        /// <summary>
        /// 清除重复任务
        /// </summary>
        /// <param name="ID">重复任务ID</param>
        public static void ClearInterval(int ID)
        {
            if (ID > Intervals.Count || ID < 0)
            {
                return;
            }
            else
            {
                Intervals[ID] = null;
            }
        }

        /// <summary>
        /// 清除延时任务
        /// </summary>
        /// <param name="ID"></param>
        public static void ClearTimeout(int ID)
        {
            if (ID > Timeouts.Count || ID < 0)
            {
                return;
            }
            else
            {
                Timeouts[ID] = null;
            }
        }
    }
}
