using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TODO.ViewModel
{
    public class BaseViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected void UpdateProperty<T>(ref T properValue, T newValue, [CallerMemberName] string properName = "")
        {
            if (object.Equals(properValue, newValue))
                return;
            properValue = newValue;
            NotifyPropertyChanged(properName);
        }
    }
}
