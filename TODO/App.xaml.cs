using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows;

namespace TODO
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        //private static System.Threading.Mutex mutex;
        ////系统能够识别有名称的互斥，因此可以使用它禁止应用程序启动两次 
        ////第二个参数可以设置为产品的名称:Application.ProductName 
        //// 每次启动应用程序，都会验证名称为OnlyRun的互斥是否存在 
        //protected override void OnStartup(StartupEventArgs e)
        //{
        //    mutex = new System.Threading.Mutex(true, "OnlyRun");
        //    if (mutex.WaitOne(0, false))
        //    {
        //        base.OnStartup(e);
        //    }
        //    else
        //    {
        //        MessageBox.Show("程序已经在运行！", "提示");
        //        this.Shutdown();
        //    }
        //}

        /// <summary>
        /// 防止多开，并且置顶已开程序
        /// </summary>
        /// <param name="hwnd"></param>
        /// <returns></returns>
        [DllImport("user32")]
        private static extern int SetForegroundWindow(IntPtr hwnd);
        [DllImport("user32.dll")]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        protected override void OnStartup(StartupEventArgs e)
        {
            IntPtr parenthWnd = FindWindow(null, Assembly.GetExecutingAssembly().GetName().Name);
            if (parenthWnd != IntPtr.Zero)
            {
                //选中当前的句柄窗口
                SetForegroundWindow(parenthWnd);
                Application.Current.Shutdown();
                return;
            }
            base.OnStartup(e);
        }
    }
}
