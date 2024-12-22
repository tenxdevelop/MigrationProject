using MigrantProjectMVC.Commands;
using MigrantProjectMVC.Interfaces;
using MigrantProjectMVC.Models;

namespace MigrantProjectMVC.CommandHandlers
{
    public class RegisterUserCommandHandler : ICommandHandler<RegisterUserCommand, bool>
    {
        private IMigrantRepository _migrantRepository;
        private IUserRepository _userRepository;
        public RegisterUserCommandHandler(IUserRepository userRepository, IMigrantRepository migrantRepository)
        {
            _userRepository = userRepository;
            _migrantRepository = migrantRepository;
        }

        public async Task<bool> Handle(RegisterUserCommand requist)
        {
            var role = RoleModel.GetDefaultRole();
            UserModel user;
            if (requist.IsMigrant)
            {
                role = new RoleModel() { Name = "Migrant" };
                var migrant = new MigrantModel()
                {
                    Id = Guid.NewGuid(),
                    Name = requist.Name,
                    Surname = requist.Surname,
                    Patronymic = requist.Patronymic,
                    Email = requist.Email,
                    Phone = requist.Phone,
                    PasswordHash = requist.Password,
                    Role = role,
                };
                await _migrantRepository.AddMigrant(migrant);
                user = migrant;
            }
            else
            {
                user = new UserModel()
                {
                    Id = Guid.NewGuid(),
                    Name = requist.Name,
                    Surname = requist.Surname,
                    Patronymic = requist.Patronymic,
                    Email = requist.Email,
                    Phone = requist.Phone,
                    PasswordHash = requist.Password,
                    Role = role
                };
            }

            await _userRepository.Add(user);
            
            return true;
            

        }
    }
}
