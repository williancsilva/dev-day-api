using DevSecOps.backoffice.Domain.Models;

namespace DevSecOps.backoffice.Domain.Interfaces.Repository;

public interface IClienteRepository
{
    Task<IEnumerable<Cliente>> ObterDadosCliente(string cpfCnpj);
    Task InativarCliente(string cpfCnpj);
}