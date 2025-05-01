using MigrantProjectMVC.Models;

namespace MigrantProjectMVC.Interfaces
{
    public interface INotificationRepository
    {
        Task<bool> AddNotification(NotificationModel notification);
    }
}