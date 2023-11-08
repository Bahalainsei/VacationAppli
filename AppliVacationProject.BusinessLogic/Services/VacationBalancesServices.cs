using AppliVacationProject.BusinessLogic.Interfaces.InterfaceService;
using AppliVacationProject.BusinessLogic.Interfaces.InterfacesRepository;
using AppliVacationProject.DataAccess.Models;
namespace AppliVacationProject.BusinessLogic.Services
{
    public class VacationsBalanceService : IVacationsBalanceService
    {
        private readonly IVacationsBalanceRepository _vacationsBalanceRepository;

        public VacationsBalanceService(IVacationsBalanceRepository vacationsBalanceRepository)
        {
            _vacationsBalanceRepository = vacationsBalanceRepository;
        }

        #region Recupère tous les vacationsBalance (solde de congé) de manière asynchrone
        public async Task<IEnumerable<VacationBalances>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _vacationsBalanceRepository.GetAllVacationsBalanceAsync(cancellationToken);
        }
        #endregion

        #region Récupère vacationsBalance (solde de congé) role par ID de manière asynchrone
        public async Task<VacationBalances> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            if (id == 0)
            {
                throw new ArgumentException(nameof(id));
            }
            return await _vacationsBalanceRepository.GetVacationsBalanceByIdAsync(id, cancellationToken);
        }
        #endregion

        #region Crée un nouveau vacations Balance (solde de congé) de manière asynchrone
        public async Task<VacationBalances> AddAsync(VacationBalances vacationsBalance, CancellationToken cancellationToken)
        {
            if (vacationsBalance == null)
            {
                throw new ArgumentException(nameof(vacationsBalance));
            }

            return await _vacationsBalanceRepository.CreateVacationsBalanceAsync(vacationsBalance, cancellationToken);
        }
        #endregion

        #region Met à jour un vacation Balance (solde de congé) de manière asynchrone
        public async Task<bool> UpdateAsync(int id, VacationBalances vacationsBalance, CancellationToken cancellationToken)
        {
            if (id == 0)
            {
                throw new ArgumentNullException(nameof(id));
            }

            if (vacationsBalance == null)
            {
                throw new ArgumentNullException(nameof(vacationsBalance));
            }

            var existingVacationBalance = await _vacationsBalanceRepository.GetVacationsBalanceByIdAsync(id, cancellationToken);

            if (existingVacationBalance == null)
            {
                return false;
            }

            existingVacationBalance.UsersId = vacationsBalance.UsersId;
            existingVacationBalance.UsersId = vacationsBalance.UsersId;
            existingVacationBalance.VacationType = vacationsBalance.VacationType;
            existingVacationBalance.CurrentBalance = vacationsBalance.CurrentBalance;

            return await _vacationsBalanceRepository.UpdateVacationsBalanceAsync(id, vacationsBalance, cancellationToken);
        }
        #endregion

        #region Supprime un vacation Balance (solde de congé) de manière asynchrone
        public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken)
        {
            if (id == 0)
            {
                throw new ArgumentNullException(nameof(id));
            }
            return await _vacationsBalanceRepository.DeleteVacationsBalanceAsync(id, cancellationToken);
        }
        #endregion
    }
}
