using MigrantProjectMVC.Commands;
using MigrantProjectMVC.Interfaces;

namespace MigrantProjectMVC.CommandHandlers
{
    public class UpdateDataMigrantCommandHandler : ICommandHandler<UpdateDataMigrantCommand, bool>
    {
        private IMigrantRepository _migrantRepository;
        public UpdateDataMigrantCommandHandler(IMigrantRepository migrantRepository)
        {
            _migrantRepository = migrantRepository;
        }
        public async Task<bool> Handle(UpdateDataMigrantCommand requist)
        {
            var migrant = await _migrantRepository.GetMigrantById(requist.MigrantId);
            migrant.ResettelmentProgramMember = requist.ResettelmentProgramMember;
            migrant.EnteringDate = requist.EnteringDate;
            migrant.ConsistOfMigrationRegistration = requist.ConsistOfMigrationRegistration;
            migrant.HighlyQualified = requist.HighlyQualifled;
            migrant.Country = requist.Country;
            _migrantRepository.SaveContext();
            return true;
        }
    }
}
