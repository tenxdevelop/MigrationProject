using MigrantProjectMVC.Enums;
using MigrantProjectMVC.Interfaces;

namespace MigrantProjectMVC.Commands
{
    public class SetStatementStatusCommand : ICommand<bool>
    {
        public Guid Id { get; set; }
        public StatusType Status { get; set; }

        public SetStatementStatusCommand(Guid id, StatusType status)
        {
            Id = id;
            Status = status;
        }
    }
}
