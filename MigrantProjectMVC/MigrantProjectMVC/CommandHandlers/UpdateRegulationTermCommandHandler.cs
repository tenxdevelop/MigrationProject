using MigrantProjectMVC.Commands;
using MigrantProjectMVC.Interfaces;

namespace MigrantProjectMVC.CommandHandlers
{
    public class UpdateRegulationTermCommandHandler : ICommandHandler<UpdateRegulationTermCommand, bool>
    {
        private IRegulationRepository _regulationRepository;

        public UpdateRegulationTermCommandHandler(IRegulationRepository regulationRepository)
        {
            _regulationRepository = regulationRepository;
        }

        public async Task<bool> Handle(UpdateRegulationTermCommand requist)
        {
            await _regulationRepository.UpdateRegulation(requist.Regulation);
            return true;
        }
    }
}
