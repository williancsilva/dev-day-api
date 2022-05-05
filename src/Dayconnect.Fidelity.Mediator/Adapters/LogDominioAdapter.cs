using Dayconnect.Fidelity.Domain.Models;
using Dayconnect.Fidelity.Mediator.Notifications;

namespace Dayconnect.Fidelity.Mediator.Adapters;

public static class LogDominioAdapter
{
    public static LogDominio ConvertToDomain(this LogNotification notification)
    {
        return new LogDominio(notification.cpfCnpjCliente, notification.Metodo, notification.Url, notification.LoginOperador, notification.Ip);
    }
}