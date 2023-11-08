

using AppliVacationProject.DataAccess.Models;

namespace AppliVacationProject.BusinessLogic.Interfaces.InterfaceService
{
    public interface IVacationServices
    {
        Task<IEnumerable<Vacation>> GetAllVacationsAsync(CancellationToken cancellationToken);
        Task<Vacation> GetVacationsByIdAsync(int id, CancellationToken cancellationToken);
        Task<Vacation> CreateVacationsAsync(Vacation vacation, CancellationToken cancellationToken);
        Task<bool> UpdateVacationsAsync(int id, Vacation vacations, CancellationToken cancellationToken);
        Task<bool> DeleteVacationsAsync(int id, CancellationToken cancellationToken);
    }
}
