using System.ComponentModel.DataAnnotations;

public class EventDetails
{
    [Key]
    public int EventId { get; set; }

    [Required, MaxLength(50)]
    public string EventName { get; set; }

    [Required, MaxLength(50)]
    public string EventCategory { get; set; }

    [Required]
    public DateTime EventDate { get; set; }

    public string? Description { get; set; }

    [Required]
    [RegularExpression("Active|In-Active")]
    public string Status { get; set; }
}
