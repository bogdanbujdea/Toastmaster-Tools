namespace ToastmastersTimer.UWP.Controls
{
    using ViewModels;

    public sealed partial class TimePicker
    {
        public TimePicker()
        {
            InitializeComponent();
            Loaded += ViewLoaded;
        }

        private void ViewLoaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            MinutesBox.SelectedIndex = 0;
            SecondsBox.SelectedIndex = 0;
        }

        public TimePickerViewModel ViewModel => DataContext as TimePickerViewModel;
    }
}