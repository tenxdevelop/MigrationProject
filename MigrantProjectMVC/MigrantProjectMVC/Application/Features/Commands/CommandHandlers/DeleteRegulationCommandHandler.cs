using MigrantProjectMVC.Commands;
using MigrantProjectMVC.Interfaces;
using MigrantProjectMVC.Interfaces.Services;

namespace MigrantProjectMVC.CommandHandlers
{
    public class DeleteRegulationCommandHandler : ICommandHandler<DeleteRegulationCommand, bool>
    {
        private ITargetService _targetService;

        public DeleteRegulationCommandHandler(ITargetService targetService)
        {
            _targetService = targetService;
            
        }
        public async Task<bool> Handle(DeleteRegulationCommand request)
        {
            var result = await _targetService.DeleteRegulation(request.TargetName, request.RegulationName);
            
            return result;
        }
    }    
}

