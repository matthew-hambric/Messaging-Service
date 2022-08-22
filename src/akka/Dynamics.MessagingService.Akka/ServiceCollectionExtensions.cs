using Microsoft.Extensions.DependencyInjection;
using Akka.Actor;
using Akka.Event;
using Akka.Hosting;
using Akka.Cluster;
using Akka.Cluster.Hosting;
using Akka.Cluster.Sharding;
using Akka.Remote.Hosting;
using Dynamics.MessagingService.Akka.Actors;
using Dynamics.MessagingService.Akka.Model;
using Dynamics.MessagingService.Abtractions.Services;
using Dynamics.MessagingService.Akka.Services;

namespace Dynamics.MessagingService.Akka;

public static class CustomeAkkaServiceExtenions
{
    public static IServiceCollection AddCustomAkkaServices(this IServiceCollection builder){
        
        builder.AddScoped<ITokenBucketService, TokenBucketActorService>();
        builder.AddScoped<IUserMessageSequenceService, UserMessageSequenceService>();

        return builder.AddAkka(CONFIG.ACTOR_SYSTEM, akkaBuilder =>
        {
            akkaBuilder
                .ConfigureLoggers(options => {
                    options.LogLevel = LogLevel.DebugLevel;
                })
                .WithRemoting(CONFIG.HOST_NAME, CONFIG.PORT)
                .WithClustering(new ClusterOptions()
                {
                    Roles = new string[]{ "all-roles" },
                    SeedNodes = CONFIG.SEED_NODES_ARRAY
                })
                .WithActors((actorSystem, actorRegistry) =>
                {
                    var sharding = ClusterSharding.Get(actorSystem);

                    var shardRegion = sharding.Start(
                        "token-buckets",
                        s => TokenBucketActor.PropsFor(),
                        ClusterShardingSettings.Create(actorSystem),
                        new TokenBucketShardMessageExtractor());

                    var sequenceNumberShardRegion = sharding.Start(
                        "sequence-numbers",
                        s => UserMessageSequenceActor.PropsFor(),
                        ClusterShardingSettings.Create(actorSystem),
                        new TokenBucketShardMessageExtractor());

                    actorRegistry.Register<ITokenBucketActorBridge>(shardRegion);
                    actorRegistry.Register<IUserMessageSequenceActorBridge>(sequenceNumberShardRegion);
                });
        });
    }
}
