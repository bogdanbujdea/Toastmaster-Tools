﻿using System;
using Windows.UI.Xaml.Data;

namespace ToastmasterTools.Core.Helpers.Converters
{
    public class NullToBooleanConverter: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return value != null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
