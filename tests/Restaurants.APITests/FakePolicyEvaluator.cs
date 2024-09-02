using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Policy;
using Microsoft.AspNetCore.Http;

namespace Restaurants.APITests;

public class FakePolicyEvaluator:IPolicyEvaluator
{
    public async Task<AuthenticateResult> AuthenticateAsync(AuthorizationPolicy policy, HttpContext context)
    {
        var claimPrincipal = new ClaimsPrincipal();
        claimPrincipal.AddIdentity(new ClaimsIdentity(
            new []
            {
                new Claim(ClaimTypes.NameIdentifier,"1"),
                new Claim(ClaimTypes.Role,"Admin"),
            }));

        var ticket = new AuthenticationTicket(claimPrincipal, "Test");
        var result = AuthenticateResult.Success(ticket);
        return await Task.FromResult(result);
    }

    public async Task<PolicyAuthorizationResult> AuthorizeAsync(AuthorizationPolicy policy, AuthenticateResult authenticationResult, HttpContext context,
        object? resource)
    {
        var result = PolicyAuthorizationResult.Success();
        return await Task.FromResult(result);
    }
}