using MigrantProjectMVC.Interfaces;

namespace MigrantProjectMVC.Commands
{
    public class CreateNotificationCommand : ICommand<bool>
    {
        public Guid StatementId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }

        public CreateNotificationCommand(Guid statementId, string name, string surname, string patronymic)
        {
            StatementId = statementId;
            Name = name;
            Surname = surname;
            Patronymic = patronymic;
        }
    }
}
