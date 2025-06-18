// Implementations/CartRepository.cs
using HotPot.DAL.Context;
using HotPot.DAL.Models;
using HotPot.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotPot.DAL.Repositories.Implementations
{
    public class CartRepository : ICartRepository
    {
        private readonly HotPotDbContext _context;

        public CartRepository(HotPotDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Cart>> GetAllAsync() => await _context.Carts.ToListAsync();

        public async Task<Cart> GetByIdAsync(int id) => await _context.Carts.FindAsync(id);

        public async Task AddAsync(Cart cart)
        {
            await _context.Carts.AddAsync(cart);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Cart cart)
        {
            _context.Carts.Update(cart);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var cart = await _context.Carts.FindAsync(id);
            if (cart != null)
            {
                _context.Carts.Remove(cart);
                await _context.SaveChangesAsync();
            }
        }
    }
}
