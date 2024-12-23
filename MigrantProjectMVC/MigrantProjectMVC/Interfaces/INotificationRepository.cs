using MigrantProjectMVC.Enums;
using MigrantProjectMVC.Models;

namespace MigrantProjectMVC.Interfaces
{
    public interface INotificationRepository
    {

        public Task<NotificationModel> GetNotification(Guid id);
        public Task Add(NotificationModel notification);
        public Task<IList<NotificationModel>> GetAll(Guid placeOwnerId);
        public Task UpdateNotification(NotificationModel notification);
        public Task<Dictionary<NotificationType, string>> GetAllNotificationTypes();
        public Task SaveContext();
    }
}
