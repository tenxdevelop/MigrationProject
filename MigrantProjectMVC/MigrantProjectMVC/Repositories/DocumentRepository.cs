using MigrantProjectMVC.Interfaces;
using MigrantProjectMVC.Models;

namespace MigrantProjectMVC.Repositories
{
    public class DocumentRepository : IDocumentRepository
    {
        StatementRepository _statementRepository; // Пока под вопросом
        public List<DocumentModel> Documents;

        public DocumentRepository(IStatementRepository statementRepository)
        {
            _statementRepository = statementRepository as StatementRepository;
        }

        public Task AddDocument(DocumentModel document)
        {
            Documents.Add(document);
            return Task.CompletedTask;
        }

        public Task<IList<DocumentModel>> GetDocumentsByStatmentId(Guid statementId)
        {
            var foundedDocuments = _statementRepository.Statements.FirstOrDefault(x => x.Id == statementId).MigrantDocuments;
            return Task.FromResult(foundedDocuments as IList<DocumentModel>);
         
        }
    }
}
