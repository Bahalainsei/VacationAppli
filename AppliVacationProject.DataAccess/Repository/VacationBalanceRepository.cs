using AppliVacationProject.BusinessLogic.Interfaces.InterfaceService;
using AppliVacationProject.BusinessLogic.Interfaces.InterfacesRepository;
using AppliVacationProject.DataAccess.Data;
using AppliVacationProject.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace AppliVacationProject.BusinessLogic.Services
{
    public class VacationBalanceRepository : IVacationsBalanceRepository
    {
        private readonly AppliVacationDbContext _databaseContext;

        public VacationBalanceRepository(AppliVacationDbContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        #region Recupère tous les vacations balances (solde de congé) de manière asynchrone en incluant le nom des utilisateur pour chaque solde de congé
        public async Task<IEnumerable<VacationBalances>> GetAllVacationsBalanceAsync(CancellationToken cancellationToken)
        {
            //return await _databaseContext.Roles.ToListAsync();
            return await _databaseContext.VacationBalances.Include(u => u.Users).ToListAsync();
        }
        #endregion

        #region Recupere un vacation balance (sold de congé) en fonction de son ID
       public async Task<VacationBalances> GetVacationsBalanceByIdAsync(int id, CancellationToken cancellationToken)
        {
            // Récupère un rôle en fonction de son ID
            return await _databaseContext.VacationBalances.FindAsync(id);
        }
        #endregion

        #region Ajoute un nouveau vacation balance (solde de congé) de manière asynchrone
        public async Task<VacationBalances> CreateVacationsBalanceAsync(VacationBalances vacationsBalance, CancellationToken cancellationToken)
        {
            // Ajoute un rôle à la base de données
            _databaseContext.VacationBalances.Add(vacationsBalance);
            // Enregistre les modifications dans la base de données
            await _databaseContext.SaveChangesAsync();
            // Renvoie le rôle
            return vacationsBalance;
        }
        #endregion

        #region Met à jour un vacation balance (solde de congé) existant de manière asynchrone
        public async Task<bool> UpdateVacationsBalanceAsync(int id, VacationBalances vacationsBalance, CancellationToken cancellationToken)
        {
            // Modifie l'état de l'entité pour indiquer qu'elle est modifiée
            _databaseContext.Entry(vacationsBalance).State = EntityState.Modified;

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
        #endregion

        #region Supprime un vacation balance (solde de congé) par ID de manière asynchrone
        public async Task<bool> DeleteVacationsBalanceAsync(int id, CancellationToken cancellationToken)
        {
            // Recherche le rôle en fonction de son ID
            var vacationBalanceToDelete = await _databaseContext.VacationBalances.FindAsync(id);

            if (vacationBalanceToDelete != null)
            {
                // Supprime le rôle de la base de données
                _databaseContext.VacationBalances.Remove(vacationBalanceToDelete);
                // Enregistre les modifications dans la base de données
                await _databaseContext.SaveChangesAsync();
                // Renvoie un booléen indiquant le succès de la suppression
                return true;
            }
            else
            {
                // Renvoie false si le rôle n'est pas trouvé
                return false;
            }
        }
        #endregion
    }
}
