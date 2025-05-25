using MigrantProjectMVC.Interfaces.Services;
using MigrantProjectMVC.Interfaces;
using MigrantProjectMVC.Models;

namespace MigrantProjectMVC.Application.Features.Services
{
    public class MigrantService : IMigrantService
    {
        private IMigrantRepository _migrantRepository;
        private ICountryRepository _countryRepository;
        
        private IDocumentRepository _documentRepository;
        
        public MigrantService(IMigrantRepository migrantRepository, ICountryRepository countryRepository, IDocumentRepository documentRepository)
        {
            _migrantRepository = migrantRepository;
            _countryRepository = countryRepository;
            _documentRepository = documentRepository;
        }
        
        public async Task<bool> RegisterMigrant(Guid userId, string name, string surname, string patronymic, DateTime enteringDate, string countryName, List<string> documentNames)
        {
            var isHaveMigrantData = await _migrantRepository.IsHaveMigrantData(userId);
            
            if (isHaveMigrantData)
                return false;
            
            var country = await _countryRepository.GetCountryByName(countryName);
            
            var documents = new List<Document>();
            foreach (var documentName in documentNames)
            {
                var document = await _documentRepository.GetDocument(documentName);
                if(document is not null)
                    documents.Add(document);
            }
            
            var result = await _migrantRepository.CreateMigrant(userId, name, surname, patronymic, enteringDate, country, documents);
            return result;
        }

        public async Task<bool> IsHaveMigrantData(Guid userId)
        {
            var result = await _migrantRepository.IsHaveMigrantData(userId);
            return result;
        }
    }
}