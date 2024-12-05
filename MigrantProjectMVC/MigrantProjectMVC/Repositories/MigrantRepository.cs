using MigrantProjectMVC.Interfaces;
using MigrantProjectMVC.Models;

namespace MigrantProjectMVC.Repositories
{
    public class MigrantRepository : IMigrantRepository
    {
        public List<MigrantModel> migrants;
        public Task<string> GetCountryByMigrantId(string email) // вопрос тот же
        {
            throw new NotImplementedException();
        }

        public Task<MigrantModel?> GetMigrantBySNP(string name, string surname, string patronymic)
        {
            var migrant = migrants.Find(x =>
            x.Name.Equals(name, StringComparison.OrdinalIgnoreCase) &&
            x.Surname.Equals(surname, StringComparison.OrdinalIgnoreCase) &&
            x.Patronymic.Equals(patronymic, StringComparison.OrdinalIgnoreCase)
            );
            return Task.FromResult(migrant);
        }

        public Task<bool> UpdateMigrant(MigrantModel migrant)
        {
            throw new NotImplementedException();
        }
    }
}
