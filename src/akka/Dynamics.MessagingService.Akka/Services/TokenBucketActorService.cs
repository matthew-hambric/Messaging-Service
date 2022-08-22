using Dynamics.MessagingService.Abtractions.Services;
using Dynamics.MessagingService.Akka;
using Dynamics.MessagingService.Akka.Model;
using Akka.Hosting;
using Akka.Actor;
using Microsoft.Extensions.Logging;

namespace Dynamics.MessagingService.Akka.Services;

public class TokenBucketActorService: ITokenBucketService {
    private readonly IUserContextService _userContextService;
    private readonly ILogger<TokenBucketActorService> _logger;
    private readonly IActorRef _tokenBucketActorBridge;

    public TokenBucketActorService(IUserContextService userContextService, ILogger<TokenBucketActorService> logger, ActorRegistry actorRegistry){
        _userContextService = userContextService;
        _logger = logger;

        if(actorRegistry.TryGet<ITokenBucketActorBridge>(out IActorRef actor)){
            _tokenBucketActorBridge = actor;
        }
        else {
            throw new Exception("Could not resolve IActorRef dependency ITokenBucketActorBridge");
        }
    }

    public async Task GetToken(){
        var userId = await _userContextService.GetCurrentUserId();

        var response = await _tokenBucketActorBridge.Ask(new GetTokenRequest(userId), TimeSpan.FromSeconds(0.5));

        switch(response){
            case GetTokenResponse getTokenResponse:
                break;
            case ThrottledResponse throttledResponse:
                throw new ThrottledException();
            default:
                throw new Exception("Token Bucket Actor returned an unrecognized response");
        }
    }
}

public class ThrottledException : Exception
{
    public ThrottledException() : base("Throttled") { }
}