using System;
using System.Collections.Generic;
using System.ComponentModel;
using ToastmasterTools.Core.Features.AHCounter;

namespace ToastmasterTools.Core.Models
{
    public interface ISpeech
    {
        SpeechType SpeechType { get; set; }
        bool IsCustom { get; set; }
        Member Speaker{ get; set; }
        DateTime Date { get; set; }
        List<Counter> Counters { get; set; }
        string Notes { get; set; }
        double SpeechTimeInSeconds { get; set; }
        event PropertyChangedEventHandler PropertyChanged;
    }
}