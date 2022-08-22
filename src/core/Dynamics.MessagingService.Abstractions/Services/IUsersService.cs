using System.Threading.Tasks;
using System.Collections.Generic;
using Dynamics.MessagingService.Abtractions.Models;

namespace Dynamics.MessagingService.Abtractions.Services;

public interface IUsersService {

    public Task<IEnumerable<User>> GetUsers(GetUsersCommand command);

    public Task<User> GetUserById(GetUserByIdCommand command);

    public Task<User> CreateUser(CreateUserCommand command);

    public Task<string> UpdateUser(UpdateUserCommand command);

    public Task<string> UpdateUserPhone(UpdateUserPhoneCommand command);

    public Task<string> VerifyUserPhone(VerifyUserPhoneCommand command);

    // We don't support deleting users //
}