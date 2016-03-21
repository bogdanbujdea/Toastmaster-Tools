using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.UI.Xaml.Navigation;
using ToastmastersTimer.UWP.Features.Feedback;
using ToastmastersTimer.UWP.Services.SettingsServices;

namespace ToastmastersTimer.UWP.ViewModels
{
    using Mvvm;
    using Views;

    public class HomeViewModel : ViewModelBase
    {
        private readonly IFeedbackCollector _feedbackCollector;
        private readonly IAppSettings _appSettings;
        private string _userDisplayName;

        public HomeViewModel(IFeedbackCollector feedbackCollector, IAppSettings appSettings)
        {
            _feedbackCollector = feedbackCollector;
            _appSettings = appSettings;
        }

        public void GoToTimerView()
        {
            NavigationService.Navigate(typeof(TimerView));
        }

        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            if (IsLoggedIn)
                UserDisplayName = _appSettings.Get<string>(StorageKey.UserDisplayName);
        }

        public bool IsLoggedIn
        {
            get
            {
                var sessionId = _appSettings.Get<string>(StorageKey.SessionId);
                return string.IsNullOrWhiteSpace(sessionId) == false;
            }
            set
            {
                RaisePropertyChanged();
            }
        }

        public void GoToSettings()
        {
            NavigationService.Navigate(typeof(SettingsView));
        }

        public void Login()
        {
            NavigationService.Navigate(typeof(LoginView));
        }

        public void Logout()
        {
            _appSettings.Remove(StorageKey.SessionId);
            _appSettings.Remove(StorageKey.SessionExpiration);
            _appSettings.Remove(StorageKey.UserDisplayName);
            _appSettings.Remove(StorageKey.Country);
            _appSettings.Remove(StorageKey.City);
            _appSettings.Remove(StorageKey.UserStatus);
            UserDisplayName = string.Empty;
            IsLoggedIn = false;
        }

        public void GoToSpeechPractice()
        {
            NavigationService.Navigate(typeof(SpeechPracticeView));
        }

        public string UserDisplayName
        {
            get { return _userDisplayName; }
            set
            {
                if (_userDisplayName == value)
                    return;
                _userDisplayName = value;
                RaisePropertyChanged();
            }
        }
    }
}