using AutoMapper;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using Restaurants.Application.Restaurants.Commands.CreateRestaurant;
using Restaurants.Application.Users;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repository;
using Xunit;

namespace Restaurants.ApplicationTests.Restaurants.Commands.CreateRestaurant;

public class CreateRestaurantCommandHandlerTests
{
    [Fact]
    public async Task Handle_ForValidCommand_ReturnsCreatedRestaurant()
    {
        // Arrange
        var loggerMock = new Mock<ILogger<CreateRestaurantCommandHandler>>();
        var mapperMock = new Mock<IMapper>();
        var command = new CreateRestaurantCommand();
        var restaurant = new Restaurant();

        mapperMock.Setup(u => u.Map<Restaurant>(command)).Returns(restaurant);
        var restaurantRepositoryMock = new Mock<IRestaurantRepository>();
        restaurantRepositoryMock.Setup(repo => repo.CreateAsync(It.IsAny<Restaurant>()))
            .ReturnsAsync(restaurant);
        var userContext = new Mock<IUserContext>();
        var currentUser = new CurrentUser("owner-Id", "test@test.com", [], null, null);
        userContext.Setup(u => u.GetCurrentUser()).Returns(currentUser);
        var commandHandler = new CreateRestaurantCommandHandler(loggerMock.Object, mapperMock.Object,
            restaurantRepositoryMock.Object, userContext.Object);

        // Act
        var result = await commandHandler.Handle(command, CancellationToken.None);

        // Assert
        result.Should().Be(result);
        restaurant.OwnerId.Should().Be("owner-Id");
        restaurantRepositoryMock.Verify(r => r.CreateAsync(restaurant), Times.Once);
    }
}