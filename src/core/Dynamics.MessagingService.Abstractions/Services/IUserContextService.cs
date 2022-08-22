using System.Threading.Tasks;
using Dynamics.MessagingService.Abtractions.Models;

namespace Dynamics.MessagingService.Abtractions.Services;

public interface IUserContextService {
    public Task<User> GetCurrentUser();
    
    public Task<string> GetCurrentUserId();
}