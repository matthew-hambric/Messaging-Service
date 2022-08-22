using Microsoft.AspNetCore.Authorization;

namespace Dynamics.MessagingService.Core.Middleware;

public class AllowAnonymous_TESTING : IAuthorizationHandler
{
    public Task HandleAsync(AuthorizationHandlerContext context)
    {
        foreach (IAuthorizationRequirement requirement in context.PendingRequirements.ToList())
            context.Succeed(requirement);

        return Task.CompletedTask;
    }
}