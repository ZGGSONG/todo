﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TODO.ViewModel.PopItem;

namespace TODO.ViewModel
{
    [Serializable]
    public class MainViewModel : BaseViewModel
    { 
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue(nameof(Records), Records);
        }
        public MainViewModel(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            Records = (BindingList<RecordItem>)info.GetValue(nameof(Records), typeof(BindingList<RecordItem>));
            Initial();
        }
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
                return string.IsNullOrEmpty(InputMessage) ? false : true;
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
