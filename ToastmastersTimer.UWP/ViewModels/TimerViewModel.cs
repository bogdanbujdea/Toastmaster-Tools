namespace ToastmastersTimer.UWP.ViewModels
{
    using Windows.UI.Xaml;

    using Mvvm;

    public class TimerViewModel: ViewModelBase
    {
	    public TimerViewModel()
		{
			
		}

        public void SetTimer(object element, DataContextChangedEventArgs context)
        {
            Timer = context.NewValue as ToastmastersTimerViewModel;
        }

        public ToastmastersTimerViewModel Timer { get; set; }
    }
}