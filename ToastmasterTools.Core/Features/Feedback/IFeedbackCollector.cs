using System.Threading.Tasks;

namespace ToastmasterTools.Core.Features.Feedback
{
    public interface IFeedbackCollector
    {
        Task CheckForFeedback(int sessionsCountBeforeFeedback = 5, int sessionsCountBeforeRating = 3);
    }
}