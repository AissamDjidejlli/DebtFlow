using DeptFlow.DL;
using DeptFlow.DTOs.Parties.DTOs;
using Microsoft.Extensions.Configuration;

namespace DeptFlow.BL
{
    public class Perties
    {
        public static void Initialize(IConfiguration configuration)
        {
            PertiesData.Initialize(configuration);
        }
        public static async Task<int> AddPartyAsync(AddPartyDTO NewParty)
        {
            if(NewParty == null)
                throw new ArgumentNullException(nameof(NewParty), " NewParty cannot be null.");

            
            return await PertiesData.AddPartyAsync(NewParty);
        }

    }
}
