using System.Threading.Tasks;
using System.Collections.Generic;
using Dynamics.MessagingService.Abtractions.Models;

namespace Dynamics.MessagingService.Abtractions.Services;

public interface IMessagesService {

    public Task<IEnumerable<Message>> GetMessages(GetMessagesCommand command);

    public Task<Message> GetMessageById(GetMessageByIdCommand command);

    public Task<string> SendMessage(SendMessageCommand command);

    // Messages, once persisted are immutable so we
    // don't support deleting or updating messages
}