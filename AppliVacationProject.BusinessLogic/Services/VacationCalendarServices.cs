using AppliVacationProject.BusinessLogic.Interfaces.InterfaceService;
using AppliVacationProject.DataAccess.Models;

namespace AppliVacationProject.BusinessLogic.Services
{
    public class VacationsCalendarService : IVacationsCalendarService
    {
        private readonly IVacationsCalendarService _vacationsCalendarRepository;

        public VacationsCalendarService(IVacationsCalendarService vacationsCalendarRepository)
        {
            _vacationsCalendarRepository = vacationsCalendarRepository;
        }

        #region Recupère toute les calendrier congés (Vacations calendar) de manière asynchrone
        public async Task<IEnumerable<VacationCalendar>> GetAllVacationsCalendarAsync(CancellationToken cancellationToken)
        {
            return await _vacationsCalendarRepository.GetAllVacationsCalendarAsync(cancellationToken);
        }
        #endregion

        #region Recupère un calendrier de congé (Vacations calendar) par son Id de manière asynchrone
        public async Task<VacationCalendar> GetVacationsCalendarByIdAsync(int id, CancellationToken cancellationToken)
        {
            if (id == 0)
            {
                throw new ArgumentException(nameof(id));
            }

            return await _vacationsCalendarRepository.GetVacationsCalendarByIdAsync(id, cancellationToken);
        }
        #endregion

        #region Création de nouveau calendrier congé (Vacations) de manière asynchrone
        public async Task<VacationCalendar> CreateVacationsCalendarAsync(VacationCalendar vacationsCalendar, CancellationToken cancellationToken)
        {
            if (vacationsCalendar == null)
            {
                throw new ArgumentNullException(nameof(vacationsCalendar));
            }

            return await _vacationsCalendarRepository.CreateVacationsCalendarAsync(vacationsCalendar, cancellationToken);
        }
        #endregion

        #region Met à jour un calendrier congé (Vacations calendrier) par son Id
        public async Task<bool> UpdateVacationsCalendarAsync(int id, VacationCalendar vacationsCalendar, CancellationToken cancellationToken)
        {
            if (id == 0)
            {
                throw new ArgumentException(nameof(id));
            }

            if (vacationsCalendar == null)
            {
                throw new ArgumentNullException(nameof(vacationsCalendar));
            }

            var existingVacationsCalendar = await _vacationsCalendarRepository.GetVacationsCalendarByIdAsync(id, cancellationToken);

            if (existingVacationsCalendar == null)
            {
                return false;
            }
            existingVacationsCalendar.StartDate = DateTime.UtcNow;

            return await _vacationsCalendarRepository.UpdateVacationsCalendarAsync(id, vacationsCalendar, cancellationToken);
        }
        #endregion

        #region Supprime un congé (Vacations) de manière asynchrone
        public async Task<bool> DeleteVacationsCalendarAsync(int id, CancellationToken cancellationToken)
        {
            if (id == 0)
            {
                throw new ArgumentNullException(nameof(id));
            }

            return await _vacationsCalendarRepository.DeleteVacationsCalendarAsync(id, cancellationToken);
        }
        #endregion
    }
}
