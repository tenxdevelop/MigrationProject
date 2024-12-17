using MigrantProjectMVC.Enums;
using MigrantProjectMVC.Interfaces;
using MigrantProjectMVC.Models;
using System.Text.Json;

namespace MigrantProjectMVC.Repositories
{
    public class NotificationRepository : INotificationRepository
    {
        public List<NotificationModel> Notifications { get; set; }
        string _filePath = "jsons/notifications.json";
        private IStatementRepository _statementRepository;

        public NotificationRepository(IStatementRepository statementRepository)
        {
            _statementRepository = statementRepository;
            var fs = new FileStream(_filePath, FileMode.Open);
            try
            {
                Notifications = JsonSerializer.Deserialize<List<NotificationModel>>(fs);
            }
            catch (Exception ex) 
            {
                Notifications = new List<NotificationModel>()
                {
                    new NotificationModel()
                    {
                        StatementId = statementRepository.GetAllStatements().Result.Where(x => x.Status == StatusType.APPROVED).First().Id,
                        Name = "PlaceOwner",
                        Surname = "PlaceOwner",
                        Patronymic = "PlaceOwner"
                    }
                };
            }
        }

        public Task<NotificationModel> GetNotification(Guid statementId)
        {
            return Task.FromResult(Notifications.FirstOrDefault(x => x.StatementId == statementId));
        }

        public Task Add(NotificationModel notification)
        {
            Notifications.Add(notification);
            SaveContext();
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

        public Task SaveContext()
        {
            var data = JsonSerializer.Serialize(Notifications);
            File.WriteAllText(_filePath, data);
            return Task.CompletedTask;
        }

    }
}
