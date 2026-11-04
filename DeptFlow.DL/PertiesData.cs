using System.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using DeptFlow.DTOs.Parties.DTOs;
using DeptFlow.DTOs.Common;

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



        public static async Task<FindPartyByIDResponseDTO?> FindPartyByID(int? PartyID)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            using (var command = new SqlCommand("SP_FindPartyByID", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@PartyID", SqlDbType.Int).Value = PartyID;

                await connection.OpenAsync();
                using (var reader = await command.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        return new FindPartyByIDResponseDTO
                        (
                            reader.GetString(reader.GetOrdinal("Name")),
                            (enPartyTypeDTO.enPartyType)reader.GetInt32(reader.GetOrdinal("PartyType")),
                            reader.IsDBNull(reader.GetOrdinal("Email")) ? null : reader.GetString(reader.GetOrdinal("Email")),
                            reader.IsDBNull(reader.GetOrdinal("Phone")) ? null : reader.GetString(reader.GetOrdinal("Phone")),
                            reader.IsDBNull(reader.GetOrdinal("Notes")) ? null : reader.GetString(reader.GetOrdinal("Notes")),
                            reader.GetDateTime(reader.GetOrdinal("CreatedAt")),
                            reader.IsDBNull(reader.GetOrdinal("UpdatedAt")) ? null : reader.GetDateTime(reader.GetOrdinal("UpdatedAt")),
                            reader.GetInt32(reader.GetOrdinal("CreatedByUserID"))
                        );
                    }

                      return null;
                    
                }
            }
        }



        public static async Task<List<FindPartyByNameResponseDTO>> FindPartyByName(string? PartyName)
        {
            var PartiesList = new List<FindPartyByNameResponseDTO>();


            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            using (var command = new SqlCommand("SP_FindPartyByName", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@PartyName", SqlDbType.NVarChar, 200).Value = PartyName;

                await connection.OpenAsync();
                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        PartiesList.Add(new FindPartyByNameResponseDTO
                        (
                            reader.GetInt32(reader.GetOrdinal("PartyID")),
                            reader.GetString(reader.GetOrdinal("Name")),
                            (enPartyTypeDTO.enPartyType)reader.GetInt32(reader.GetOrdinal("PartyType")),
                            reader.IsDBNull(reader.GetOrdinal("Email")) ? null : reader.GetString(reader.GetOrdinal("Email")),
                            reader.IsDBNull(reader.GetOrdinal("Phone")) ? null : reader.GetString(reader.GetOrdinal("Phone")),
                            reader.IsDBNull(reader.GetOrdinal("Notes")) ? null : reader.GetString(reader.GetOrdinal("Notes")),
                            reader.GetDateTime(reader.GetOrdinal("CreatedAt")),
                            reader.IsDBNull(reader.GetOrdinal("UpdatedAt")) ? null : reader.GetDateTime(reader.GetOrdinal("UpdatedAt")),
                            reader.GetInt32(reader.GetOrdinal("CreatedByUserID"))
                        ));
                    }

                    return PartiesList;

                }
            }
        }



    }


}
