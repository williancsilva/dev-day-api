using Dayconnect.backoffice.App.Dto;
using Dayconnect.backoffice.App.Notifications;

namespace Dayconnect.backoffice.App.Base;

public abstract class ApplicationBase
{
    private readonly NotificationContext _notificationContext;

    protected ApplicationBase(NotificationContext notificationContext)
    {
        _notificationContext = notificationContext;
    }

    public bool DtoValido<T>(T signature) where T : DtoBase, IDtoContract
    {
        signature.ValidarDto();

        if (!signature.Invalid) return true;
        _notificationContext.AddNotifications(signature.ValidationResult);
        return false;
    }
}