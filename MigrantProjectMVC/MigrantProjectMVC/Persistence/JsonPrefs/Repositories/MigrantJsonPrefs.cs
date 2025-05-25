using MigrantProjectMVC.Models.JsonPrefs.Base;
using MigrantProjectMVC.Interfaces;
using MigrantProjectMVC.Models;

namespace MigrantProjectMVC.Repositories
{
    public class MigrantJsonPrefs : JsonPrefs<List<MigrantModel>>, IMigrantRepository
    {
        private const string FILE_PATH = "jsons/migrants.json";
        
        private List<MigrantModel> _migrants;
        
        public MigrantJsonPrefs() : base(FILE_PATH)
        {
            _migrants = LoadFromJson();
        }

        public Task<bool> IsHaveMigrantData(Guid userId)
        {
            var migrant = _migrants.Where(migrant => migrant.UserId.Equals(userId)).FirstOrDefault();
            
            var result = migrant is not null;
            return Task.FromResult(result);
        }

        public Task<bool> CreateMigrant(Guid userId, string name, string surname, string patronymic, DateTime enteringDate, CountryModel country, List<Document> documents)
        {
            var migrant = new MigrantModel(userId, name, surname, patronymic, enteringDate, country, documents);
            _migrants.Add(migrant);
            
            var result = SaveToJson(_migrants);
            return Task.FromResult(result);
        }

        public Task<MigrantModel> GetMigrant(string name, string surname, string patronymic)
        {
            var migrant = _migrants.Where(migrant => migrant.Name.Equals(name) && migrant.Surname.Equals(surname) && migrant.Patronymic.Equals(patronymic)).FirstOrDefault();
            
            return Task.FromResult(migrant);
        }
    }
}