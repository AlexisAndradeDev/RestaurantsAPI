using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Dishes.Commands.DeleteRestaurantDishes;

public class DeleteRestaurantDishesCommandHandler(ILogger<DeleteRestaurantDishesCommandHandler> logger,
    IRestaurantsRepository restaurantsRepository,
    IDishesRepository dishesRepository) : IRequestHandler<DeleteRestaurantDishesCommand>
{
    public async Task Handle(DeleteRestaurantDishesCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Deleting all dishes from restaurant {RestaurantId}", request.RestaurantId);
        var restaurant = await restaurantsRepository.GetOneAsync(request.RestaurantId)
            ?? throw new NotFoundException(nameof(Restaurant), request.RestaurantId.ToString());

        var dishes = restaurant.Dishes;
        await dishesRepository.DeleteAll(dishes);
    }
}
