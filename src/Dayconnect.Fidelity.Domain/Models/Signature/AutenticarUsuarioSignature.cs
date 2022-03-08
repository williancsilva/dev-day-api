using System.Text.Json;

namespace Dayconnect.Fidelity.Domain.Models.Signature;

public class AutenticarUsuarioSignature
{
    public int CodSistema => 353;
    public string SessionId { get; }
    public string Login { get; }
    public FatorAutenticacao[] MutiploFatorAutenticacao { get; }
    public bool IsValid { get; private set; }

    public AutenticarUsuarioSignature(string sessionId, string login, string senha)
    {
        SessionId = sessionId;
        Login = login;
        MutiploFatorAutenticacao = new FatorAutenticacao[] {new(senha)};
        Validar();
    }

    private void Validar()
    {
        if (string.IsNullOrWhiteSpace(SessionId))
            throw new ArgumentNullException(SessionId, "SessionId obrigatório");

        IsValid = true;
    }
}

public class FatorAutenticacao
{
    public static int TipoAutenticacao => 9;
    public string SerializedAuth => JsonSerializer.Serialize(new {Senha = Pass});
    private string Pass { get; }

    public FatorAutenticacao(string senha)
    {
        Pass = senha;
    }
}