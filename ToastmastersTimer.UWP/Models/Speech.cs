namespace ToastmastersTimer.UWP.Models
{
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    using Annotations;

    public class Speech: INotifyPropertyChanged
    {
        private string _speakerName;
        private string _name;
        private bool _isCustom;
        private double _speechTimeInSeconds;

        public Lesson Lesson { get; set; }

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

        public bool IsCustom
        {
            get { return _isCustom; }
            set
            {
                if (value == _isCustom) return;
                _isCustom = value;
                OnPropertyChanged();
            }
        }

        public string SpeakerName
        {
            get { return _speakerName; }
            set
            {
                if (value == _speakerName) return;
                _speakerName = value;
                OnPropertyChanged();
            }
        }

        public double SpeechTimeInSeconds
        {
            get { return _speechTimeInSeconds; }
            set
            {
                if (value.Equals(_speechTimeInSeconds)) return;
                _speechTimeInSeconds = value;
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