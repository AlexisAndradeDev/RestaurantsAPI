using MediatR;
using Microsoft.AspNetCore.Mvc;
using Restaurants.Application.Restaurants;
using Restaurants.Application.Restaurants.Commands;
using Restaurants.Application.Restaurants.Dtos;
using Restaurants.Application.Restaurants.Queries.GetAllRestaurants;
using Restaurants.Application.Restaurants.Queries.GetRestaurant;

namespace Restaurants.API.Controllers;

[ApiController]
[Route("api/restaurants")]
public class RestaurantsControllers(IMediator mediator): ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var restaurants = await mediator.Send(new GetAllRestaurantsQuery());
        return Ok(restaurants);
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetOne([FromRoute] int id)
    {
        var restaurant = await mediator.Send(new GetRestaurantQuery(id));

        if (restaurant is null)
            return NotFound();

        return Ok(restaurant);
    }

    [HttpPost]
    public async Task<IActionResult> CreateRestaurant([FromBody] CreateRestaurantCommand command)
    {
        int id = await mediator.Send(command);
        return CreatedAtAction(nameof(GetOne), new { id }, null);
    }
}
