using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using ToastmasterTools.Core.Models;
using ToastmasterTools.Core.ViewModels;

namespace ToastmasterTools.UWP.Views
{
    public sealed partial class HistoryView
    {
        public HistoryView()
        {
            InitializeComponent();
        }

        public HistoryViewModel ViewModel => DataContext as HistoryViewModel;

        private void SpeechTapped(object sender, TappedRoutedEventArgs e)
        {
            ViewModel.ShowSpeech((sender as Border)?.DataContext as Speech);
        }
    }
}