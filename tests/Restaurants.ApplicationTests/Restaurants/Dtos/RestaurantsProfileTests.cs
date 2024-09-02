using AutoMapper;
using FluentAssertions;
using Restaurants.Application.Restaurants.Commands.CreateRestaurant;
using Restaurants.Application.Restaurants.Commands.UpdateRestaurant;
using Restaurants.Application.Restaurants.Dtos;
using Restaurants.Domain.Entities;
using Xunit;

namespace Restaurants.ApplicationTests.Restaurants.Dtos;

public class RestaurantsProfileTests
{
    private readonly IMapper _mapper;

    public RestaurantsProfileTests()
    {
        var configuration = new MapperConfiguration(cfg => { cfg.AddProfile<RestaurantsProfile>(); });
        _mapper = configuration.CreateMapper();
    }

    [Fact]
    public void CreateMap_ForRestaurantToRestaurantDto_MapsCorrectly()
    {
        // Arrange

        var restaurant = new Restaurant
        {
            Id = 1,
            Name = "Test Restaurant",
            Description = "Test Restaurant",
            Category = "Test",
            HasDelivery = true,
            ContentEmail = "test@test.com",
            ContentNumber = "23847464",
            Address = new Address
            {
                City = "test city",
                PostalCode = "22-222",
                Street = "test"
            }
        };

        // Act 
        var restaurantDto = _mapper.Map<RestaurantDto>(restaurant);

        // Assert
        restaurantDto.Should().NotBeNull();
        restaurantDto.Id.Should().Be(restaurant.Id);
        restaurantDto.Name.Should().Be(restaurant.Name);
        restaurantDto.Description.Should().Be(restaurant.Description);
        restaurantDto.HasDelivery.Should().Be(restaurant.HasDelivery);
        restaurantDto.Category.Should().Be(restaurant.Category);
        restaurantDto.City.Should().Be(restaurant.Address.City);
        restaurantDto.PostalCode.Should().Be(restaurant.Address.PostalCode);
        restaurantDto.Street.Should().Be(restaurant.Address.Street);
    }

    [Fact]
    public void CreateMap_ForCreateRestaurantCommandToRestaurant_MapsCorrectly()
    {
        // Arrange
        var command = new CreateRestaurantCommand
        {
            Name = "Test Restaurant",
            Description = "Test Restaurant",
            Category = "Test",
            HasDelivery = true,
            ContentEmail = "test@test.com",
            ContentNumber = "23847464",
            City = "test city",
            PostalCode = "22-222",
            Street = "test"
        };

        // Act 
        var restaurant = _mapper.Map<Restaurant>(command);

        // Assert
        restaurant.Should().NotBeNull();
        restaurant.Name.Should().Be(command.Name);
        restaurant.Description.Should().Be(command.Description);
        restaurant.HasDelivery.Should().Be(command.HasDelivery);
        restaurant.Category.Should().Be(command.Category);
        restaurant.Address!.City.Should().Be(command.City);
        restaurant.Address.PostalCode.Should().Be(command.PostalCode);
        restaurant.Address.Street.Should().Be(command.Street);
    }


    [Fact]
    public void CreateMap_ForUpdateRestaurantCommandToRestaurant_MapsCorrectly()
    {
        // Arrange
        var command = new UpdateRestaurantCommand
        {
            Id = 1,
            Name = "Test Restaurant",
            Description = "Test Restaurant",
            HasDelivery = false
        };

        // Act 
        var restaurant = _mapper.Map<Restaurant>(command);

        // Assert
        restaurant.Should().NotBeNull();
        restaurant.Id.Should().Be(command.Id);
        restaurant.Name.Should().Be(command.Name);
        restaurant.Description.Should().Be(command.Description);
        restaurant.HasDelivery.Should().Be(command.HasDelivery);
    }
}