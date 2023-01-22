using System.Text.Json;

namespace DevSecOps.backoffice.Domain.Models.Signature;

public class AutenticarUsuarioSignature
{
    public int SessionId { get; }
    public string Login { get; }
    public string Senha { get; }
    public bool IsValid { get; private set; }

    public AutenticarUsuarioSignature(int sessionId, string login, string senha)
    {
        SessionId = sessionId;
        Login = login;
        Senha = senha;

        Validar();
    }

    private void Validar()
    {
        if (SessionId <= 0)
            throw new ArgumentNullException(SessionId.ToString(), "SessionId obrigatório");

        IsValid = true;
    }
}