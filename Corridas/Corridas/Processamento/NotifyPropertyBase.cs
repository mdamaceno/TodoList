using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corridas.Processamento
{
    public class NotifyPropertyBase : INotifyPropertyChanged, INotifyPropertyChanging
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public event PropertyChangingEventHandler PropertyChanging;

        protected virtual void OnPropertyChanged(string info)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(info));
        }

        protected virtual void OnPropertyChanging(string info)
        {
            if (this.PropertyChanging != null)
                this.PropertyChanging(this, new PropertyChangingEventArgs(info));
        }
    }
}
