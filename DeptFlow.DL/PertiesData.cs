using System.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using DeptFlow.DTOs.Parties.DTOs;

namespace DeptFlow.DL
{
    
    public class PertiesData
    {
        private static  IConfiguration _configuration;

        public static void Initialize(IConfiguration configuration)
        {
            _configuration = configuration;
        }



        public static async Task<int> AddPartyAsync(AddPartyDTO NewParty)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            using (var command = new SqlCommand("SP_AddNewParty", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@Email", (object?)NewParty.Email ?? DBNull.Value);
                command.Parameters.AddWithValue("@Phone", (object?)NewParty.Phone ?? DBNull.Value);
                command.Parameters.AddWithValue("@Notes", (object?)NewParty.Notes ?? DBNull.Value);
                command.Parameters.AddWithValue("@PartyType", NewParty.PartyType);
                command.Parameters.AddWithValue("@Name", NewParty.Name);
                command.Parameters.AddWithValue("@CreatedByUserID", NewParty.CreatedByUserID);


                var outputIdParam = new SqlParameter("@PartyID", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };
                command.Parameters.Add(outputIdParam);

     

                await connection.OpenAsync();
                await command.ExecuteNonQueryAsync();

                return (int)outputIdParam.Value;
            }
        }

    }
}
