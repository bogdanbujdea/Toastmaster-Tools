using System.Threading.Tasks;
using Windows.Web.Http;

namespace ToastmastersTimer.UWP.Features.Communication
{
    public interface IWebClient
    {
        Task<HttpResponseMessage> ExecuteSOAPRequest(string uri, string data, string soapAction);
    }
}