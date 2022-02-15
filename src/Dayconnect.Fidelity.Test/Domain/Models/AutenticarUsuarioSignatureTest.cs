using Bogus;
using Bogus.Extensions.Brazil;
using Dayconnect.Fidelity.Domain.Models;
using Dayconnect.Fidelity.Domain.Models.Signature;
using Dayconnect.Fidelity.Test.Domain.Fixtures;
using System;
using System.Linq;
using Xunit;

namespace Dayconnect.Fidelity.Test.Domain.Models
{
    [Collection(nameof(ModelsCollection))]
    public class AutenticarUsuarioSignatureTest
    {
        private readonly ModelFixture _modelFixture;
        public AutenticarUsuarioSignatureTest(ModelFixture modelFixture)
        {
            _modelFixture = modelFixture;
        }
        [Fact]
        public void DeveAutenticarUsuarioSignatureValido()
        {
            var session = _modelFixture.AutenticarUsuario;

            Assert.True(session.IsValid);
        }
        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void DeveGerarUmErroAoAutenticarUsuarioSignature(string param)
        {
            var facker = new Faker<AutenticarUsuarioSignature>("pt_BR").CustomInstantiator(f =>
            {
                var autenticarUsuario = new AutenticarUsuarioSignature(param, f.Internet.Email(), f.Internet.Password());
                return autenticarUsuario;
            });

            Assert.Throws<ArgumentNullException>(() => facker.Generate(1).First());
        }
    }
}
