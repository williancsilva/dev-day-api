using System.Data;
using System.Data.SqlClient;
using DevSecOps.backoffice.Domain.Models.Result;
using DevSecOps.backoffice.Repository.Mappers;
using DevSecOps.BackOffice.Domain.Interfaces.Repository;

namespace DevSecOps.backoffice.Repository;

public class AutenticacaoRepository : IAutenticacaoRepository
{
    readonly string connString = "Server=(localdb)\\MSSQLLocalDB;Database=DCV_DEVDAY;Integrated Security=SSPI;";

    public async Task<SessaoResult> ObterSessao(int dayId)
    {
        using (SqlConnection con = new SqlConnection(connString))
        {
            using (SqlCommand cmd = new SqlCommand("P_OBTER_SESSAO", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@DayId", SqlDbType.Int).Value = dayId;

                await con.OpenAsync();
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    var listaCliente = new List<SessaoResult>();
                    while (await reader.ReadAsync())
                    {
                        listaCliente.Add(SessaoMapper.Convert(reader));
                    }
                    return listaCliente?.FirstOrDefault() ?? new SessaoResult();
                }
            }
        }
    }

    public async Task<int> CriarSessao(string email)
    {
        using (SqlConnection con = new SqlConnection(connString))
        {
            using (SqlCommand cmd = new SqlCommand("P_INCLUIR_SESSAO", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@login", SqlDbType.VarChar).Value = email;

                await con.OpenAsync();

                var dayId = await cmd.ExecuteScalarAsync();
                return dayId != null ? (int)dayId : 0;
            }
        }
    }

    public async Task AtualizarSessao(int dayId, bool isAuthenticated )
    {
        using (SqlConnection con = new SqlConnection(connString))
        {
            using (SqlCommand cmd = new SqlCommand("P_ATUALIZAR_SESSAO", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@DayId", SqlDbType.Int).Value = dayId;
                cmd.Parameters.Add("@isAuthenticated", SqlDbType.VarChar).Value = isAuthenticated;

                await con.OpenAsync();
                await cmd.ExecuteNonQueryAsync();
            }
        }
    }

   
}