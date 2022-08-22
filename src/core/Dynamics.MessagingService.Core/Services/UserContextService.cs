using Dynamics.MessagingService.Abtractions.Services;
using Dynamics.MessagingService.Abtractions.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Dynamics.MessagingService.Core.Services;

public class UserContextService: IUserContextService {
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly ILogger<UserContextService> _logger;

    public UserContextService(
        IHttpContextAccessor httpContextAccessor,
        ILogger<UserContextService> logger
    ){
        _httpContextAccessor = httpContextAccessor;
        _logger = logger;
    }

    public async Task<string> GetCurrentUserId(){
        // We could write some factory to extract the identity of
        // the user based on some configuration at startup

        return tryGetClaim("sub");
    }

    public async Task<User> GetCurrentUser(){
        var output = new User();

        output.Id = await GetCurrentUserId();
        output.FirstName = tryGetClaim("first_name");
        output.LastName = tryGetClaim("last_name");
        output.Phone = tryGetClaim("phone_number");

        return output;
    }

    private string tryGetClaim(string claimType){
        return _httpContextAccessor.HttpContext.User.Identities.First().Claims.Where(c => c.Type == claimType).FirstOrDefault().Value;
    }
}