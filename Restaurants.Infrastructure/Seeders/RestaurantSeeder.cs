﻿using Microsoft.EntityFrameworkCore;
using Restaurants.Domain.Entities;
using Restaurants.Infrastructure.Persistence;

namespace Restaurants.Infrastructure.Seeders;

internal class RestaurantSeeder(RestaurantsDbContext dbContext): IRestaurantSeeder
{
    public async Task Seed()
    {
        if (await dbContext.Database.CanConnectAsync())
        {
            if (await dbContext.Restaurants.AnyAsync())
            {
                var restaurants = GetRestaurants();
                dbContext.Restaurants.AddRange(restaurants);
                await dbContext.SaveChangesAsync();
            }
        }
    }

    private static IEnumerable<Restaurant> GetRestaurants()
    {
        List<Restaurant> restaurants =
        [
            new()
            {
                Name = "The Gourmet Bistro",
                Description = "A fine dining experience with a wide range of gourmet dishes.",
                Category = "Fine Dining",
                HasDelivery = true,
                ContentEmail = "contact@gourmetbistro.com",
                ContentNumber = "+1234567890",
                Address = new ()
                {
                    City = "New York",
                    Street = "123 Gourmet St",
                    PostalCode = "10001"
                },
                Dishes =
                [
                    new ()
                    {
                        Name = "Truffle Risotto", Description = "Creamy risotto with black truffle",
                        Price = 29.99m, RestaurantId = 1
                    },
                    new()
                    {
                        Name = "Beef Wellington", Description = "Tender beef wrapped in puff pastry",
                        Price = 49.99m, RestaurantId = 1
                    }
                ]
            },
            new ()
            {

                Name = "The Cozy Cafe",
                Description = "A casual cafe with a relaxed atmosphere and comfort food.",
                Category = "Cafe",
                HasDelivery = false,
                ContentEmail = "info@cozycafe.com",
                ContentNumber = "+0987654321",
                Address = new ()
                {
                    City = "San Francisco",
                    Street = "456 Coffee Ave",
                    PostalCode = "94105"
                },
                Dishes =
                [
                    new ()
                    {
                         Name = "Classic Cheeseburger", Description = "Juicy beef patty with melted cheese",
                        Price = 12.99m, RestaurantId = 2
                    },
                    new ()
                    {
                        Name = "Pumpkin Spice Latte", Description = "Warm latte with pumpkin spice",
                        Price = 5.99m, RestaurantId = 2
                    }
                ]
            },
            new ()
            {
                Name = "Sushi World",
                Description = "Authentic Japanese sushi and sashimi.",
                Category = "Japanese",
                HasDelivery = true,
                ContentEmail = "hello@sushiworld.com",
                ContentNumber = "+1122334455",
                Address = new ()
                {
                    City = "Los Angeles",
                    Street = "789 Sushi Blvd",
                    PostalCode = "90001"
                },
                Dishes =
                [
                    new ()
                    {
                        Name = "California Roll",
                        Description = "Sushi roll with crab, avocado, and cucumber", Price = 8.99m, RestaurantId = 3
                    },
                    new ()
                    {
                         Name = "Spicy Tuna Sashimi",
                        Description = "Sliced spicy tuna with a hint of wasabi", Price = 14.99m, RestaurantId = 3
                    }
                ]
            },
            new ()
            {
                Name = "Pasta Paradise",
                Description = "Delicious pasta dishes made from scratch.",
                Category = "Italian",
                HasDelivery = true,
                ContentEmail = "info@pastaparadise.com",
                ContentNumber = "+2233445566",
                Address = new ()
                {
                    City = "Chicago",
                    Street = "321 Pasta Lane",
                    PostalCode = "60601"
                },
                Dishes =
                [
                    new ()
                    {
                        Name = "Spaghetti Carbonara",
                        Description = "Classic spaghetti with creamy carbonara sauce", Price = 15.99m,
                        RestaurantId = 4
                    },
                    new ()
                    {
                         Name = "Lasagna", Description = "Layers of pasta with meat sauce and cheese",
                        Price = 18.99m, RestaurantId = 4
                    }
                ]
            }
        ];

        return restaurants;
    }
}