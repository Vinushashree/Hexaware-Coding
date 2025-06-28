using System.ComponentModel.DataAnnotations;
using System.Collections.Generic; // for ICollection
using System;

namespace DAL.Models // ✅ This is the key fix
{
    public class EventDetails
    {
        [Key]
        public int EventId { get; set; }

        [Required, StringLength(50, MinimumLength = 1)]
        public string EventName { get; set; }

        [Required, StringLength(50, MinimumLength = 1)]
        public string EventCategory { get; set; }

        [Required]
        public DateTime EventDate { get; set; }

        public string? Description { get; set; }

        [Required]
        [RegularExpression("Active|In-Active", ErrorMessage = "Status must be either 'Active' or 'In-Active'")]
        public string Status { get; set; }

        // Navigation Properties
        public ICollection<SessionInfo> Sessions { get; set; }
        public ICollection<ParticipantEventDetails> Participants { get; set; }
    }
}

