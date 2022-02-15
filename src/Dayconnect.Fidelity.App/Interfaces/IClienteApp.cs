using Dayconnect.Fidelity.App.Dto.Result;
using Dayconnect.Fidelity.App.Dto.Signature;

namespace Dayconnect.Fidelity.App.Interfaces
{
    public interface IClienteApp
    {
        Task<IEnumerable<ObterDadosClienteResult>> ObterDadosCliente(ObterDadosClienteSignature signature);
        Task InativarCliente(InativarClienteSignature signature);
    }
}
