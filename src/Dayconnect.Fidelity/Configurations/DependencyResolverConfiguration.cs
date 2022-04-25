using Dayconnect.Fidelity.App;
using Dayconnect.Fidelity.App.Interfaces;
using Dayconnect.Fidelity.App.Notifications;
using Dayconnect.Fidelity.Domain.Interfaces.ExternalService;
using Dayconnect.Fidelity.Domain.Interfaces.Repository;
using Dayconnect.Fidelity.Domain.Interfaces.Service;
using Dayconnect.Fidelity.Domain.Service;
using Dayconnect.Fidelity.ExternalService;
using Dayconnect.Fidelity.Mediator.Events;
using Dayconnect.Fidelity.Mediator.Handles;
using Dayconnect.Fidelity.Mediator.Notifications;
using Dayconnect.Fidelity.Repository;
using MediatR;

namespace Dayconnect.Fidelity.Configurations;

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