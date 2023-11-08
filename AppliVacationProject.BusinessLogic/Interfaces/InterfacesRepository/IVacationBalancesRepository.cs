using AppliVacationProject.DataAccess.Models;
namespace AppliVacationProject.BusinessLogic.Interfaces.InterfacesRepository
{
    public interface IVacationsBalanceRepository
    {
        Task<IEnumerable<VacationBalances>> GetAllVacationsBalanceAsync(CancellationToken cancellationToken);
        Task<VacationBalances> GetVacationsBalanceByIdAsync(int id, CancellationToken cancellationToken);
        Task<VacationBalances> CreateVacationsBalanceAsync(VacationBalances vacationsBalance, CancellationToken cancellationToken);
        Task<bool> UpdateVacationsBalanceAsync(int id, VacationBalances vacationsBalance, CancellationToken cancellationToken);
        Task<bool> DeleteVacationsBalanceAsync(int id, CancellationToken cancellationToken);
    }
}
