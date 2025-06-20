﻿namespace HotPot.DAL.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Role { get; set; }

        public ICollection<Cart> Carts { get; set; }  // optional back-reference
    }
}

