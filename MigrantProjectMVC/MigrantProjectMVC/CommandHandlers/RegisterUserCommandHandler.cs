using MigrantProjectMVC.Commands;
using MigrantProjectMVC.Interfaces;

namespace MigrantProjectMVC.CommandHandlers
{
    public class RegisterUserCommandHandler : ICommandHandler<RegisterUserCommand, bool>
    {
        private IPasswordHasher _passwordHasher;
        private IUserRepository _userRepository;
        public RegisterUserCommandHandler(IUserRepository userRepository, IPasswordHasher passwordHasker)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasker;
        }

        public Task<bool> Handle(RegisterUserCommand requist)
        {
            throw new NotImplementedException();
        }
    }
}
