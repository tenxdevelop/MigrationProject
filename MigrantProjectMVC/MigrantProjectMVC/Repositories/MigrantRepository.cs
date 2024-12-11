using MigrantProjectMVC.Interfaces;
using MigrantProjectMVC.Models;

namespace MigrantProjectMVC.Repositories
{
    public class MigrantRepository : IMigrantRepository
    {
        public List<MigrantModel> migrants;
        public Task<string> GetCountryByMigrantId(string email)
        {
            var migrant = migrants.FirstOrDefault(x => x.Email == email);
            if (migrant == null)
            {
                throw new NullReferenceException();
            }
            return Task.FromResult(migrant.Country);
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
            var foundedMigrant = migrants.FirstOrDefault(x => x.Id == migrant.Id);
            if (foundedMigrant == null) return Task.FromResult(false);
            foundedMigrant.EnteringDate = migrant.EnteringDate;
            foundedMigrant.HighlyQualified = migrant.HighlyQualified;
            foundedMigrant.ResettelmentProgramMember = migrant.ResettelmentProgramMember;
            foundedMigrant.ConsistOfMigrationRegistration = migrant.ConsistOfMigrationRegistration;
            foundedMigrant.Country = migrant.Country;
            return Task.FromResult(true);
        }
    }
}
