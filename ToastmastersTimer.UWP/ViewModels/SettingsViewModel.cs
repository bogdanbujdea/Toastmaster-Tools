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
        private readonly IAppSettings _appSettings;

        public SettingsViewModel(IStatisticsService statisticsService, IAppSettings appSettings)
        {
            _statisticsService = statisticsService;
            _appSettings = appSettings;
        }

        public override async Task OnNavigatedFromAsync(IDictionary<string, object> pageState, bool suspending)
        {
            _statisticsService.RegisterPage("SettingsView");
        }

        public bool VibrationIsEnabled
        {
            get { return _appSettings.Get<bool>(StorageKey.VibrationEnabled); }
            set
            {
                _appSettings.Set(StorageKey.VibrationEnabled, value);
                _statisticsService.RegisterEvent(EventCategory.AppEvent, EventAction.Settings, value.ToString());
                RaisePropertyChanged();
            }
        }
    }
}