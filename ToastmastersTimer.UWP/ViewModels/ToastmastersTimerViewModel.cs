using System.ComponentModel;
using ToastmastersTimer.UWP.Mvvm;

namespace ToastmastersTimer.UWP.ViewModels
{
    public class ToastmastersTimerViewModel: ViewModelBase
    {
        private bool _timerIsRunning;

        public ToastmastersTimerViewModel()
        {

        }

        public bool TimerIsRunning
        {
            get { return _timerIsRunning; }
            set
            {
                _timerIsRunning = value; 
                RaisePropertyChanged();
            }
        }

        #region Timer

        public void StartTimer()
        {

        }

        #endregion
    }
}
