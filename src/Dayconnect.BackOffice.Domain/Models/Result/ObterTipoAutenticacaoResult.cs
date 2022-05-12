namespace Dayconnect.backoffice.Domain.Models.Result
{
    public class ObterTipoAutenticacaoResult
    {
        public IEnumerable<FatorAutenticacao> MutiploFatorAutenticacao { get; set; }

    }
    public class FatorAutenticacao
    {
        public int TipoAutenticacao { get; set; }
    }
}
