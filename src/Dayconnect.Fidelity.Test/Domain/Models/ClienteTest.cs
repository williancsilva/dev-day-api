using Bogus;
using Bogus.Extensions.Brazil;
using Dayconnect.Fidelity.Domain.Models;
using Dayconnect.Fidelity.Test.Domain.Fixtures;
using System;
using System.Linq;
using Xunit;

namespace Dayconnect.Fidelity.Test.Domain.Models
{
    [Collection(nameof(ModelsCollection))]
    public class ClienteTest
    {
        private readonly ModelFixture _modelFixture;
        public ClienteTest(ModelFixture modelFixture)
        {
            _modelFixture = modelFixture;
        }
        [Fact]
        public void DeveCriarClienteValido()
        {
            var cliente = _modelFixture.Cliente;

            Assert.True(cliente.IsValid);
        }
        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void DeveGerarUmErroAoCriarUmClienteSemNome(string param)
        {
            var facker = new Faker<Cliente>("pt_BR").CustomInstantiator(f =>
            {
                var cliente = new Cliente(param, f.Person.Cpf());
                return cliente;
            });

            Assert.Throws<ArgumentNullException>(() => facker.Generate(1).First());
        }
        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void DeveGerarUmErroAoCriarUmClienteSemDocumento(string param)
        {
            var facker = new Faker<Cliente>("pt_BR").CustomInstantiator(f =>
            {
                var cliente = new Cliente(f.Person.FullName, param);
                return cliente;
            });

            Assert.Throws<ArgumentNullException>(() => facker.Generate(1).First());
        }
    }
}
