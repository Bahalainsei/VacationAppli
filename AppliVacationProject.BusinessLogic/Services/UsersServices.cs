using AppliVacationProject.BusinessLogic.Interfaces.InterfaceService;
using AppliVacationProject.BusinessLogic.Interfaces.InterfacesRepository;
using AppliVacationProject.DataAccess.Models;

namespace AppliVacationProject.BusinessLogic.Services
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository _usersRepository;

        public UsersService(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        //Recupère tous les utilisateurs de manière asynchrone
        public async Task<IEnumerable<Users>> GetAllUsersAsync(CancellationToken cancellationToken)
        {
            return await _usersRepository.GetAllUsersAsync(cancellationToken);
        }
        // Récupère un utilisateur par ID de manière asynchrone
        public async Task<Users> GetUsersByIdAsync(int id, CancellationToken cancellationToken)
        {
            if (id == 0)
            {
                throw new ArgumentException(nameof(id));
            }

            return await _usersRepository.GetUsersByIdAsync(id, cancellationToken);
        }
        // Crée un nouvel utilisateur de manière asynchrone
        public async Task<Users> CreateUsersAsync(Users user, CancellationToken cancellationToken)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            return await _usersRepository.CreateUsersAsync(user, cancellationToken);
        }
       

        // Met à jour un utilisateur de manière asynchrone
        public async Task<bool> UpdateUsersAsync(int id, Users user, CancellationToken cancellationToken)
        {
            if (id == 0)
            {
                throw new ArgumentNullException(nameof(id));
            }

            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            var existingUser = await _usersRepository.GetUsersByIdAsync(id, cancellationToken);

            if (existingUser == null)
            {
                return false;
            }

            existingUser.FirstName = user.FirstName;
            existingUser.LastName = user.LastName;
            existingUser.Email = user.Email;
            existingUser.Password = user.Password;
            existingUser.Gender = user.Gender;
            existingUser.PhoneNumber = user.PhoneNumber;
            existingUser.Address = user.Address;
            existingUser.Status = user.Status;
            existingUser.CreatedDate = user.CreatedDate;
            existingUser.UpdatedDate = user.UpdatedDate;
            existingUser.RoleId = user.RoleId;
            existingUser.Role = user.Role;
            existingUser.Vacations = user.Vacations;
            return await _usersRepository.UpdateUsersAsync(id, user, cancellationToken) ;
        }

        // Supprime un utilisateur de manière asynchrone
        public async Task<bool> DeleteUsersAsync(int id, CancellationToken cancellationToken)
        {
            if (id == 0)
            {
                throw new ArgumentNullException(nameof(id));
            }
            return await _usersRepository.DeleteUsersAsync(id, cancellationToken);
        }

        // Authentification
        public async Task<Users> GetUserByEmailAsync(string email, CancellationToken cancellationToken)
        {
            try
            {
                // Utilisez Entity Framework pour rechercher l'utilisateur par e-mail
                var users = await _usersRepository.GetAllUsersAsync(cancellationToken);
                var user = users.FirstOrDefault(u => u.Email.Equals(email, StringComparison.OrdinalIgnoreCase));

                return user;
            }
            catch (Exception ex)
            {
                // Gérez les erreurs ou lancez-les pour être gérées en amont
                throw new Exception($"Erreur lors de la recherche de l'utilisateur par e-mail : {ex.Message}");
            }
        }
    }
}
