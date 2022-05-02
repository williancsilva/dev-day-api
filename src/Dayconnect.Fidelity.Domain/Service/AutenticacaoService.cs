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
        var tipoAutenticacao = await _service.ObterTipoAutenticacao(new Models.Signature.ObterTipoAutenticacaoSignature(login));
        if (tipoAutenticacao == 0) return null;
        var sessionId = await _service.CriarSessao(new Models.Signature.CriarSessaoSignature(login, ip, deviceId, versaoDispositivo));
        var result = await _service.AutenticarUsuario(new Models.Signature.AutenticarUsuarioSignature(sessionId, login, senha, tipoAutenticacao));

        return new Login(sessionId, result?.Autenticado, result?.LoginHabilitado);
    }
}