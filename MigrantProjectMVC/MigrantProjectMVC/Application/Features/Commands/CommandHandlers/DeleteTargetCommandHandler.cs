using MigrantProjectMVC.Commands;
using MigrantProjectMVC.Interfaces;
using MigrantProjectMVC.Interfaces.Services;

namespace MigrantProjectMVC.CommandHandlers
{
    public class DeleteTargetCommandHandler : ICommandHandler<DeleteTargetCommand, bool>
    {
        private ITargetService _targetService;

        public DeleteTargetCommandHandler(ITargetService targetService)
        {
            _targetService = targetService;
        }
        
        public async Task<bool> Handle(DeleteTargetCommand requist)
        {
            var result = await _targetService.DeleteTarget(requist.TargetName);
            
            return result;
        }
    }
}