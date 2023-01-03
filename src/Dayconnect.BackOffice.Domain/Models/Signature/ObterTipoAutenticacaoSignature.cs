namespace DevSecOps.backoffice.Domain.Models.Signature
{
    public class ObterTipoAutenticacaoSignature
    {
        public ObterTipoAutenticacaoSignature(string _login)
        {
            CodSistema = 353;
            Login = _login;
            Validar();
        }

        public int CodSistema { get; }
        public string Login { get; }
        public bool IsValid { get; private set; }
        private void Validar()
        {
            if (string.IsNullOrWhiteSpace(Login))
                throw new ArgumentNullException(Login, "Login obrigatório");

            IsValid = true;
        }
    }
}
