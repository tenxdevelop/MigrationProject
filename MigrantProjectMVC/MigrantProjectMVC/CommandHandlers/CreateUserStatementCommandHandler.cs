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
                Name = requist.Name,
                Surname = requist.Surname,
                Patronymic = requist.Patronymic,
                Email = requist.Email,
                Password = requist.Password,
            };
            await _userRepository.Add(user);
            Console.WriteLine("Completed");
            return true;
        }
    }
}
