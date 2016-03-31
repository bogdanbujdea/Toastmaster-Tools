using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Windows.UI.Xaml.Navigation;
using ToastmasterTools.Core.Features.AHCounter;
using ToastmasterTools.Core.Features.Analytics;
using ToastmasterTools.Core.Features.Members;
using ToastmasterTools.Core.Features.SpeechTools;
using ToastmasterTools.Core.Services.SettingsServices;

namespace ToastmasterTools.Core.ViewModels
{
    public class GrammarViewModel: RoleViewModel
    {
        private readonly IStatisticsService _statisticsService;

        public GrammarViewModel(IStatisticsService statisticsService, IMemberSelector memberSelector, IAppSettings appSettings, ISpeechSelector speechSelector): base(appSettings, memberSelector, speechSelector)
        {
            _statisticsService = statisticsService;
        }

        public override Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            _statisticsService.RegisterPage("GrammarView");
            return base.OnNavigatedToAsync(parameter, mode, state);
        }

        public ObservableCollection<Counter> Counters { get; set; }

        public void AddCounter()
        {
            
        }

        public void RemoveCounter(string counterName)
        {
            
        }

        public async Task SaveSession()
        {
            
        }
    }
}