using MigrantProjectMVC.Models;

namespace MigrantProjectMVC.Interfaces
{
    public interface ITargetRepository
    {
        Task<TargetModel> GetTarget(string targetName, DateTime date);
        
        Task<List<TargetModel>> GetTargets();

        Task<bool> SaveTarget(TargetModel target);
        
        Task<bool> IsHaveTarget(string targetName);
        
        Task<bool> RegisterTarget(string targetName);
        Task<bool> DeleteTarget(string targetName);
        
    }
}