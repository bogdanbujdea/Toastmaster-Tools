using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace ToastmastersTimer.UWP.Helpers.Converters
{
    public class ReversedBooleanToVisiblityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            bool b = (bool)value;
            if (b)
                return Visibility.Collapsed;
            return Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            var visibility = value as Visibility?;
            return visibility == Visibility.Collapsed;
        }
    }
}