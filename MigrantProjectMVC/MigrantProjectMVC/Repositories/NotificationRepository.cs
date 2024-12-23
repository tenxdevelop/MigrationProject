using MigrantProjectMVC.Enums;
using MigrantProjectMVC.Interfaces;
using MigrantProjectMVC.Models;
using System.Text.Json;

namespace MigrantProjectMVC.Repositories
{
    public class NotificationRepository : INotificationRepository
    {
        public List<NotificationModel> Notifications { get; set; }
        private string _filePath = "jsons/notification.json";
        private IStatementRepository _statementRepository;

        public NotificationRepository(IStatementRepository statementRepository)
        {
            _statementRepository = statementRepository;
            var fs = new FileStream(_filePath, FileMode.Open);
            try
            {
                Notifications = JsonSerializer.Deserialize<List<NotificationModel>>(fs);
                fs.Dispose();
            }
            catch (Exception ex) 
            {
                fs.Dispose();
                Notifications = new List<NotificationModel>()
                {
                    new NotificationModel()
                    {
                        StatementId = new Guid("998d3456-1ea0-4d2b-a516-7105cd1c9fed"),
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

        public Task<IList<NotificationModel>> GetAll(Guid placeOwnerId)
        {
            var statementIds = _statementRepository.GetAllStatementsByPlaceOwnerId(placeOwnerId).Result
                .Where(statement => statement.Status.Equals(StatusType.APPROVED) || statement.Status.Equals(StatusType.DENIED))
                .Select(statement => statement.Id);

            var result = Notifications.Where(x => statementIds.Contains(x.StatementId)).ToList();
            return Task.FromResult(result as IList<NotificationModel>);
        }

        public Task<Dictionary<NotificationType, string>> GetAllNotificationTypes()
        {
            var NotificationTypes = new Dictionary<NotificationType, string>() 
            {
                {NotificationType.EMAIl, "Электронная почта"},
                {NotificationType.PHYSICALMESSAGE, "Физическое сообщение"},
            };
            return Task.FromResult(NotificationTypes);
        }
    }
}
