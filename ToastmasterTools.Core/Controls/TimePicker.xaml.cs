using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using ToastmasterTools.Core.Models;
using ToastmasterTools.Core.ViewModels;

namespace ToastmasterTools.Core.Controls
{
    public sealed partial class TimePicker
    {
        public TimePicker()
        {
            InitializeComponent();
            ViewModel.Initialize();
        }

        public TimePickerViewModel ViewModel => DataContext as TimePickerViewModel;

        public CardTime SelectedCardTime
        {
            get { return (CardTime)GetValue(SelectedCardTimeProperty); }
            set { SetValue(SelectedCardTimeProperty, value); }
        }

        public static readonly DependencyProperty SelectedCardTimeProperty =
            DependencyProperty.Register("SelectedCardTime", typeof(CardTime), typeof(TimePicker), new PropertyMetadata(new CardTime(), PropertyChangedCallback));

        private static void PropertyChangedCallback(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
        {
            var timePicker = dependencyObject as TimePicker;
            var time = dependencyPropertyChangedEventArgs.NewValue as CardTime;
            if (timePicker != null && timePicker.ViewModel.IsInitialized)
            {
                timePicker.SelectedCardTime = time;
                var minute = timePicker.ViewModel.Minutes.FirstOrDefault(m => time != null && int.Parse(m) == time.Minutes);
                var second = timePicker.ViewModel.Seconds.FirstOrDefault(m => time != null && int.Parse(m) == time.Seconds);
                if (!timePicker.MinutesBox.Items.Any() || !timePicker.MinutesBox.Items.Any())
                    return;
                timePicker.MinutesBox.SelectedIndex = timePicker.ViewModel.Minutes.IndexOf(minute);
                timePicker.SecondsBox.SelectedIndex = timePicker.ViewModel.Seconds.IndexOf(second);
            }
        }

        private void MinutesChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SelectedCardTime == null || MinutesBox.SelectedItem == null)
                SelectedCardTime = new CardTime();
            SelectedCardTime = new CardTime(int.Parse(MinutesBox.SelectedItem as string), SelectedCardTime.Seconds);
        }

        private void SecondsChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SelectedCardTime == null || SecondsBox.SelectedItem == null)
                SelectedCardTime = new CardTime();
            SelectedCardTime = new CardTime(SelectedCardTime.Minutes, int.Parse(SecondsBox.SelectedItem as string));
        }

        private void MinutesLoaded(object sender, RoutedEventArgs e)
        {
            var minute = ViewModel.Minutes.FirstOrDefault(m => int.Parse(m) == SelectedCardTime.Minutes);
            if (!MinutesBox.Items.Any() || !MinutesBox.Items.Any())
                return;
            MinutesBox.SelectedIndex = ViewModel.Minutes.IndexOf(minute);
        }

        private void SecondsLoaded(object sender, RoutedEventArgs e)
        {
            var second = ViewModel.Seconds.FirstOrDefault(m => int.Parse(m) == SelectedCardTime.Seconds);
            if (!MinutesBox.Items.Any() || !MinutesBox.Items.Any())
                return;
            SecondsBox.SelectedIndex = ViewModel.Seconds.IndexOf(second);
        }
    }
}