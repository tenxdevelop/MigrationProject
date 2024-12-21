using MigrantProjectMVC.Interfaces;
using System.Windows.Input;

namespace MigrantProjectMVC.Commands
{
    public class FillStatementWithMigrantDataCommand : ICommand<bool>
    {
        public Guid StatementId { get; set; }
        public string MigrantName { get; set; }
        public string MigrantSurname { get; set; }
        public string MigrantPatronymic { get; set; }

        public FillStatementWithMigrantDataCommand(Guid statementId, string migrantName, string migrantSurname, string migrantPatronymic)
        {
            StatementId = statementId;
            MigrantName = migrantName;
            MigrantSurname = migrantSurname;
            MigrantPatronymic = migrantPatronymic;
        }
    }
}
