// Implementations/RestaurantRepository.cs
using HotPot.DAL.Context;
using HotPot.DAL.Models;
using HotPot.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotPot.DAL.Repositories.Implementations
{
    public class RestaurantRepository : IRestaurantRepository
    {
        private readonly HotPotDbContext _context;

        public RestaurantRepository(HotPotDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Restaurant>> GetAllAsync() => await _context.Restaurants.ToListAsync();

        public async Task<Restaurant> GetByIdAsync(int id) => await _context.Restaurants.FindAsync(id);

        public async Task AddAsync(Restaurant restaurant)
        {
            await _context.Restaurants.AddAsync(restaurant);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Restaurant restaurant)
        {
            _context.Restaurants.Update(restaurant);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var restaurant = await _context.Restaurants.FindAsync(id);
            if (restaurant != null)
            {
                _context.Restaurants.Remove(restaurant);
                await _context.SaveChangesAsync();
            }
        }
    }
}

