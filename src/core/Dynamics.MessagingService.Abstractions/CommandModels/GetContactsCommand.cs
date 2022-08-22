
namespace Dynamics.MessagingService.Abtractions.Models;

public record class GetContactsCommand
{
    const int maxPageSize = 100;

    private int _pageSize = 50;

    /// <summary>
    /// The Id of the last contact received. Used to continue retrieving the next contacts in the sequence
    /// </summary>
    public string LastEvaluatedKey { get; init; }

    /// <summary>
    /// The number of contacts to retrieve. 
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