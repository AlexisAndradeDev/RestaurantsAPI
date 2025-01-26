using MediatR;

namespace Restaurants.Application.Dishes.Commands.DeleteRestaurantDishes;

public class DeleteRestaurantDishesCommand(int restaurantId) : IRequest
{
    public int RestaurantId { get; } = restaurantId;
}
