
using AppliVacationProject.DataAccess.Models;

namespace AppliVacationProject.BusinessLogic.Interfaces.InterfaceService
{
    public interface IVacationsCalendarService
    {
        Task<IEnumerable<VacationCalendar>> GetAllVacationsCalendarAsync(CancellationToken cancellationToken);
        Task<VacationCalendar> GetVacationsCalendarByIdAsync(int id, CancellationToken cancellationToken);
        Task<VacationCalendar> CreateVacationsCalendarAsync(VacationCalendar vacationsCalendar, CancellationToken cancellationToken);
        Task<bool> UpdateVacationsCalendarAsync(int id, VacationCalendar vacationsCalendar, CancellationToken cancellationToken);
        Task<bool> DeleteVacationsCalendarAsync(int id, CancellationToken cancellationToken);
    }
}
