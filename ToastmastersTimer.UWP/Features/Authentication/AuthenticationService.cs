using System;
using System.Threading.Tasks;
using System.Xml;
using Windows.Storage.Streams;
using Windows.Web.Http;

namespace ToastmastersTimer.UWP.Features.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        public async Task<AuthenticationReport> Login(string username, string password)
        {
            var report = new AuthenticationReport();
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
            var authenticationReport = new AuthenticationReport(true) { UserData = userData };
            return authenticationReport;
        }

        private static async Task<HttpResponseMessage> ExecuteLoginRequest(string username, string password)
        {
            HttpClient client = new HttpClient();
            var xml =
                "<?xml version=\"1.0\" encoding=\"utf-8\"?><s:Envelope xmlns:s=\"http://schemas.xmlsoap.org/soap/envelope/\"><s:Body><FullStartupRequest xmlns=\"http://tempuri.org/\"><username>" +
                username + "</username><password>" + password + "</password></FullStartupRequest></s:Body></s:Envelope>";
            var httpStringContent = new HttpStringContent(xml, UnicodeEncoding.Utf8, "text/xml");
            client.DefaultRequestHeaders.Add("SOAPAction", "http://tempuri.org/ILoginWebService/FullStartupRequest");
            var message = await
                client.PostAsync(new Uri("https://mapi.toastmasters.org/LoginWebService.svc"), httpStringContent);
            return message;
        }

        private static UserData GetUserDataFromXml(XmlDocument doc)
        {
            var city = doc.DocumentElement.GetElementsByTagName("b:City").Item(0).InnerText;
            var country = doc.DocumentElement.GetElementsByTagName("b:Country").Item(0).InnerText;
            var status = doc.DocumentElement.GetElementsByTagName("b:MembershipStatus").Item(0).InnerText;
            var sessionId = doc.DocumentElement.GetElementsByTagName("b:ID").Item(0).InnerText;
            var displayName = doc.DocumentElement.GetElementsByTagName("b:DisplayName").Item(0).InnerText;
            var userData = new UserData(displayName, city, country, status, sessionId);
            return userData;
        }
    }
}
