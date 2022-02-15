using Dayconnect.Fidelity.Domain.Models.Result;
using Dayconnect.Fidelity.Domain.Models.Signature;
using System.Threading.Tasks;

namespace Dayconnect.Fidelity.Domain.Interfaces.ExternalService
{
    public interface IAccessControlSession
    {
        Task<SessaoResult> ObterSessao(SessaoSignature signature);
        Task<string> CriarSessao(CriarSessaoSignature signature);
        Task<AutenticarUsuarioResult> AutenticarUsuario(AutenticarUsuarioSignature signature);
    }
}
