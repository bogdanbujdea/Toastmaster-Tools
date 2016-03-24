namespace ToastmasterTools.Core.Models
{
    public class Member
    {
        public Member()
        {
            Function = "Unknown";
        }

        public int MemberId { get; set; }

        public string Name { get; set; }

        public string Function { get; set; }

        public SpeechType CurrentLesson { get; set; }

        public string ImageUrl { get; set; }

        public string Club { get; set; }
    }
}