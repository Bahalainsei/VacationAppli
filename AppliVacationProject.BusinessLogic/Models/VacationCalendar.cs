
namespace AppliVacationProject.DataAccess.Models
{
    public class VacationCalendar
    {
        public int VacationCalendarId { get; set; }
        public int VacationId { get; set; }
        public int UsersId { get; set; }
        public string Status { get; set; }
        public string Type { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Users Users { get; set; }
    }
}
