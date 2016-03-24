namespace ToastmasterTools.Core.Models
{
    public class CardTime
    {
        public CardTime()
        {
            
        }

        public int CardTimeId { get; set; }

        public CardTime(int minutes, int seconds)
        {
            Minutes = minutes;
            Seconds = seconds;
        }

        public int Minutes { get; set; }

        public int Seconds { get; set; }
    }
}