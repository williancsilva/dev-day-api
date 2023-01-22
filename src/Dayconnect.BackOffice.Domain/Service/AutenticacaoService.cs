using DevSecOps.backoffice.Domain.Interfaces.ExternalService;
using DevSecOps.backoffice.Domain.Interfaces.Service;
using DevSecOps.backoffice.Domain.Models;
using DevSecOps.BackOffice.Domain.Interfaces.Repository;

namespace DevSecOps.backoffice.Domain.Service;

public class AutenticacaoService : IAutenticacaoService
{
    private readonly IAccessControlSession _service;
    private readonly IAutenticacaoRepository _repository;

    public AutenticacaoService(IAccessControlSession service, IAutenticacaoRepository repository)
    {
        _service = service;
        _repository = repository;
    }

    public async Task<Login?> Login(string login, string senha, string ip, string deviceId, string versaoDispositivo)
    {
        var sessionId = await _repository.CriarSessao(login);
        var result = await _service.AutenticarUsuario(new Models.Signature.AutenticarUsuarioSignature(sessionId, login, senha));

        return new Login(sessionId, result?.Autenticado, true);
    }
}