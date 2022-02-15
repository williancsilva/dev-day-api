using Dayconnect.Fidelity.Domain.Models;
using Dayconnect.Fidelity.Mediator.Notifications;

namespace Dayconnect.Fidelity.Mediator.Adapters
{
    public static class LogDominiioAdapter
    {
        public static LogDominio ConvertToDomain(this LogNotification notification)
        {
            return new LogDominio(notification.CpfCnpjCliente, notification.Metodo, notification.Url, notification.LoginOperador, notification.Ip);
        }
    }
}
