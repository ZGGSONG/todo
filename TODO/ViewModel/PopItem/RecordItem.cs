using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TODO.ViewModel.PopItem
{

    public class RecordItem : BaseViewModel
    {
        private string _msg;
        public string msg
        {
            get => _msg;
            set { _msg = value; NotifyPropertyChanged("msg"); }
        }

        private DateTime _datetime;
        public DateTime datetime
        {
            get => _datetime;
            set { _datetime = value; NotifyPropertyChanged("datetime"); }
        }

    }
}
