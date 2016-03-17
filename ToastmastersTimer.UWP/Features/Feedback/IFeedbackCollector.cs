using System.Threading.Tasks;

namespace ToastmastersTimer.UWP.Features.Feedback
{
    public interface IFeedbackCollector
    {
        Task CheckForFeedback(int sessionsCountBeforeFeedback = 5, int sessionsCountBeforeRating = 3);
    }
}