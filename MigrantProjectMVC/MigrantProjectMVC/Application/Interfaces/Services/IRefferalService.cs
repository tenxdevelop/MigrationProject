using MigrantProjectMVC.ViewModel;

namespace MigrantProjectMVC.Interfaces.Services
{
    public interface IRefferalService
    {
        Task<RefferalViewModel> GetRefferal(string targetName, string name, string surname, string patronymic);
    }
}