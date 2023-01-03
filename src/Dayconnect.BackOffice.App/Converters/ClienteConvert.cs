using DevSecOps.backoffice.App.Dto.Result;
using DevSecOps.backoffice.Domain.Models;

namespace DevSecOps.backoffice.App.Converters;

public static class ClienteConvert
{
    public static IEnumerable<ObterDadosClienteResult> Convert(this IEnumerable<Cliente> result)
    {
        return result?.Select(x => new ObterDadosClienteResult
        {
            Nome = x.Nome,
            CpfCnpj = x.CpfCnpj,
            Ativo = x.Ativo
        });
    }
}