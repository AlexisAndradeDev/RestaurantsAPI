﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using Restaurants.Application.Dishes.Commands.CreateDish;
using Restaurants.Application.Dishes.Commands.DeleteRestaurantDishes;
using Restaurants.Application.Dishes.Dtos;
using Restaurants.Application.Dishes.Queries.GetRestaurantDish;
using Restaurants.Application.Dishes.Queries.GetRestaurantDishes;

namespace Restaurants.API.Controllers;

[Route("api/restaurants/{restaurantId}/dishes")]
[ApiController]
public class DishesController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateDish([FromRoute] int restaurantId, CreateDishCommand command)
    {
        command.RestaurantId = restaurantId;
        var dishId = await mediator.Send(command);
        return CreatedAtAction(nameof(GetRestaurantDish), new { restaurantId, dishId }, null );
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<DishDto>>> GetRestaurantDishes([FromRoute] int restaurantId)
    {
        var dishes = await mediator.Send(new GetRestaurantDishesQuery(restaurantId));
        return Ok(dishes);
    }

    [HttpGet("{dishId}")]
    public async Task<ActionResult<DishDto>> GetRestaurantDish([FromRoute] int restaurantId, [FromRoute] int dishId)
    {
        var dish = await mediator.Send(new GetRestaurantDishQuery(restaurantId, dishId));
        return Ok(dish);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteRestaurantDishes([FromRoute] int restaurantId)
    {
        await mediator.Send(new DeleteRestaurantDishesCommand(restaurantId));
        return NoContent();
    }
}
