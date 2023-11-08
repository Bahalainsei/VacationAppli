

using AppliVacationProject.DataAccess.Models;

namespace AppliVacationProject.BusinessLogic.Interfaces.InterfaceService
{
    public interface IVacationsBalanceService
    {
        Task<IEnumerable<VacationBalances>> GetAllAsync(CancellationToken cancellationToken);
        Task<VacationBalances> GetByIdAsync(int id, CancellationToken cancellationToken);
        Task<VacationBalances> AddAsync(VacationBalances vacationsBalance, CancellationToken cancellationToken);
        Task<bool> UpdateAsync(int id, VacationBalances vacationsBalance, CancellationToken cancellationToken);
        Task<bool> DeleteAsync(int id, CancellationToken cancellationToken);
    }
}
