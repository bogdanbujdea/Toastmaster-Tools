using System;
using System.Threading.Tasks;
using Windows.ApplicationModel.Core;
using Windows.UI.Core;
using Windows.UI.Popups;

namespace ToastmasterTools.Core.Features.UserDialogs
{
    public class DialogService : IDialogService
    {
        private static TaskCompletionSource<bool> _currentDialogShowRequest;

        public async Task<bool> AskQuestion(string question, string title = null, string approveMessage = "Yes", string cancelMessage = "No")
        {
            while (_currentDialogShowRequest != null)
            {
                await _currentDialogShowRequest.Task;
            }

            var request = _currentDialogShowRequest = new TaskCompletionSource<bool>();
            approveMessage = string.IsNullOrWhiteSpace(approveMessage)
                            ? "Yes"
                            : approveMessage;
            cancelMessage = string.IsNullOrWhiteSpace(cancelMessage)
                            ? "No"
                            : cancelMessage;
            var messageDialog = string.IsNullOrEmpty(title) ? new MessageDialog(question) : new MessageDialog(question, title);
            var result = false;
            messageDialog.Commands.Add(new UICommand { Id = "yes", Label = approveMessage, Invoked = delegate { result = true; } });
            messageDialog.Commands.Add(new UICommand { Id = "no", Label = cancelMessage, Invoked = delegate { result = false; } });
            await messageDialog.ShowAsync();
            _currentDialogShowRequest = null;
            request.SetResult(result);
            return result;
        }

        public async Task<bool> ShowMessageDialog(string message, string title = null, string dismissButtonTitle = "Ok")
        {
            while (_currentDialogShowRequest != null)
            {
                await _currentDialogShowRequest.Task;
            }

            var request = _currentDialogShowRequest = new TaskCompletionSource<bool>();
            var result = false;
            if (CoreApplication.MainView != null && CoreApplication.MainView.CoreWindow != null)
            {
                var dispatcher = CoreApplication.MainView.CoreWindow.Dispatcher;
                if (dispatcher != null)
                {
                    await dispatcher.RunAsync(CoreDispatcherPriority.Normal, async () =>
                    {
                        var dialog = new MessageDialog(message, title ?? string.Empty);
                        dismissButtonTitle = string.IsNullOrWhiteSpace(dismissButtonTitle)
                            ? "Ok"
                            : dismissButtonTitle;
                        dialog.Commands.Add(new UICommand
                        {
                            Id = "dismissButton",
                            Label = dismissButtonTitle,
                            Invoked = delegate
                            {
                                result = true;
                            }
                        });
                        await dialog.ShowAsync();
                        _currentDialogShowRequest = null;
                        request.SetResult(result);
                    });
                }
            }
            return result;
        }
    }
}