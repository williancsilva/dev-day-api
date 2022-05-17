using Bogus;
using Dayconnect.backoffice.Domain.Models.Signature;
using Dayconnect.backoffice.Test.Domain.Fixtures;
using System;
using System.Linq;
using Xunit;

namespace Dayconnect.backoffice.Test.Domain.Models;

[Collection(nameof(ModelsCollection))]
public class CriarSessaoSignatureTest
{
    [Fact]
    public void DeveCriarModelCriarSessaoSignatureValido()
    {
        Assert.True(ModelFixture.CriarSessao.IsValid);
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    public void DeveGerarUmErroAoCriarModelCriarSessaoSignatureSemLogin(string param)
    {
        var faker = new Faker<CriarSessaoSignature>("pt_BR").CustomInstantiator(f =>
        {
            var session = new CriarSessaoSignature(param, f.Internet.Ip(), f.Random.Number(10, 30).ToString(), f.Random.Word());
            return session;
        });

        Assert.Throws<ArgumentNullException>(() => faker.Generate(1).First());
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    public void DeveGerarUmErroAoCriarModelCriarSessaoSignatureSemIp(string param)
    {
        var faker = new Faker<CriarSessaoSignature>("pt_BR").CustomInstantiator(f =>
        {
            var session = new CriarSessaoSignature(f.Internet.Email(), param, f.Random.Number(10, 30).ToString(), f.Random.Word());
            return session;
        });

        Assert.Throws<ArgumentNullException>(() => faker.Generate(1).First());
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    public void DeveGerarUmErroAoCriarModelCriarSessaoSignatureSemDeviceId(string param)
    {
        var faker = new Faker<CriarSessaoSignature>("pt_BR").CustomInstantiator(f =>
        {
            var session = new CriarSessaoSignature(f.Internet.Email(), f.Internet.Ip(), param, f.Random.Word());
            return session;
        });

        Assert.Throws<ArgumentNullException>(() => faker.Generate(1).First());
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    public void DeveGerarUmErroAoCriarModelCriarSessaoSignatureSemVersaoDispositivo(string param)
    {
        var faker = new Faker<CriarSessaoSignature>("pt_BR").CustomInstantiator(f =>
        {
            var session = new CriarSessaoSignature(f.Internet.Email(), f.Internet.Ip(), f.Random.Number(10, 30).ToString(), param);
            return session;
        });

        Assert.Throws<ArgumentNullException>(() => faker.Generate(1).First());
    }
}