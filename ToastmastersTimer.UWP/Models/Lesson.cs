using System.ComponentModel;
using System.Runtime.CompilerServices;
using ToastmastersTimer.UWP.Annotations;

namespace ToastmastersTimer.UWP.Models
{
    public class Lesson: INotifyPropertyChanged
    {
        private CardTime _greenCardTime;
        private string _name;
        private CardTime _yellowCardTime;
        private CardTime _redCardTime;

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

        public CardTime GreenCardTime
        {
            get { return _greenCardTime; }
            set
            {
                if (Equals(value, _greenCardTime)) return;
                _greenCardTime = value;
                OnPropertyChanged();
            }
        }

        public CardTime YellowCardTime
        {
            get { return _yellowCardTime; }
            set
            {
                if (Equals(value, _yellowCardTime)) return;
                _yellowCardTime = value;
                OnPropertyChanged();
            }
        }

        public CardTime RedCardTime
        {
            get { return _redCardTime; }
            set
            {
                if (Equals(value, _redCardTime)) return;
                _redCardTime = value;
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