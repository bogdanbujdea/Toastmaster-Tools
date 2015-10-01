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

        public TimePickerViewModel()
        {
            Minutes = new List<string>();
            Seconds = new List<string>();
            foreach (var i in Enumerable.Range(0, 60))
            {
                var number = i < 10 ? "0" + i : i.ToString();
                Minutes.Add(number);
            }
            Seconds.Add("00");
            Seconds.Add("10");
            Seconds.Add("20");
            Seconds.Add("30");
            Seconds.Add("40");
            Seconds.Add("50");
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
        public Time SelectedTime { get; set; }

        public bool IsInitialized => Minutes.Count > 0 && Seconds.Count > 0;
    }
}
