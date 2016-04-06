using System;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;

namespace ToastmasterTools.Core.Helpers.Converters
{
    public class NullToCommandBarVisibility: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value == null)
                return AppBarClosedDisplayMode.Hidden;
            return AppBarClosedDisplayMode.Compact;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new System.NotImplementedException();
        }
    }
}
