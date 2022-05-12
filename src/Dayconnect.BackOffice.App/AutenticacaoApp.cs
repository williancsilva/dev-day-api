using Dayconnect.backoffice.App.Base;
using Dayconnect.backoffice.App.Converters;
using Dayconnect.backoffice.App.Dto.Result;
using Dayconnect.backoffice.App.Dto.Signature;
using Dayconnect.backoffice.App.Interfaces;
using Dayconnect.backoffice.App.Notifications;
using Dayconnect.backoffice.Domain.Interfaces.Service;

namespace Dayconnect.backoffice.App;

public class AutenticacaoApp : ApplicationBase, IAutenticacaoApp
{
    private readonly IAutenticacaoService _service;

    public AutenticacaoApp(NotificationContext notificationContext, IAutenticacaoService service) : base(notificationContext)
    {
        _service = service;
    }

    public async Task<LoginResult> Login(LoginSignature signature)
    {
        if (!DtoValido(signature))
            return null;

        var result = await _service.Login(signature.Login, signature.Password, signature.Ip, signature.DeviceId, signature.VersaoDispositivo);
        return result.Convert();
    }
}