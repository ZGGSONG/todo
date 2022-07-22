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
            inputBox.Focus();
            Opacity = 0.9;
            
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

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            //是否置顶
            if (e.KeyboardDevice.Modifiers.HasFlag(ModifierKeys.Control) && e.Key == Key.T)
            {
                Topmost = Topmost == true ? false : true;
                Opacity = Topmost == true ? 1 : 0.9;
            }
            //最小化
            if (e.KeyboardDevice.Modifiers.HasFlag(ModifierKeys.Control) && e.Key == Key.M)
            {
                WindowState = WindowState.Minimized;
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Console.WriteLine("退出");
            ViewModelHelper.Instance().Dispose();
        }
    }
}
