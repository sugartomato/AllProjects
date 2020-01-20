using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZS.Common.Win32
{
	public class Window
	{

		#region 查找窗口

		public class WindowSearcher
		{
			public String Title { get; set; } = null;
			public Boolean IsTitleFullMatch { get; set; } = false;
			public String Class { get; set; } = null;
			public IntPtr Parent { get; set; } = IntPtr.Zero;

			public WindowSearcher() { }
			public WindowSearcher(String title)
			{
				this.Title = title;
			}
			public WindowSearcher(IntPtr parent, String title)
			{
				this.Parent = parent;
				this.Title = title;
			}

			private IntPtr Result = IntPtr.Zero;
			public IntPtr Find()
			{
				ZS.Common.Win32.API.EnumChildWindows(Parent, new Win32.API.EnumChildProc(EnumChildWindowProc), 0);
				return Result;
			}

			private Boolean EnumChildWindowProc(IntPtr hwnd, Int32 lparam)
			{
				if (hwnd != IntPtr.Zero)
				{
					// 找到该句柄的窗
					String className = Win32.API.GetClassName(hwnd);
					String text = Win32.API.GetWindowText(hwnd);

					if (String.IsNullOrEmpty(Title) && String.IsNullOrEmpty(Class))
					{
						return true;
					}
					else if (!String.IsNullOrEmpty(Title) && string.IsNullOrEmpty(Class))
					{
						if (IsTitleFullMatch)
						{
							if (text == Title) Result = hwnd;
							return true;
						}
						else
						{
							if (text.Contains(Title)) Result = hwnd;
							return true;
						}

					}
					else if (String.IsNullOrEmpty(Title) && !String.IsNullOrEmpty(Class))
					{
						if (className == Class) Result = hwnd;
						return true;
					}
					else
					{

					}


				}
				return true;
			}

		}
		#endregion

		/// <summary>
		/// 模糊查找某个窗口下的包含指定名称的子窗口
		/// </summary>
		/// <param name="parent"></param>
		/// <param name="title"></param>
		/// <returns></returns>
		public static IntPtr FindWindow(IntPtr parent, String title)
		{
			WindowSearcher s = new WindowSearcher();
			s.Parent = parent;
			s.Title = title;
			return s.Find();
		}

	}
}
