using System.Threading.Tasks;
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

        public async Task Login()
        {
            var authenticationReport = await _authenticationService.Login(Username, Password);
            if (authenticationReport.Successful)
            {
                var userData = authenticationReport.UserData;
                _appSettings.Set(StorageKey.SessionId, userData.SessionId);
                _appSettings.Set(StorageKey.UserDisplayName, userData.DisplayName);
                _appSettings.Set(StorageKey.City, userData.City);
                _appSettings.Set(StorageKey.UserStatus, userData.Status);
                _appSettings.Set(StorageKey.Country, userData.Country);
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
            /* HttpClient client = new HttpClient();
            var xml = "<?xml version=\"1.0\" encoding=\"utf-8\"?><s:Envelope xmlns:s=\"http://schemas.xmlsoap.org/soap/envelope/\"><s:Body><FullStartupRequest xmlns=\"http://tempuri.org/\"><username>bujdeabogdan@gmail.com</username><password>115852</password></FullStartupRequest></s:Body></s:Envelope>";
            var httpStringContent = new HttpStringContent(xml, UnicodeEncoding.Utf8, "text/xml");
            client.DefaultRequestHeaders.Add("SOAPAction", "http://tempuri.org/ILoginWebService/FullStartupRequest");
            var message = await
                client.PostAsync(new Uri("https://mapi.toastmasters.org/LoginWebService.svc"), httpStringContent);
            var content = await message.Content.ReadAsStringAsync();
            Debug.WriteLine(content);*/
        }
    }
}