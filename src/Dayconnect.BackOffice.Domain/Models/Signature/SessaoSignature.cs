namespace DevSecOps.backoffice.Domain.Models.Signature;

public class SessaoSignature
{
    public int SessionId { get; }
    public int Expiration { get; }
    public bool IsValid { get; private set; }

    public SessaoSignature(int sessionId)
    {
        SessionId = sessionId;
        Expiration = 20;
        Validar();
    }

    private void Validar()
    {
        if (SessionId <= 0)
            throw new ArgumentNullException(SessionId.ToString(),"SessionId obrigatório");

        IsValid = true;
    }
}