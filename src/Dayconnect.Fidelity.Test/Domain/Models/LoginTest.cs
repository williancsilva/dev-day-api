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
    public class LoginTest
    {
        private readonly ModelFixture _modelFixture;
        public LoginTest(ModelFixture modelFixture)
        {
            _modelFixture = modelFixture;
        }
        [Fact]
        public void DeveCriarLoginValido()
        {
            var login = _modelFixture.Login;

            Assert.True(login.IsValid);
        }
        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void DeveGerarUmErroAoCriarUmLoginSemId(string param)
        {
            var facker = new Faker<Login>("pt_BR").CustomInstantiator(f =>
            {
                var login = new Login(param, true, true);
                return login;
            });

            Assert.Throws<ArgumentNullException>(() => facker.Generate(1).First());
        }
        [Theory]
        [InlineData(true,true)]
        public void DeveEstarLogado(bool? autenticado, bool? habilitado)
        {
            string id = $"353_{Guid.NewGuid()}";
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
            string id = $"353_{Guid.NewGuid()}";
            var login = new Login(id, autenticado, habilitado);
            Assert.False(login.Logado);
        }
    }
}
