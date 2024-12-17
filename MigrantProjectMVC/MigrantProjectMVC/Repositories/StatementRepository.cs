using MigrantProjectMVC.Enums;
using MigrantProjectMVC.Interfaces;
using MigrantProjectMVC.Models;
using System.Text.Json;

namespace MigrantProjectMVC.Repositories
{
    public class StatementRepository : IStatementRepository
    {
        public List<StatementModel> Statements;
        private string _filePath = "jsons/statements.json";
        private IDocumentRepository _documentRepository;
        private IServiceProvider _serviceProvider;

        public StatementRepository(IDocumentRepository documentRepository, IServiceProvider serviceProvider)
        {
            _documentRepository = documentRepository;
            _serviceProvider = serviceProvider;
            var fs = new FileStream(_filePath, FileMode.Open);
            try
            {
                Statements = JsonSerializer.Deserialize<List<StatementModel>>(fs);
                fs.Dispose();
            }
            catch (Exception ex) 
            {
                var regulationRepository = _serviceProvider.GetService<IRegulationRepository>();
                var userRepository = _serviceProvider.GetService<IUserRepository>();
                fs.Dispose();
                Statements = new List<StatementModel>()
                {
                    new StatementModel()
                    {
                        AccountingAddress = "Дзержинского 23",
                        PreviousAddress = null,
                        Id = Guid.NewGuid(),
                        Documents = new List<DocumentModel>()
                        {
                            new DocumentModel()
                            {
                                Name = "Паспорт гражданина РФ",
                                Content = "74416 234521",
                                CreationDate = DateTime.Parse("2005-05-15"),
                                DocumentType = new DocumentTypeModel(){Name = "PassportOfRussia"}
                            },
                        },
                        MigrantDocuments = new List<DocumentModel>()
                        {
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
                        },
                        Status = StatusType.CREATED,
                        Regulation = regulationRepository.GetRegulationWithCountry("Белоруссь").Result,
                        PlaceOwner = userRepository.GetUserByEmail("PlaceOwner").Result 
                    }
                };
                SaveContext();
            }

        }



        public async Task<IList<StatementModel>> GetAllStatementsByPlaceOwnerId(Guid userId)
        {
            return Statements.Where(x => x.PlaceOwner.Id == userId).ToList();
        }

        public async Task<StatusType> GetStatementStatus(Guid statementId)
        {
            return Statements.FirstOrDefault(x => x.Id == statementId).Status;
        }

        public async Task<IList<StatementModel>> GetAllStatements()
        {
            return Statements;
        }

        public async Task UpdateStatement(StatementModel statement)
        {
            var foundedStatement = Statements.FirstOrDefault(x => x.Id == statement.Id);
            if (foundedStatement == null) return;
            foundedStatement.Status = statement.Status;
            foundedStatement.Documents = statement.Documents;
            foundedStatement.MigrantDocuments = statement.MigrantDocuments;
            foundedStatement.Regulation = statement.Regulation;
            foundedStatement.AccountingAddress = statement.AccountingAddress;
            foundedStatement.PlaceOwner = statement.PlaceOwner;
            foundedStatement.PreviousAddress = statement.PreviousAddress;
            return;

        }

        public async Task Add(StatementModel statement)
        {
            Statements.Add(statement);
            foreach (var document in statement.Documents)
            {
                await _documentRepository.AddDocument(document);
            }
            foreach (var migrantDocument in statement.MigrantDocuments)
            {
                await _documentRepository.AddDocument(migrantDocument);
            }
            return;
        }

        public async Task<StatementModel> GetStatementById(Guid id)
        {
            return Statements.FirstOrDefault(x => x.Id == id);
        }

        public async Task SaveContext()
        {
            var data = JsonSerializer.Serialize(Statements);
            File.WriteAllText(_filePath, data);
            return;
        }
    }
}
