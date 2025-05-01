
using MigrantProjectMVC.Interfaces;
using MigrantProjectMVC.Commands;
using MigrantProjectMVC.Interfaces.Services;
using MigrantProjectMVC.Models;

namespace MigrantProjectMVC.CommandHandlers
{
    public class LoginUserCommandHandler : ICommandHandler<LoginUserCommand, string>
    {
        private IUserService _userService;
        
        public LoginUserCommandHandler(IUserService userRepository)
        {
            _userService = userRepository;
        }
        public async Task<string> Handle(LoginUserCommand requist)
        {
            var token = await _userService.LoginUser(requist.Email, requist.Password);
            return token;
        }
    }
}
