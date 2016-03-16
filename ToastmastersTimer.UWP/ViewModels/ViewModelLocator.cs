using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using ToastmastersTimer.UWP.Features.Analytics;

namespace ToastmastersTimer.UWP.ViewModels
{
    public class ViewModelLocator
    {
        static ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register<IStatisticsService, StatisticsService>();
            SimpleIoc.Default.Register<ToastmastersTimerViewModel>();
            SimpleIoc.Default.Register<TimerViewModel>();
            SimpleIoc.Default.Register<HomeViewModel>();        
        }

        public HomeViewModel HomeViewModel => ServiceLocator.Current.GetInstance<HomeViewModel>();
        public TimerViewModel TimerViewModel => ServiceLocator.Current.GetInstance<TimerViewModel>();
        public ToastmastersTimerViewModel ToastmastersTimerViewModel => ServiceLocator.Current.GetInstance<ToastmastersTimerViewModel>();
    }
}
