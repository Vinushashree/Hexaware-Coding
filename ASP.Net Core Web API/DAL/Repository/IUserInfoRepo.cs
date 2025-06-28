using System.Collections.Generic;

public interface IUserInfoRepo
{
    IEnumerable<UserInfo> GetAllUsers();
    UserInfo GetUserByEmail(string email);
    void AddUser(UserInfo user);
    void UpdateUser(UserInfo user);
    void DeleteUser(string email);
    void Save();
}

