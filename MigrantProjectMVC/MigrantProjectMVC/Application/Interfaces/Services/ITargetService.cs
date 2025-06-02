using MigrantProjectMVC.Models;

namespace MigrantProjectMVC.Interfaces.Services
{
    public interface ITargetService
    {
        Task<bool> RegisterTarget(string targetName, string instruction, List<RegulationDTO> regulations);

        Task<bool> DeleteTarget(string targetName);

        Task<bool> RegisterRegulation(string targetName, string regulationName, List<string> countries, List<string> useDocuments, int term);
        
        Task<bool> DeleteRegulation(string targetName, string regulationName);
        Task<bool> ChangeCondition(string targetName, string newInstruction);
        
        Task<bool> ChangeRegulation(string regulationName, string targetName, List<string> countries, List<string> useDocuments, int term);
    }
}