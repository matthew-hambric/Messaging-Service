using Dynamics.MessagingService.Abtractions.Services;
using Microsoft.AspNetCore.Http;
using Dynamics.MessagingService.Akka.Services;

public class ThrottleMiddleware
{
    private readonly RequestDelegate _next;

    public ThrottleMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    // IMessageWriter is injected into InvokeAsync
    public async Task InvokeAsync(HttpContext httpContext, ITokenBucketService tokenBucketService)
    {
        try{
            await tokenBucketService.GetToken();
            await _next(httpContext);
        }
        catch(ThrottledException e){
            httpContext.Response.StatusCode = 429;
        }
    }
}