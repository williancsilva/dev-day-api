using System.ComponentModel;

namespace Dayconnect.Fidelity.Enum
{
    public enum AcoesEnum
    {
        [Description("Consultar lista de clientes a serem bloqueados")]
        ConsultarClientes,

        [Description("Bloquear clientes com suspeita de fraude")]
        BloquearClientes,
    }
}
