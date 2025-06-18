// Interfaces/IUserRepository.cs
using HotPot.DAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotPot.DAL.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllAsync();
        Task<User> GetByIdAsync(int id);
        Task<User> GetByEmailAsync(string email);
        Task AddAsync(User user);
        Task UpdateAsync(User user);
        Task DeleteAsync(int id);
    }
}

