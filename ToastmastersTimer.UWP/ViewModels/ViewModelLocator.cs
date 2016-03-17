using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using ToastmastersTimer.UWP.Features.Analytics;
using ToastmastersTimer.UWP.Features.Feedback;
using ToastmastersTimer.UWP.Features.UserDialogs;
using ToastmastersTimer.UWP.Services.SettingsServices;

namespace ToastmastersTimer.UWP.ViewModels
{
    public class ViewModelLocator
    {
        static ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register<IStatisticsService, StatisticsService>();
            SimpleIoc.Default.Register<IAppSettings, AppSettings>();
            SimpleIoc.Default.Register<IDialogService, DialogService>();
            SimpleIoc.Default.Register<IFeedbackCollector, FeedbackCollector>();
            SimpleIoc.Default.Register<GroupViewModel>();        
            SimpleIoc.Default.Register<ToastmastersTimerViewModel>();
            SimpleIoc.Default.Register<TimerViewModel>();
            SimpleIoc.Default.Register<SettingsViewModel>();
            SimpleIoc.Default.Register<HomeViewModel>();        
        }

        public HomeViewModel HomeViewModel => ServiceLocator.Current.GetInstance<HomeViewModel>();
        public TimerViewModel TimerViewModel => ServiceLocator.Current.GetInstance<TimerViewModel>();
        public ToastmastersTimerViewModel ToastmastersTimerViewModel => ServiceLocator.Current.GetInstance<ToastmastersTimerViewModel>();
        public SettingsViewModel SettingsViewModel => ServiceLocator.Current.GetInstance<SettingsViewModel>();
        public GroupViewModel GroupViewModel => ServiceLocator.Current.GetInstance<GroupViewModel>();
    }
}
