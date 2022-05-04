using Bogus;
using Dayconnect.Fidelity.Domain.Models.Signature;
using Dayconnect.Fidelity.Test.Domain.Fixtures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Dayconnect.Fidelity.Test.Domain.Models
{
    [Collection(nameof(ModelsCollection))]
    public class ObterTipoAutenticacaoTest
    {
        [Fact]
        public void DeveCriarObterTipoAutenticacaoSignatureValido()
        {
            var signature = ModelFixture.ObterTipoAutenticacao;

            Assert.True(signature.IsValid);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void DeveGerarUmErroAoCriarObterTipoAutenticacaoSignature(string param)
        {
            var faker = new Faker<ObterTipoAutenticacaoSignature>("pt_BR").CustomInstantiator(f =>
            {
                var signature = new ObterTipoAutenticacaoSignature(param);
                return signature;
            });

            Assert.Throws<ArgumentNullException>(() => faker.Generate(1).First());
        }
    }
}
