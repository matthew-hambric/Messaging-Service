using System.Threading.Tasks;
using System.Collections.Generic;
using Dynamics.MessagingService.Abtractions.Models;

namespace Dynamics.MessagingService.Abtractions.Services;

public interface IUserMessageSequenceService
{
    public Task<int> GetNextSequenceNumber();
}