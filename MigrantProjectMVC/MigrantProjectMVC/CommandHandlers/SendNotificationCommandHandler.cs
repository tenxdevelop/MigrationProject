using MigrantProjectMVC.Commands;
using MigrantProjectMVC.Interfaces;

namespace MigrantProjectMVC.CommandHandlers
{
    public class SendNotificationCommandHandler : ICommandHandler<SendNotificationCommand, bool>
    {
        private IUserRepository _userRepository;
        private INotificationRepository _notificationRepository;


        public SendNotificationCommandHandler(IUserRepository userRepository, INotificationRepository notificationRepository)
        {
            _userRepository = userRepository;
            _notificationRepository = notificationRepository;
        }

        public async Task<bool> Handle(SendNotificationCommand requist)
        {
            var notification = await _notificationRepository.GetNotification(requist.statementId);
            var user = await _userRepository.GetUserBySNP(notification.Surname, notification.Name, notification.Patronymic);
            ///??? опять же вопрос, как будем реализовывать уведомление? Каким то образом в личном кабинете отображать?
            return true;
        }
    }
}
