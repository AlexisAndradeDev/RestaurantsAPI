using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Dishes.Dtos;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Dishes.Queries.GetRestaurantDishes;

public class GetRestaurantDishesQueryHandler(ILogger<GetRestaurantDishesQueryHandler> logger,
    IRestaurantsRepository restaurantsRepository,
    IMapper mapper) : IRequestHandler<GetRestaurantDishesQuery, IEnumerable<DishDto>>
{
    public async Task<IEnumerable<DishDto>> Handle(GetRestaurantDishesQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Getting all dishes from restaurant {RestaurantId}", request.RestaurantId);
        var restaurant = await restaurantsRepository.GetOneAsync(request.RestaurantId)
            ?? throw new NotFoundException(nameof(Restaurant), request.RestaurantId.ToString());

        var dishesDtos = mapper.Map<IEnumerable<DishDto>>(restaurant.Dishes);

        return dishesDtos;
    }
}
