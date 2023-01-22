using DevSecOps.backoffice.Domain.Interfaces.ExternalService;
using DevSecOps.backoffice.Domain.Models.Result;
using DevSecOps.backoffice.Domain.Models.Signature;
using DevSecOps.BackOffice.Domain.Interfaces.Repository;
using System.Text;
using System.Text.Json;

#nullable disable

namespace DevSecOps.backoffice.ExternalService;

public class AccessControlSession : IAccessControlSession
{
    private readonly IAutenticacaoRepository _autenticacaoRepository;

    public AccessControlSession(IAutenticacaoRepository autenticacaoRepository)
    {
        _autenticacaoRepository = autenticacaoRepository;
    }

    public async Task<SessaoResult> ObterSessao(SessaoSignature signature)
    {
        return await _autenticacaoRepository.ObterSessao(signature.SessionId);
    }

    public async Task<AutenticarUsuarioResult> AutenticarUsuario(AutenticarUsuarioSignature signature)
    {
        var sessao = await _autenticacaoRepository.ObterSessao(signature.SessionId);
        var autenticacaoUsuario = new AutenticarUsuarioResult();

        if (sessao != null && sessao.Senha == signature.Senha)
        {
            autenticacaoUsuario.AutenticarUsuario();
            await _autenticacaoRepository.AtualizarSessao(signature.SessionId);
        }

        return autenticacaoUsuario;
    }
}