using Bogus;
using DevSecOps.backoffice.Domain.Models;
using DevSecOps.backoffice.Test.Domain.Fixtures;
using System;
using System.Linq;
using Xunit;

namespace DevSecOps.backoffice.Test.Domain.Models;

[Collection(nameof(ModelsCollection))]
public class LoginTest
{
    [Fact]
    public void DeveCriarLoginValido()
    {
        Assert.True(ModelFixture.Login.IsValid);
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    public void DeveGerarUmErroAoCriarUmLoginSemId(string param)
    {
        var faker = new Faker<Login>("pt_BR").CustomInstantiator(_ =>
        {
            var login = new Login(param, true, true);
            return login;
        });

        Assert.Throws<ArgumentNullException>(() => faker.Generate(1).First());
    }

    [Theory]
    [InlineData(true, true)]
    public void DeveEstarLogado(bool? autenticado, bool? habilitado)
    {
        var id = $"353_{Guid.NewGuid()}";
        var login = new Login(id, autenticado, habilitado);
        Assert.True(login.Logado);
    }

    [Theory]
    [InlineData(null, null)]
    [InlineData(false, true)]
    [InlineData(true, false)]
    [InlineData(false, false)]
    public void DeveNaoEstarLogado(bool? autenticado, bool? habilitado)
    {
        var id = $"353_{Guid.NewGuid()}";
        var login = new Login(id, autenticado, habilitado);
        Assert.False(login.Logado);
    }
}