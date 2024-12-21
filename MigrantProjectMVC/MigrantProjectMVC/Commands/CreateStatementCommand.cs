using MigrantProjectMVC.Interfaces;
using System.Windows.Input;

namespace MigrantProjectMVC.Commands
{
    public class CreateStatementCommand : ICommand<bool>
    {
        public string Name {  get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public string? PreviousAddress { get; set; }
        public string AccountingAddress { get; set; }


        public CreateStatementCommand(string name, string surname, string patronymic, string? previousAddress, string accountingAddress)
        {
            Name = name;
            Surname = surname;
            Patronymic = patronymic;
            PreviousAddress = previousAddress;
            AccountingAddress = accountingAddress;
        }
    }
}
