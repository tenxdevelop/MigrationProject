using MigrantProjectMVC.Enums;
using MigrantProjectMVC.Interfaces;

namespace MigrantProjectMVC.Commands
{
    public class SetNotificationTypeCommand : ICommand<bool>
    {
        public Guid StatementId { get; set; }
        public NotificationType NotificationType { get; set; }

        public SetNotificationTypeCommand(Guid statementid, NotificationType notificationType)
        {
            StatementId = statementid;
            NotificationType = notificationType;
        }

    }
}
