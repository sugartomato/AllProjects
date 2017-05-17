using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZS.Common.Win32
{
    /// <summary>
    /// 鼠标
    /// </summary>
    public class Mouse
    {

        /// <summary>
        /// 将鼠标从当前坐标移动到指定坐标。以[]毫秒的移动速度作为间隔。
        /// </summary>
        /// <param name="pt"></param>
        public static void MoveTo(System.Drawing.Point pt)
        {
            MoveTo(pt, 1);
            ////ZS.Common.Win32.API.mouse_event(Win32.API.MouseEvent.MOUSEEVENTF_MOVE, 4, 4, 0, UIntPtr.Zero);
            //ZS.Common.Win32.API.mouse_event(Win32.API.MouseEvent.MOUSEEVENTF_LEFTDOWN, 0, 0, 0, UIntPtr.Zero);
            //System.Threading.Thread.Sleep(100);
            //ZS.Common.Win32.API.mouse_event(Win32.API.MouseEvent.MOUSEEVENTF_LEFTUP, 0, 0, 0, UIntPtr.Zero);
        }

        /// <summary>
        /// 按照指定的速度将鼠标从当前坐标移动到指定坐标
        /// </summary>
        /// <param name="targetPt"></param>
        /// <param name="delay">移动延迟。单位为毫秒</param>
        public static void MoveTo(System.Drawing.Point targetPt, Int32 delay)
        {
            // 获取当前鼠标坐标
            API.POINT currentPt = new API.POINT();
            API.GetCursorPos(ref currentPt);
            Int32 step = 2;

            if (currentPt.X == targetPt.X) // 横坐标相同，既鼠标垂直移动
            {

            }
            else if (currentPt.Y == targetPt.Y) // 纵坐标相同，既鼠标水平移动
            {
                Int32 lastX = currentPt.X;
                if (currentPt.X > targetPt.X) // 向左
                {
                    while (lastX > targetPt.X)
                    {
                        lastX -= step;
                        ZS.Common.Win32.API.mouse_event(Win32.API.MouseEvent.MOUSEEVENTF_MOVE, step, 0, 0, UIntPtr.Zero);
                        System.Threading.Thread.Sleep(delay);
                    }
                }
                if (currentPt.X < targetPt.X) // 向右
                {
                    while (lastX < targetPt.X)
                    {
                        lastX += step;
                        ZS.Common.Win32.API.mouse_event(Win32.API.MouseEvent.MOUSEEVENTF_MOVE, step, 0, 0, UIntPtr.Zero);
                        System.Threading.Thread.Sleep(delay);
                    }
                }
            }
            else
            {
                double slope = 0;
                slope = Math.Abs((double)(targetPt.Y - currentPt.Y) / (targetPt.X - currentPt.X));
                if (targetPt.X > currentPt.X)
                {
                    Int32 lastX = currentPt.X;
                    while (lastX <= targetPt.X)
                    {
                        lastX += step;
                        Int32 stepY = (Int32)(slope * step);
                        if (targetPt.Y < currentPt.Y)
                        {
                            stepY = -stepY;
                        }
                        ZS.Common.Win32.API.mouse_event(Win32.API.MouseEvent.MOUSEEVENTF_MOVE, step, stepY, 0, UIntPtr.Zero);
                        System.Threading.Thread.Sleep(delay);
                    }
                }

                if (targetPt.X < currentPt.X)
                {
                    step = -step;
                    Int32 lastX = currentPt.X;
                    while (lastX >= targetPt.X)
                    {
                        lastX += step;
                        Int32 stepY = (Int32)(slope * Math.Abs(step));
                        if (targetPt.Y < currentPt.Y)
                        {
                            stepY = -stepY;
                        }
                        ZS.Common.Win32.API.mouse_event(Win32.API.MouseEvent.MOUSEEVENTF_MOVE, step, stepY, 0, UIntPtr.Zero);
                        System.Threading.Thread.Sleep(delay);
                    }
                }
                ZS.Common.Win32.API.SetCursorPos(targetPt.X, targetPt.Y);
            }
        }

    }
}
