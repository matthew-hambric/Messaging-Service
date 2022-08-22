
namespace Dynamics.MessagingService.Abtractions.Models;

public record class UpdateUserCommand {
    public string Id { get; set; }
    public string FirstName { get; init; }
    public string LastName { get; init; }
    
    // Yes the phone number field is missing. The reason being that
    // the user must validate ownership of the phone number if they
    // should update it. It is cleaner to handle it under another
    // command => UserUpdatePhoneRequest
}