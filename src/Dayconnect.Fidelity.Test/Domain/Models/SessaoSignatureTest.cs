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
    public class SessaoSignatureTest
    {
        private readonly ModelFixture _modelFixture;
        public SessaoSignatureTest(ModelFixture modelFixture)
        {
            _modelFixture = modelFixture;
        }
        [Fact]
        public void DeveCriarSessaoSignatureValido()
        {
            var session = _modelFixture.Sessao;

            Assert.True(session.IsValid);
        }
        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void DeveGerarUmErroAoCriarSessaoSignature(string param)
        {
            var facker = new Faker<SessaoSignature>("pt_BR").CustomInstantiator(f =>
            {
                var session = new SessaoSignature(param);
                return session;
            });

            Assert.Throws<ArgumentNullException>(() => facker.Generate(1).First());
        }
    }
}
