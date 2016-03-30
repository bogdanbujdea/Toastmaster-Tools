using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using ToastmasterTools.UWP.Annotations;

namespace ToastmasterTools.Core.Models
{
    public class SpeechType: INotifyPropertyChanged, ILesson
    {
        private CardTime _greenCardTime;
        private string _name;
        private CardTime _yellowCardTime;
        private CardTime _redCardTime;

        public int SpeechTypeId { get; set; }

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

        [NotMapped]
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

        [NotMapped]
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

        [NotMapped]
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