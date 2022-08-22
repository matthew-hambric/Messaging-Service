using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Dynamics.MessagingService.Abtractions.Models;
using Dynamics.MessagingService.Abtractions.Services;

namespace Dynamics.MessagingService.WebApi.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class MessagesController : ControllerBase {
    private readonly IMessagesService _messagesService;
    private readonly ILogger<MessagesController> _logger;

    public MessagesController(
        IMessagesService messagesService,
        ILogger<MessagesController> logger
    ){
        _messagesService = messagesService;
        _logger = logger;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Message>>> GetMessages([FromQuery] GetMessagesCommand command){
        return Ok(await _messagesService.GetMessages(command));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Message>> GetMessageById(string id){
        return Ok(await _messagesService.GetMessageById(new GetMessageByIdCommand(id)));
    }

    [HttpPost]
    public async Task<ActionResult<string>> SendMessage(SendMessageCommand command){
        return Ok(await _messagesService.SendMessage(command));
    }
}