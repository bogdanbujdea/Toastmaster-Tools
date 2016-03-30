using System;
using System.Collections.Generic;
using Windows.UI.Xaml.Controls;
using ToastmasterTools.Core.Features.Storage;
using ToastmasterTools.Core.Models;

namespace ToastmasterTools.Core.Features.SpeechTools
{
    public class SpeechSelector : ISpeechSelector
    {
        public List<SpeechType> Lessons { get; set; }

        public event EventHandler<SelectionChangedEventArgs> SelectedSpeechChanged;

        public void Initialize()
        {
            Lessons = ToastmasterContext.ListOfLessons;
        }

        public virtual void OnSelectedSpeechChanged(SelectionChangedEventArgs e)
        {
            SelectedSpeechChanged?.Invoke(this, e);
        }
    }
}