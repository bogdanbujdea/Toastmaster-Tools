using ToastmastersTimer.UWP.ViewModels;

namespace ToastmastersTimer.UWP.Views
{
    public sealed partial class SpeechPracticeView
    {
        public SpeechPracticeView()
        {
            InitializeComponent();
        }

        public SpeechPracticeViewModel ViewModel => DataContext as SpeechPracticeViewModel;
    }
}