

namespace AppliVacationProject.BusinessLogic.DTO
{
    public class VacationDTO
    {
        public int UsersID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string VacationType { get; set; }
        public string Justification { get; set; }
        public string VacationStatus { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ApprobationDate { get; set; }
        public int? ApprovedBy { get; set; }
        public string Comments { get; set; }
    }
}
