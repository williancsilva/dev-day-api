using Dayconnect.backoffice.Domain.Models;
using Dayconnect.backoffice.Mediator.Notifications;

namespace Dayconnect.backoffice.Mediator.Adapters;

public static class LogDominioAdapter
{
    public static LogDominio ConvertToDomain(this LogNotification notification)
    {
        return new LogDominio(notification.cpfCnpjCliente, notification.Metodo, notification.Url, notification.LoginOperador, notification.Ip);
    }
}