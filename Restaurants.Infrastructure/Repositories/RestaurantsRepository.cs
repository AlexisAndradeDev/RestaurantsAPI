using Microsoft.EntityFrameworkCore;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;
using Restaurants.Infrastructure.Persistance;

namespace Restaurants.Infrastructure.Repositories;

internal class RestaurantsRepository(RestaurantsDbContext dbContext): IRestaurantsRepository
{
    public async Task<IEnumerable<Restaurant>> GetAllAsync()
    {
        var restaurants = await dbContext.Restaurants
            .Include(r => r.Dishes)
            .ToListAsync();
        return restaurants;
    }

    public async Task<Restaurant?> GetOneAsync(int id)
    {
        //var restaurant = await dbContext.Restaurants.Include(r => r.Dishes).FindAsync(id);
        var restaurant = await dbContext.Restaurants
            .Include(r => r.Dishes)
            .FirstOrDefaultAsync(r => r.Id == id);
        return restaurant;
    }
}
