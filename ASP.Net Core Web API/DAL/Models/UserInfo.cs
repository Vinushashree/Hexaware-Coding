using System.ComponentModel.DataAnnotations;
    public class UserInfo
    {
        [Key]
        public string EmailId { get; set; }

        [Required, StringLength(50, MinimumLength = 1)]
        public string UserName { get; set; }

        [Required]
        public string Role { get; set; } // Admin or Participant

        [Required, StringLength(20, MinimumLength = 6)]
        public string Password { get; set; }
    }


