using MigrantProjectMVC.Commands;
using MigrantProjectMVC.Interfaces;
using MigrantProjectMVC.Interfaces.Services;

namespace MigrantProjectMVC.CommandHandlers
{
    public class RegisterRegulationCommandHandler : ICommandHandler<RegisterRegulationCommand, bool>
    {
        private ITargetService _targetService;

        public RegisterRegulationCommandHandler(ITargetService targetService)
        {
            _targetService = targetService;
        }
        
        public async Task<bool> Handle(RegisterRegulationCommand request)
        {
            var result = await _targetService.RegisterRegulation(request.TargetName, request.RegulationName, request.CountriesNames, request.UseDocumentsNames, request.Term);
            return result;
        }
    }
}