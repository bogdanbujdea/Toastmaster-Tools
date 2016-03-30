using System;
using System.Collections.Generic;
using Windows.UI.Xaml.Controls;
using ToastmasterTools.Core.Models;

namespace ToastmasterTools.Core.Features.SpeechTools
{
    public interface ISpeechSelector
    {
        List<SpeechType> Lessons { get; set; }
        event EventHandler<SelectionChangedEventArgs> SelectedSpeechChanged;
        void Initialize();
    }
}