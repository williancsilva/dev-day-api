using Dayconnect.backoffice.App;
using Dayconnect.backoffice.App.Interfaces;
using Dayconnect.backoffice.App.Notifications;
using Dayconnect.backoffice.Domain.Interfaces.ExternalService;
using Dayconnect.backoffice.Domain.Interfaces.Repository;
using Dayconnect.backoffice.Domain.Interfaces.Service;
using Dayconnect.backoffice.Domain.Service;
using Dayconnect.backoffice.ExternalService;
using Dayconnect.backoffice.Mediator.Events;
using Dayconnect.backoffice.Mediator.Handles;
using Dayconnect.backoffice.Mediator.Notifications;
using Dayconnect.backoffice.Repository;
using MediatR;

namespace Dayconnect.backoffice.Configurations;

public static class DependencyResolverConfiguration
{
    public static void IntegrateDependencyResolver(this IServiceCollection services)
    {
        RegisterApps(services);
        RegisterEvents(services);
        RegisterExternalServices(services);
        RegisterRepositorys(services);
    }

    private static void RegisterEvents(IServiceCollection services)
    {
        services.AddScoped<IMediatorHandler, MediatorHandler>();
        services.AddScoped<INotificationHandler<LogNotification>, LogEventHandler>();
    }

    private static void RegisterApps(IServiceCollection services)
    {
        services.AddScoped<NotificationContext>();
        services.AddScoped<IClienteApp, ClienteApp>();
        services.AddScoped<IAutenticacaoApp, AutenticacaoApp>();
    }

    private static void RegisterExternalServices(IServiceCollection services)
    {
        services.AddScoped<IAccessControlSession, AccessControlSession>();
        services.AddScoped<IAutenticacaoService, AutenticacaoService>();
    }

    private static void RegisterRepositorys(IServiceCollection services)
    {
        services.AddScoped<IClienteRepository, ClienteRepository>();
        services.AddScoped<ILogRepository, LogRepository>();
    }
}