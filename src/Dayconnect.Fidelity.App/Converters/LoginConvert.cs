using Dayconnect.Fidelity.App.Dto.Result;
using Dayconnect.Fidelity.Domain.Models;

namespace Dayconnect.Fidelity.App.Converters;

public static class LoginConvert
{
    public static LoginResult Convert(this Login result)
    {
        if (result == null) return null;

        return new LoginResult
        {
            DayId = result.Id,
            Logado = result.Logado
        };
    }
}