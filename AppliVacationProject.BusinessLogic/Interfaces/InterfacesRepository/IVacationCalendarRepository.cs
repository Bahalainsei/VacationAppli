using AppliVacationProject.DataAccess.Models;
namespace AppliVacationProject.BusinessLogic.Interfaces.InterfacesRepository
{
    public interface IVacationCalendarRepository
    {
            Task<IEnumerable<VacationCalendar>> GetAllAsync(CancellationToken cancellationToken);
            Task<VacationCalendar> GetByIdAsync(int id, CancellationToken cancellationToken);
            Task<VacationCalendar> AddAsync(VacationCalendar vacationsCalendar, CancellationToken cancellationToken);
            Task<bool> UpdateAsync(int id, VacationCalendar vacationsCalendar, CancellationToken cancellationToken);
            Task<bool> DeleteAsync(int id, CancellationToken cancellationToken); 
    }
}
