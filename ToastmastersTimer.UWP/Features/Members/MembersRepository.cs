using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Windows.Data.Xml.Dom;
using Windows.Storage;
using Windows.Web.Http;
using Newtonsoft.Json;
using ToastmastersTimer.UWP.Features.Authentication;
using ToastmastersTimer.UWP.Features.Communication;
using ToastmastersTimer.UWP.Models.Reports;
using ToastmastersTimer.UWP.Services.SettingsServices;
using ToastmastersTimer.UWP.ViewModels;

namespace ToastmastersTimer.UWP.Features.Members
{
    public class MembersRepository : IMembersRepository
    {
        private readonly IWebClient _webClient;
        private readonly IAuthenticationService _authenticationService;
        private readonly IAppSettings _appSettings;

        public MembersRepository(IWebClient webClient, IAuthenticationService authenticationService, IAppSettings appSettings)
        {
            _webClient = webClient;
            _authenticationService = authenticationService;
            _appSettings = appSettings;
        }

        public async Task<MembersReport> RefreshClubMembers()
        {
            MembersReport membersReport;
            var responseMessage = await ExecuteMembersRequest();
            var xml = await responseMessage.Content.ReadAsStringAsync();
            if (responseMessage.StatusCode == HttpStatusCode.InternalServerError && xml.Contains("InvalidSessionFault"))
            {
                var report = await _authenticationService.LoginWithStoredCredentials();
                if (report.Successful)
                    await RefreshClubMembers();
                else
                {
                    membersReport = new MembersReport(false, null) { Error = report.Error };
                    return membersReport;
                }
            }
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            var members = new List<Member>();
            var nodeList = doc.GetElementsByTagName("b:MemberIdentification");
            foreach (var memberNode in nodeList)
            {
                var node = memberNode.ChildNodes.FirstOrDefault(c => c.NodeName == "Name");
                members.Add(new Member(node.InnerText));
            }
            var storageFile = await ApplicationData.Current.LocalFolder.CreateFileAsync("members.txt", CreationCollisionOption.OpenIfExists);
            await FileIO.WriteTextAsync(storageFile, JsonConvert.SerializeObject(members));
            membersReport = new MembersReport(true, members);
            return membersReport;
        }

        public async Task<MembersReport> RetrieveClubMembers()
        {
            var storageFile = await ApplicationData.Current.LocalFolder.CreateFileAsync("members.txt", CreationCollisionOption.OpenIfExists);
            var json = await FileIO.ReadTextAsync(storageFile);
            var members = JsonConvert.DeserializeObject<List<Member>>(json);
            var membersReport = new MembersReport(true, members);
            return membersReport;
        }

        private async Task<HttpResponseMessage> ExecuteMembersRequest()
        {
            var xml = "<?xml version=\"1.0\" encoding=\"utf-8\"?><s:Envelope xmlns:s=\"http://schemas.xmlsoap.org/soap/envelope/\"><s:Body><GetActiveMembersForClub xmlns=\"http://tempuri.org/\"><sessionID xmlns:d4p1=\"http://schemas.datacontract.org/2004/07/TI.Commons.Login\" xmlns:i=\"http://www.w3.org/2001/XMLSchema-instance\"><Value xmlns=\"http://schemas.datacontract.org/2004/07/TI.Commons.General\">" + _appSettings.Get<string>(StorageKey.SessionId) + "</Value></sessionID><member xmlns:d4p1=\"http://schemas.datacontract.org/2004/07/TI.Commons.Members\" xmlns:i=\"http://www.w3.org/2001/XMLSchema-instance\"><Value xmlns=\"http://schemas.datacontract.org/2004/07/TI.Commons.General\">04889705</Value></member><clubID xmlns:d4p1=\"http://schemas.datacontract.org/2004/07/TI.Commons.Club\" xmlns:i=\"http://www.w3.org/2001/XMLSchema-instance\"><Value xmlns=\"http://schemas.datacontract.org/2004/07/TI.Commons.General\">01712971</Value></clubID></GetActiveMembersForClub></s:Body></s:Envelope>";
            var message = await _webClient.ExecuteSOAPRequest("https://mapi.toastmasters.org/ClubWebService.svc", xml, "http://tempuri.org/IClubWebService/GetActiveMembersForClub");
            return message;
        }
    }
}
