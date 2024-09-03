using System.Net;
using System.Net.Http.Json;
using FluentAssertions;
using Microsoft.AspNetCore.Authorization.Policy;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Moq;
using Restaurants.Application.Restaurants.Dtos;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repository;
using Restaurants.Infrastructure.Seeders;
using Xunit;

namespace Restaurants.APITests.Controllers;

public class RestaurantsControllerTests
    : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;
    private readonly Mock<IRestaurantRepository> _restaurantRepositoryMock = new();
    private readonly Mock<IRestaurantSeeder> _restaurantSeederMock = new();

    public RestaurantsControllerTests(WebApplicationFactory<Program> factory)
    {
        _factory = factory.WithWebHostBuilder(builder =>
        {
            builder.ConfigureTestServices(service =>
            {
                service.AddSingleton<IPolicyEvaluator, FakePolicyEvaluator>();
                service.Replace(ServiceDescriptor.Scoped(typeof(IRestaurantRepository),
                    _ => _restaurantRepositoryMock.Object));

                service.Replace(ServiceDescriptor.Scoped(typeof(IRestaurantSeeder),
                  _ => _restaurantSeederMock.Object));
            });
        });
    }

    [Fact]
    public async Task GetAll_ForValidRequest_Return200Ok()
    {
        // Arrange
        var client = _factory.CreateClient();

        // Act
        var result = await client.GetAsync("api/restaurants?pageNumber=2&pageSize=10");

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.OK);
    }

    [Fact]
    public async Task GetById_ForNonExistingId_ShouldReturn404NotFound()
    {
        // Arrange
        var id = 1123;
        _restaurantRepositoryMock.Setup(m => m.GetByIdAsync(id)).ReturnsAsync((Restaurant?)null);
        var client = _factory.CreateClient();

        // Act 
        var response = await client.GetAsync($"/api/restaurants/{id}");

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.NotFound);
    }

    [Fact]
    public async Task GetById_ForExistingId_ShouldReturn200OK()
    {
        // Arrange
        var id = 99;
        var restaurant = new Restaurant
        {
            Id = id,
            Name = "Test",
            Description = "Test desc"
        };
        _restaurantRepositoryMock.Setup(m => m.GetByIdAsync(id)).ReturnsAsync(restaurant);
        var client = _factory.CreateClient();

        // Act 
        var response = await client.GetAsync($"/api/restaurants/{id}");
        var restaurantDto = await response.Content.ReadFromJsonAsync<RestaurantDto>();
        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        restaurantDto.Should().NotBeNull();
        restaurantDto!.Name.Should().Be("Test");
        restaurantDto.Description.Should().Be("Test desc");
    }

    [Fact]
    public async Task GetAll_ForInValidRequest_Return400BadRequest()
    {
        // Arrange
        var client = _factory.CreateClient();

        // Act
        var result = await client.GetAsync("api/restaurants");

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }
}