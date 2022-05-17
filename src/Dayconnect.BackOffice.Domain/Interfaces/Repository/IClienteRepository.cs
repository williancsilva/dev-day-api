using Dayconnect.backoffice.Domain.Models;

namespace Dayconnect.backoffice.Domain.Interfaces.Repository;

public interface IClienteRepository
{
    Task<IEnumerable<Cliente>> ObterDadosCliente(string cpfCnpj);
    Task InativarCliente(string cpfCnpj);
}