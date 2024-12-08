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

            await _userRepository.Add(new UserModel()
            {
                Id = requist.Id,
                Name = requist.Name,
                Surname = requist.Surname,
                Patronymic = requist.Patronymic,
                Email = requist.Email,
                Phone = requist.Phone,
                Password = requist.Password,
                Role = requist.Role
            });

            return true;
            

        }
    }
}
