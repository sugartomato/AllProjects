using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interop;
using System.Runtime.InteropServices;

namespace ZS.WPFControls
{
    public class WindowBase : Window
    {

        /* 参考文章：
         * http://blog.csdn.net/jian200801/article/details/12619379
         * http://www.cnblogs.com/Vito2008/articles/WPF-UIShell-UIFramework-Blink-WmNCHitTest-WmGetMinMaxInfo.html
         * http://www.cnblogs.com/scy251147/archive/2012/07/28/2612670.html
         * https://blogs.msdn.microsoft.com/llobo/2006/08/01/maximizing-window-with-windowstylenone-considering-taskbar/
         * http://blog.csdn.net/smartsmile2012/article/category/1062357
         * http://www.cnblogs.com/Vito2008/articles/WPF-UIShell-UIFramework-Blink-WmNCHitTest-WmGetMinMaxInfo.html
        */

        private readonly ResourceDictionary m_WindowResource = new ResourceDictionary();
        protected ResourceDictionary m_MainStyle = null;
        private string m_ResourcesBasePath = "/ZS.WPFControls;component/Styles/{ResourceName}/Style.xaml";

        /// <summary>主窗口模板</summary>
        private ControlTemplate m_WindowTemplate;

        /// <summary>鼠标坐标</summary>
        private Point m_MousePoint = new Point();
        /// <summary>尺寸修改鼠标定位-窗口拐角宽度</summary>
        private readonly int m_CornerWidth = 12;
        /// <summary>尺寸修改鼠标定位-边框宽度</summary>
        private readonly int m_Thickness = 4;

        /// <summary>标题栏对象</summary>
        private Border m_TitleBar = null;

        public WindowBase()
        {
            // 加载资源
            m_WindowResource.Source = new Uri("ZS.WPFControls;component/Styles/WindowTemplate.xaml", UriKind.Relative);
            this.Resources.MergedDictionaries.Add(m_WindowResource);
            this.Style = (Style)m_WindowResource["WindowStyle"];

            // 加载窗体模板
            m_WindowTemplate = (ControlTemplate)m_WindowResource["WindowTemplate"];
            this.Template = m_WindowTemplate;

            // 窗体Load事件绑定
            this.Loaded += new RoutedEventHandler(WindowBase_Loaded);

            this.StateChanged += WindowBase_StateChanged;

            //this.MaxWidth = SystemParameters.MaximizedPrimaryScreenWidth;
            //this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;

        }

        private void WindowBase_StateChanged(object sender, EventArgs e)
        {
            if (this.WindowState == WindowState.Maximized)
            {
                this.MaxHeight = SystemParameters.MaximumWindowTrackHeight;
            }
        }

        private void WindowBase_Loaded(object sender, RoutedEventArgs e)
        {
            // 默认主题
            if (this.Theme == null || this.Theme == string.Empty) this.Theme = "Default";

            // 获取标题栏对象
            m_TitleBar = (Border)m_WindowTemplate.FindName("TitleBar", this);

            // 标题
            ((TextBlock)m_WindowTemplate.FindName("Toolbar_AppTitle", this)).Text = this.Title;
            // 图标
            ((Image)m_WindowTemplate.FindName("Toolbar_AppIcon", this)).Source = this.Icon;

            // 最大化按钮事件
            ((Button)m_WindowTemplate.FindName("Toolbar_MaxButton", this)).Click += (ts, te) =>
             {
                 this.WindowState = (this.WindowState == WindowState.Normal) ? WindowState.Maximized : WindowState.Normal;
             };

            // 最小化按钮事件
            ((Button)m_WindowTemplate.FindName("Toolbar_MinButton", this)).Click += (ts, te) =>
            {
                this.WindowState = WindowState.Minimized;
            };

            // 关闭按钮事件
            ((Button)m_WindowTemplate.FindName("Toolbar_CloseButton", this)).Click += (ts, te) => { this.Close(); };

            // 标题栏双击事件：最大化和还原


            // 添加系统消息钩子
            var hwndSource = PresentationSource.FromVisual(this) as HwndSource;
            if (hwndSource != null)
            {
                hwndSource.AddHook(new HwndSourceHook(WndProc));
            }
        }

        protected override void OnStateChanged(EventArgs e)
        {
            base.OnStateChanged(e);
        }

        #region 系统消息处理

        /// <summary>
        /// 系统消息
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="msg"></param>
        /// <param name="wParam"></param>
        /// <param name="lParam"></param>
        /// <param name="handled"></param>
        /// <returns></returns>
        protected virtual IntPtr WndProc(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            switch (msg)
            {
                case ZS.Common.Win32Messages.Messages.WM_NCHITTEST:  // 鼠标探测，窗口边缘
                    return WmNCHitTest(lParam, ref handled);
                case ZS.Common.Win32Messages.Messages.WM_GETMINMAXINFO: // 
                    ZS.Common.Monitor.Monitor.SetWindowToMax(hWnd, lParam);
                    //WmGetMinMaxInfo(hWnd, lParam);
                    handled = true;
                    break;
            }

            return IntPtr.Zero;

        }

