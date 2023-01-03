using Bogus;
using Bogus.Extensions.Brazil;
using DevSecOps.backoffice.Domain.Models;
using DevSecOps.backoffice.Domain.Models.Signature;
using DevSecOps.backoffice.Test.Domain.Fixtures;
using System;
using System.Linq;
using Xunit;

namespace DevSecOps.backoffice.Test.Domain.Models;

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