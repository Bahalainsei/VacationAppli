using AppliVacationProject.DataAccess.Models;
namespace AppliVacationProject.BusinessLogic.Interfaces.InterfacesRepository
{
    public interface IUserRoleRepository
    {
        Task<IEnumerable<UserRole>> GetAllRolesAsync(CancellationToken cancellationToken);
        Task<UserRole> GetRolesByIdAsync(int id, CancellationToken cancellationToken);
        Task<UserRole> CreateUserRoleAsync(UserRole role, CancellationToken cancellationToken);
        Task<bool> UpdateRolesAsync(int id, UserRole role, CancellationToken cancellationToken);
        Task<bool> DeleteRolesAsync(int id, CancellationToken cancellationToken);
    }
}
