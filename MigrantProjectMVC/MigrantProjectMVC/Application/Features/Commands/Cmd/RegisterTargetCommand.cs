using MigrantProjectMVC.Interfaces;

namespace MigrantProjectMVC.Commands
{
    public class RegisterTargetCommand : ICommand<bool>
    {
        public string TargetName { get; private set; }

        public RegisterTargetCommand(string targetName)
        {
            TargetName = targetName;
        }
    }
}