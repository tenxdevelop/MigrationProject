using MigrantProjectMVC.Interfaces;

namespace MigrantProjectMVC.Commands
{
    public class RegisterUserCommand : ICommand<bool>
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
