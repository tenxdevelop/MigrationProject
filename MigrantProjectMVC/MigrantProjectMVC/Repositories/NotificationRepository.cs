using MigrantProjectMVC.Interfaces;
using MigrantProjectMVC.Models;

namespace MigrantProjectMVC.Repositories
{
    public class NotificationRepository : INotificationRepository
    {
        public List<NotificationModel> Notifications { get; set; }

        public NotificationRepository()
        {

        }

        public Task<NotificationModel> GetNotification(Guid statementId)
        {
            return Task.FromResult(Notifications.FirstOrDefault(x => x.StatementId == statementId));
        }

        public Task Add(NotificationModel notification)
        {
            Notifications.Add(notification);
            return Task.CompletedTask;
        }

        public Task UpdateNotification(NotificationModel notification)
        {
            var foundedNotification = Notifications.FirstOrDefault(x => x.StatementId == notification.StatementId);
            foundedNotification.Status = notification.Status;
            foundedNotification.Surname = notification.Surname;
            foundedNotification.Name = notification.Name;
            foundedNotification.NotificationType = notification.NotificationType;
            foundedNotification.Patronymic = notification.Patronymic;
            return Task.CompletedTask;
        }
    }
}
