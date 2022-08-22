

public record class CreateUserCommand {
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public string Phone { get; init; }
    public bool PhoneVerified { get; init; }
}