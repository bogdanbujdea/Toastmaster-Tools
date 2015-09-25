namespace ToastmastersTimer.UWP.Views
{
    using ViewModels;

    public sealed partial class TimerView
    {
        public TimerView()
        {
            InitializeComponent();
        }
        
        public TimerViewModel ViewModel => DataContext as TimerViewModel;
    }
}