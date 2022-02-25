using Dayconnect.Fidelity.App.Dto;
using Dayconnect.Fidelity.App.Notifications;

namespace Dayconnect.Fidelity.App.Base;

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