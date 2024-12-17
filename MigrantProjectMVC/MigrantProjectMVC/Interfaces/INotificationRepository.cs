using MigrantProjectMVC.Models;

namespace MigrantProjectMVC.Interfaces
{
    public interface INotificationRepository
    {

        public Task<NotificationModel> GetNotification(Guid id);
        public Task Add(NotificationModel notification);
        public Task UpdateNotification(NotificationModel notification);
    }
}
