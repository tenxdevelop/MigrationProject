using MigrantProjectMVC.Commands;
using MigrantProjectMVC.Enums;
using MigrantProjectMVC.Interfaces;
using MigrantProjectMVC.Models;

namespace MigrantProjectMVC.CommandHandlers
{
    public class CreateStatementCommandHandler : ICommandHandler<CreateStatementCommand, bool>
    {
        private IStatementRepository _statementRepository;
        private IUserRepository _userRepository;
        private IDocumentRepository _documentRepository;

        public CreateStatementCommandHandler(IStatementRepository statementRepository, IUserRepository userRepository, IDocumentRepository documentRepository)
        {
            _statementRepository = statementRepository;
            _userRepository = userRepository;
            _documentRepository = documentRepository;
        }

        public async Task<bool> Handle(CreateStatementCommand requist)
        {
            var placeOwner = await _userRepository.GetUserBySNP(requist.Name, requist.Surname, requist.Patronymic);
            var placeOwnerDocuments = await _documentRepository.GetAllDocumentsByUserId(placeOwner.Id);
            var statement = new StatementModel()
            {
                Id = new Guid(),
                AccountingAddress = requist.AccountingAddress,
                PreviousAddress = requist.PreviousAddress,
                PlaceOwner = placeOwner,
                Documents = placeOwnerDocuments.ToList(),
                MigrantDocuments = new List<DocumentModel>(),
            };
            _statementRepository.Add(statement);
            return true;
        }
    }
}
