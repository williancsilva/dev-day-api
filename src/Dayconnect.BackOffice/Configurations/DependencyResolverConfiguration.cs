using DevSecOps.backoffice.App;
using DevSecOps.backoffice.App.Interfaces;
using DevSecOps.backoffice.App.Notifications;
using DevSecOps.backoffice.Domain.Interfaces.Repository;
using DevSecOps.backoffice.Domain.Interfaces.Service;
using DevSecOps.backoffice.Domain.Service;
using DevSecOps.backoffice.Mediator.Events;
using DevSecOps.backoffice.Mediator.Handles;
using DevSecOps.backoffice.Mediator.Notifications;
using DevSecOps.backoffice.Repository;
using DevSecOps.BackOffice.Domain.Interfaces.Repository;
using MediatR;

namespace DevSecOps.backoffice.Configurations;

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
        services.AddScoped<IAutenticacaoService, AutenticacaoService>();
    }

    private static void RegisterRepositorys(IServiceCollection services)
    {
        services.AddScoped<IClienteRepository, ClienteRepository>();
        services.AddScoped<IAutenticacaoRepository, AutenticacaoRepository>();
        services.AddScoped<ILogRepository, LogRepository>();
    }
}