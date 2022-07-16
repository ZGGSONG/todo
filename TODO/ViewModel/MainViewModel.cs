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
            AddCommand = new Command.RelayCommand((_) =>
            {
                return true;
            }, (_) =>
            {
                var record = new RecordItem()
                {
                    msg = Input,
                    datetime = DateTime.Now
                };
                Records.Insert(0, record);
                Input = "";
            });

            DoneCommand = new Command.RelayCommand((_) =>
            {
                return true;
            }, (mm) =>
            {
                Records.Remove((RecordItem)mm);
            });
        }



        private string _Input;
        public string Input
        {
            get { return _Input; }
            set { _Input = value; NotifyPropertyChanged("Input"); }
        }

        public BindingList<RecordItem> Records { get; set; } = new BindingList<RecordItem>();
        public ICommand AddCommand { get; private set; }
        public ICommand DoneCommand { get; private set; }
    }
}
