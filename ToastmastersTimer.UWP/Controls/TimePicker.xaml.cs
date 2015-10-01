using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using ToastmastersTimer.UWP.Models;

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

        private void ViewLoaded(object sender, RoutedEventArgs e)
        {
            MinutesBox.SelectedIndex = 0;
            SecondsBox.SelectedIndex = 0;
        }

        public TimePickerViewModel ViewModel => DataContext as TimePickerViewModel;

        public Time SelectedTime
        {
            get { return (Time)GetValue(SelectedTimeProperty); }
            set { SetValue(SelectedTimeProperty, value); }
        }

        public static readonly DependencyProperty SelectedTimeProperty =
            DependencyProperty.Register("SelectedTime", typeof(Time), typeof(TimePicker), new PropertyMetadata(new Time(), PropertyChangedCallback));

        private static void PropertyChangedCallback(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
        {
            var timePicker = dependencyObject as TimePicker;
            var time = dependencyPropertyChangedEventArgs.NewValue as Time;
            if (timePicker != null && timePicker.ViewModel.IsInitialized)
            {
                timePicker.ViewModel.SelectedTime = time;
                var minute = timePicker.ViewModel.Minutes.FirstOrDefault(m => int.Parse(m) == time.Minutes);
                var second = timePicker.ViewModel.Seconds.FirstOrDefault(m => int.Parse(m) == time.Seconds);
                if(!timePicker.MinutesBox.Items.Any() || !timePicker.MinutesBox.Items.Any())
                    return;
                timePicker.MinutesBox.SelectedIndex = timePicker.ViewModel.Minutes.IndexOf(minute);
                timePicker.SecondsBox.SelectedIndex = timePicker.ViewModel.Seconds.IndexOf(second);
            }
        }

        private void MinutesChanged(object sender, SelectionChangedEventArgs e)
        {
            if(ViewModel.SelectedTime == null)
                ViewModel.SelectedTime = new Time();
            ViewModel.SelectedTime = new Time(int.Parse(MinutesBox.SelectedItem as string), ViewModel.SelectedTime.Seconds);
        }

        private void SecondsChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ViewModel.SelectedTime == null)
                ViewModel.SelectedTime = new Time();
            ViewModel.SelectedTime = new Time(ViewModel.SelectedTime.Minutes, int.Parse(SecondsBox.SelectedItem as string));
        }
    }
}