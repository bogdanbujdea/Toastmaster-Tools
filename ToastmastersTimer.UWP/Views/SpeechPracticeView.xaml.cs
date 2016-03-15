using System;
using Windows.UI.Core;
using Windows.UI.Xaml;
using ToastmastersTimer.UWP.ViewModels;

namespace ToastmastersTimer.UWP.Views
{
    public sealed partial class SpeechPracticeView
    {
        public SpeechPracticeView()
        {
            InitializeComponent();
            Loaded += ViewLoaded;
        }

        private void ViewLoaded(object sender, RoutedEventArgs e)
        {
            ViewModel.Scroll = TextScroll;
        }

        public SpeechPracticeViewModel ViewModel => DataContext as SpeechPracticeViewModel;

        private async void StartListening(object sender, RoutedEventArgs e)
        {
            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, async () => await ViewModel.StartListeningAsync());
        }
    }
}