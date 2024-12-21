using MigrantProjectMVC.Enums;
using MigrantProjectMVC.Interfaces;
using System.Windows.Input;

namespace MigrantProjectMVC.Commands
{
    public class SendNotificationCommand : ICommand<bool>
    {
        public Guid statementId { get; set; }
        public NotificationType notificationType { get; set; }

        public SendNotificationCommand(Guid statementId, NotificationType notificationType)
        {
            this.statementId = statementId;
            this.notificationType = notificationType;
        }
    }
}
