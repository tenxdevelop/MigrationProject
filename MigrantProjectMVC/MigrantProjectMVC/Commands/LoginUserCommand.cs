using MigrantProjectMVC.Interfaces;
using System.Windows.Input;

namespace MigrantProjectMVC.Commands
{
    public class LoginUserCommand : ICommand<string>
    {
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
