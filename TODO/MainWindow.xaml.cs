using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TODO.ViewModel;

namespace TODO
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //读取配置文件
            //配置文件位置: C:\\Users\\ksat\\AppData\\Local\\TODO\\TODO.exe_Url_uhqbim33x02tyr0y0ladkknyvv3fe5pw\\1.0.0.0
            //https://blog.csdn.net/qq_43307934/article/details/87971342
            try
            {
                //设置位置、大小
                Rect restoreBounds = Properties.Settings.Default.MainRestoreBounds;
                this.WindowState = WindowState.Normal;
                this.Left = restoreBounds.Left;
                this.Top = restoreBounds.Top;
                this.Width = restoreBounds.Width;
                this.Height = restoreBounds.Height;
                this.Topmost = Properties.Settings.Default.MainWindowTopmost;
                Opacity = Topmost ? 1 : 0.9;
                //设置窗口状态
                this.WindowState = Properties.Settings.Default.MainWindowState;
            }
            catch { }

            inputBox.Focus();
            
            if (ViewModelHelper.Instance().MainViewModel is null)
            {
                DataContext = new MainViewModel();
                ViewModelHelper.Instance().MainViewModel = (IMainViewModel)DataContext;
                return;
            }
            DataContext = ViewModelHelper.Instance().MainViewModel;
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        /// <summary>
        /// 快捷键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            //置顶/取消置顶 Ctrl+T
            if (e.KeyboardDevice.Modifiers.HasFlag(ModifierKeys.Control) && e.Key == Key.T)
            {
                Topmost = Topmost != true;
                Opacity = Topmost ? 1 : 0.9;
            }
            //最小化 Ctrl+M
            if (e.KeyboardDevice.Modifiers.HasFlag(ModifierKeys.Control) && e.Key == Key.M)
            {
                WindowState = WindowState.Minimized;
            }
            //退出 Ctrl+Q
            if (e.KeyboardDevice.Modifiers.HasFlag(ModifierKeys.Control) && e.Key == Key.Q)
            {
                Application.Current.Shutdown();
            }
            //缩小 Ctrl+[
            if (e.KeyboardDevice.Modifiers.HasFlag(ModifierKeys.Control) && e.Key == Key.OemOpenBrackets)
            {
                if (Width < 245)
                {
                    return;
                }
                Width /= 1.2;
                Height /= 1.2;
            }
            //放大 Ctrl+]
            if (e.KeyboardDevice.Modifiers.HasFlag(ModifierKeys.Control) && e.Key == Key.OemCloseBrackets)
            {
                if (Width > 600)
                {
                    return;
                }
                Width *= 1.2;
                Height *= 1.2;
            }
            //恢复界面大小 Ctrl+P
            if (e.KeyboardDevice.Modifiers.HasFlag(ModifierKeys.Control) && e.Key == Key.P)
            {
                Width = 350;
                Height = 420;
            }
            //一键清理所有数据 Ctrl+Shift+Alt+C
            if (e.KeyboardDevice.Modifiers.HasFlag(ModifierKeys.Control) && e.KeyboardDevice.Modifiers.HasFlag(ModifierKeys.Shift) && e.KeyboardDevice.Modifiers.HasFlag(ModifierKeys.Alt) && e.Key == Key.C)
            {
                (DataContext as MainViewModel).ClearCommand.Execute(null);
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //保存当前位置、大小和状态，到配置文件
            Properties.Settings.Default.MainRestoreBounds = this.RestoreBounds;
            Properties.Settings.Default.MainWindowState = this.WindowState;
            Properties.Settings.Default.MainWindowTopmost = this.Topmost;
            Properties.Settings.Default.Save();

            ViewModelHelper.Instance().Dispose();
        }
    }
}
