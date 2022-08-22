using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Dynamics.MessagingService.Abtractions.Models;
using Dynamics.MessagingService.Abtractions.Services;

namespace Dynamics.MessagingService.WebApi.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class ContactsController : ControllerBase
{
    private readonly IContactsService _contactsService;
    private readonly ILogger<MessagesController> _logger;

    public ContactsController(
        IContactsService contactsService,
        ILogger<MessagesController> logger
    )
    {
        _contactsService = contactsService;
        _logger = logger;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Contact>>> GetContacts([FromQuery] GetContactsCommand command){
        return Ok(await _contactsService.GetContacts(command));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Contact>> GetContactById(string id){
        return Ok(await _contactsService.GetContactById(new GetContactByIdCommand(id)));
    }

    [HttpPost]
    public async Task<ActionResult<string>> CreateContact(CreateContactCommand command){
        return Ok(await _contactsService.CreateContact(command));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<string>> UpdateContact([FromRoute]string id, UpdateContactCommand command){
        if(id != command.Id){
            return BadRequest();
        }

        return Ok(await _contactsService.UpdateContact(command));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<string>> DeleteContact(string id){
        return Ok(await _contactsService.DeleteContact(new DeleteContactByIdCommand(id)));
    }
}