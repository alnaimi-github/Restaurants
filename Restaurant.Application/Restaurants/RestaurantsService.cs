using Microsoft.Extensions.Logging;
using Restaurants.Application.Dishes.Dtos;
using Restaurants.Application.Restaurants.Dtos;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repository;

namespace Restaurants.Application.Restaurants;

internal class RestaurantsService(IRestaurantRepository restaurantRepository,
    ILogger<RestaurantsService>logger) : IRestaurantsService
{
    public async Task<IEnumerable<RestaurantDto>> GetAllRestaurants()
    {
        logger.LogInformation("Getting all restaurants!.");
        var restaurants = await restaurantRepository.GetAllAsync();
        var restaurantsDto = restaurants.Select(RestaurantDto.FromEntity);
        return restaurantsDto;
    }

    public async Task<RestaurantDto> GetById(int id)
    {
        logger.LogInformation($"Getting  restaurant: {id}!.");
        var restaurant = await restaurantRepository.GetByIdAsync(id);
        var restaurantDto = RestaurantDto.FromEntity(restaurant);
        return restaurantDto!;
    }
}
