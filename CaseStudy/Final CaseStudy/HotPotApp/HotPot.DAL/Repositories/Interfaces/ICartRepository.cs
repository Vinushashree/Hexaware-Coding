// Interfaces/ICartRepository.cs
using HotPot.DAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotPot.DAL.Repositories.Interfaces
{
    public interface ICartRepository
    {
        Task<IEnumerable<Cart>> GetAllAsync();
        Task<Cart> GetByIdAsync(int id);
        Task AddAsync(Cart cart);
        Task UpdateAsync(Cart cart);
        Task DeleteAsync(int id);
    }
}
