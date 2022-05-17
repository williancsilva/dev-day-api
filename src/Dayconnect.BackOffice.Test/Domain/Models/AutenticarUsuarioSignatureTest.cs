using Bogus;
using Dayconnect.backoffice.Domain.Models.Signature;
using Dayconnect.backoffice.Test.Domain.Fixtures;
using System;
using System.Linq;
using Xunit;

namespace Dayconnect.backoffice.Test.Domain.Models;

[Collection(nameof(ModelsCollection))]
public class AutenticarUsuarioSignatureTest
{
    [Fact]
    public void DeveAutenticarUsuarioSignatureValido()
    {
        Assert.True(ModelFixture.AutenticarUsuario.IsValid);
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    public void DeveGerarUmErroAoAutenticarUsuarioSignature(string param)
    {
        var faker = new Faker<AutenticarUsuarioSignature>("pt_BR").CustomInstantiator(f =>
        {
            var autenticarUsuario = new AutenticarUsuarioSignature(param, f.Internet.Email(), f.Internet.Password(), 9);
            return autenticarUsuario;
        });

        Assert.Throws<ArgumentNullException>(() => faker.Generate(1).First());
    }
}