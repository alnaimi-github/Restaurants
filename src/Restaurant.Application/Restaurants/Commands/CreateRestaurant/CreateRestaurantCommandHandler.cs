using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Restaurants.Dtos;
using Restaurants.Application.Users;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repository;

namespace Restaurants.Application.Restaurants.Commands.CreateRestaurant;

public class CreateRestaurantCommandHandler(
    ILogger<CreateRestaurantCommandHandler> logger,
    IMapper mapper,
    IRestaurantRepository restaurantRepository,
    IUserContext userContext) : IRequestHandler<CreateRestaurantCommand, RestaurantDto>
{
    public async Task<RestaurantDto> Handle(CreateRestaurantCommand request, CancellationToken cancellationToken)
    {
        var currentUser = userContext.GetCurrentUser();
        logger.LogInformation("{UserEmail} [{UserId}] is Creating a new  restaurant {@Restaurant}",
            currentUser!.Email,
            currentUser.Id,
            request);

        var restaurantMapper = mapper.Map<Restaurant>(request);
        restaurantMapper.OwnerId = currentUser.Id;
        var restaurant = await restaurantRepository.CreateAsync(restaurantMapper);
        return mapper.Map<RestaurantDto>(restaurant);
    }
}