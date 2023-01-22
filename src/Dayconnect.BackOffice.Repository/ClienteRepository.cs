using System.Data;
using System.Data.SqlClient;
using DevSecOps.backoffice.Domain.Interfaces.Repository;
using DevSecOps.backoffice.Domain.Models;
using DevSecOps.backoffice.Repository.Mappers;

namespace DevSecOps.backoffice.Repository;

public class ClienteRepository : IClienteRepository
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

    public async Task InativarCliente(string cpfCnpj)
    {
        using (SqlConnection con = new SqlConnection(connString))
        {
            using (SqlCommand cmd = new SqlCommand("P_INATIVAR_CLIENTE", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@documento", SqlDbType.VarChar, 11).Value = cpfCnpj;

                await con.OpenAsync();
                await cmd.ExecuteNonQueryAsync();
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