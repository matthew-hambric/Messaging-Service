

namespace Dynamics.MessagingService.Abtractions.Models;

public record class UpdateContactCommand {
    public string Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Phone { get; set; }
}