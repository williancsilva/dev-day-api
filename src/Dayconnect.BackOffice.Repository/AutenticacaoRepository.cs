using System.Data;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;
using DevSecOps.backoffice.Domain.Interfaces.Repository;
using DevSecOps.backoffice.Domain.Models;
using DevSecOps.backoffice.Repository.Mappers;
using DevSecOps.BackOffice.Domain.Interfaces.Repository;

namespace DevSecOps.backoffice.Repository;

public class AutenticacaoRepository : IAutenticacaoRepository
{
    readonly string connString = "Server=(localdb)\\MSSQLLocalDB;Database=DCV_DEVDAY;Integrated Security=SSPI;";

    public async Task<IEnumerable<Cliente>> ObterDadosCliente(string cpfCnpj)
    {
        using (SqlConnection con = new SqlConnection(connString))
        {
            using (SqlCommand cmd = new SqlCommand("P_OBTER_CLIENTE", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@documento", SqlDbType.VarChar, 11).Value = cpfCnpj;

                await con.OpenAsync();
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    var listaCliente = new List<Cliente>();
                    while (await reader.ReadAsync())
                    {
                        listaCliente.Add(ClienteMapper.Convert(reader));
                    }
                    return listaCliente;
                }
            }
        }
    }

    public async Task<string> CriarSessao(string email)
    {
        using (SqlConnection con = new SqlConnection(connString))
        {
            using (SqlCommand cmd = new SqlCommand("P_INCLUIR_SESSAO", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@login", SqlDbType.VarChar).Value = email;

                await con.OpenAsync();
                var reader = await cmd.ExecuteReaderAsync();

                return reader.GetString(reader.GetOrdinal("DayId"));
;
            }
        }
    }

    public async Task ExcluirCliente(string cpfCnpj)
    {
        using (SqlConnection con = new SqlConnection(connString))
        {
            using (SqlCommand cmd = new SqlCommand("P_EXCLUIR_CLIENTE", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@documento", SqlDbType.VarChar, 11).Value = cpfCnpj;

                await con.OpenAsync();
                await cmd.ExecuteNonQueryAsync();
            }
        }
    }
}