using MigrantProjectMVC.Interfaces.Services;
using MigrantProjectMVC.Interfaces;
using MigrantProjectMVC.Models;

namespace MigrantProjectMVC.Application.Features.Services
{
    public class MigrantService : IMigrantService
    {
        private IMigrantRepository _migrantRepository;
        private ICountryRepository _countryRepository;
        
        public MigrantService(IMigrantRepository migrantRepository, ICountryRepository countryRepository)
        {
            _migrantRepository = migrantRepository;
            _countryRepository = countryRepository;
        }
        
        public async Task<bool> RegisterMigrant(Guid userId, string name, string surname, string patronymic, DateTime enteringDate, string countryName, List<string> documentNames)
        {
            var isHaveMigrantData = await _migrantRepository.IsHaveMigrantData(userId);
            
            if (isHaveMigrantData)
                return false;
            
            var country = await _countryRepository.GetCountryByName(countryName);
            
            var migrant = MigrantModel.Create(userId, name, surname, patronymic, enteringDate, country, documentNames);
            var result = await _migrantRepository.AddMigrant(migrant);
            return result;
        }

        public async Task<bool> IsHaveMigrantData(Guid userId)
        {
            var result = await _migrantRepository.IsHaveMigrantData(userId);
            return result;
        }
    }
}