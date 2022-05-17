using Dayconnect.backoffice.App.Dto.Result;
using Dayconnect.backoffice.App.Dto.Signature;

namespace Dayconnect.backoffice.App.Interfaces;

public interface IAutenticacaoApp
{
    public Task<LoginResult> Login(LoginSignature signature);
}