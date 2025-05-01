using MigrantProjectMVC.Interfaces;

namespace MigrantProjectMVC.Commands
{
    public class LoginUserCommand : ICommand<string>
    {
        public string Email { get; private set; }
        public string Password { get; private set; }

        public LoginUserCommand(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}
