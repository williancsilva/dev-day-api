using DevSecOps.backoffice.Domain.Models;
using DevSecOps.backoffice.Mediator.Notifications;

namespace DevSecOps.backoffice.Mediator.Adapters;

public static class LogDominioAdapter
{
    public static LogDominio ConvertToDomain(this LogNotification notification)
    {
        return new LogDominio(notification.cpfCnpjCliente, notification.Metodo, notification.Url, notification.LoginOperador, notification.Ip);
    }
}