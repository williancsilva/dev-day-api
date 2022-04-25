using Dayconnect.Fidelity.App.Dto.Result;
using Dayconnect.Fidelity.App.Dto.Signature;

namespace Dayconnect.Fidelity.App.Interfaces;

public interface IAutenticacaoApp
{
    public Task<LoginResult> Login(LoginSignature signature);
}