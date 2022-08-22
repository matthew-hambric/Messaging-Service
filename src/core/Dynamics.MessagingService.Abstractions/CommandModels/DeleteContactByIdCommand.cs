

namespace Dynamics.MessagingService.Abtractions.Models;

public record class DeleteContactByIdCommand {
    public string Id { get; init; }

    public DeleteContactByIdCommand(string id){
        Id = id;
    }
}