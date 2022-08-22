using Dynamics.MessagingService.Abtractions.Models;
using Dynamics.MessagingService.Abtractions.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Be.Vlaanderen.Basisregisters.Generators.Guid;

namespace Dynamics.MessagingService.Core.Services;

public class MessagesService: IMessagesService {
    private readonly IUserContextService _userContextService;
    private readonly ILogger<MessagesService> _logger;
    private readonly IDbContext _dbContext;
    private readonly IUserMessageSequenceService _userMessageSequenceService;

    public MessagesService(
        IUserContextService userContextService,
        ILogger<MessagesService> logger,
        IDbContext dbContext,
        IUserMessageSequenceService userMessageSequenceService
    ){
        _userContextService = userContextService;
        _logger = logger;
        _dbContext = dbContext;
        _userMessageSequenceService = userMessageSequenceService;
    }

    public async Task<IEnumerable<Message>> GetMessages(GetMessagesCommand command){
        var userId = await _userContextService.GetCurrentUserId();

        _logger.LogCritical(System.Text.Json.JsonSerializer.Serialize(command));
        
        IQueryable<Message> messages = _dbContext.Messages
            .Where(m => m.OwnerId == userId && command.LastEvaluatedKey < m.SequenceId)
            .Take(command.PageSize);

        return await messages.ToListAsync();
    }

    public async Task<Message> GetMessageById(GetMessageByIdCommand command){
        var userId = await _userContextService.GetCurrentUserId();

        return await _dbContext.Messages.Where(m => m.Id == command.Id && m.OwnerId == userId).FirstOrDefaultAsync();
    }

    public async Task<string> SendMessage(SendMessageCommand command){
        // Use Akka Implementation here
        User user = await _userContextService.GetCurrentUser();
        int nextSequenceNumber = await _userMessageSequenceService.GetNextSequenceNumber();

        Message newMessage = new Message()
        {
            Id = Deterministic.Create(Deterministic.Namespaces.Commands, Guid.NewGuid().ToString(), 3).ToString(),
            To = command.To,
            SequenceId = nextSequenceNumber,
            From = user.Phone,
            Content = command.Content,
            OwnerId = user.Id
        };

        _dbContext.Messages.Add(newMessage);

        await _dbContext.SaveChangesAsync();

        return newMessage.Id;
    }
}