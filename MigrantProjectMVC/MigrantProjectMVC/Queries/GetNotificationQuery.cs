using MigrantProjectMVC.Interfaces;
using MigrantProjectMVC.Models;

namespace MigrantProjectMVC.Queries
{
    public class GetNotificationQuery : IQuery<NotificationModel>
    {
        public Guid StatementId { get; set; }

        public GetNotificationQuery(Guid statementId)
        {
            StatementId = statementId;
        }
    }
}
