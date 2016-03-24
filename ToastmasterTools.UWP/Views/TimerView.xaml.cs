using Windows.UI.Xaml;
using ToastmasterTools.Core.ViewModels;

namespace ToastmasterTools.UWP.Views
{
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
            ViewModel.SelectedSpeechType = ViewModel.Lessons[0];
            ViewModel.ShowSpeechUI();
        }
    }
}