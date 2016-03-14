namespace ToastmastersTimer.UWP.ViewModels
{
    using Mvvm;
    using Views;

    public class HomeViewModel : ViewModelBase
    {
        public void GoToTimerView()
        {
            NavigationService.Navigate(typeof(TimerView));
        }

        public void GoToSpeechPractice()
        {
            NavigationService.Navigate(typeof(SpeechPracticeView));
        }

        public void GoToSettings()
        {
            NavigationService.Navigate(typeof(SettingsView));
        }
    }
}