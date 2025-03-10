using MediatR;

namespace Restaurants.Application.Users.Commands.UnassignUserRoleCommand;

public class UnassignUserRoleCommand : IRequest
{
    public string UserEmail { set; get; } = default!;
    public string RoleName { set; get; } = default!;
}
