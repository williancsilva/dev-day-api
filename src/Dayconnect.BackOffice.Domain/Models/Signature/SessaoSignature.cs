namespace DevSecOps.backoffice.Domain.Models.Signature;

public class SessaoSignature
{
    public string SessionId { get; }
    public int Expiration { get; }
    public bool IsValid { get; private set; }

    public SessaoSignature(string sessionId)
    {
        SessionId = sessionId;
        Expiration = 20;
        Validar();
    }

    private void Validar()
    {
        if (string.IsNullOrWhiteSpace(SessionId))
            throw new ArgumentNullException(SessionId,"SessionId obrigatório");

        IsValid = true;
    }
}