using DevSecOps.backoffice.App.Dto.Result;
using DevSecOps.backoffice.Domain.Models;

namespace DevSecOps.backoffice.App.Converters;

public static class LoginConvert
{
    public static LoginResult Convert(this Login result)
    {
        if (result == null) return null;

        return new LoginResult
        {
            DayId = result.Id,
            Logado = result.Logado,
            Permissoes = result.Permissoes,
            Senha = result.Senha
        };
    }
}