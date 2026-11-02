
namespace DeptFlow.DTOs.Parties.DTOs
{
    public class AddPartyDTO
    {

        public enum enPartyType{ Person = 1, Company = 2}
        public AddPartyDTO(string? Email, string? Phone, string? Notes, int PartyType, string Name, int CreatedByUserID)
        {
            this.Email = Email;
            this.Phone = Phone;
            this.Notes = Notes;
            this.PartyType = (enPartyType)PartyType;
            this.Name = Name;
            this.CreatedByUserID = CreatedByUserID;
        }


        public string? Email { get; set; }

        public string? Phone { get; set; }

        public string? Notes { get; set; }

        public enPartyType PartyType { get; set; }

        public string Name { get; set; }
        public int CreatedByUserID { get; set; }
    }


}

