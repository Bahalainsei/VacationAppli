using AppliVacationProject.BusinessLogic.Interfaces.InterfacesRepository;
using AppliVacationProject.DataAccess.Data;
using AppliVacationProject.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace AppliVacationProject.BusinessLogic.Services
{
    public class VacationCalendarRepository : IVacationCalendarRepository
    {
        private readonly AppliVacationDbContext _databaseContext;

        public VacationCalendarRepository(AppliVacationDbContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        //region Recupère tous les vacations Calendar de manière asynchrone incluant l'utilisateur qui a demandé un calendrier congé
        public async Task<IEnumerable<VacationCalendar>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _databaseContext.VacationCalendars.ToListAsync();
            /*return await _databaseContext.Vacations.Include(u => u.Users).ToListAsync();*/
        }
        

        //region Récupère un calendrier de congé (Vacation Calendar) par ID de manière asynchrone
        public async Task<VacationCalendar> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _databaseContext.VacationCalendars.FindAsync(id);
        }
     

        // region Ajoute un calendrier de congé (Vacation Calendar) de manière asynchrone
        public async Task<VacationCalendar> AddAsync(VacationCalendar vacationCalendar, CancellationToken cancellationToken)
        {
            _databaseContext.VacationCalendars.Add(vacationCalendar);
            await _databaseContext.SaveChangesAsync();
            return vacationCalendar;
        }


        // Met à jour un calendrier de congé existant de manière asynchrone
       public async Task<bool> UpdateAsync(int id, VacationCalendar vacationCalendar, CancellationToken cancellationToken)
        {
            // Modifie l'état de l'entité pour indiquer qu'elle est modifiée
            _databaseContext.Entry(vacationCalendar).State = EntityState.Modified;

            try
            {
                // Enregistre les modifications dans la base de données
                await _databaseContext.SaveChangesAsync();
                // Renvoie un booléen indiquant le succès de la mise à jour
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                // Gestion des conflits de concurrence si nécessaire
                return false;
            }
        }
    
        //Supprime un calendrier de conge (Vacation Calendar) par ID de manière asynchrone
        public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken)
        {
            // Recherche l'utilisateur en fonction de son ID
            var vacationsCalendarToDelete = await _databaseContext.VacationCalendars.FindAsync(id);

            if (vacationsCalendarToDelete != null)
            {
                // Supprime l'utilisateur de la base de données
                _databaseContext.VacationCalendars.Remove(vacationsCalendarToDelete);
                // Enregistre les modifications dans la base de données
                await _databaseContext.SaveChangesAsync();
                // Renvoie un booléen indiquant le succès de la suppression
                return true;
            }
            else
            {
                // Renvoie false si l'utilisateur n'est pas trouvé
                return false;
            }
        }
    }
}

