using ToastmastersTimer.UWP.Models;

namespace ToastmastersTimer.UWP.ViewModels
{
    using System.Linq;
    using System.Collections.Generic;

    using Mvvm;

    public class TimePickerViewModel: ViewModelBase
    {
        private List<string> _minutes;
        private List<string> _seconds;

        public void Initialize()
        {
            var minutes = new List<string>();
            var seconds = new List<string>();
            foreach (var i in Enumerable.Range(0, 60))
            {
                var number = i < 10 ? "0" + i : i.ToString();
                minutes.Add(number);
            }
            seconds.Add("00");
            seconds.Add("10");
            seconds.Add("20");
            seconds.Add("30");
            seconds.Add("40");
            seconds.Add("50");
            Minutes = minutes;
            Seconds = seconds;
        }

        public List<string> Minutes
        {
            get { return _minutes; }
            set
            {
                _minutes = value;
                RaisePropertyChanged();
            }
        }

        public List<string> Seconds
        {
            get { return _seconds; }
            set
            {
                _seconds = value; 
                RaisePropertyChanged();
            }
        }

        public int SelectedSecondsIndex { get; set; }
        public CardTime SelectedCardTime { get; set; }

        public bool IsInitialized => Minutes.Count > 0 && Seconds.Count > 0;
    }
}
