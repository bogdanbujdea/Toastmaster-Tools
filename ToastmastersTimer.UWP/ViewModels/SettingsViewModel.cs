using System.Collections.Generic;
using System.Threading.Tasks;
using Template10.Mvvm;
using ToastmastersTimer.UWP.Features.Analytics;
using ToastmastersTimer.UWP.Services.SettingsServices;

namespace ToastmastersTimer.UWP.ViewModels
{
    public class SettingsViewModel: ViewModelBase
    {
        private readonly IStatisticsService _statisticsService;

        public SettingsViewModel(IStatisticsService statisticsService)
        {
            _statisticsService = statisticsService;
        }

        public override async Task OnNavigatedFromAsync(IDictionary<string, object> pageState, bool suspending)
        {
            _statisticsService.RegisterPage("SettingsView");
        }

        public bool VibrationIsEnabled
        {
            get { return SettingsService.Instance.VibrationIsEnabled; }
            set
            {
                SettingsService.Instance.VibrationIsEnabled = value;
                _statisticsService.RegisterEvent(EventCategory.AppEvent, EventAction.Settings, value.ToString());
                RaisePropertyChanged();
            }
        }
    }
}