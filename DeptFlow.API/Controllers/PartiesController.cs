using DeptFlow.DTOs.Parties.DTOs;
using Microsoft.AspNetCore.Mvc;
using DeptFlow.BL;

namespace DeptFlow.API.Controllers
{

    [Route("api/Parties")]
    [ApiController]
    public class PartiesController : ControllerBase
    {
        [HttpPost("AddParty")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<AddPartyDTO>> AddParty(AddPartyDTO NewParty)
        {
            if (NewParty == null || string.IsNullOrWhiteSpace(NewParty.Name) || !Enum.IsDefined(typeof(AddPartyDTO.enPartyType), NewParty.PartyType))
            {
                return BadRequest("Invalid Party data.");
            }

            int NewPartyID = await Perties.AddPartyAsync(NewParty);

            return Created();

        }
    }
}
