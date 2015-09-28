namespace ToastmastersTimer.UWP.ViewModels
{
    using System;
    using System.Diagnostics;

    using Windows.UI;
    using Windows.UI.Xaml;

    using Mvvm;
    using Models;
    using Helpers;

    public class ToastmastersTimerViewModel : ViewModelBase
    {
        private bool _timerIsRunning;
        Stopwatch _stopWatch;
        private string _secondsText;
        private string _minutesText;
        private DispatcherTimer _dispatcherTimer;
        private Color _selectedBackground;

        public ToastmastersTimerViewModel()
        {
            if (Windows.ApplicationModel.DesignMode.DesignModeEnabled)
            {
                SelectedBackground = DarkBackground;
                return;
            }
            ResetTimer();
        }

        #region Properties

        public bool TimerIsRunning
        {
            get { return _timerIsRunning; }
            set
            {
                _timerIsRunning = value;
                RaisePropertyChanged();
            }
        }

        public Color SelectedBackground
        {
            get { return _selectedBackground; }
            set
            {
                _selectedBackground = value;
                RaisePropertyChanged();
            }
        }

        public string MinutesText
        {
            get { return _minutesText; }
            set
            {
                _minutesText = value;
                RaisePropertyChanged();
            }
        }

        public string SecondsText
        {
            get { return _secondsText; }
            set
            {
                _secondsText = value;
                RaisePropertyChanged();
            }
        }

        public Speech CurrentSpeech { get; set; }

        #endregion

        #region Timer

        public Color DarkBackground { get; set; } = Color.FromArgb(255, 0, 65, 101);

        private bool TimeIsBetweenYellowAndRed(TimeSpan timeSpan)
        {
            return timeSpan.TotalMilliseconds >= CurrentSpeech.MiddleTime.TotalMilliseconds &&
                   timeSpan.TotalMilliseconds < CurrentSpeech.MaximumTime.TotalMilliseconds;
        }

        private bool TimeIsAfterRed(TimeSpan timeSpan)
        {
            return timeSpan.TotalMilliseconds >= CurrentSpeech.MaximumTime.TotalMilliseconds;
        }

        public void StartTimer()
        {
            CurrentSpeech = new Speech
            {
                MinimumTime = TimeSpan.FromSeconds(5),
                MiddleTime = TimeSpan.FromSeconds(8),
                MaximumTime = TimeSpan.FromSeconds(12),
            };
            _dispatcherTimer.Start();
            _stopWatch.Start();
            TimerIsRunning = true;
        }

        public void PauseTimer()
        {
            if (_dispatcherTimer.IsEnabled)
            {
                _dispatcherTimer.Stop();
                _stopWatch.Stop();
                TimerIsRunning = false;
            }
            else
            {
                _dispatcherTimer.Start();
                _stopWatch.Start();
                TimerIsRunning = true;
            }
        }

        public void StopTimer()
        {
            ResetTimer();
        }

        #endregion

        #region Private

        private void ResetTimer()
        {
            SelectedBackground = DarkBackground;
            MinutesText = SecondsText = "00";
            _dispatcherTimer?.Stop();
            _stopWatch?.Stop();
            _stopWatch = new Stopwatch();
            _dispatcherTimer = new DispatcherTimer();
            _dispatcherTimer.Interval = TimeSpan.FromMilliseconds(100);
            _dispatcherTimer.Tick += TimerCallback;
            TimerIsRunning = false;
        }

        private void TimerCallback(object sender, object e)
        {
            var timeSpan = _stopWatch.Elapsed;
            MinutesText = timeSpan.Minutes.GetTimeText();
            SecondsText = timeSpan.Seconds.GetTimeText();
            UpdateBackground(timeSpan);
        }

        private void UpdateBackground(TimeSpan timeSpan)
        {
            if (TimeIsBetweenGreenAndYellow(timeSpan))
                SelectedBackground = Colors.ForestGreen;
            else if (TimeIsBetweenYellowAndRed(timeSpan))
                SelectedBackground = Color.FromArgb(255, 242, 223, 116);
            else if (TimeIsAfterRed(timeSpan))
                SelectedBackground = Color.FromArgb(255, 205, 32, 44);
        }

        private bool TimeIsBetweenGreenAndYellow(TimeSpan timeSpan)
        {
            return timeSpan.TotalMilliseconds >= CurrentSpeech.MinimumTime.TotalMilliseconds &&
                   timeSpan.TotalMilliseconds < CurrentSpeech.MiddleTime.TotalMilliseconds;
        }

        #endregion
    }
}