        /// <summary>
        /// 鼠标在窗体四周的窗口放大缩小处理
        /// </summary>
        /// <param name="lParam"></param>
        /// <param name="handled"></param>
        /// <returns></returns>
        private IntPtr WmNCHitTest(IntPtr lParam, ref bool handled)
        {
            m_MousePoint.X = lParam.ToInt32() & 0xFFFF;
            m_MousePoint.Y = lParam.ToInt32() >> 16;

            handled = true;
            if (this.WindowState == WindowState.Normal)
            {
                // 左上角
                if (m_MousePoint.Y - Top <= m_CornerWidth && m_MousePoint.X - Left <= m_CornerWidth)
                {
                    return new IntPtr(ZS.Common.Win32Messages.NCHITTEST.HTTOPLEFT);
                }

                // 左下角
                if ((ActualHeight + Top - m_MousePoint.Y <= m_CornerWidth) && (m_MousePoint.X - Left <= m_CornerWidth))
                {
                    return new IntPtr(ZS.Common.Win32Messages.NCHITTEST.HTBOTTOMLEFT);
                }

                // 右上角
                if ((m_MousePoint.Y - Top <= m_CornerWidth) && (ActualWidth + Left - m_MousePoint.X <= m_CornerWidth))
                {
                    return new IntPtr(ZS.Common.Win32Messages.NCHITTEST.HTTOPRIGHT);
                }

                // 右下角
                if ((ActualHeight + Top - m_MousePoint.Y <= m_CornerWidth) && (ActualWidth + Left - m_MousePoint.X <= m_CornerWidth))
                {
                    return new IntPtr(ZS.Common.Win32Messages.NCHITTEST.HTBOTTOMRIGHT);
                }

                // 左侧
                if (m_MousePoint.X - (Left + 4) < m_Thickness)
                {
                    return new IntPtr(ZS.Common.Win32Messages.NCHITTEST.HTLEFT);
                }

                // 右侧
                if ((Left + ActualWidth - 4) - m_MousePoint.X < m_Thickness)
                {
                    return new IntPtr(ZS.Common.Win32Messages.NCHITTEST.HTRIGHT);
                }

                // 上侧
                if (m_MousePoint.Y - Top <= m_Thickness)
                {
                    return new IntPtr(ZS.Common.Win32Messages.NCHITTEST.HTTOP);
                }

                // 下侧
                if ((Top + ActualHeight) - m_MousePoint.Y <= m_Thickness)
                {
                    return new IntPtr(ZS.Common.Win32Messages.NCHITTEST.HTBOTTOM);
                }


                // 内容区域
                if (m_MousePoint.Y - Top > 0 && m_MousePoint.Y - Top < 25 && Left + ActualWidth - m_MousePoint.X > 100)
                {
                    return new IntPtr(ZS.Common.Win32Messages.NCHITTEST.HTCLIENT);
                }
            }

            if (this.WindowState == WindowState.Maximized)
            {

            }

            // 设置其它区域为客户端。
            return new IntPtr(ZS.Common.Win32Messages.NCHITTEST.HTCLIENT);
        }

        #endregion

        #region 鼠标按键处理

        #region 鼠标左键按下处理

        /// <summary>
        /// 标题栏鼠标左键点击拖拽
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);

            // 鼠标左键按住
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                // 标题栏位置，按住拖拽
                //Point pos = e.GetPosition(m_TitleBar);
                //if (pos.X >= 0 && pos.X < m_TitleBar.ActualWidth && pos.Y >= 0 && pos.Y < m_TitleBar.ActualHeight)
                //{
                //    // 全屏状态下，窗口先设置为正常模式，并且将位置定位到鼠标附近
                //    if (this.WindowState == WindowState.Maximized)
                //    {
                //        this.WindowState = WindowState.Normal;
                //        this.Top = pos.Y;
                //        this.Left = pos.X;
                //    }
                //    this.DragMove();
                //}
            }
        }

        #endregion

        #region 鼠标移动处理

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            // 鼠标左键按住
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                // 标题栏位置，按住拖拽
                Point pos = e.GetPosition(m_TitleBar);
                if (pos.X >= 0 && pos.X < m_TitleBar.ActualWidth && pos.Y >= 0 && pos.Y < m_TitleBar.ActualHeight)
                {
                    // 全屏状态下，窗口先设置为正常模式，并且将窗口定位到鼠标附近
                    if (this.WindowState == WindowState.Maximized)
                    {
                        this.WindowState = WindowState.Normal;
                        this.Top = pos.Y - m_TitleBar.ActualHeight / 2;
                        this.Left = pos.X - m_TitleBar.ActualWidth / 2;
                    }
                    this.DragMove();
                }
            }
        }

        #endregion

        #region 鼠标左键双击处理

        protected override void OnMouseDoubleClick(MouseButtonEventArgs e)
        {
            base.OnMouseDoubleClick(e);

            // 标题栏位置，双击最大化或者还原
            Point pos = e.GetPosition(m_TitleBar);
            if (pos.X >= 0 && pos.X < m_TitleBar.ActualWidth && pos.Y >= 0 && pos.Y < m_TitleBar.ActualHeight)
            {
                this.WindowState = this.WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;
                return;
            }

        }

        #endregion

        #endregion

        #region 颜色主题

        private string _propTheme = string.Empty;
        /// <summary>
        /// 设置窗口的主题，或者获取窗口的主题名称。
        /// </summary>
        protected string Theme
        {
            get
            {
                return _propTheme;
            }
            set
            {

#if !DEBUG
#endif
                _propTheme = value;
                if (value == null || value == string.Empty) _propTheme = "Default";

                m_MainStyle = new ResourceDictionary();
                m_MainStyle.Source = new Uri(m_ResourcesBasePath.Replace("{ResourceName}", _propTheme), UriKind.Relative);
                this.Resources.MergedDictionaries[this.Resources.MergedDictionaries.Count - 1] = m_MainStyle;
                


                //m_WindowResource.MergedDictionaries.Clear();
                //m_WindowResource.MergedDictionaries.Add(m_MainStyle);
            }
        }

        /// <summary>
        /// 默认主题列表
        /// </summary>
        protected List<string> Themes = new List<string>() {
            "Default",
            "Blue"
        };

        #endregion

    }
}
