using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Dishes.Dtos;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Dishes.Queries.GetRestaurantDish;

public class GetRestaurantDishQueryHandler(ILogger<GetRestaurantDishQueryHandler> logger,
    IRestaurantsRepository restaurantsRepository,
    IMapper mapper) : IRequestHandler<GetRestaurantDishQuery, DishDto>
{
    public async Task<DishDto> Handle(GetRestaurantDishQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Getting dish {DishId} from restaurant {RestaurantId}", request.DishId, request.RestaurantId);
        var restaurant = await restaurantsRepository.GetOneAsync(request.RestaurantId)
            ?? throw new NotFoundException(nameof(Restaurant), request.RestaurantId.ToString());

        var dish = restaurant.Dishes.FirstOrDefault(dish => dish.Id == request.DishId)
            ?? throw new NotFoundException(nameof(Dish), request.DishId.ToString());

        var dishDto = mapper.Map<DishDto>(dish);

        return dishDto;
    }
}
