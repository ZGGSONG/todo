using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TODO.ViewModel
{
    [Serializable]
    public class BaseViewModel : IMainViewModel, INotifyPropertyChanged, ISerializable
    {
        public bool isLogin { get => true; }

        public event PropertyChangedEventHandler PropertyChanged;

        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            //info.AddValue("props", myProperty_value, typeof(string));
        }

        public BaseViewModel(SerializationInfo info, StreamingContext context)
        {
            //myProperty_value = (string)info.GetValue("props", typeof(string));
        }
        public BaseViewModel()
        {

        }

        protected void UpdateProperty<T>(ref T properValue, T newValue, [CallerMemberName] string properName = "")
        {
            if (object.Equals(properValue, newValue))
                return;
            properValue = newValue;
            NotifyPropertyChanged(properName);
        }

        public void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
