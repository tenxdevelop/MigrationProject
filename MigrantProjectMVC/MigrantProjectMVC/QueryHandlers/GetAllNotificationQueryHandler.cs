using MigrantProjectMVC.Interfaces;
using MigrantProjectMVC.Models;
using MigrantProjectMVC.Queries;

namespace MigrantProjectMVC.QueryHandlers
{
    public class GetAllNotificationQueryHandler : IQueryHandler<GetAllNotificationQuery, IList<NotificationModel>>
    {

        private INotificationRepository _notificationRepository;

        public GetAllNotificationQueryHandler(INotificationRepository notificationRepository)
        {
            _notificationRepository = notificationRepository;
        }

        public Task<IList<NotificationModel>> Handle(GetAllNotificationQuery query)
        {
            return _notificationRepository.GetAll(query.PlaceOwnerId);
        }
    }
}
