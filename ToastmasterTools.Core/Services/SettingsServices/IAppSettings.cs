namespace ToastmasterTools.Core.Services.SettingsServices
{
    public interface IAppSettings
    {
        T Get<T>(StorageKey key);
        void Set<T>(StorageKey key, T value);
        void Remove(StorageKey key);
    }
}