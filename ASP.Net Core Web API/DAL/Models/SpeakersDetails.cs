using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace DAL.Models // ✅ Wrap the class in this namespace
{
    public class SpeakersDetails
    {
        [Key]
        public int SpeakerId { get; set; }

        [Required, StringLength(50, MinimumLength = 1)]
        public string SpeakerName { get; set; }

        // Navigation Property
        public ICollection<SessionInfo> Sessions { get; set; }
    }
}


