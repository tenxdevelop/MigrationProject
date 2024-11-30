using MigrantProjectMVC.Interfaces;
using System.Windows.Input;

namespace MigrantProjectMVC.Commands
{
    public class CreateUserStatementCommand : ICommand<bool>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public CreateUserStatementCommand(string name, string surname, string patronymic, string email, string password)
        {
            Name = name;
            Surname = surname;
            Patronymic = patronymic;
            Email = email;
            Password = password;
        }
        public CreateUserStatementCommand() { }
    }
}
