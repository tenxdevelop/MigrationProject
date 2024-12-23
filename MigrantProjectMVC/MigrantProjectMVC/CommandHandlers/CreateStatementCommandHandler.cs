using MigrantProjectMVC.Commands;
using MigrantProjectMVC.Enums;
using MigrantProjectMVC.Interfaces;
using MigrantProjectMVC.Models;

namespace MigrantProjectMVC.CommandHandlers
{
    public class CreateStatementCommandHandler : ICommandHandler<CreateStatementCommand, bool>
    {
        private IStatementRepository _statementRepository;
        private IMigrantRepository _migrantRepository;
        private IDocumentRepository _documentRepository;
        private IRegulationRepository _regulationRepository;

        public CreateStatementCommandHandler(IStatementRepository statementRepository, IMigrantRepository migrantRepository, 
                                             IDocumentRepository documentRepository, IRegulationRepository regulationRepository)
        {
            _statementRepository = statementRepository;
            _migrantRepository = migrantRepository;
            _documentRepository = documentRepository;
            _regulationRepository = regulationRepository;
        }

        public async Task<bool> Handle(CreateStatementCommand requist)
        {
            var migrant = await _migrantRepository.GetMigrantBySNP(requist.Name, requist.Surname, requist.Patronymic);

            if (migrant is null)
                return false;

            var migrantDocuments = await _documentRepository.GetAllDocumentsByUserId(migrant.Id);

            var placeOwnerDocuments = await _documentRepository.GetAllDocumentsByUserId(requist.PlaceOwner.Id);

            var regulation = await _regulationRepository.GetRegulationWithCountry(migrant.Country);

            var statement = StatementModel.Create(migrantDocuments.ToList(), placeOwnerDocuments.ToList(), requist.PreviousAddress, requist.AccountingAddress, 
                                                  StatusType.CREATED, requist.PlaceOwner, regulation, migrant);

            await _statementRepository.Add(statement);
            return true;
        }
    }
}
