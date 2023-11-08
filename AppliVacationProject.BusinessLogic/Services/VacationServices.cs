using AppliVacationProject.BusinessLogic.Interfaces.InterfaceService;
using AppliVacationProject.BusinessLogic.Interfaces.InterfacesRepository;
using AppliVacationProject.DataAccess.Models;

namespace AppliVacationProject.BusinessLogic.Services
{
    public class VacationsService : IVacationServices
    {
        private readonly IVacationRepository _vacationsRepository;

        public VacationsService(IVacationRepository vacationsRepository)
        {
            _vacationsRepository = vacationsRepository;
        }

        #region Recupère toute les congés (Vacations) de manière asynchrone
        public async Task<IEnumerable<Vacation>> GetAllVacationsAsync(CancellationToken cancellationToken)
        {
            return await _vacationsRepository.GetAllAsync(cancellationToken);
        }
        #endregion

        // Recupère un congé (Vacations) par son Id de manière asynchrone
        public async Task<Vacation> GetVacationsByIdAsync(int id, CancellationToken cancellationToken)
        {
            if (id == 0)
            {
                throw new ArgumentException(nameof(id));
            }

            return await _vacationsRepository.GetByIdAsync(id, cancellationToken);
        }
        

        // Création de nouveau congé (Vacations) de manière asynchrone
        public async Task<Vacation> CreateVacationsAsync(Vacation vacations, CancellationToken cancellationToken)
        {
            if (vacations == null)
            {
                throw new ArgumentNullException(nameof(vacations));
            }

            return await _vacationsRepository.AddAsync(vacations, cancellationToken);
        }
        

        // Met à jour un congé (Vacations) par son Id
        public async Task<bool> UpdateVacationsAsync(int id, Vacation vacations, CancellationToken cancellationToken)
        {
            if (id == 0)
            {
                throw new ArgumentException(nameof(id));
            }

            if (vacations == null)
            {
                throw new ArgumentNullException(nameof(vacations));
            }

            var existingVacations = await _vacationsRepository.GetByIdAsync(id, cancellationToken);

            if (existingVacations == null)
            {
                return false;
            }
            existingVacations.ApprobationDate = DateTime.Now;

            return await _vacationsRepository.UpdateAsync(existingVacations, cancellationToken);
        }
       

        //Supprime un congé (Vacations) de manière asynchrone
        public async Task<bool> DeleteVacationsAsync(int id, CancellationToken cancellationToken)
        {
            if (id == 0)
            {
                throw new ArgumentNullException(nameof(id));
            }

            return await _vacationsRepository.DeleteAsync(id, cancellationToken);
        }
    }
}

