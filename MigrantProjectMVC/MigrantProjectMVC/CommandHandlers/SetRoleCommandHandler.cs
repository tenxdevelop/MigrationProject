using MigrantProjectMVC.Commands;
using MigrantProjectMVC.Interfaces;
using MigrantProjectMVC.Models;

namespace MigrantProjectMVC.CommandHandlers
{
    public class SetRoleCommandHandler : ICommandHandler<SetRoleCommand, bool>
    {
        private IUserRepository _userRepository;
        private IMigrantRepository _migrantRepository;

        public SetRoleCommandHandler(IUserRepository userRepository, IMigrantRepository migrantRepository)
        {
            _userRepository = userRepository;
            _migrantRepository = migrantRepository;
        }

        public async Task<bool> Handle(SetRoleCommand requist)
        {
            var user = _userRepository.GetAllUsers().Result.FirstOrDefault(x => x.Id == requist.Id);
            if (user == null) 
            {
                return false;
            }
            if (requist.Role.Name.Equals("Migrant") && !user.Role.Name.Equals("Migrant"))
            {
                var migrant = new MigrantModel()
                {
                    Id = requist.Id,
                    Name = user.Name,
                    Surname = user.Surname,
                    PasswordHash = user.PasswordHash,
                    Patronymic = user.Patronymic,
                    Email = user.Email,
                    Phone = user.Phone,
                    Role = requist.Role
                };
                _migrantRepository.AddMigrant(migrant);

            }
            else if (user.Role.Name.Equals("Migrant") && !requist.Role.Name.Equals("Migrant"))
            {
                _migrantRepository.DeleteMigrant(user.Id);
            }

            user.Role = requist.Role;
            await _userRepository.SaveContext();
            return true;
        }
    }
}
