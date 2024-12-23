using MigrantProjectMVC.Enums;
using MigrantProjectMVC.Models;

namespace MigrantProjectMVC.Interfaces
{
    public interface IDocumentRepository
    {
        public Task AddDocument(DocumentModel document);

        public Task<IList<DocumentModel>> GetAllDocumentsByStatementId(Guid id);

        public Task<IList<DocumentModel>> GetAllDocumentsByUserId(Guid userId);
        public Task<Dictionary<DocumentType, string>> GetAllDocumentTypes();
        public Task SaveContext();
    }
}
