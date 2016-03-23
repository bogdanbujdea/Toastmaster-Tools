using System;
using System.Threading.Tasks;
using System.Xml;
using Windows.Web;
using Windows.Web.Http;
using ToastmasterTools.Core.Features.Communication;
using ToastmasterTools.Core.Models.Reports;
using ToastmasterTools.Core.Services.SettingsServices;

namespace ToastmasterTools.Core.Features.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IWebClient _webClient;
        private readonly IAppSettings _appSettings;

        public AuthenticationService(IWebClient webClient, IAppSettings appSettings)
        {
            _webClient = webClient;
            _appSettings = appSettings;
        }

        public async Task<AuthenticationReport> Login(string username, string password)
        {
            var report = new AuthenticationReport();
            try
            {
                var message = await ExecuteLoginRequest(username, password);
                var content = await message.Content.ReadAsStringAsync();
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(content);
                var invalidCredentials = doc.DocumentElement.GetElementsByTagName("InvalidCredentialsFault").Count > 0;
                if (invalidCredentials)
                {
                    report.Error = WebError.InvalidCredentials;
                    return report;
                }
                var userData = GetUserDataFromXml(doc);
                report = new AuthenticationReport(true) { UserData = userData };
            }
            catch (Exception exception)
            {
                var webErrorStatus = Windows.Web.WebError.GetStatus(exception.HResult);
                if (webErrorStatus == WebErrorStatus.HostNameNotResolved)
                    report.ErrorMessage = "Please check your internet connection and try again";
                else report.ErrorMessage = "Unknown error. Please try again!";
                return report;
            }
            return report;
        }

        public async Task<AuthenticationReport> LoginWithStoredCredentials()
        {
            var username = _appSettings.Get<string>(StorageKey.Username);
            var password = _appSettings.Get<string>(StorageKey.Password);
            return await Login(username, password);
        }

        private async Task<HttpResponseMessage> ExecuteLoginRequest(string username, string password)
        {
            var xml =
                "<?xml version=\"1.0\" encoding=\"utf-8\"?><s:Envelope xmlns:s=\"http://schemas.xmlsoap.org/soap/envelope/\"><s:Body><FullStartupRequest xmlns=\"http://tempuri.org/\"><username>" +
                username + "</username><password>" + password + "</password></FullStartupRequest></s:Body></s:Envelope>";
            var message = await _webClient.ExecuteSOAPRequest("https://mapi.toastmasters.org/LoginWebService.svc", xml, "http://tempuri.org/ILoginWebService/FullStartupRequest");
            return message;
        }

        private static UserData GetUserDataFromXml(XmlDocument doc)
        {
            var city = doc.DocumentElement.GetElementsByTagName("b:City").Item(0).InnerText;
            var country = doc.DocumentElement.GetElementsByTagName("b:Country").Item(0).InnerText;
            var status = doc.DocumentElement.GetElementsByTagName("b:MembershipStatus").Item(0).InnerText;
            var sessionId = doc.DocumentElement.GetElementsByTagName("b:ID").Item(0).InnerText;
            var expiration = doc.DocumentElement.GetElementsByTagName("b:Expiration").Item(0).InnerText;
            var displayName = doc.DocumentElement.GetElementsByTagName("b:DisplayName").Item(0).InnerText;
            var userData = new UserData(displayName, city, country, status, sessionId, expiration);
            return userData;
        }
    }
}
