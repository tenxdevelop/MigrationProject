using MigrantProjectMVC.Interfaces;
using System.Windows.Input;

namespace MigrantProjectMVC.Commands
{
    public class ChangeDataCommand : ICommand<bool>
    {
        public DateTime EnteringDate { get; set; }
        public string Country { get; set; }
        public bool resettelmentProgramMember { get; set; }
        public bool consistOfMigrationRegistration { get; set; }
        public bool highlyQualifiled { get; set; }
    }
}
