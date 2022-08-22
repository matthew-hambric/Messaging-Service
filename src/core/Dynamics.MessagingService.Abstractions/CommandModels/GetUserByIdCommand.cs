

namespace Dynamics.MessagingService.Abtractions.Models;

public record class GetUserByIdCommand
{
    public string Id { get; init; }

    public GetUserByIdCommand(string id){
        Id = id;
    }
}