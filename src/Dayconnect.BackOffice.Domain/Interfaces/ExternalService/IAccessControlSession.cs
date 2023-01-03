using DevSecOps.backoffice.Domain.Models.Result;
using DevSecOps.backoffice.Domain.Models.Signature;

namespace DevSecOps.backoffice.Domain.Interfaces.ExternalService;

public interface IAccessControlSession
{
    Task<SessaoResult> ObterSessao(SessaoSignature signature);
    Task<string> CriarSessao(CriarSessaoSignature signature);
    Task<AutenticarUsuarioResult> AutenticarUsuario(AutenticarUsuarioSignature signature);
    Task<int> ObterTipoAutenticacao(ObterTipoAutenticacaoSignature signature);
}