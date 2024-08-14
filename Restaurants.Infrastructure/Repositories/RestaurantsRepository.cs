using Microsoft.EntityFrameworkCore;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repository;
using Restaurants.Infrastructure.Persistence;

namespace Restaurants.Infrastructure.Repositories;

internal class RestaurantsRepository(RestaurantsDbContext dbContext) : IRestaurantRepository
{
    public async Task<IEnumerable<Restaurant>> GetAllAsync()
    {
        var restaurants = await dbContext.Restaurants.ToListAsync();
        return restaurants;
    }

    public async Task<Restaurant?> GetByIdAsync(int id)
    {
        var restaurant = await dbContext.Restaurants.Include(r => r.Dishes).FirstOrDefaultAsync(r => r.Id == id);
        return restaurant;
    }

    public async Task<Restaurant?> CreateAsync(Restaurant entity)
    {
       await dbContext.Restaurants.AddAsync(entity);
       await dbContext.SaveChangesAsync();
       return entity;
    }
}