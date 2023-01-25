using DevSecOps.backoffice.Domain.Interfaces.Service;
using DevSecOps.backoffice.Domain.Models;
using DevSecOps.backoffice.Domain.Models.Result;
using DevSecOps.backoffice.Domain.Models.Signature;
using DevSecOps.BackOffice.Domain.Interfaces.Repository;

namespace DevSecOps.backoffice.Domain.Service;

public class AutenticacaoService : IAutenticacaoService
{
    private readonly IAutenticacaoRepository _repository;

    public AutenticacaoService(IAutenticacaoRepository repository)
    {
        _repository = repository;
    }

    public async Task<Login?> Login(string login, string senha, string ip, string deviceId, string versaoDispositivo)
    {
        var sessionId = await _repository.CriarSessao(login);
        var result = await AutenticarUsuario(new AutenticarUsuarioSignature(sessionId, login, senha));

        return new Login(sessionId, result?.Autenticado, true, result?.Permissoes, result.Senha);
    }

    public async Task<SessaoResult> ObterSessao(SessaoSignature signature)
    {
        return await _repository.ObterSessao(signature.SessionId);
    }

    public async Task<AutenticarUsuarioResult> AutenticarUsuario(AutenticarUsuarioSignature signature)
    {
        var sessao = await _repository.ObterSessao(signature.SessionId);
        var autenticacaoUsuario = new AutenticarUsuarioResult();

        if (sessao != null && sessao.Senha == signature.Senha)
        {
            autenticacaoUsuario.AutenticarUsuario(sessao);
            await _repository.AtualizarSessao(signature.SessionId);

        }

        return autenticacaoUsuario;
    }
}