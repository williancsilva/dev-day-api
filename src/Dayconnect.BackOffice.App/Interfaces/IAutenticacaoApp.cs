using DevSecOps.backoffice.App.Dto.Result;
using DevSecOps.backoffice.App.Dto.Signature;

namespace DevSecOps.backoffice.App.Interfaces;

public interface IAutenticacaoApp
{
    public Task<LoginResult> Login(LoginSignature signature);
}