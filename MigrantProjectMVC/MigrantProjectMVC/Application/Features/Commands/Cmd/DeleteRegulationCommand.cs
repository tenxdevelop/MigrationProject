using MigrantProjectMVC.Interfaces;

namespace MigrantProjectMVC.Commands
{
    public class DeleteRegulationCommand : ICommand<bool>
    {
        public string TargetName { get; private set; }
        public string RegulationName { get; private set; }

        public DeleteRegulationCommand(string targetName, string regulationName)
        {
            TargetName = targetName;
            RegulationName = regulationName;
            
        }
    }
    
}