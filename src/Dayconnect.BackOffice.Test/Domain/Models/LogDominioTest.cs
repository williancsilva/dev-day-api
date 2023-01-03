using Bogus;
using Bogus.Extensions.Brazil;
using DevSecOps.backoffice.Domain.Models;
using DevSecOps.backoffice.Test.Domain.Fixtures;
using System;
using System.Linq;
using Xunit;

namespace DevSecOps.backoffice.Test.Domain.Models;

[Collection(nameof(ModelsCollection))]
public class LogDominioTest
{
    [Fact]
    public void DeveCriarLogDominioValido()
    {
        Assert.True(ModelFixture.LogDominio.IsValid);
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    public void DeveGerarUmErroAoCriarUmLogDominioSemDocumento(string param)
    {
        var faker = new Faker<LogDominio>("pt_BR").CustomInstantiator(f => new LogDominio(param, f.Random.Word(), f.Internet.Url(), f.Internet.Email(), f.Internet.Ip()));

        Assert.Throws<ArgumentNullException>(() => faker.Generate(1).First());
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    public void DeveGerarUmErroAoCriarUmLogDominioSemMetodo(string param)
    {
        var faker = new Faker<LogDominio>("pt_BR").CustomInstantiator(f => new LogDominio(f.Person.Cpf(), param, f.Internet.Url(), f.Internet.Email(), f.Internet.Ip()));

        Assert.Throws<ArgumentNullException>(() => faker.Generate(1).First());
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    public void DeveGerarUmErroAoCriarUmLogDominioSemUrl(string param)
    {
        var faker = new Faker<LogDominio>("pt_BR").CustomInstantiator(f => new LogDominio(f.Person.Cpf(), f.Random.Word(), param, f.Internet.Email(), f.Internet.Ip()));

        Assert.Throws<ArgumentNullException>(() => faker.Generate(1).First());
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    public void DeveGerarUmErroAoCriarUmLogDominioSemLogin(string param)
    {
        var faker = new Faker<LogDominio>("pt_BR").CustomInstantiator(f => new LogDominio(f.Person.Cpf(), f.Random.Word(), f.Internet.Url(), param, f.Internet.Ip()));

        Assert.Throws<ArgumentNullException>(() => faker.Generate(1).First());
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    public void DeveGerarUmErroAoCriarUmLogDominioSemIp(string param)
    {
        var faker = new Faker<LogDominio>("pt_BR").CustomInstantiator(f => new LogDominio(f.Person.Cpf(), f.Random.Word(), f.Internet.Url(), f.Internet.Email(), param));

        Assert.Throws<ArgumentNullException>(() => faker.Generate(1).First());
    }
}