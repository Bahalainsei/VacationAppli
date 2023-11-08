using AppliVacationProject.DataAccess.Models;
namespace AppliVacationProject.BusinessLogic.Interfaces.InterfacesRepository
{
    public interface IUsersRepository
    {
        Task<IEnumerable<Users>> GetAllUsersAsync(CancellationToken cancellationToken);
        Task<Users> GetUsersByIdAsync(int id, CancellationToken cancellationToken);
        Task<Users> CreateUsersAsync(Users user, CancellationToken cancellationToken);
        Task<bool> UpdateUsersAsync(int id, Users user, CancellationToken cancellationToken);
        Task<bool> DeleteUsersAsync(int id, CancellationToken cancellationToken);
    }
}
