using DeptFlow.DTOs.Common;

namespace DeptFlow.DTOs.Parties.DTOs
{
    public  class FindPartyByIDResponseDTO
    {
        public FindPartyByIDResponseDTO(string Name, enPartyTypeDTO.enPartyType PartyType, string? Email, string? Phone, string? Notes,
             DateTime CreatedAt , DateTime? UpdatedAt, int CreatedByUserID)
        {
            this.Email = Email;
            this.Phone = Phone;
            this.Notes = Notes;
            this.PartyType = PartyType;
            this.Name = Name;
            this.CreatedAt = CreatedAt;
            this.UpdatedAt = UpdatedAt;
            this.CreatedByUserID = CreatedByUserID;
        }

        public string Name { get; set; }

        public enPartyTypeDTO.enPartyType PartyType { get; set; }  

        public string? Email { get; set; }

        public string? Phone { get; set; }

        public string? Notes { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public int CreatedByUserID { get; set; }
    }


    public class FindPartyByNameResponseDTO
    {
        public FindPartyByNameResponseDTO(int PartyID,string Name, enPartyTypeDTO.enPartyType PartyType, string? Email, string? Phone, string? Notes,
             DateTime CreatedAt, DateTime? UpdatedAt, int CreatedByUserID)
        {
            this.PartyID = PartyID;
            this.Email = Email;
            this.Phone = Phone;
            this.Notes = Notes;
            this.PartyType = (enPartyTypeDTO.enPartyType)PartyType;
            this.Name = Name;
            this.CreatedAt = CreatedAt;
            this.UpdatedAt = UpdatedAt;
            this.CreatedByUserID = CreatedByUserID;
        }
        
        public int PartyID { get; set; }
        public string Name { get; set; }

        public enPartyTypeDTO.enPartyType PartyType { get; set; }

        public string? Email { get; set; }

        public string? Phone { get; set; }

        public string? Notes { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public int CreatedByUserID { get; set; }
    }
}
