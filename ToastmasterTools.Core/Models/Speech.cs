using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using Microsoft.Data.Entity.Metadata.Internal;
using ToastmasterTools.Core.Features.AHCounter;
using ToastmasterTools.UWP.Annotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToastmasterTools.Core.Models
{
    public class Speech: INotifyPropertyChanged, ISpeech
    {
        private bool _isCustom;
        private double _speechTimeInSeconds;
        private Speaker _speaker;

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

        [Key]
        public int SpeechId { get; set; }
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

        public virtual ICollection<Counter> Counters { get; set; }

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

        public int SpeakerId { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}