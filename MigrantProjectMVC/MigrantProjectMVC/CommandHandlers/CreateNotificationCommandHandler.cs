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

        public CreateNotificationCommandHandler(INotificationRepository notificationRepository, IStatementRepository statementRepository)
        {
            _notificationRepository = notificationRepository;
            _statementRepository = statementRepository;
        }

        public async Task<bool> Handle(CreateNotificationCommand requist)
        {
            var statement = await _statementRepository.GetStatementById(requist.StatementId);
            if (statement == null) return false;
            var notification = new NotificationModel()
            {
                StatementId = requist.StatementId,
                Name = statement.Migrant.Name,
                Surname = statement.Migrant.Surname,
                Patronymic = statement.Migrant.Patronymic,
                Status = statement.Status.Equals(StatusType.APPROVED),
                NotificationType = null
            };
            await _notificationRepository.Add(notification);
            return true;

        }
    }
}
