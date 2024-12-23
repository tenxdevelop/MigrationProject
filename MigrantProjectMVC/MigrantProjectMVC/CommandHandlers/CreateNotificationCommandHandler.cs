using MigrantProjectMVC.Commands;
using MigrantProjectMVC.Enums;
using MigrantProjectMVC.Interfaces;
using MigrantProjectMVC.Models;

namespace MigrantProjectMVC.CommandHandlers
{
    public class CreateNotificationCommandHandler : ICommandHandler<CreateNotificationCommand, bool>
    {

        private INotificationRepository _notificationRepository;
        private IStatementRepository _statementRepository;
        private IUserRepository _userRepository;

        public CreateNotificationCommandHandler(INotificationRepository notificationRepository, IStatementRepository statementRepository, IUserRepository userRepository)
        {
            _notificationRepository = notificationRepository;
            _statementRepository = statementRepository;
            _userRepository = userRepository;
        }
        public async Task<bool> Handle(CreateNotificationCommand requist)
        {
            var statement = await _statementRepository.GetStatementById(requist.StatementId);
            if (statement == null) return false;
            var notification = new NotificationModel()
            {
                StatementId = requist.StatementId,
                Name = statement.PlaceOwner.Name,
                Surname = statement.PlaceOwner.Surname,
                Patronymic = statement.PlaceOwner.Patronymic,
                Status = false,
                NotificationType = null
            };
            _notificationRepository.Add(notification);
            return true;

        }
    }
}
