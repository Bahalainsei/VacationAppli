using AppliVacationProject.BusinessLogic.Interfaces.InterfaceService;
using AppliVacationProject.BusinessLogic.Interfaces.InterfacesRepository;
using AppliVacationProject.DataAccess.Models;
using System.Threading;

namespace AppliVacationProject.BusinessLogic.Services
{
    public class UserRoleService: IUserRoleService
    {
        private readonly IUserRoleRepository _userRoleRepository;

        public UserRoleService(IUserRoleRepository userRoleRepository)
        {
            _userRoleRepository = userRoleRepository;
        }

        public async Task<UserRole> CreateUserRoleAsync(UserRole userRole, CancellationToken cancellationToken)
        {
            return await _userRoleRepository.CreateUserRoleAsync(userRole, cancellationToken);
        }

        public async Task<UserRole> GetRolesByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _userRoleRepository.GetRolesByIdAsync(id, cancellationToken);
        }

        public async Task<IEnumerable<UserRole>> GetAllRolesAsync(CancellationToken cancellationToken)
        {
            return await _userRoleRepository.GetAllRolesAsync(cancellationToken);
        }

        public async Task<bool> UpdateRolesAsync(int id, UserRole role, CancellationToken cancellationToken)
        {
            return await _userRoleRepository.UpdateRolesAsync(id, role, cancellationToken);
        }

       
            public async Task<bool> DeleteRolesAsync(int id, CancellationToken cancellationToken)
            {
                if (id == 0)
                {
                    throw new ArgumentNullException(nameof(id));
                }

                return await _userRoleRepository.DeleteRolesAsync(id, cancellationToken);
            }

        //public async Task<bool> IsUserRoleExistAsync(string roleName, CancellationToken cancellationToken)
       // {
            //return await _userRoleRepository.IsUserRoleExistAsync(roleName, cancellationToken);
       // }
    }
}
