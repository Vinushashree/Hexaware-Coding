using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace DAL.Models // ✅ Add this to match other model files
{
    public class ParticipantEventDetails
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string ParticipantEmailId { get; set; }

        [ForeignKey("ParticipantEmailId")]
        public UserInfo Participant { get; set; }

        [Required]
        public int EventId { get; set; }

        [ForeignKey("EventId")]
        public EventDetails Event { get; set; }

        [Required]
        [RegularExpression("Yes|No", ErrorMessage = "IsAttended must be 'Yes' or 'No'")]
        public string IsAttended { get; set; }
    }
}
