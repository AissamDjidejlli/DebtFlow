using DeptFlow.DL;
using DeptFlow.DTOs.Parties.DTOs;
using Microsoft.Extensions.Configuration;

namespace DeptFlow.BL
{
    public class Parties
    {
        public static void Initialize(IConfiguration configuration)
        {
            PertiesData.Initialize(configuration);
        }

        public static Task<int> AddParty(AddPartyDTO NewParty)
        {
            if(NewParty == null)
                throw new ArgumentNullException(nameof(NewParty), " NewParty cannot be null.");

            
            return  PertiesData.AddPartyAsync(NewParty);
        }


        public static Task<FindPartyByIDResponseDTO?> FindPartyByID(int? PartyID)
        {
            if (PartyID == null)
                throw new ArgumentNullException(nameof(PartyID));

            if (PartyID <= 0)
                throw new ArgumentOutOfRangeException(nameof(PartyID), "PartyID must be greater than zero.");

            return PertiesData.FindPartyByID(PartyID);
        }

        public static Task<List<FindPartyByNameResponseDTO>> FindPartyByName(string? PartyName)
        {
            if (PartyName == null || string.IsNullOrWhiteSpace(PartyName))
                throw new ArgumentNullException(nameof(PartyName));

            return PertiesData.FindPartyByName(PartyName);
        }
    }
}
