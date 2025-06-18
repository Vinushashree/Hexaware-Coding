// Implementations/OrderRepository.cs
using HotPot.DAL.Context;
using HotPot.DAL.Models;
using HotPot.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotPot.DAL.Repositories.Implementations
{
    public class OrderRepository : IOrderRepository
    {
        private readonly HotPotDbContext _context;

        public OrderRepository(HotPotDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Order>> GetAllAsync() => await _context.Orders.ToListAsync();

        public async Task<Order> GetByIdAsync(int id) => await _context.Orders.FindAsync(id);

        public async Task AddAsync(Order order)
        {
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Order order)
        {
            _context.Orders.Update(order);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order != null)
            {
                _context.Orders.Remove(order);
                await _context.SaveChangesAsync();
            }
        }
    }
}

