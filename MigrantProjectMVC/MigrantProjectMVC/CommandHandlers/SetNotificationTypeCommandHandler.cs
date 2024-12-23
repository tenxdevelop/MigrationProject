using MigrantProjectMVC.Commands;
using MigrantProjectMVC.Interfaces;

namespace MigrantProjectMVC.CommandHandlers
{
    public class SetNotificationTypeCommandHandler : ICommandHandler<SetNotificationTypeCommand, bool>
    {
        private INotificationRepository _notificationRepository;

        public SetNotificationTypeCommandHandler(INotificationRepository notificationRepository)
        {
            _notificationRepository = notificationRepository;
        }

        public async Task<bool> Handle(SetNotificationTypeCommand requist)
        {
            var notification = await _notificationRepository.GetNotification(requist.StatementId);
            if (notification == null) return false;
            notification.NotificationType = requist.NotificationType;
            _notificationRepository.SaveContext();
            return true;
        }
    }
}
