using MediatR;

namespace Restaurants.Application.Users.Commands.UpdateUserDetailsCommand;

public class UpdateUserDetailsCommand : IRequest
{
    public DateOnly? DateOfBirth { get; set; }
    public string? Nationality { get; set; }
}
