using Dayconnect.backoffice.App.Dto.Result;
using Dayconnect.backoffice.App.Dto.Signature;

namespace Dayconnect.backoffice.App.Interfaces;

public interface IClienteApp
{
    Task<IEnumerable<ObterDadosClienteResult>> ObterDadosCliente(ObterDadosClienteSignature signature);
    Task InativarCliente(InativarClienteSignature signature);
}