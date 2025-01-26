using Restaurants.Domain.Entities;

namespace Restaurants.Domain.Repositories;

public interface IDishesRepository
{
    Task<int> Create(Dish dish);
    Task DeleteAll(IEnumerable<Dish> dishes);
}
