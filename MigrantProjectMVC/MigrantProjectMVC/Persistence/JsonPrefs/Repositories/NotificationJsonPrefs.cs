using MigrantProjectMVC.Models.JsonPrefs.Base;
using MigrantProjectMVC.Interfaces;
using MigrantProjectMVC.Models;

namespace MigrantProjectMVC.Repositories
{

    public class NotificationJsonPrefs : JsonPrefs<List<NotificationModel>>, INotificationRepository
    {
        private const string FILE_PATH = "jsons/notifications.json";
        
        private List<NotificationModel> _notifications;
        
        public NotificationJsonPrefs() : base(FILE_PATH)
        {
            _notifications = LoadFromJson();
        }

        public Task<bool> AddNotification(NotificationModel notification)
        {
            _notifications.Add(notification);
            var result = SaveToJson(_notifications);
            return Task.FromResult(result);
        }
    }
}