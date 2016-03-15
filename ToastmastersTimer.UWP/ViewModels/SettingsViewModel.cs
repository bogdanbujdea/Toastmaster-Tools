using Template10.Mvvm;
using ToastmastersTimer.UWP.Services.SettingsServices;

namespace ToastmastersTimer.UWP.ViewModels
{
    public class SettingsViewModel: ViewModelBase
    {
        public bool VibrationIsEnabled
        {
            get { return SettingsService.Instance.VibrationIsEnabled; }
            set
            {
                SettingsService.Instance.VibrationIsEnabled = value;
                RaisePropertyChanged();
            }
        }
    }
}