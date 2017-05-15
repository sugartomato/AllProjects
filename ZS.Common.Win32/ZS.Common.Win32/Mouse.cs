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
            MoveTo(pt, 80);
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
            }
            else
            {
                double slope = 0;
                if (targetPt.Y > currentPt.Y && targetPt.X > currentPt.X) // 左上到右下
                //if (true)
                {
                    // 计算斜率
                    slope = Math.Abs((double)(targetPt.Y - currentPt.Y) / (targetPt.X - currentPt.X));
                    Int32 lastX = currentPt.X;
                    Int32 lastY = currentPt.Y;
                    while (lastX <= targetPt.X)
                    {
                        lastX += step;
                        Int32 y = (Int32)(targetPt.Y - slope * (targetPt.X - lastX));
                        ZS.Common.Win32.API.mouse_event(Win32.API.MouseEvent.MOUSEEVENTF_MOVE, step, y - lastY, 0, UIntPtr.Zero);
                        lastY = y;
                        System.Threading.Thread.Sleep(delay);
                    }
                }
                if (targetPt.Y < currentPt.Y && targetPt.X < currentPt.X) // 右下到左上
                {
                    // 计算斜率
                    slope = Math.Abs((double)(targetPt.Y - currentPt.Y) / (targetPt.X - currentPt.X));
                    Int32 lastX = currentPt.X;
                    Int32 lastY = currentPt.Y;
                    while (lastX >= targetPt.X)
                    {
                        lastX += -step;
                        Int32 y = (Int32)(targetPt.Y - slope * (targetPt.X - lastX));
                        ZS.Common.Win32.API.mouse_event(Win32.API.MouseEvent.MOUSEEVENTF_MOVE, -step, y - lastY, 0, UIntPtr.Zero);
                        lastY = y;
                        System.Threading.Thread.Sleep(delay);
                    }
                }
                if (targetPt.X > currentPt.X && targetPt.Y < currentPt.Y) // 左下到右上
                {
                    // 计算斜率
                    slope =Math.Abs((double)(targetPt.Y - currentPt.Y) / (targetPt.X - currentPt.X));
                    Int32 lastX = currentPt.X;
                    Int32 lastY = currentPt.Y;
                    while (lastX <= targetPt.X)
                    {
                        lastX += step;
                        Int32 y = (Int32)(targetPt.Y - slope * (targetPt.X - lastX));
                        ZS.Common.Win32.API.mouse_event(Win32.API.MouseEvent.MOUSEEVENTF_MOVE, step, y - lastY, 0, UIntPtr.Zero);
                        lastY = y;
                        System.Threading.Thread.Sleep(delay);
                    }
                }

                if (targetPt.X < currentPt.X && targetPt.Y > currentPt.Y) // 右上到左下
                {
                    // 计算斜率
                    slope = Math.Abs((double)(targetPt.Y - currentPt.Y) / (targetPt.X - currentPt.X));
                    Int32 lastX = currentPt.X;
                    Int32 lastY = currentPt.Y;
                    while (lastX >= targetPt.X)
                    {
                        lastX += -step;
                        Int32 y = (Int32)(targetPt.Y - slope * (targetPt.X - lastX));
                        ZS.Common.Win32.API.mouse_event(Win32.API.MouseEvent.MOUSEEVENTF_MOVE, -step, y - lastY, 0, UIntPtr.Zero);
                        lastY = y;
                        System.Threading.Thread.Sleep(delay);
                    }
                }

            }

            return;

            System.Drawing.Point target = targetPt;
            Int32 count = 100;
            while (count != 0)
            {
                Int32 stepX = (target.X - currentPt.X) / count;
                Int32 stepY = (target.Y - currentPt.Y) / count;
                count--;
                if (count != 0)
                {
                    ZS.Common.Win32.API.mouse_event(Win32.API.MouseEvent.MOUSEEVENTF_MOVE, stepX, stepY, 0, UIntPtr.Zero);
                    System.Threading.Thread.Sleep(delay);
                }
            }
        }

    }
}
