using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.UI.Xaml.Navigation;
using ToastmasterTools.UWP.Views;
using ToastmasterTools.Core.Features.Analytics;
using ToastmasterTools.Core.Mvvm;
using ToastmasterTools.Core.Services.SettingsServices;

namespace ToastmasterTools.Core.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        private readonly IStatisticsService _statisticsService;
        private readonly IAppSettings _appSettings;
        private string _userDisplayName;
        private bool _isLoggedIn;

        public HomeViewModel(IStatisticsService statisticsService, IAppSettings appSettings)
        {
            _statisticsService = statisticsService;
            _appSettings = appSettings;
        }

        public void GoToTimerView()
        {
            NavigationService.Navigate(typeof(TimerView));
        }

        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            var sessionId = _appSettings.Get<string>(StorageKey.SessionId);
            IsLoggedIn = string.IsNullOrWhiteSpace(sessionId) == false;
            if (IsLoggedIn)
                UserDisplayName = _appSettings.Get<string>(StorageKey.UserDisplayName);
        }        

        public bool IsLoggedIn
        {
            get { return _isLoggedIn; }
            set
            {
                _isLoggedIn = value; 
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
            _statisticsService.RegisterEvent(EventCategory.UserEvent, "logged out", UserDisplayName);
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