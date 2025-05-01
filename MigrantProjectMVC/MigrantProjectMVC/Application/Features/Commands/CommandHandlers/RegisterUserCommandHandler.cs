using MigrantProjectMVC.Interfaces;
using MigrantProjectMVC.Commands;
using MigrantProjectMVC.Models;

namespace MigrantProjectMVC.CommandHandlers
{
    public class RegisterUserCommandHandler : ICommandHandler<RegisterUserCommand, bool>
    {
        private IUserRepository _userRepository;
        private IPasswordHasher _passwordHasher;
        public RegisterUserCommandHandler(IUserRepository userRepository, IPasswordHasher passwordHasher)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
        }

        public async Task<bool> Handle(RegisterUserCommand requist)
        {
            var passwordHash = _passwordHasher.GenerateHash(requist.Password);
            
            var user = new UserModel()
            {
                Id = Guid.NewGuid(),
                Email = requist.Email,
                PasswordHash = passwordHash
            };
            
            await _userRepository.AddUser(user);
            
            return true;
            

        }
    }
}
