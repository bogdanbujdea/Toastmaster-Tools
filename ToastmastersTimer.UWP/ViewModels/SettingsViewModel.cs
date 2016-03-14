using Template10.Mvvm;
using ToastmastersTimer.UWP.Services.SettingsServices;

namespace ToastmastersTimer.UWP.ViewModels
{
    public class SettingsViewModel: ViewModelBase
    {
        private bool _vibrationIsEnabled;

        public bool VibrationIsEnabled
        {
            get { return _vibrationIsEnabled; }
            set
            {
                _vibrationIsEnabled = value;
                SettingsService.Instance.VibrationIsEnabled = value;
                RaisePropertyChanged();
            }
        }
    }
}