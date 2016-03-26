using System.Collections.Generic;

namespace ToastmasterTools.Core.Models
{
    public class Speaker
    {
        public Speaker()
        {
            Function = "Unknown";
            IsMember = true;
        }

        public int SpeakerId { get; set; }
        
        public virtual List<Speech> Speeches { get; set; }

        public string Name { get; set; }

        public string Function { get; set; }

        public string CurrentLesson { get; set; }
        
        public string ImageUrl { get; set; }

        public string Club { get; set; }

        public bool IsMember { get; set; }
    }
}