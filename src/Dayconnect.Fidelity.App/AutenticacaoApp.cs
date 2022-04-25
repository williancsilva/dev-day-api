using Dayconnect.Fidelity.App.Base;
using Dayconnect.Fidelity.App.Converters;
using Dayconnect.Fidelity.App.Dto.Result;
using Dayconnect.Fidelity.App.Dto.Signature;
using Dayconnect.Fidelity.App.Interfaces;
using Dayconnect.Fidelity.App.Notifications;
using Dayconnect.Fidelity.Domain.Interfaces.Service;

namespace Dayconnect.Fidelity.App;

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