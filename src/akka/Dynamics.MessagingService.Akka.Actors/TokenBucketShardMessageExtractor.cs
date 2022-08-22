using Akka.Cluster.Sharding;
using Dynamics.MessagingService.Akka.Model;

namespace Dynamics.MessagingService.Akka.Actors;

public sealed class TokenBucketShardMessageExtractor: HashCodeMessageExtractor
{
    /// <summary>
    /// For learning purposes we are not going to allow the deployment
    /// to specify a configurabel number of shards. Instead we will 
    /// default to 30
    /// </summary>
    public TokenBucketShardMessageExtractor(): base(30){

    }

    public override string EntityId(object message)
    {
        switch(message)
        {
            case IWithUserId withUserId: return withUserId.UserId;
            default: return null;
        }
    }

    public override string ShardId(object message)
    {
        return base.ShardId(message);
    }

    public override object EntityMessage(object message) => message;
}
