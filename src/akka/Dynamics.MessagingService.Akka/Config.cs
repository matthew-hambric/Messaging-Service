

using Akka.Actor;

namespace Dynamics.MessagingService.Akka;

internal static class CONFIG
{

    public static string ACTOR_SYSTEM {
        get {
            return Environment.GetEnvironmentVariable("ACTOR_SYSTEM")?.Trim() ?? "ActorSystem";
        }
    }
    public static string HOST_NAME {
        get
        {
            return Environment.GetEnvironmentVariable("CLUSTER_IP")?.Trim() ?? "127.0.0.1";
        }
    }
    public static int PORT {
        get {
            return int.Parse(Environment.GetEnvironmentVariable("CLUSTER_PORT") ?? "58697");
        }
    }
    public static string SEED_NODES {
        get {
            return Environment.GetEnvironmentVariable("CLUSTER_SEEDS") ?? "akka.tcp://ActorSystem@127.0.0.1:58697";
        }
    }

    public static Address[] SEED_NODES_ARRAY {
        get {
            var output = new List<Address>();
            foreach(string address in SEED_NODES.Split(',')){
                if(Address.TryParse(address, out Address a)){
                    output.Add(a);
                }
            }
            return output.ToArray();
        }
    } 
}