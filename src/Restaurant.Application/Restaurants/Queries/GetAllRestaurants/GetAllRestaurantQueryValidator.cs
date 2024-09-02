using FluentValidation;
using Restaurants.Application.Restaurants.Dtos;

namespace Restaurants.Application.Restaurants.Queries.GetAllRestaurants;

public class GetAllRestaurantQueryValidator:AbstractValidator<GetAllRestaurantQuery>
{
    private readonly int[] _allowPagesSizes = [5, 10, 15, 30];
    private readonly string[] _allowedSortByColumnNames = [nameof(RestaurantDto.Name),nameof(RestaurantDto.Description)];
    public GetAllRestaurantQueryValidator()
    {
        RuleFor(r => r.PageNumber)
            .GreaterThan(1);
        RuleFor(r => r.PageSize)
            .Must(value => _allowPagesSizes.Contains(value))
            .WithMessage($"Page size must be in [{string.Join(",",_allowPagesSizes)}]");

        RuleFor(r => r.SortBy)
            .Must(value => _allowedSortByColumnNames.Contains(value))
            .When(q=>q.SortBy !=null)
            .WithMessage($"Sorting by is optional, or must be in [{string.Join(",", _allowedSortByColumnNames)}]");
    }
}