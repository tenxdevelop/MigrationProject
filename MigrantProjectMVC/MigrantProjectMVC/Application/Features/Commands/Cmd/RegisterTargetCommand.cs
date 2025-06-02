using MigrantProjectMVC.Interfaces;
using MigrantProjectMVC.Models;

namespace MigrantProjectMVC.Commands
{
    public class RegisterTargetCommand : ICommand<bool>
    {
        public string TargetName { get; private set; }
        public string Instruction { get; private set; }

        public List<RegulationDTO> Regulations { get; private set; }

        public RegisterTargetCommand(string targetName, string instruction, List<RegulationDTO> regulations)
        {
            TargetName = targetName;
            Instruction = instruction;
            Regulations = regulations;
        }
    }
}