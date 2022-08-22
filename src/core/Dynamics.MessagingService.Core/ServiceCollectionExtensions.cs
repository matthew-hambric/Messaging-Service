using Dynamics.MessagingService.Abtractions.Services;
using Dynamics.MessagingService.Core.Middleware;
using Dynamics.MessagingService.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;

namespace Dynamics.MessagingService;

public static class ServiceCollectionExtensions
{

    public static IServiceCollection AddCoreServices(this IServiceCollection builder)
    {
        builder.AddScoped<IMessagesService, MessagesService>();
        builder.AddScoped<IContactsService, ContactsService>();
        builder.AddScoped<IUsersService, UsersService>();
        builder.AddScoped<IUserContextService, UserContextService>();
        return builder;
    }

    public static IServiceCollection AddCoreServices_TESTING(this IServiceCollection builder)
    {
        builder.AddScoped<IMessagesService, MessagesService>();
        builder.AddScoped<IContactsService, ContactsService>();
        builder.AddScoped<IUsersService, UsersService>();
        builder.AddScoped<IUserContextService, UserContextService_TESTING>();
        builder.AddSingleton<IAuthorizationHandler, AllowAnonymous_TESTING>();
        return builder;
    }

}