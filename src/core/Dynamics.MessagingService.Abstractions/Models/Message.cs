

namespace Dynamics.MessagingService.Abtractions.Models;

public class Message {
    public string Id { get; set; }
    public int SequenceId { get; set; }
    public string OwnerId { get; set; }
    
    /// <summary>
    /// The phone Number that a message was sent to
    /// </summary>
    public string To { get; set; }

    /// <summary>
    /// The Phone Number that a message came from
    /// </summary>
    public string From { get; set; }
    public string Content { get; set; }
}