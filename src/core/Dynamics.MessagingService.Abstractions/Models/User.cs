

namespace Dynamics.MessagingService.Abtractions.Models;

public class User {
    public string Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Phone { get; set; }
    public bool PhoneVerified { get; set; }
}