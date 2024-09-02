using MediatR;

namespace Restaurants.Application.Users.Commands.AssignUserRole;

public class AssignUserRoleCommand : IRequest
{
    public string Email { get; set; } = string.Empty;
    public string RoleName { get; set; } = string.Empty;
}