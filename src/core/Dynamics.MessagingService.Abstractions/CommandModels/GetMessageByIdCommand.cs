

namespace Dynamics.MessagingService.Abtractions.Models;

public record class GetMessageByIdCommand {
    public string Id { get; init; }

    public GetMessageByIdCommand(string id){
        Id = id;
    }
}