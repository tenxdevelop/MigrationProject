using MigrantProjectMVC.Commands;
using MigrantProjectMVC.Interfaces;
using MigrantProjectMVC.Interfaces.Services;

namespace MigrantProjectMVC.CommandHandlers
{
    public class ChangeConditionCommandHandler : ICommandHandler<ChangeConditionCommand, bool>
    {
        private ITargetService _targetService;

        public ChangeConditionCommandHandler(ITargetService targetService)
        {
            _targetService = targetService;
        }
        
        public async Task<bool> Handle(ChangeConditionCommand request)
        {
            var result = await _targetService.ChangeCondition(request.TargetName, request.NewInstruction);
            return result;
        }
    }
}