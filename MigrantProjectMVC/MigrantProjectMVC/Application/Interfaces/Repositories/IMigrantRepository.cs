using MigrantProjectMVC.Models;

namespace MigrantProjectMVC.Interfaces
{
    public interface IMigrantRepository
    {
        Task<bool> IsHaveMigrantData(Guid userId);

        Task<bool> CreateMigrant(Guid userId, string name, string surname, string patronymic, DateTime enteringDate, CountryModel country, List<Document> documents);
        
        Task<MigrantModel> GetMigrant(string name, string surname, string patronymic);
    }
}