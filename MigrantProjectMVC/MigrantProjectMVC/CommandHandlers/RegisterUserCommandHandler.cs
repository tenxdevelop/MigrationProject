using MigrantProjectMVC.Commands;
using MigrantProjectMVC.Interfaces;
using MigrantProjectMVC.Models;
using System.Data;
using System.Numerics;
using System.Xml.Linq;

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

        public async Task<bool> Handle(RegisterUserCommand requist)
        {
            var user = new UserModel()
            {
                Id = Guid.NewGuid(),
                Email = requist.Email,
                Phone = requist.Phone,
                Password = requist.Password,
                Role = RoleModel.GetDefaultRole()
            };
            await _userRepository.Add(user);

            return true;
            

        }
    }
}
