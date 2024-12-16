using MigrantProjectMVC.Enums;
using MigrantProjectMVC.Interfaces;
using MigrantProjectMVC.Models;
using System.Text.Json;

namespace MigrantProjectMVC.Repositories
{
    public class DocumentRepository : IDocumentRepository
    {
        IStatementRepository _statementRepository; // Пока под вопросом
        public List<DocumentModel> Documents;
        private string _filePath = "jsons/documents.json";

        public DocumentRepository(IStatementRepository statementRepository)
        {
            _statementRepository = statementRepository;

            var fs = new FileStream(_filePath, FileMode.Open);
            try
            {
                Documents = JsonSerializer.Deserialize<List<DocumentModel>>(fs);
                fs.Dispose();
            }
            catch (Exception ex)
            {
                fs.Dispose();
                Documents = new List<DocumentModel>()
                {
                    new DocumentModel()
                    {
                        Name = "Паспорт гражданина РФ",
                        Content = "74416 234521",
                        CreationDate = DateTime.Parse("2005-05-15"),
                        DocumentType = new DocumentTypeModel(){Name = "PassportOfRussia"}
                    },
                    new DocumentModel()
                    {
                        Name = "Паспорт Белорусси",
                        Content = "32 23 \t 231 512",
                        CreationDate = DateTime.Parse("2016-02-24"),
                        DocumentType = new DocumentTypeModel(){ Name = "Passport Belorus"}
                    },
                    new DocumentModel()
                    {
                        Name = "Карта мигранта",
                        Content = "4614 1234567",
                        CreationDate = DateTime.Parse("2014-03-01"),
                        DocumentType = new DocumentTypeModel(){Name = "GreenMigrantCard"}
                    },
                    new DocumentModel()
                    {
                        Name = "Виза РФ",
                        Content = "YA 8844444",
                        CreationDate = DateTime.Parse("1999-07-07"),
                        DocumentType = new DocumentTypeModel(){Name = "VisaRF"}
                    }
                };
                SaveContext();
                
            }


        }

        public Task AddDocument(DocumentModel document)
        {
            Documents.Add(document);
            SaveContext();
            return Task.CompletedTask;
        }

        public async Task<IList<DocumentModel>> GetAllDocumentsByStatementId(Guid statementId)
        {
            var statement = await _statementRepository.GetStatementById(statementId);
            var migrantDocuments = statement.MigrantDocuments;
            var documents = statement.Documents;
            return migrantDocuments.Concat(documents).ToList();
         
        }

        public Task SaveContext()
        {
            var data = JsonSerializer.Serialize(Documents);
            File.WriteAllText(_filePath, data);
            return Task.CompletedTask;
        }
    }
}
