using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.UI.Xaml.Navigation;
using Template10.Mvvm;
using ToastmastersTimer.UWP.Features.Authentication;
using ToastmastersTimer.UWP.Features.UserDialogs;
using ToastmastersTimer.UWP.Services.SettingsServices;
using ToastmastersTimer.UWP.Views;

namespace ToastmastersTimer.UWP.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IAppSettings _appSettings;
        private readonly IDialogService _dialogService;
        private string _username;
        private string _password;
        private bool _rememberMe;

        public LoginViewModel(IAuthenticationService authenticationService, IAppSettings appSettings, IDialogService dialogService)
        {
            _authenticationService = authenticationService;
            _appSettings = appSettings;
            _dialogService = dialogService;
        }

        public string Username
        {
            get { return _username; }
            set
            {
                _username = value;
                RaisePropertyChanged();
            }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                RaisePropertyChanged();
            }
        }

        public bool RememberMe
        {
            get { return _rememberMe; }
            set
            {
                _rememberMe = value;
                RaisePropertyChanged();
            }
        }

        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            var sessionId = _appSettings.Get<string>(StorageKey.SessionId);
            var expiration = _appSettings.Get<DateTime>(StorageKey.SessionExpiration);
            if (string.IsNullOrWhiteSpace(sessionId) == false)
            {
                if (expiration > DateTime.Now)
                    NavigationService.Navigate(typeof(HomeView));
                else
                {
                    var username = _appSettings.Get<string>(StorageKey.Username);
                    var password = _appSettings.Get<string>(StorageKey.Password);
                    if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                        return;
                    RememberMe = true;
                    Username = username;
                    Password = password;
                    await Login();
                }
            }
        }

        public void ContinueWithoutLogin()
        {
            NavigationService.Navigate(typeof(HomeView));
        }

        public async Task Login()
        {
            var authenticationReport = await AuthenticateUser(Username, Password);
            await HandleAuthenticationResult(authenticationReport);
        }

        private async Task HandleAuthenticationResult(AuthenticationReport authenticationReport)
        {
            if (authenticationReport.Successful)
            {
                var userData = authenticationReport.UserData;
                _appSettings.Set(StorageKey.SessionId, userData.SessionId);
                _appSettings.Set(StorageKey.UserDisplayName, userData.DisplayName);
                _appSettings.Set(StorageKey.City, userData.City);
                _appSettings.Set(StorageKey.UserStatus, userData.Status);
                _appSettings.Set(StorageKey.Country, userData.Country);
                _appSettings.Set(StorageKey.SessionExpiration, userData.Expiration);
                if (RememberMe)
                {
                    _appSettings.Set(StorageKey.Username, Username);
                    _appSettings.Set(StorageKey.Password, Password);
                }
                NavigationService.Navigate(typeof(HomeView));
            }
            else
            {
                switch (authenticationReport.Error)
                {
                    case WebError.InvalidCredentials:
                        await
                            _dialogService.ShowMessageDialog(
                                "The credentials are invalid. Please check your username and password.");
                        break;
                }
            }
        }

        private async Task<AuthenticationReport> AuthenticateUser(string username, string password)
        {
            var authenticationReport = await _authenticationService.Login(username, password);
            return authenticationReport;
        }
    }
}