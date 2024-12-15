using MigrantProjectMVC.Interfaces;
using MigrantProjectMVC.Models;
using MigrantProjectMVC.Queries;

namespace MigrantProjectMVC.QueryHandlers
{
    public class GetNotificationQueryHandler : IQueryHandler<GetNotificationQuery, NotificationModel>
    {
        public Task<NotificationModel> Handle(GetNotificationQuery query)
        {
            throw new NotImplementedException();
        }
    }
}
