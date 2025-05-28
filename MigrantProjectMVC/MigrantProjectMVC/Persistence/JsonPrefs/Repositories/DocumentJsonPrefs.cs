using MigrantProjectMVC.Models.JsonPrefs.Base;
using MigrantProjectMVC.Interfaces;
using MigrantProjectMVC.Models;

namespace MigrantProjectMVC.Repositories
{
    public class DocumentJsonPrefs : JsonPrefs<List<Document>>, IDocumentRepository
    {
        private const string FILE_PATH = "jsons/document.json";

        private List<Document> _documents;
        
        public DocumentJsonPrefs() : base(FILE_PATH)
        {
            
            //for test
            var documents = new List<Document>();
            documents.Add(new Document() { Name = "HighlyQualifiedDocument" });
            documents.Add(new Document() { Name = "ConsistOfMigrationProgramDocument" });
            documents.Add(new Document() { Name = "ResettlementDocument" });
            //SaveToJson(documents);

            _documents = LoadFromJson();
        }

        public Task<Document> GetDocument(string documentName)
        {
            var document = _documents.Where(document => document.Name == documentName).FirstOrDefault();
            
            return Task.FromResult(document);
        }
    }
}