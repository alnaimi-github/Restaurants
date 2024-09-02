using MediatR;

namespace Restaurants.Application.Users.Commands.UnassignUserRole;

public class UnassignUserRoleCommand : IRequest
{
    public string Email { get; set; } = string.Empty;
    public string RoleName { get; set; } = string.Empty;
}