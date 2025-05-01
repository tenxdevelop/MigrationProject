using MigrantProjectMVC.Models;

namespace MigrantProjectMVC.Interfaces.Services
{
    public interface IMigrantService
    {
        Task<bool> RegisterMigrant(Guid userId, string name, string surname, string patronymic, DateTime enteringDate, string countryName, List<string> documentNames);
        Task<bool> IsHaveMigrantData(Guid userId);
    }
}