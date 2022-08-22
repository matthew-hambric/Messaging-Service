using Dynamics.MessagingService.Abtractions.Services;
using Dynamics.MessagingService.Abtractions.Models;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace Dynamics.MessagingService.Core.Services;

public class UsersService: IUsersService {
    private readonly IUserContextService _userContextService;
    private readonly ILogger<UsersService> _logger;
    private readonly IDbContext _dbContext;

    public UsersService(
        IUserContextService userContextService,
        ILogger<UsersService> logger,
        IDbContext dbContext
    ){
        _userContextService = userContextService;
        _logger = logger;
        _dbContext = dbContext;
    }


    public async Task<IEnumerable<User>> GetUsers(GetUsersCommand command){
        //IQueryable<User> users = _dbContext.Users;
        //.Where(c => command.LastEvaluatedKey.CompareTo(c.Id) > 0)
        //.OrderBy(m => m.Id)
        //.Take(command.PageSize);

        return await _dbContext.Users.ToListAsync();
    }

    public async Task<User> GetUserById(GetUserByIdCommand command){
        return await _dbContext.Users.FindAsync(command.Id);
    }

    public async Task<User> CreateUser(CreateUserCommand command){
        throw new NotImplementedException();
    }

    public async Task<string> UpdateUser(UpdateUserCommand command){
        throw new NotImplementedException();
    }

    public async Task<string> UpdateUserPhone(UpdateUserPhoneCommand command){
        throw new NotImplementedException();
    }

    public async Task<string> VerifyUserPhone(VerifyUserPhoneCommand command){
        throw new NotImplementedException();
    }
}