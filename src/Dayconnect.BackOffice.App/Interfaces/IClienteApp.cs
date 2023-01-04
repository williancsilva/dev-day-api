using DevSecOps.backoffice.App.Dto.Result;
using DevSecOps.backoffice.App.Dto.Signature;

namespace DevSecOps.backoffice.App.Interfaces;

public interface IClienteApp
{
    Task<IEnumerable<ObterDadosClienteResult>> ObterDadosCliente(ObterDadosClienteSignature signature);
    Task InativarCliente(InativarClienteSignature signature);
    Task ExcluirCliente(ExcluirClienteSignature signature);
}