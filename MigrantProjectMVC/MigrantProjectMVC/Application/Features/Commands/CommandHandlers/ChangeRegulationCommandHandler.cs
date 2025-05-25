using MigrantProjectMVC.Commands;
using MigrantProjectMVC.Interfaces;
using MigrantProjectMVC.Interfaces.Services;

namespace MigrantProjectMVC.CommandHandlers
{
    public class ChangeRegulationCommandHandler : ICommandHandler<ChangeRegulationCommand, bool>
    {
        private ITargetService _targetService;

        public ChangeRegulationCommandHandler(ITargetService targetService)
        {
            _targetService = targetService;
        }
        public async Task<bool> Handle(ChangeRegulationCommand request)
        {
            var result = await _targetService.ChangeRegulation(request.RegulationName, request.TargetName,
                request.CountryNames, request.UseDocumentNames, request.Term);
            
            return result;
        }
    }
}