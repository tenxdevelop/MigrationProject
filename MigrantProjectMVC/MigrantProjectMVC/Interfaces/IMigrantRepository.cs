using MigrantProjectMVC.Models;

namespace MigrantProjectMVC.Interfaces
{
    public interface IMigrantRepository
    {
        public Task<string> GetCountryByEmail(string email); // Почему входит почта?
        public Task<bool> UpdateMigrant(MigrantModel migrant);
        public Task<MigrantModel> GetMigrantBySNP(string name, string surname, string patronymic);
        public Task<MigrantModel> GetMigrantById(Guid id);

        public Task<bool> AddMigrant(MigrantModel migrant);

        public Task<bool> DeleteMigrant(Guid id);
        public Task SaveContext();

    }
}
