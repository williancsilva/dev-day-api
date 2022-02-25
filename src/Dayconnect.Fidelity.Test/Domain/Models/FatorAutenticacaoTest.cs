using Dayconnect.Fidelity.Domain.Models.Signature;
using Dayconnect.Fidelity.Test.Domain.Fixtures;
using Xunit;

namespace Dayconnect.Fidelity.Test.Domain.Models;

[Collection(nameof(ModelsCollection))]
public class FatorAutenticacaoTest
{
    [Fact]
    public void DeveCriarFatorAutenticacaoValido()
    {
        var model = new FatorAutenticacao("xxx");
        Assert.Equal(9, FatorAutenticacao.TipoAutenticacao);
        Assert.Contains("xxx", model.SerializedAuth);
    }
}