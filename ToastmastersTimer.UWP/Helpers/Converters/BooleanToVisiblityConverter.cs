using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace ToastmastersTimer.UWP.Helpers.Converters
{
    public class BooleanToVisiblityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            bool b = (bool)value;
            if (b)
                return Visibility.Visible;
            return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            var visibility = value as Visibility?;
            return visibility == Visibility.Visible;
        }
    }
}
