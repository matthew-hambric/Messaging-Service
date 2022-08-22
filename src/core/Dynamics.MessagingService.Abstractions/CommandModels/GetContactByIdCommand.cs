

namespace Dynamics.MessagingService.Abtractions.Models;

public record class GetContactByIdCommand {
    public string Id { get; init; }

    public GetContactByIdCommand(string id){
        Id = Id;
    }
}