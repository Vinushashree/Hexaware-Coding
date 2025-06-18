using System.ComponentModel.DataAnnotations;

namespace EventManagement.DAL.Entities
{
    public class UserInfo
    {
        [Key]  // ✅ Required
        public string EmailId { get; set; }

        public string UserName { get; set; }
        public string Role { get; set; }
        public string Password { get; set; }
    }
}
