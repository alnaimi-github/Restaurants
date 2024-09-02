using Restaurants.Domain.Entities;

namespace Restaurants.Domain.Repository;

public interface IDishRepository
{
    Task<Dish?> CreateAsync(Dish entity);
    Task DeleteAsync(IEnumerable<Dish> entities);
}