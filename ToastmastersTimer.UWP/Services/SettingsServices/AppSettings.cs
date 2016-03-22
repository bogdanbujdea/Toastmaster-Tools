using System;

namespace ToastmastersTimer.UWP.Services.SettingsServices
{
    public class AppSettings : IAppSettings
    {
        readonly Template10.Services.SettingsService.SettingsHelper _helper;

        public AppSettings()
        {
            _helper = new Template10.Services.SettingsService.SettingsHelper();
        }

        public T Get<T>(StorageKey key)
        {
            try
            {
                return _helper.Read(key.ToString(), default(T));
            }
            catch (Exception)
            {
                return default(T);
            }
        }

        public void Set<T>(StorageKey key, T value)
        {
            _helper.Write(key.ToString(), value);
        }

        public void Remove(StorageKey key)
        {
            _helper.Remove(key.ToString());
        }
    }
}
