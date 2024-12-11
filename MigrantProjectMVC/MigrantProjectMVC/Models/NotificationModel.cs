using MigrantProjectMVC.Enums;

namespace MigrantProjectMVC.Models
{
    public class NotificationModel
    {
        public Guid StatementId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public bool Status { get; set; }
        public NotificationType NotificationType { get; set; }

        public static NotificationModel Create(Guid StatementId, string name, string surname, string patronymic)
        {
            return new NotificationModel
            {
                StatementId = StatementId,
                Name = name,
                Surname = surname,
                Patronymic = patronymic
            };
        }
    }
}
