using MigrantProjectMVC.Enums;
using MigrantProjectMVC.Interfaces;
using MigrantProjectMVC.Queries;

namespace MigrantProjectMVC.QueryHandlers
{
    public class GetAllNotificationReadableTypesQueryHandler : IQueryHandler<GetAllNotificationReadableTypesQuery, Dictionary<NotificationType, string>>
    {

        private INotificationRepository _notificationRepository;

        public GetAllNotificationReadableTypesQueryHandler(INotificationRepository notificationRepository)
        {
            _notificationRepository = notificationRepository;
        }

        public async Task<Dictionary<NotificationType, string>> Handle(GetAllNotificationReadableTypesQuery query)
        {
            return  await _notificationRepository.GetAllNotificationTypes();
        }
    }
}
