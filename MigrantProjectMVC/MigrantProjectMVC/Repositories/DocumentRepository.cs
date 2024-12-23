using MigrantProjectMVC.Enums;
using MigrantProjectMVC.Interfaces;
using MigrantProjectMVC.Models;
using System.Text.Json;

namespace MigrantProjectMVC.Repositories
{
    public class DocumentRepository : IDocumentRepository
    {
        private IServiceProvider _serviceProvider;
        public List<DocumentModel> Documents;
        private string _filePath = "jsons/documents.json";

        public DocumentRepository( IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
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
                        OwnerId = Guid.Parse("48e483c0-8c43-47d7-9833-112358380836"),
                        Name = "Паспорт гражданина РФ",
                        Content = "74416 234521",
                        CreationDate = DateTime.Parse("2005-05-15"),
                        DocumentType = new DocumentTypeModel(){Name = "PassportOfRussia"}
                    },
                    new DocumentModel()
                    {
                        OwnerId = Guid.Parse("26b188de-d553-47c1-ac7d-8af144d00253"),
                        Name = "Паспорт Белорусси",
                        Content = "32 23 \t 231 512",
                        CreationDate = DateTime.Parse("2016-02-24"),
                        DocumentType = new DocumentTypeModel(){ Name = "Passport Belorus"}
                    },
                    new DocumentModel()
                    {
                        OwnerId = Guid.Parse("26b188de-d553-47c1-ac7d-8af144d00253"),
                        Name = "Карта мигранта",
                        Content = "4614 1234567",
                        CreationDate = DateTime.Parse("2014-03-01"),
                        DocumentType = new DocumentTypeModel(){Name = "GreenMigrantCard"}
                    },
                    new DocumentModel()
                    {
                        OwnerId = Guid.Parse("26b188de-d553-47c1-ac7d-8af144d00253"),
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
            IStatementRepository _statementRepository = _serviceProvider.GetService<IStatementRepository>();
            var statement = await _statementRepository.GetStatementById(statementId);
            var migrantDocuments = statement.MigrantDocuments;
            var documents = statement.Documents;
            return migrantDocuments.Concat(documents).ToList();
         
        }

        public Task<IList<DocumentModel>> GetAllDocumentsByUserId(Guid userId)
        {
            var userDocuments = Documents.Where(x => x.OwnerId == userId);
            return Task.FromResult(userDocuments.ToList() as IList<DocumentModel>);
        }

        public Task<Dictionary<DocumentType, string>> GetAllDocumentTypes()
        {
            var docs = new Dictionary<DocumentType, string>() 
            {
                {DocumentType.PASSPORTPLACEOWNER, "Паспорт РФ"},
                {DocumentType.PASSPORTMIGRANT , "Паспорт мигранта"},
                {DocumentType.VISA, "Виза мигранта"},
                {DocumentType.MIGRATIONCARD, "Миграционная карта"},
            };
            return Task.FromResult(docs);
        }

        public Task SaveContext()
        {
            var data = JsonSerializer.Serialize(Documents);
            File.WriteAllText(_filePath, data);
            return Task.CompletedTask;
        }
    }
}
