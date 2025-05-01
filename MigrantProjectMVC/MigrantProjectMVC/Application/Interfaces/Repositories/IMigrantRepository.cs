using MigrantProjectMVC.Models;

namespace MigrantProjectMVC.Interfaces
{
    public interface IMigrantRepository
    {
        public Task<bool> IsHaveMigrantData(Guid userId);

        public Task<bool> AddMigrant(MigrantModel migrant);
    }
}