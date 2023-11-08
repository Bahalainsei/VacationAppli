using AppliVacationProject.DataAccess.Models;
namespace AppliVacationProject.BusinessLogic.Interfaces.InterfacesRepository
{
    public interface IVacationRepository
    {
        Task<IEnumerable<Vacation>> GetAllAsync(CancellationToken cancellationToken);
        Task<Vacation> GetByIdAsync(int vacations, CancellationToken cancellationToken);
        Task<Vacation> AddAsync(Vacation vacations, CancellationToken cancellationToken);
        Task<bool> UpdateAsync(Vacation vacations, CancellationToken cancellationToken);
        Task<bool> DeleteAsync(int id, CancellationToken cancellationToken);
    }
}
