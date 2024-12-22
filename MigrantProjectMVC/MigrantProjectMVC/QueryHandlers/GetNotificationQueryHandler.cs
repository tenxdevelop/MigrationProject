using MigrantProjectMVC.Interfaces;
using MigrantProjectMVC.Models;
using MigrantProjectMVC.Queries;

namespace MigrantProjectMVC.QueryHandlers
{
    public class GetNotificationQueryHandler : IQueryHandler<GetNotificationQuery, NotificationModel>
    {
        private INotificationRepository _notificationRepository;
        public GetNotificationQueryHandler(INotificationRepository notificationRepository)
        {
            _notificationRepository = notificationRepository;
        }
        public Task<NotificationModel> Handle(GetNotificationQuery query)
        {
            return _notificationRepository.GetNotification(query.StatementId);
        }
    }
}
