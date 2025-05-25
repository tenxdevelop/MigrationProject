using MigrantProjectMVC.Interfaces;

namespace MigrantProjectMVC.Commands
{
    public class DeleteTargetCommand : ICommand<bool>
    {
        public string TargetName { get; private set; }

        public DeleteTargetCommand(string targetName)
        {
            TargetName = targetName;
        }
    }
}