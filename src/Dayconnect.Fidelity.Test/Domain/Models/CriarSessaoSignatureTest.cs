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
    public class CriarSessaoSignatureTest
    {
        private readonly ModelFixture _modelFixture;
        public CriarSessaoSignatureTest(ModelFixture modelFixture)
        {
            _modelFixture = modelFixture;
        }
        [Fact]
        public void DeveCriarModelCriarSessaoSignatureValido()
        {
            var session = _modelFixture.CriarSessao;

            Assert.True(session.IsValid);
        }
        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void DeveGerarUmErroAoCriarModelCriarSessaoSignatureSemLogin(string param)
        {
            var facker = new Faker<CriarSessaoSignature>("pt_BR").CustomInstantiator(f =>
            {
                var session = new CriarSessaoSignature(param, f.Internet.Ip(), f.Random.Number(10,30).ToString(), f.Random.Word());
                return session;
            });

            Assert.Throws<ArgumentNullException>(() => facker.Generate(1).First());
        }
        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void DeveGerarUmErroAoCriarModelCriarSessaoSignatureSemIp(string param)
        {
            var facker = new Faker<CriarSessaoSignature>("pt_BR").CustomInstantiator(f =>
            {
                var session = new CriarSessaoSignature(f.Internet.Email(), param, f.Random.Number(10, 30).ToString(), f.Random.Word());
                return session;
            });

            Assert.Throws<ArgumentNullException>(() => facker.Generate(1).First());
        }
        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void DeveGerarUmErroAoCriarModelCriarSessaoSignatureSemDeviceId(string param)
        {
            var facker = new Faker<CriarSessaoSignature>("pt_BR").CustomInstantiator(f =>
            {
                var session = new CriarSessaoSignature(f.Internet.Email(), f.Internet.Ip(), param, f.Random.Word());
                return session;
            });

            Assert.Throws<ArgumentNullException>(() => facker.Generate(1).First());
        }
        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void DeveGerarUmErroAoCriarModelCriarSessaoSignatureSemVersaoDispositivo(string param)
        {
            var facker = new Faker<CriarSessaoSignature>("pt_BR").CustomInstantiator(f =>
            {
                var session = new CriarSessaoSignature(f.Internet.Email(), f.Internet.Ip(), f.Random.Number(10, 30).ToString(), param);
                return session;
            });

            Assert.Throws<ArgumentNullException>(() => facker.Generate(1).First());
        }
    }
}
