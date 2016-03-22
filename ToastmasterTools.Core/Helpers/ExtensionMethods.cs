using System;

namespace ToastmasterTools.Core.Helpers
{
    public static class ExtensionMethods
    {
        public static string GetTimeText(this int time)
        {
            return time < 10 ? "0" + time : time.ToString();
        }

        public static TimeSpan ToTimeSpan(this string text)
        {
            if (string.IsNullOrEmpty(text))
                return default(TimeSpan);
            try
            {
                var time = text.Split(':');
                var minutes = int.Parse(time[0]);
                var seconds = int.Parse(time[1]);
                return new TimeSpan(0, minutes, seconds);
            }
            catch (Exception)
            {
                return default(TimeSpan);
            }
        }
    }
}