using Akka.Actor;
using Dynamics.MessagingService.Akka.Model;

namespace Dynamics.MessagingService.Akka.Actors;

public class UserMessageSequenceActor : ReceiveActor, ILogReceive
{
    public static Props PropsFor() { return Props.Create(() => new UserMessageSequenceActor()); }

    private int sequenceId;

    public UserMessageSequenceActor(){
        sequenceId = 0;

        Receive<GetMessageSequenceNumberRequest>(request =>
        {
            Sender.Tell(new GetMessageSequenceNumberResponse(++sequenceId));
        });
    }
}