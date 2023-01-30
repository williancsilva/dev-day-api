using System.Text.Json;

namespace DevSecOps.backoffice.Domain.Models.Signature;

public class AutenticarUsuarioSignature
{
    public int DayId { get; }
    public string Login { get; }
    public string Senha { get; }
    public bool IsValid { get; private set; }

    public AutenticarUsuarioSignature(int dayId, string login, string senha)
    {
        DayId = dayId;
        Login = login;
        Senha = senha;

        Validar();
    }

    private void Validar()
    {
        if (DayId <= 0)
            throw new ArgumentNullException(DayId.ToString(), "SessionId obrigatório");

        IsValid = true;
    }
}