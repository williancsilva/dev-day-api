using Bogus;
using Bogus.Extensions.Brazil;
using Dayconnect.Fidelity.Domain.Models;
using Dayconnect.Fidelity.Domain.Models.Signature;
using Dayconnect.Fidelity.Test.Domain.Fixtures;
using System;
using System.Linq;
using Xunit;

namespace Dayconnect.Fidelity.Test.Domain.Models;

[Collection(nameof(ModelsCollection))]
public class SessaoSignatureTest
{
    [Fact]
    public void DeveCriarSessaoSignatureValido()
    {
        var session = ModelFixture.Sessao;

        Assert.True(session.IsValid);
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    public void DeveGerarUmErroAoCriarSessaoSignature(string param)
    {
        var faker = new Faker<SessaoSignature>("pt_BR").CustomInstantiator(f =>
        {
            var session = new SessaoSignature(param);
            return session;
        });

        Assert.Throws<ArgumentNullException>(() => faker.Generate(1).First());
    }
}