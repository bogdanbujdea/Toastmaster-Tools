using System;
using System.Threading.Tasks;
using Windows.Storage.Streams;
using Windows.Web.Http;

namespace ToastmasterTools.Core.Features.Communication
{
    public class WebClient : IWebClient
    {
        public async Task<HttpResponseMessage> ExecuteSOAPRequest(string uri, string data, string soapAction)
        {
            HttpClient client = new HttpClient();
            var httpStringContent = new HttpStringContent(data, UnicodeEncoding.Utf8, "text/xml");
            client.DefaultRequestHeaders.Add("SOAPAction", soapAction);
            var message = await
                client.PostAsync(new Uri(uri), httpStringContent);
            return message;
        }
    }
}
