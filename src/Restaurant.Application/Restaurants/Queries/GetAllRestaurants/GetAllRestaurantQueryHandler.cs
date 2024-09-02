using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Common;
using Restaurants.Application.Restaurants.Dtos;
using Restaurants.Domain.Repository;

namespace Restaurants.Application.Restaurants.Queries.GetAllRestaurants;

public class GetAllRestaurantQueryHandler(
    ILogger<GetAllRestaurantQueryHandler> logger,
    IMapper mapper,
    IRestaurantRepository restaurantRepository
)
    : IRequestHandler<GetAllRestaurantQuery, PagedResult<RestaurantDto>>
{
    public async Task<PagedResult<RestaurantDto>> Handle(GetAllRestaurantQuery request,
        CancellationToken cancellationToken)
    {
        logger.LogInformation("Getting all restaurants!.");

        var (restaurants,totalCount) = await restaurantRepository.GetAllMatchingAsync(request.SearchPhrase,
            request.PageNumber,
            request.PageSize,
            request.SortBy,
            request.SortDirection);

        var restaurantsDto = mapper.Map<IEnumerable<RestaurantDto>>(restaurants);

        var result=new PagedResult<RestaurantDto>(restaurantsDto,totalCount,request.PageSize,request.PageNumber);

        return result;
    }
}