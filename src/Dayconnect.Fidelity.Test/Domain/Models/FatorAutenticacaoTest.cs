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
    public class FatorAutenticacaoTest
    {
        private readonly ModelFixture _modelFixture;

        public FatorAutenticacaoTest(ModelFixture modelFixture)
        {
            _modelFixture = modelFixture;
        }
        
        [Fact]
        public void DeveCriarFatorAutenticacaoValido()
        {
            var model = new FatorAutenticacao("xxx");
            Assert.Equal(9, model.TipoAutenticacao);
            Assert.Contains("xxx", model.SerializedAuth);
        }
    }
}
