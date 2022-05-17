using Dayconnect.backoffice.Domain.Models.Result;
using Dayconnect.backoffice.Domain.Models.Signature;

namespace Dayconnect.backoffice.Domain.Interfaces.ExternalService;

public interface IAccessControlSession
{
    Task<SessaoResult> ObterSessao(SessaoSignature signature);
    Task<string> CriarSessao(CriarSessaoSignature signature);
    Task<AutenticarUsuarioResult> AutenticarUsuario(AutenticarUsuarioSignature signature);
    Task<int> ObterTipoAutenticacao(ObterTipoAutenticacaoSignature signature);
}