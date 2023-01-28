using DevSecOps.backoffice.App.Base;
using DevSecOps.backoffice.App.Converters;
using DevSecOps.backoffice.App.Dto.Result;
using DevSecOps.backoffice.App.Dto.Signature;
using DevSecOps.backoffice.App.Interfaces;
using DevSecOps.backoffice.App.Notifications;
using DevSecOps.backoffice.Domain.Interfaces.Service;
using Microsoft.Extensions.Primitives;

namespace DevSecOps.backoffice.App;

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

    public async Task Logoff(string dayId)
    {
        await _service.Logoff(dayId);
    }
}