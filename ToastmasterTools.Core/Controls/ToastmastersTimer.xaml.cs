using Microsoft.Practices.ServiceLocation;
using ToastmasterTools.Core.ViewModels;

namespace ToastmasterTools.Core.Controls
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