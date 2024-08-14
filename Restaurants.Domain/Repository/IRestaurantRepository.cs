using Restaurants.Domain.Entities;

namespace Restaurants.Domain.Repository;

public interface IRestaurantRepository
{
    Task<IEnumerable<Restaurant>> GetAllAsync();
    Task<Restaurant?> GetByIdAsync(int id);
    Task<Restaurant?> CreateAsync(Restaurant entity);
}