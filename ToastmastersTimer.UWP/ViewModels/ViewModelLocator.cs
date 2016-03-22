using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using ToastmastersTimer.UWP.Features.Analytics;
using ToastmastersTimer.UWP.Features.Authentication;
using ToastmastersTimer.UWP.Features.Communication;
using ToastmastersTimer.UWP.Features.Feedback;
using ToastmastersTimer.UWP.Features.Members;
using ToastmastersTimer.UWP.Features.UserDialogs;
using ToastmastersTimer.UWP.Services.SettingsServices;

namespace ToastmastersTimer.UWP.ViewModels
{
    public class ViewModelLocator
    {
        static ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register<IMembersRepository, MembersRepository>();
            SimpleIoc.Default.Register<IWebClient, WebClient>();
            SimpleIoc.Default.Register<IAuthenticationService, AuthenticationService>();
            SimpleIoc.Default.Register<IStatisticsService, StatisticsService>();
            SimpleIoc.Default.Register<IAppSettings, AppSettings>();
            SimpleIoc.Default.Register<IDialogService, DialogService>();
            SimpleIoc.Default.Register<IFeedbackCollector, FeedbackCollector>();
            SimpleIoc.Default.Register<ProfileViewModel>();        
            SimpleIoc.Default.Register<LoginViewModel>();        
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
        public LoginViewModel LoginViewModel => ServiceLocator.Current.GetInstance<LoginViewModel>();
        public ProfileViewModel ProfileViewModel => ServiceLocator.Current.GetInstance<ProfileViewModel>();
    }
}
