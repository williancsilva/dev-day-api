using DevSecOps.backoffice.Domain.Interfaces.Repository;
using DevSecOps.backoffice.Domain.Models;
using System.Data;
using System.Data.SqlClient;

namespace DevSecOps.backoffice.Repository;

public class LogRepository : ILogRepository
{
    readonly string connString = "Server=(localdb)\\MSSQLLocalDB;Database=DCV_DEVDAY;Integrated Security=SSPI;";

    public async Task InserirLog(LogDominio signature)
    {
        using (SqlConnection con = new SqlConnection(connString))
        {
            using (SqlCommand cmd = new SqlCommand("backoffice.P_INCLUIR_LOG", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.Add("@ip", SqlDbType.VarChar, 16).Value = signature.Ip;
                cmd.Parameters.Add("@login", SqlDbType.VarChar, 150).Value = signature.LoginOperador;
                cmd.Parameters.Add("@url", SqlDbType.VarChar, 150).Value = signature.Url;
                cmd.Parameters.Add("@dataRegistro", SqlDbType.DateTime).Value = signature.DataRegistro;
                cmd.Parameters.Add("@documento", SqlDbType.VarChar, 14).Value = signature.cpfCnpjCliente;
                cmd.Parameters.Add("@metodo", SqlDbType.VarChar, 80).Value = signature.Metodo;

                await con.OpenAsync();
                await cmd.ExecuteNonQueryAsync();
            }
        }
    }
}