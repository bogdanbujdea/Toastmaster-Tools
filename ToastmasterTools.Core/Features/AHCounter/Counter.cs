using System.ComponentModel;
using System.Runtime.CompilerServices;
using ToastmasterTools.UWP.Annotations;

namespace ToastmasterTools.Core.Features.AHCounter
{
    public class Counter: INotifyPropertyChanged
    {
        private int _count;
        private string _name;

        public int Count
        {
            get { return _count; }
            set
            {
                if (value == _count) return;
                if (value < 0) return;
                _count = value;
                OnPropertyChanged();
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                if (value == _name) return;
                _name = value;
                OnPropertyChanged();
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}