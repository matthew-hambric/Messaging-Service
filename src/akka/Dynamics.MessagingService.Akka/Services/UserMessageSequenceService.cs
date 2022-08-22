using Dynamics.MessagingService.Abtractions.Services;
using Dynamics.MessagingService.Akka;
using Dynamics.MessagingService.Akka.Model;
using Akka.Hosting;
using Akka.Actor;
using Microsoft.Extensions.Logging;

namespace Dynamics.MessagingService.Akka.Services;

public class UserMessageSequenceService: IUserMessageSequenceService {
    private readonly IUserContextService _userContextService;
    private readonly ILogger<UserMessageSequenceService> _logger;
    private readonly IActorRef _userMessageSequenceActorBridge;

    public UserMessageSequenceService(IUserContextService userContextService, ILogger<UserMessageSequenceService> logger, ActorRegistry actorRegistry){
        _userContextService = userContextService;
        _logger = logger;

        if(actorRegistry.TryGet<IUserMessageSequenceActorBridge>(out IActorRef actor)){
            _userMessageSequenceActorBridge = actor;
        }
        else {
            throw new Exception("Could not resolve IActorRef dependency IUserMessageSequenceActorBridge");
        }
    }

    public async Task<int> GetNextSequenceNumber(){
        var userId = await _userContextService.GetCurrentUserId();

        var response = await _userMessageSequenceActorBridge.Ask<GetMessageSequenceNumberResponse>(new GetMessageSequenceNumberRequest(userId), TimeSpan.FromSeconds(0.5));
        return response.SequenceId;
    }
}