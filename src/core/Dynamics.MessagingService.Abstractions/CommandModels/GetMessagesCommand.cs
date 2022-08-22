

namespace Dynamics.MessagingService.Abtractions.Models;

public record class GetMessagesCommand {
    const int maxPageSize = 500;

    private int _pageSize = 50;
    private int _lastEvaluatedKey = 0;

    /// <summary>
    /// The Id of the last message received. Used by to continue retrieving the next messages in the sequence
    /// </summary>
    public int LastEvaluatedKey { get; set; }

    /// <summary>
    /// The number of messages to retrieve. 
    /// </summary>
    public int PageSize
    {
        get
        {
            return _pageSize;
        }
        set
        {
            _pageSize = (value > maxPageSize) ? maxPageSize : (value < 0) ? 1 : value;
        }
    }
}