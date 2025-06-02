using MigrantProjectMVC.Models;

namespace MigrantProjectMVC.Interfaces
{
    public interface ITargetRepository
    {
        Task<TargetModel> GetTarget(string targetName, DateTime date);
        
        Task<List<TargetModel>> GetTargets();

        Task<bool> Save();
        
        Task<bool> IsHaveTarget(string targetName);
        Task<bool> RegisterTarget(string targetName, string instruction, List<RegulationModel> regulations);
        Task<bool> DeleteTarget(string targetName);
        
    }
}