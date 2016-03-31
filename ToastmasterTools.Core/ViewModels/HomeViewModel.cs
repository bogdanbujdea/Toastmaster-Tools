using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.UI.Xaml.Navigation;
using ToastmasterTools.Core.Features.Analytics;
using ToastmasterTools.Core.Features.Storage;
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
            NavigationService.Navigate(Pages.Timer);            
        }

        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            var sessionId = _appSettings.Get<string>(StorageKey.SessionId);
            IsLoggedIn = string.IsNullOrWhiteSpace(sessionId) == false;
            if (IsLoggedIn)
                UserDisplayName = _appSettings.Get<string>(StorageKey.UserDisplayName);
            using (var context = new ToastmasterContext())
            {
                await context.Seed();
            }
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
            NavigationService.Navigate(Pages.Settings);            
        }

        public void GoToAhCounter()
        {
            NavigationService.Navigate(Pages.AhCounter);            
        }

        public void GoToGrammarian()
        {
            NavigationService.Navigate(Pages.Grammarian);            
        }

        public void Login()
        {
            NavigationService.Navigate(Pages.Login);
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
            //NavigationService.Navigate(typeof(SpeechPracticeView));
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

    public enum Pages
    {
        Home,
        Timer,
        Settings,
        Login,
        AhCounter,
        Grammarian
    }
}