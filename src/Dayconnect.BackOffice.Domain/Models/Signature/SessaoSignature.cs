namespace DevSecOps.backoffice.Domain.Models.Signature;

public class SessaoSignature
{
    public int DayId { get; }
    public int Expiration { get; }
    public bool IsValid { get; private set; }

    public SessaoSignature(int dayId)
    {
        DayId = dayId;
        Expiration = 20;
        Validar();
    }

    private void Validar()
    {
        if (DayId <= 0)
            throw new ArgumentNullException(DayId.ToString(),"SessionId obrigatório");

        IsValid = true;
    }
}