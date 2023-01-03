using DevSecOps.backoffice.Domain.Models.Signature;
using DevSecOps.backoffice.Test.Domain.Fixtures;
using Xunit;

namespace DevSecOps.backoffice.Test.Domain.Models;

[Collection(nameof(ModelsCollection))]
public class FatorAutenticacaoTest
{
    [Fact]
    public void DeveCriarFatorAutenticacaoValido()
    {
        var model = new FatorAutenticacao("xxx", 9);
        Assert.Equal(9, model.TipoAutenticacao);
        Assert.Contains("xxx", model.SerializedAuth);
    }
}