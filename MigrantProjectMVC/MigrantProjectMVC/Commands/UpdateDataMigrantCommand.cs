using MigrantProjectMVC.Interfaces;
using MigrantProjectMVC.Models;
using System.Windows.Input;

namespace MigrantProjectMVC.Commands
{
    public class UpdateDataMigrantCommand: ICommand<bool>
    {
        public Guid MigrantId { get; set; } 
        public DateTime EnteringDate { get; set; }
        public string Country { get; set; }
        public bool ResettelmentProgramMember { get; set; }
        public bool ConsistOfMigrationRegistration { get; set; }
        public bool HighlyQualifled { get; set; }

        public UpdateDataMigrantCommand(Guid migrantId, DateTime enteringDate, string country, bool resettelmentProgramMember,
            bool consistOfMigrationRegistration, bool highlyQualifled)
        {
            MigrantId = migrantId;
            EnteringDate = enteringDate;
            Country = country;
            ResettelmentProgramMember = resettelmentProgramMember;
            ConsistOfMigrationRegistration = consistOfMigrationRegistration;
            HighlyQualifled = highlyQualifled;
        }
    }
}
