using MigrantProjectMVC.Interfaces;

namespace MigrantProjectMVC.Commands
{

    public class ChangeConditionCommand : ICommand<bool>
    {
        public string TargetName { get; private set; }
        public string NewInstruction { get; private set; }

        public ChangeConditionCommand(string targetName, string newInsctuction)
        {
            TargetName = targetName;
            NewInstruction = newInsctuction;
        }
    }
}