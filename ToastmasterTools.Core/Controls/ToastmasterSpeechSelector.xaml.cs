using ToastmasterTools.Core.Features.SpeechTools;

namespace ToastmasterTools.Core.Controls
{
    public sealed partial class ToastmasterSpeechSelector
    {
        public ToastmasterSpeechSelector()
        {
            InitializeComponent();
            Loaded += ControlLoaded;
        }

        private void ControlLoaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            Lessons.SelectionChanged += SelectedSpeechChanged;
        }

        private void SelectedSpeechChanged(object sender, Windows.UI.Xaml.Controls.SelectionChangedEventArgs e)
        {
            ViewModel.OnSelectedSpeechChanged(e);
        }

        public SpeechSelector ViewModel => DataContext as SpeechSelector;
    }
}