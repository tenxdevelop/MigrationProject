using MigrantProjectMVC.Commands;
using MigrantProjectMVC.Interfaces;
using MigrantProjectMVC.Models;

namespace MigrantProjectMVC.CommandHandlers
{
    public class CreateUserStatementCommandHandler : ICommandHandler<CreateUserStatementCommand, bool>
    {
        IUserRepository _userRepository;
        public CreateUserStatementCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> Handle(CreateUserStatementCommand requist)
        {
            var user = new UserModel()
            {
                Id = Guid.NewGuid(),
                Name = requist.Name,
                Surname = requist.Surname,
                Patronymic = requist.Patronymic,
                Email = requist.Email,
                PasswordHash = requist.Password,
                Role = RoleModel.GetDefaultRole()
            };
            await _userRepository.Add(user);
            await _userRepository.SaveContext();
            return true;
        }
    }
}
