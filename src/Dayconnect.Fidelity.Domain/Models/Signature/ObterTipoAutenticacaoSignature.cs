namespace Dayconnect.Fidelity.Domain.Models.Signature
{
    public class ObterTipoAutenticacaoSignature
    {
        public ObterTipoAutenticacaoSignature(string _login)
        {
            CodSistema = 353;
            Login = _login;
        }

        public int CodSistema { get; }
        public string Login { get; }  
    }
}
