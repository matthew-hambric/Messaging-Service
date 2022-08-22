
namespace Dynamics.MessagingService.Abtractions.Models;

public record class UpdateUserPhoneCommand{
    public string Phone { get; init; }
}