using Dayconnect.Fidelity.Domain.Interfaces.Repository;
using Dayconnect.Fidelity.Domain.Models;
using Dayconnect.Fidelity.Repository.Base;
using DayFw.DataAccess;
using DayFw.DataAccess.Extension.Ado;
using System.Data;
using System.Data.SqlClient;

namespace Dayconnect.Fidelity.Repository
{
    public class LogRepository : DcvDayconnect, ILogRepository
    {
        public async Task InserirLog(LogDominio signature)
        {
            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@ip", SqlDbType.VarChar, 16){Value = signature.Ip},
                new SqlParameter("@login", SqlDbType.VarChar, 150){Value = signature.LoginOperador},
                new SqlParameter("@url", SqlDbType.VarChar, 150){Value = signature.Url},
                new SqlParameter("@dataRegistro", SqlDbType.DateTime){Value = signature.DataRegistro},
                new SqlParameter("@documento", SqlDbType.VarChar, 14){Value = signature.CpfCnpjCliente},
                new SqlParameter("@metodo", SqlDbType.VarChar,80){Value = signature.Metodo}
            };

            var execute = new CreateExecuteAdo().WithParameters(parametros).WithProcedure("fidelity.P_INCLUIR_LOG");

            await ExecuteNonQueryAsync(execute);
        }
    }
}
