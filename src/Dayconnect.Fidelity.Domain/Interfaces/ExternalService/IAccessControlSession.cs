using Dayconnect.Fidelity.Domain.Models.Result;
using Dayconnect.Fidelity.Domain.Models.Signature;

namespace Dayconnect.Fidelity.Domain.Interfaces.ExternalService;

public interface IAccessControlSession
{
    Task<SessaoResult> ObterSessao(SessaoSignature signature);
    Task<string> CriarSessao(CriarSessaoSignature signature);
    Task<AutenticarUsuarioResult> AutenticarUsuario(AutenticarUsuarioSignature signature);
    Task<int> ObterTipoAutenticacao(ObterTipoAutenticacaoSignature signature);
}