using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Dynamics.MessagingService.Abtractions.Services;

namespace Dynamics.MessagingService.Persistence.EntityFramework;

public static class EntityFrameworkExtensions
{
    public static IServiceCollection UseEntityFrameworkInMemoryDatabase(this IServiceCollection builder){
        return builder.AddDbContext<IDbContext, MessagingServiceDbContext>(options => options.UseInMemoryDatabase("InMemoryDatabase"));
    }

    public static IServiceCollection UseEntityFrameworkInMemoryDatabase_TESTING(this IServiceCollection builder){
        return builder.AddDbContext<IDbContext, SeededDbContext_TESTING>(options => options.UseInMemoryDatabase("InMemoryDatabase"));
    }
}