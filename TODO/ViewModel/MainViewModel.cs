using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TODO.ViewModel.PopItem;

namespace TODO.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        private static MainViewModel mInstance = new MainViewModel();
        public static MainViewModel Instance { get => mInstance; }
        public MainViewModel()
        {
            Initial();
        }

        /// <summary>
        /// 初始化，方便做数据恢复不同的构造函数调用
        /// </summary>
        private void Initial()
        {
            AddCommand = new Command.RelayCommand((_) =>
            {
                return true;
            }, (_) =>
            {
                var record = new RecordItem()
                {
                    Message = InputMessage,
                    CreateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                };
                Records.Insert(0, record);
                InputMessage = "";
            });

            DoneCommand = new Command.RelayCommand((_) =>
            {
                return true;
            }, (mm) =>
            {
                Records.Remove((RecordItem)mm);
            });
        }

        /// <summary>
        /// 输入信息
        /// </summary>
        private string mInputMessage;
        public string InputMessage { get => mInputMessage; set => UpdateProperty(ref mInputMessage, value); }

        public BindingList<RecordItem> Records { get; set; } = new BindingList<RecordItem>();
        public ICommand AddCommand { get; private set; }
        public ICommand DoneCommand { get; private set; }
    }
}
