using MigrantProjectMVC.Interfaces;
using MigrantProjectMVC.Models;

namespace MigrantProjectMVC.Queries
{
    public class GetAllNotificationQuery : IQuery<IList<NotificationModel>>
    {
        public Guid PlaceOwnerId { get; }

        public GetAllNotificationQuery(Guid placeOwnerId)
        {
            PlaceOwnerId = placeOwnerId;
        }
    }
}
