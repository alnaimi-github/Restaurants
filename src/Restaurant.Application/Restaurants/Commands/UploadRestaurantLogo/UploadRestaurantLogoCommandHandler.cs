using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Constants;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Interfaces;
using Restaurants.Domain.Repository;

namespace Restaurants.Application.Restaurants.Commands.UploadRestaurantLogo;

internal class UploadRestaurantLogoCommandHandler(
    ILogger<UploadRestaurantLogoCommandHandler> logger,
    IRestaurantRepository restaurantRepository,
    IRestaurantAuthorizationService restaurantAuthorizationService,
    IBlobStorageService blobStorageService) 
    : IRequestHandler<UploadRestaurantLogoCommand>
{
    public async Task Handle(UploadRestaurantLogoCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Uploading restaurant logo for restaurant with id: {Id}, request: {@UploadRestaurantLogo}", request.ResturantId, request);
        var restaurant = await restaurantRepository.GetByIdAsync(request.ResturantId);
        if (restaurant is null)
            throw new NotFoundException(nameof(Restaurant), request.ResturantId.ToString());

        if (!restaurantAuthorizationService.Authorize(restaurant, ResourceOperation.Update))
            throw new ForbidException();

      var logoUrl = await  blobStorageService.UploadToBlobAsync(request.File, request.FileName);

        restaurant.LogoUrl = logoUrl;

        await restaurantRepository.SaveChangingAsync();
    }
}
