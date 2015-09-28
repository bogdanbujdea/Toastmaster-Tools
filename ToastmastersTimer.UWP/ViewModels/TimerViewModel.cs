namespace ToastmastersTimer.UWP.ViewModels
{
    using Windows.UI.Xaml;

    using Mvvm;

    public class TimerViewModel: ViewModelBase
    {
        private bool _speechUIIsVisible;

        public TimerViewModel()
		{
			
		}

        public void SetTimer(object element, DataContextChangedEventArgs context)
        {
            Timer = context.NewValue as ToastmastersTimerViewModel;
        }

        public void ShowSpeechUI()
        {
            SpeechUIIsVisible = true;
        }

        public bool SpeechUIIsVisible
        {
            get { return _speechUIIsVisible; }
            set
            {
                _speechUIIsVisible = value; 
                RaisePropertyChanged();
            }
        }

        public ToastmastersTimerViewModel Timer { get; set; }
    }
}