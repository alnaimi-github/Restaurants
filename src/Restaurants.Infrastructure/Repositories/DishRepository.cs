using Microsoft.EntityFrameworkCore;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repository;
using Restaurants.Infrastructure.Persistence;

namespace Restaurants.Infrastructure.Repositories;

internal class DishRepository(RestaurantsDbContext dbContext) : IDishRepository
{
    public async Task<Dish?> CreateAsync(Dish entity)
    {
        await dbContext.Dishes.AddAsync(entity);
        await dbContext.SaveChangesAsync();
        return entity;
    }

    public async Task DeleteAsync(IEnumerable<Dish> entities)
    {
       dbContext.Dishes.RemoveRange(entities);
       await dbContext.SaveChangesAsync();
    }
}