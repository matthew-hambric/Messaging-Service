using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Dynamics.MessagingService.Abtractions.Models;
using Dynamics.MessagingService.Abtractions.Services;
using System.Collections.Generic;

namespace Dynamics.MessagingService.WebApi.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUsersService _usersService;
    private readonly ILogger<MessagesController> _logger;

    public UsersController(
        IUsersService usersService,
        ILogger<MessagesController> logger
    )
    {
        _usersService = usersService;
        _logger = logger;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<User>>> GetUsers(){
        // We don't allow regular users to search/crawl users //

        return Ok(await _usersService.GetUsers(null));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<User>> GetUserById(string id) {
        return Ok(await _usersService.GetUserById(new GetUserByIdCommand(id)));
    }

    // No http POST (CreateUser) this process should happen on our identity provider

    [HttpPut("{id}")]
    public async Task<ActionResult<string>> UpdateUser(string id, UpdateUserCommand command){
        if(id != command.Id){
            return BadRequest();
        }

        return Ok(await _usersService.UpdateUser(command));
    }

    [HttpPost("update-phone")]
    public async Task<ActionResult<string>> UpdateUserPhone(UpdateUserPhoneCommand command){
        return Ok(await _usersService.UpdateUserPhone(command));
    }

    [HttpPost("verify-phone")]
    public async Task<ActionResult<string>> VerifyUserPhone(VerifyUserPhoneCommand command){
        return Ok(await _usersService.VerifyUserPhone(command));
    }
}

