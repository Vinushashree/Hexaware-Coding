using System.Collections.Generic;
using System.Linq;
using EventManagement.DAL.Entities;         // ✅ Correct namespace for UserInfo
using Microsoft.EntityFrameworkCore;        // Needed for EF Core
using System;                               // Optional: for logging or error handling

namespace EventManagement.DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly EventDbContext _context;

        public UserRepository(EventDbContext context)
        {
            _context = context;
        }

        public IEnumerable<UserInfo> GetAllUsers()
        {
            return _context.Users.ToList(); // Uses EventManagement.DAL.Entities.UserInfo
        }

        public UserInfo GetUserByEmail(string email)
        {
            return _context.Users.Find(email); // Uses EmailId as PK
        }

        public void AddUser(UserInfo user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void UpdateUser(UserInfo user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
        }

        public void DeleteUser(string email)
        {
            var user = _context.Users.Find(email);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
        }
    }
}
