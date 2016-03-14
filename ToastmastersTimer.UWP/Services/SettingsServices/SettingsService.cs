namespace ToastmastersTimer.UWP.Services.SettingsServices
{
    // DOCS: https://github.com/Windows-XAML/Template10/wiki/Docs-%7C-SettingsService
    public class SettingsService : ISettingsService
    {
        public static SettingsService Instance { get; private set; }

        static SettingsService()
        {
            // implement singleton pattern
            Instance = Instance ?? new SettingsService();
        }

        Template10.Services.SettingsService.SettingsHelper _helper;

        private SettingsService()
        {
            _helper = new Template10.Services.SettingsService.SettingsHelper();
        }

        public bool UseShellBackButton
        {
            get { return _helper.Read<bool>(nameof(UseShellBackButton), true); }
            set
            {
                _helper.Write(nameof(UseShellBackButton), value);
                Template10.Common.BootStrapper.Current.NavigationService.Dispatcher.Dispatch(() =>
                {
                    Template10.Common.BootStrapper.Current.ShowShellBackButton = value;
                    Template10.Common.BootStrapper.Current.UpdateShellBackButton();
                    Template10.Common.BootStrapper.Current.NavigationService.Refresh();
                });
            }
        }

        public bool VibrationIsEnabled
        {
            get { return _helper.Read(nameof(VibrationIsEnabled), true); }
            set
            {
                _helper.Write(nameof(VibrationIsEnabled), value);
            }
        }
    }
}
