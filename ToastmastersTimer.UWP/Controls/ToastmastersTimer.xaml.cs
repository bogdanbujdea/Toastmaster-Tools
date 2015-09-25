using ToastmastersTimer.UWP.ViewModels;

namespace ToastmastersTimer.UWP.Controls
{
    public sealed partial class ToastmastersTimer
    {
        public ToastmastersTimer()
        {
            InitializeComponent();
        }

        public ToastmastersTimerViewModel ViewModel => DataContext as ToastmastersTimerViewModel;
    }
}