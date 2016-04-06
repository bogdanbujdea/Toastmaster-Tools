using Windows.UI.Xaml.Input;
using ToastmasterTools.Core.Features.AHCounter;

namespace ToastmasterTools.Core.Controls
{
    public sealed partial class CounterControl
    {
        public CounterControl()
        {
            InitializeComponent();
        }

        public Counter CounterViewModel => DataContext as Counter;

        private void IncreaseCount(object sender, TappedRoutedEventArgs e)
        {
            CounterViewModel.Count++;
        }

        private void DecreaseCount(object sender, TappedRoutedEventArgs e)
        {
            CounterViewModel.Count--;
        }

        private void Reset(object sender, TappedRoutedEventArgs e)
        {
            CounterViewModel.Count = 0;
        }

        private void Remove(object sender, TappedRoutedEventArgs e)
        {
            CounterViewModel.NotifyDelete();
        }
    }
}