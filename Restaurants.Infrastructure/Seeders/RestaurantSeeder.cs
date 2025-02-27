using Restaurants.Infrastructure.Persistance;
using Restaurants.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Restaurants.Domain.Constants;

namespace Restaurants.Infrastructure.Seeders;

internal class RestaurantSeeder(RestaurantsDbContext dbContext) : IRestaurantSeeder
{
    public async Task Seed()
    {
        if (await dbContext.Database.CanConnectAsync())
        {
            if (!dbContext.Restaurants.Any())
            {
                var restaurants = GetRestaurants();
                dbContext.Restaurants.AddRange(restaurants);
                await dbContext.SaveChangesAsync();
            }

            if (!dbContext.Roles.Any())
            {
                var roles = GetRoles();
                dbContext.Roles.AddRange(roles);
                await dbContext.SaveChangesAsync();
            }
        }
    }

    private IEnumerable<IdentityRole> GetRoles()
    {
        List<IdentityRole> roles =
            [
                new(UserRoles.User),
                new(UserRoles.Owner),
                new(UserRoles.Admin),
            ];

        return roles;
    }

    private IEnumerable<Restaurant> GetRestaurants()
    {
        List<Restaurant> restaurants = [
            new()
            {
                Name = "The Italian Bistro",
                Description = "A cozy place offering authentic Italian cuisine.",
                Category = "Italian",
                HasDelivery = true,
                ContactEmail = "info@italianbistro.com",
                ContactNumber = "123-456-7890",
                Dishes = [
                    new()
                    {
                        Name = "Spaghetti Carbonara",
                        Description = "Classic Italian pasta with creamy sauce and pancetta.",
                        Price = 12.99m
                    },
                    new( )
                    {
                        Name = "Margherita Pizza",
                        Description = "Traditional pizza topped with fresh mozzarella and basil.",
                        Price = 10.99m
                    }
                ]
            },
            new Restaurant
            {
                Name = "Sushi Haven",
                Description = "A modern sushi bar offering a wide variety of sushi and sashimi.",
                Category = "Japanese",
                HasDelivery = true,
                ContactEmail = "contact@sushihaven.com",
                ContactNumber = "987-654-3210",
                Address = new Address
                {
                    City = "Los Angeles",
                    Street = "456 Sushi St",
                    PostalCode = "90001"
                }
            }
        ];

        return restaurants;
    }
}
