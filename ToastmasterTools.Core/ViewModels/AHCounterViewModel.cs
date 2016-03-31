using System.Threading.Tasks;
using ToastmasterTools.Core.Features.Analytics;
using ToastmasterTools.Core.Features.Members;
using ToastmasterTools.Core.Features.SpeechTools;
using ToastmasterTools.Core.Features.Storage;
using ToastmasterTools.Core.Features.UserDialogs;
using ToastmasterTools.Core.Services.SettingsServices;

namespace ToastmasterTools.Core.ViewModels
{
    public class AHCounterViewModel : RoleViewModel
    {

        public AHCounterViewModel(IStatisticsService statisticsService, 
            IAppSettings appSettings, 
            IDialogService dialogService, 
            IMemberSelector memberSelector, 
            ISpeechRepository speechRepository,
            ISpeechSelector speechSelector) : base(appSettings, memberSelector, speechSelector, dialogService, speechRepository, statisticsService)
        {
            ReviewerRole = ReviewerRole.AHCounter;
        }

        public async Task SaveSession()
        {
            await base.SaveSessionAsync();
        }
    }
}