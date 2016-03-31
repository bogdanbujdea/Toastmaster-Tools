using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Windows.UI.Xaml.Controls;
using ToastmasterTools.Core.Annotations;
using ToastmasterTools.Core.Features.Storage;
using ToastmasterTools.Core.Models;

namespace ToastmasterTools.Core.Features.SpeechTools
{
    public class SpeechSelector : ISpeechSelector, INotifyPropertyChanged
    {
        private List<SpeechType> _lessons;

        public List<SpeechType> Lessons
        {
            get { return _lessons; }
            set
            {
                if (Equals(value, _lessons)) return;
                _lessons = value;
                OnPropertyChanged();
            }
        }

        public event EventHandler<SelectionChangedEventArgs> SelectedSpeechChanged;

        public void Initialize()
        {
            Lessons = ToastmasterContext.ListOfLessons;
        }

        public virtual void OnSelectedSpeechChanged(SelectionChangedEventArgs e)
        {
            SelectedSpeechChanged?.Invoke(this, e);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}