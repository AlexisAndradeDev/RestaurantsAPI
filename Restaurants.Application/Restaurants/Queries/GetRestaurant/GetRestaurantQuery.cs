using MediatR;
using Restaurants.Application.Restaurants.Dtos;

namespace Restaurants.Application.Restaurants.Queries.GetRestaurant;

public class GetRestaurantQuery(int id) : IRequest<RestaurantDto>
{
    public int Id { get; } = id;
}
