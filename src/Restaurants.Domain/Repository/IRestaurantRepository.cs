using Restaurants.Domain.Constants;
using Restaurants.Domain.Entities;

namespace Restaurants.Domain.Repository;

public interface IRestaurantRepository
{
    Task<IEnumerable<Restaurant>> GetAllAsync();

    Task<(IEnumerable<Restaurant>, int)> GetAllMatchingAsync(string? searchPhrase, int pageNumber, int pageSize,
        string? sortBy, SortDirection sortDirection);

    Task<Restaurant?> GetByIdAsync(int id);
    Task<Restaurant?> CreateAsync(Restaurant entity);
    Task DeleteAsync(Restaurant entity);
    Task SaveChangingAsync();
}