using MigrantProjectMVC.Interfaces.Services;
using MigrantProjectMVC.Interfaces;
using MigrantProjectMVC.Commands;
using MigrantProjectMVC.ViewModel;

namespace MigrantProjectMVC.CommandHandlers
{
    public class RegisterUserCommandHandler : ICommandHandler<RegisterUserCommand, RegisterViewModel>
    {
        private IUserService _userService;
        public RegisterUserCommandHandler(IUserService userService)
        {
            _userService = userService;
        }
        public async Task<RegisterViewModel> Handle(RegisterUserCommand requist)
        {
            var result = await _userService.RegisterUser(requist.Email, requist.Password);
            return result;
        }
    }
}
