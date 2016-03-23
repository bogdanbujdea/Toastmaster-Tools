using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Windows.ApplicationModel.Email;
using Windows.System;
using ToastmasterTools.Core.Features.UserDialogs;
using ToastmasterTools.Core.Services.SettingsServices;

namespace ToastmasterTools.Core.Features.Feedback
{
    public class FeedbackCollector : IFeedbackCollector
    {
        private readonly IAppSettings _appSettings;
        private readonly IDialogService _dialogService;

        public FeedbackCollector(IAppSettings appSettings, IDialogService dialogService)
        {
            _appSettings = appSettings;
            _dialogService = dialogService;
        }

        public async Task CheckForFeedback(int sessionsCountBeforeFeedback = 5, int sessionsCountBeforeRating = 3)
        {
            var sessionsCount = _appSettings.Get<int>(StorageKey.SessionCount);
            await SendFeedbackAndRating(sessionsCountBeforeFeedback, sessionsCountBeforeRating, sessionsCount);
            sessionsCount++;
            _appSettings.Set(StorageKey.SessionCount, sessionsCount);
        }

        private async Task SendFeedbackAndRating(int sessionsCountBeforeFeedback, int sessionsCountBeforeRating, int sessionsCount)
        {
            try
            {
                if (sessionsCount == sessionsCountBeforeRating)
                {
                    var canRateApp =
                        await _dialogService.AskQuestion("Would you like to rate the app in the Store? It would mean a lot to us!",
                            "Rate us");
                    if (canRateApp)
                    {
                        await
                            Launcher.LaunchUriAsync(
                                new Uri(string.Format("ms-windows-store:REVIEW?PFN={0}",
                                    Windows.ApplicationModel.Package.Current.Id.FamilyName)));
                    }
                }
                if (sessionsCount == sessionsCountBeforeFeedback)
                {
                    var canGiveFeedback =
                        await
                            _dialogService.AskQuestion(
                                "Would you like to give us an email with your opinion about the app? It would mean a lot to us!",
                                "Feedback");
                    if (canGiveFeedback)
                    {
                        await SendEmail();
                    }
                }
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception.Message);
            }
        }

        private static async Task SendEmail()
        {
            var emailMessage = new EmailMessage();
            emailMessage.To.Add(new EmailRecipient("apps@thewindev.net"));
            emailMessage.Subject = "Toastmaster Tools Feedback";
            await EmailManager.ShowComposeNewEmailAsync(emailMessage);
        }
    }
}