using MigrantProjectMVC.Commands;
using MigrantProjectMVC.Enums;
using MigrantProjectMVC.Interfaces;
using System.Windows.Input;

namespace MigrantProjectMVC.CommandHandlers
{
    public class FillStatementWithMigrantDataCommandHandler : ICommandHandler<FillStatementWithMigrantDataCommand, bool>
    {
        private IDocumentRepository _documentRepository;
        private IStatementRepository _statementRepository;
        private IMigrantRepository _migrantRepository;
        private IRegulationRepository _regulationRepository;

        public FillStatementWithMigrantDataCommandHandler(IDocumentRepository documentRepository, IStatementRepository statementRepository, IMigrantRepository migrantRepository, IRegulationRepository regulationRepository)
        {
            _documentRepository = documentRepository;
            _statementRepository = statementRepository;
            _migrantRepository = migrantRepository;
            _regulationRepository = regulationRepository;
        }

        public async Task<bool> Handle(FillStatementWithMigrantDataCommand requist)
        {
            var migrant = await _migrantRepository.GetMigrantBySNP(requist.MigrantName, requist.MigrantSurname, requist.MigrantPatronymic);
            var migrantDocuments = await _documentRepository.GetAllDocumentsByUserId(migrant.Id);
            var statement = await _statementRepository.GetStatementById(requist.StatementId);
            var regulation = await _regulationRepository.GetRegulationWithCountry(migrant.Country);
            if (regulation != null) statement.Regulation = regulation;
            statement.MigrantDocuments = migrantDocuments.ToList();
            statement.Status = StatusType.CREATED;
            _statementRepository.SaveContext();
            return true;
        }
    }
}
