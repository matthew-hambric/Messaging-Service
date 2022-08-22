
namespace Dynamics.MessagingService.Abtractions.Models;

public record class CreateContactCommand {
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public string Phone { get; init; }
}