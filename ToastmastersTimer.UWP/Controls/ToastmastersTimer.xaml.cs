using Microsoft.Practices.ServiceLocation;
using ToastmastersTimer.UWP.ViewModels;

namespace ToastmastersTimer.UWP.Controls
{
    public sealed partial class ToastmastersTimer
    {
        public ToastmastersTimer()
        {
            InitializeComponent();
        }

        public ToastmastersTimerViewModel ViewModel => ServiceLocator.Current.GetInstance<ToastmastersTimerViewModel>();
    }
}