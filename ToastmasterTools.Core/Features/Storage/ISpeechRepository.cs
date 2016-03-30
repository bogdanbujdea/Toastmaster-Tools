using System.Threading.Tasks;
using ToastmasterTools.Core.Models;

namespace ToastmasterTools.Core.Features.Storage
{
    public interface ISpeechRepository
    {
        Task SaveSpeech(Speech speech, string speakerName, string speechName);
    }
}