

using AppliVacationProject.DataAccess.Models;

namespace AppliVacationProject.BusinessLogic.Interfaces.InterfaceService
{
    public interface IUsersService
    {
        Task<IEnumerable<Users>> GetAllUsersAsync(CancellationToken cancellationToken);
        Task<Users> GetUsersByIdAsync(int id, CancellationToken cancellationToken);
        Task<Users> CreateUsersAsync(Users user, CancellationToken cancellationToken);
        Task<bool> UpdateUsersAsync(int id, Users user, CancellationToken cancellationToken);
        Task<bool> DeleteUsersAsync(int id, CancellationToken cancellationToken);
        Task<Users> GetUserByEmailAsync(string email, CancellationToken cancellationToken);
    }
}
