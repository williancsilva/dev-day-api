using Dayconnect.Fidelity.App.Dto.Result;
using Dayconnect.Fidelity.Domain.Models;

namespace Dayconnect.Fidelity.App.Converters;

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