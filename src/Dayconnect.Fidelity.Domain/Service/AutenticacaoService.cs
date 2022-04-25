using Dayconnect.Fidelity.Domain.Interfaces.ExternalService;
using Dayconnect.Fidelity.Domain.Interfaces.Service;
using Dayconnect.Fidelity.Domain.Models;

namespace Dayconnect.Fidelity.Domain.Service;

public class AutenticacaoService : IAutenticacaoService
{
    private readonly IAccessControlSession _service;

    public AutenticacaoService(IAccessControlSession service)
    {
        _service = service;
    }

    public async Task<Login> Login(string login, string senha, string ip, string deviceId, string versaoDispositivo)
    {
        var sessionId = await _service.CriarSessao(new Models.Signature.CriarSessaoSignature(login, ip, deviceId, versaoDispositivo));
        var result = await _service.AutenticarUsuario(new Models.Signature.AutenticarUsuarioSignature(sessionId, login, senha));

        return new Login(sessionId, result?.Autenticado, result?.LoginHabilitado);
    }
}