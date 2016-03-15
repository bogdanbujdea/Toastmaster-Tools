using System;
using Windows.Foundation.Collections;
using Windows.Storage;

namespace ToastmastersTimer.UWP.Services.SettingsServices
{
    public class AppSettings
    {
        public static AppSettings Instance { get; private set; }

        static AppSettings()
        {
            Instance = Instance ?? new AppSettings();

        }

        private AppSettings()
        {
        }

        public T Get<T>(StorageKey key)
        {
            try
            {
                return (T)SettingsSet[key.ToString()];
            }
            catch (Exception)
            {
                return default(T);
            }
        }

        public void Set<T>(StorageKey key, T value)
        {
            SettingsSet[key.ToString()] = value;
        }

        public void Remove(StorageKey key)
        {
            SettingsSet[key.ToString()] = null;
        }

        private static IPropertySet SettingsSet
        {
            get { return ApplicationData.Current.LocalSettings.Values; }
        }
    }

    public enum StorageKey
    {
        VibrationEnabled
    }
}
