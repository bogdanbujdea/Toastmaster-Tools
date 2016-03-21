using Windows.UI.Xaml;

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

        private void ShowSpeechUI(object sender, RoutedEventArgs e)
        {
            DefaultTimes.SelectedIndex = 0;
            ViewModel.SelectedLesson = ViewModel.Lessons[0];
            ViewModel.ShowSpeechUI();
        }
    }
}