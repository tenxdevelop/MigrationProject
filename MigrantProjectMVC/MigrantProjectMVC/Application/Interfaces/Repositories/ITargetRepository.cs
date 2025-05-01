using MigrantProjectMVC.Models;

namespace MigrantProjectMVC.Interfaces
{
    public interface ITargetRepository
    {
        Task<TargetModel> GetTarget(string targetName, DateTime date);
    }
}