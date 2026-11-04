using DeptFlow.BL;
using DeptFlow.DTOs.Common;
using DeptFlow.DTOs.Parties.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace DeptFlow.API.Controllers
{

    [Route("api/Parties")]
    [ApiController]
    public class PartiesController : ControllerBase
    {
        [HttpPost("AddParty")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<FindPartyByIDResponseDTO>> AddParty(AddPartyDTO NewParty)
        {
            if (NewParty == null || string.IsNullOrWhiteSpace(NewParty.Name) || !Enum.IsDefined(typeof(enPartyTypeDTO.enPartyType), NewParty.PartyType))
            {
                return BadRequest("Invalid Party data.");
            }

            int PartyID = await Parties.AddParty(NewParty);

            return CreatedAtRoute("FindPartyByID", new { PartyID = NewParty.PartyID }, NewParty);

        }


        [HttpGet("ByID/{PartyID}", Name = "FindPartyByID")]

        [ProducesResponseType(typeof(FindPartyByIDResponseDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<FindPartyByIDResponseDTO>> FindPartyByID(int? PartyID)
        {

            if (PartyID == null || PartyID < 1)
            {
                return BadRequest($"Not accepted ID {PartyID}");
            }

            FindPartyByIDResponseDTO? Party = await Parties.FindPartyByID(PartyID);

            if (Party == null)
            {
                return NotFound($"Party with ID {PartyID} not found.");
            }

            return Ok(Party);

        }



        [HttpGet("ByName/{PartyName}")]

        [ProducesResponseType(typeof(FindPartyByNameResponseDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<FindPartyByNameResponseDTO>>> FindPartyByName (string? PartyName)
        {

            if (PartyName == null || string.IsNullOrWhiteSpace(PartyName))
            {
                return BadRequest($"Not accepted Name {PartyName}");
            }
            
            var PartiesList = new List<FindPartyByNameResponseDTO>();

            PartiesList = await Parties.FindPartyByName(PartyName);

            if (PartiesList.Count == 0)
            {
                return NotFound($"Party with Name {PartyName} not found.");
            }

            return Ok(PartiesList);

        }
    }
}
