using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using ToastmasterTools.Core.Features.Analytics;
using ToastmasterTools.Core.Features.Authentication;
using ToastmasterTools.Core.Features.Communication;
using ToastmasterTools.Core.Features.Feedback;
using ToastmasterTools.Core.Features.Members;
using ToastmasterTools.Core.Features.UserDialogs;
using ToastmasterTools.Core.Services.SettingsServices;

namespace ToastmasterTools.Core.ViewModels
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
            SimpleIoc.Default.Register<AHCounterViewModel>();        
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
        public AHCounterViewModel AHCounterViewModel => ServiceLocator.Current.GetInstance<AHCounterViewModel>();
    }
}
