using Dayconnect.Fidelity.App.Validators;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Dayconnect.Fidelity.App.Dto.Signature
{
    public class LoginSignature : DtoBase, IDtoContract
    {
        [SwaggerSchema("Email cadastrado para efetuar o login", Nullable = false)]
        public string Login { get; set; }
        [SwaggerSchema("Senha fornecida pelo Daycoval", Nullable = false)]
        public string Password { get; set; }
        [JsonIgnore]
        public string Ip { get; set; }
        [SwaggerSchema("Número do device ou navegador", Nullable = false)]
        public string DeviceId { get; set; }
        [SwaggerSchema("Versão do dispositivo ou navegador", Nullable = false)]
        public string VersaoDispositivo { get; set; }
        public void ValidarDto()
        {
            Validar(this, new LoginValidator());
        }
    }
}
