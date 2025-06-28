using System.Collections.Generic;
using EventManagement.DAL.Entities;

namespace EventManagement.DAL.Repositories
{
    public interface IUserRepository
    {
        IEnumerable<UserInfo> GetAllUsers();
        UserInfo GetUserByEmail(string email);
        void AddUser(UserInfo user);
        void UpdateUser(UserInfo user);
        void DeleteUser(string email);
    }
}
