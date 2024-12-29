using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants.Commands.UpdateRestaurant;

public class UpdateRestaurantCommandHandler(IRestaurantsRepository restaurantsRepository,
    ILogger<UpdateRestaurantCommandHandler> logger,
    IMapper mapper) : IRequestHandler<UpdateRestaurantCommand, bool>
{
    public async Task<bool> Handle(UpdateRestaurantCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation($"Getting restaurant with id {request.Id}...");
        var restaurant = await restaurantsRepository.GetOneAsync(request.Id);
        if (restaurant is null)
            return false;

        logger.LogInformation("Updating restaurant...");
        var restaurantUpdated = mapper.Map(request, restaurant);

        await restaurantsRepository.Update(restaurantUpdated);
        return true;
    }
}
