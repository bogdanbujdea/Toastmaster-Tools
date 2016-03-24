using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using ToastmasterTools.Core.Features.AHCounter;
using ToastmasterTools.UWP.Annotations;

namespace ToastmasterTools.Core.Models
{
    public class Speech: INotifyPropertyChanged, ISpeech
    {
        private bool _isCustom;
        private double _speechTimeInSeconds;
        private Member _speaker;

        public SpeechType SpeechType { get; set; }

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

        public int SpeechId { get; set; }

        public Member Speaker
        {
            get { return _speaker; }
            set
            {
                if (Equals(value, _speaker)) return;
                _speaker = value;
                OnPropertyChanged();
            }
        }

        public DateTime Date { get; set; }
        public List<Counter> Counters { get; set; }
        public string Notes { get; set; }

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