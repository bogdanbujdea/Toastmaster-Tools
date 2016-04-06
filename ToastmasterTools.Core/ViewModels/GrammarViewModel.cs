using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.UI.Xaml.Navigation;
using ToastmasterTools.Core.Features.Analytics;
using ToastmasterTools.Core.Features.Members;
using ToastmasterTools.Core.Features.SpeechTools;
using ToastmasterTools.Core.Features.Storage;
using ToastmasterTools.Core.Features.UserDialogs;
using ToastmasterTools.Core.Services.SettingsServices;

namespace ToastmasterTools.Core.ViewModels
{
    public class GrammarViewModel: RoleViewModel
    {
        private readonly IStatisticsService _statisticsService;

        public GrammarViewModel(IStatisticsService statisticsService,
            IAppSettings appSettings,
            IDialogService dialogService,
            IMemberSelector memberSelector,
            ISpeechRepository speechRepository,
            ISpeechSelector speechSelector) : base(appSettings, memberSelector, speechSelector, dialogService, speechRepository, statisticsService)
        {
            _statisticsService = statisticsService;
            ReviewerRole = ReviewerRole.Grammarian;
        }

        public override Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            _statisticsService.RegisterPage("GrammarView");
            return base.OnNavigatedToAsync(parameter, mode, state);
        }

        public async Task SaveSession()
        {
            await SaveSessionAsync();
        }
    }
}