

namespace Dynamics.MessagingService.Abtractions.Models;

public record class SendMessageCommand {
    /// <summary>
    /// The phone number to send the message to
    /// </summary>
    public string To { get; init; }
    public string Content { get; init; }
}