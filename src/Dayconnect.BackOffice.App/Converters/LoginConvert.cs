using Dayconnect.backoffice.App.Dto.Result;
using Dayconnect.backoffice.Domain.Models;

namespace Dayconnect.backoffice.App.Converters;

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