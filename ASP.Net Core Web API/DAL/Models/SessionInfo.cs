using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace DAL.Models // ✅ Wrap the class in the proper namespace
{
    public class SessionInfo
    {
        [Key]
        public int SessionId { get; set; }

        [Required]
        public int EventId { get; set; }

        [ForeignKey("EventId")]
        public EventDetails Event { get; set; } // ✅ This will now be recognized

        [Required, StringLength(50, MinimumLength = 1)]
        public string SessionTitle { get; set; }

        public int? SpeakerId { get; set; }

        [ForeignKey("SpeakerId")]
        public SpeakersDetails? Speaker { get; set; } // ✅ This too

        public string? Description { get; set; }

        [Required]
        public DateTime SessionStart { get; set; }

        [Required]
        public DateTime SessionEnd { get; set; }

        public string? SessionUrl { get; set; }
    }
}

