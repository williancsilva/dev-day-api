using Bogus;
using Bogus.Extensions.Brazil;
using Dayconnect.Fidelity.Domain.Models;
using Dayconnect.Fidelity.Test.Domain.Fixtures;
using System;
using System.Linq;
using Xunit;

namespace Dayconnect.Fidelity.Test.Domain.Models;

[Collection(nameof(ModelsCollection))]
public class ClienteTest
{
    [Fact]
    public void DeveCriarClienteValido()
    {
        Assert.True(ModelFixture.Cliente.IsValid);
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    public void DeveGerarUmErroAoCriarUmClienteSemNome(string param)
    {
        var faker = new Faker<Cliente>("pt_BR").CustomInstantiator(f =>
        {
            var cliente = new Cliente(param, f.Person.Cpf());
            return cliente;
        });

        Assert.Throws<ArgumentNullException>(() => faker.Generate(1).First());
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    public void DeveGerarUmErroAoCriarUmClienteSemDocumento(string param)
    {
        var faker = new Faker<Cliente>("pt_BR").CustomInstantiator(f =>
        {
            var cliente = new Cliente(f.Person.FullName, param);
            return cliente;
        });

        Assert.Throws<ArgumentNullException>(() => faker.Generate(1).First());
    }
}