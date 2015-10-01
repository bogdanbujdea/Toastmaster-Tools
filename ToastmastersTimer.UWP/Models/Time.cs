namespace ToastmastersTimer.UWP.Models
{
    public class Time
    {
        public Time()
        {
            
        }

        public Time(int minutes, int seconds)
        {
            Minutes = minutes;
            Seconds = seconds;
        }

        public int Minutes { get; set; }

        public int Seconds { get; set; }
    }
}