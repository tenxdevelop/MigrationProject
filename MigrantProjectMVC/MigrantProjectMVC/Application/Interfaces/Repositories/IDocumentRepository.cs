using MigrantProjectMVC.Models;

namespace MigrantProjectMVC.Interfaces
{

    public interface IDocumentRepository
    {
        Task<Document> GetDocument(string documentName);
    }
}