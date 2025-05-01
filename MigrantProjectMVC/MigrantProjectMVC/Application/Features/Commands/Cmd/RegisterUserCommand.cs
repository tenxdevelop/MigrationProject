using MigrantProjectMVC.Interfaces;
using MigrantProjectMVC.ViewModel;

namespace MigrantProjectMVC.Commands
{
    public class RegisterUserCommand : ICommand<RegisterViewModel>
    {
        public string Email { get; private set; }
        public string Password { get; private set; }

        public RegisterUserCommand(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}
