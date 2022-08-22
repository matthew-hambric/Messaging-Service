using Microsoft.AspNetCore.Builder;

namespace Dynamics.MessagingService.Akka;

public static class ApplicationBuilderExtensions
{
    public static IApplicationBuilder UseDistributedThrottling(this IApplicationBuilder builder){
        return builder.UseMiddleware<ThrottleMiddleware>();
    }
}