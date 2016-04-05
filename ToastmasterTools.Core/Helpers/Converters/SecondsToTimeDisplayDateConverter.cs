using System;
using Windows.UI.Xaml.Data;

namespace ToastmasterTools.Core.Helpers.Converters
{
    public class SecondsToTimeDisplayDateConverter:IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var seconds = System.Convert.ToInt32(value);
            var timespan = TimeSpan.FromSeconds(seconds);
            var text = "";
            if (timespan.Minutes < 10)
                text += "0";
            text += timespan.Minutes + ":";
            if (timespan.Seconds < 10)
                text += "0";
            text += timespan.Seconds;
            return text;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new System.NotImplementedException();
        }
    }
}
