using Akka.Actor;
using Dynamics.MessagingService.Akka.Model;

namespace Dynamics.MessagingService.Akka.Actors;

public class TokenBucketActor: ReceiveActor, IWithTimers, ILogReceive
{
    public static Props PropsFor() { return Props.Create(() => new TokenBucketActor()); }

    /// <summary>
    /// The burstable number of requests provided to the caller
    /// </summary>
    private int _maxTokens { get; set; }
    /// <summary>
    /// The number of request tokens available to the caller at a given moment.
    /// Cannot exceed <see cref="_maxTokens" />
    /// </summary>
    private int _tokens { get; set; }

    public ITimerScheduler Timers { get; set; }

    public TokenBucketActor(){
        // We are not going to recover any state when the actor boots up.
        // Instead we are simply going to start an actor with default set
        // of tokens then start tracking from there.
        _tokens = _maxTokens = 10;

        Receive<GetTokenRequest>(request =>
        {
            if(_tokens > 0){
                _tokens--;
                Sender.Tell(new GetTokenResponse());
                if(_tokens == 9)
                    Timers.StartPeriodicTimer("add", new AddToken(), TimeSpan.FromSeconds(1));
            }
            else{
                Sender.Tell(new ThrottledResponse());
            }
        });

        Receive<AddToken>(request =>
        {
            _tokens++;
            if (_tokens == 10)
                Timers.Cancel("add");
        });
    }

    private class AddToken { }
}
