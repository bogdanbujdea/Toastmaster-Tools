using System.Threading.Tasks;

namespace ToastmastersTimer.UWP.Features.UserDialogs
{
    public interface IDialogService
    {
        Task<bool> AskQuestion(string question, string title = null, string approveMessage = "Yes", string cancelMessage = "No");

        Task<bool> ShowMessageDialog(string message, string title = null, string dismissButtonTitle = "Ok");
    }
}