

namespace Dynamics.MessagingService.Abtractions.Models;

public record class GetUsersCommand {
    const int maxPageSize = 100;

    private int _pageSize = 50;

    /// <summary>
    /// The Id of the last user received. Used to continue retrieving the next users in the sequence
    /// </summary>
    public string LastEvaluatedKey { get; init; }

    /// <summary>
    /// The number of users to retrieve. 
    /// </summary>
    public int PageSize
    {
        get
        {
            return _pageSize;
        }
        init
        {
            _pageSize = (value > maxPageSize) ? maxPageSize : (value < 0) ? 1 : value;
        }
    }
}