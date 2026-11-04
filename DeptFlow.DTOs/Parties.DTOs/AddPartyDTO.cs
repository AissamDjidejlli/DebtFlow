using DeptFlow.DTOs.Common;

namespace DeptFlow.DTOs.Parties.DTOs
{
    public class AddPartyDTO
    {

       
        public AddPartyDTO(string? Email, string? Phone, string? Notes, enPartyTypeDTO.enPartyType PartyType, string Name, int CreatedByUserID)
        {
            this.Email = Email;
            this.Phone = Phone;
            this.Notes = Notes;
            this.PartyType = PartyType;
            this.Name = Name;
            this.CreatedByUserID = CreatedByUserID;
        }

        public int PartyID { get; set; }    
        public string? Email { get; set; }

        public string? Phone { get; set; }

        public string? Notes { get; set; }

        public enPartyTypeDTO.enPartyType PartyType { get; set; }

        public string Name { get; set; }
        public int CreatedByUserID { get; set; }
    }


}

