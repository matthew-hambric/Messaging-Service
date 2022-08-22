using Dynamics.MessagingService.Abtractions.Services;
using Dynamics.MessagingService.Abtractions.Models;

namespace Dynamics.MessagingService.Core.Services;

public class UserContextService_TESTING : IUserContextService
{
    public async Task<User> GetCurrentUser()
    {
        return new User()
        {
            Id = "1",
            FirstName = "Matthew",
            LastName = "Hambric",
            Phone = "5405358713"
        };
    }

    public async Task<string> GetCurrentUserId()
    {
        return "1";
    }
}