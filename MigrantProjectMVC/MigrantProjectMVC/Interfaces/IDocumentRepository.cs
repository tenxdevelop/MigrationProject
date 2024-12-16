using MigrantProjectMVC.Models;

namespace MigrantProjectMVC.Interfaces
{
    public interface IDocumentRepository
    {
        public Task AddDocument(DocumentModel document);

        public Task<IList<DocumentModel>> GetAllDocumentsByStatementId(Guid id);
    }
}
