using System.Collections.Generic;
using System.Linq;

public class UserInfoRepo : IUserInfoRepo
{
    private readonly ApplicationDbContext _context;

    public UserInfoRepo(ApplicationDbContext context)
    {
        _context = context;
    }

    public IEnumerable<UserInfo> GetAllUsers()
    {
        return _context.UserInfos.ToList();
    }

    public UserInfo GetUserByEmail(string email)
    {
        return _context.UserInfos.Find(email);
    }

    public void AddUser(UserInfo user)
    {
        _context.UserInfos.Add(user);
    }

    public void UpdateUser(UserInfo user)
    {
        _context.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
    }

    public void DeleteUser(string email)
    {
        var user = _context.UserInfos.Find(email);
        if (user != null)
        {
            _context.UserInfos.Remove(user);
        }
    }

    public void Save()
    {
        _context.SaveChanges();
    }
}

