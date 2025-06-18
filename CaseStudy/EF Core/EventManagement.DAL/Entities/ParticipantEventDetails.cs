using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

public class ParticipantEventDetails
{
    [Key]
    public int Id { get; set; }

    [ForeignKey("UserInfo")]
    [Required]
    public string ParticipantEmailId { get; set; }

    [ForeignKey("EventDetails")]
    [Required]
    public int EventId { get; set; }

    [Required]
    [RegularExpression("Yes|No")]
    public string IsAttended { get; set; }
}
