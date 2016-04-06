using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using ToastmasterTools.Core.Features.AHCounter;
using ToastmasterTools.Core.ViewModels;
using ToastmasterTools.UWP.Annotations;

namespace ToastmasterTools.Core.Models
{
    public class Speech : INotifyPropertyChanged, ISpeech
    {
        private bool _isCustom;
        private double _speechTimeInSeconds;
        private Speaker _speaker;
        private ICollection<Counter> _counters;

        public virtual SpeechType SpeechType { get; set; }

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

        public int SpeakerId { get; set; }

        public virtual Speaker Speaker
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

        public virtual ICollection<Counter> Counters
        {
            get { return _counters; }
            set
            {
                _counters = value; 
                OnPropertyChanged();
            }
        }

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

        public ReviewerRole Reviewer { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}