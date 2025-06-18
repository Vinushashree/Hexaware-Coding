using System.ComponentModel.DataAnnotations;

public class SpeakersDetails
{
    [Key]
    public int SpeakerId { get; set; }

    [Required, MaxLength(50)]
    public string SpeakerName { get; set; }
}
