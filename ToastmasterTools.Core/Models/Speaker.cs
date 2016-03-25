using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToastmasterTools.Core.Models
{
    public class Speaker
    {
        public Speaker()
        {
            Function = "Unknown";
            IsMember = true;
        }

        [Key]
        public int SpeakerId { get; set; }

        [ForeignKey("Speech")]
        public int SpeechId { get; set; }

        public virtual ICollection<Speech> Speeches { get; set; }

        public string Name { get; set; }

        public string Function { get; set; }

        public string CurrentLesson { get; set; }
        
        public string ImageUrl { get; set; }

        public string Club { get; set; }

        public bool IsMember { get; set; }
    }
}