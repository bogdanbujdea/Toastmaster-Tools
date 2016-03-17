using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.UI.Xaml.Navigation;
using ToastmastersTimer.UWP.Features.Feedback;

namespace ToastmastersTimer.UWP.ViewModels
{
    using Mvvm;
    using Views;

    public class HomeViewModel : ViewModelBase
    {
        private readonly IFeedbackCollector _feedbackCollector;

        public HomeViewModel(IFeedbackCollector feedbackCollector)
        {
            _feedbackCollector = feedbackCollector;
        }

        public void GoToTimerView()
        {
            NavigationService.Navigate(typeof(TimerView));
        }

        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            await _feedbackCollector.CheckForFeedback();
        }

        public void GoToSettings()
        {
            NavigationService.Navigate(typeof(SettingsView));
        }

        public void ManageGroup()
        {
            NavigationService.Navigate(typeof(GroupView));
        }

        public void GoToSpeechPractice()
        {
            NavigationService.Navigate(typeof(SpeechPracticeView));
        }
    }
}