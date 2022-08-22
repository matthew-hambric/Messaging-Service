
namespace Dynamics.MessagingService.Abtractions.Models;

public record class VerifyUserPhoneCommand{
    public string Code { get; init; }
}