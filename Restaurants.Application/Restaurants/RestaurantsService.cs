using Microsoft.Extensions.Logging;
using Restaurants.Application.Restaurants.Dtos;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants;

internal class RestaurantsService(IRestaurantsRepository restaurantsRepository,
    ILogger<RestaurantsService> logger) : IRestaurantsService
{
    public async Task<IEnumerable<RestaurantDto>> GetAllRestaurants()
    {
        logger.LogInformation("Getting all restaurants");
        var restaurants = await restaurantsRepository.GetAllAsync();
        var restaurantsDtos = restaurants.Select(r => RestaurantDto.FromEntity(r));
        return restaurantsDtos;
    }

    public async Task<RestaurantDto?> GetRestaurant(int id)
    {
        logger.LogInformation($"Getting restaurant {id}...");
        var restaurant = await restaurantsRepository.GetOneAsync(id);

        return restaurant is null ? null : RestaurantDto.FromEntity(restaurant);
    }
}
