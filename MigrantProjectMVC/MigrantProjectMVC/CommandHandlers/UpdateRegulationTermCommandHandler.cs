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

        public Task<bool> Handle(UpdateRegulationTermCommand requist)
        {
            throw new NotImplementedException();
        }
    }
}
