using MigrantProjectMVC.Models;

namespace MigrantProjectMVC.Interfaces
{
    public interface IMigrantRepository
    {
        Task<bool> IsHaveMigrantData(Guid userId);

        Task<bool> AddMigrant(MigrantModel migrant);
        
        Task<MigrantModel> GetMigrant(string name, string surname, string patronymic);
    }
}