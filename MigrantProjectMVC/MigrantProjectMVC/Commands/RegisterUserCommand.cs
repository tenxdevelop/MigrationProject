using MigrantProjectMVC.Interfaces;
using System.Windows.Input;

namespace MigrantProjectMVC.Commands
{
    public class RegisterUserCommand : ICommand<bool>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
    }
}
