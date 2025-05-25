using MigrantProjectMVC.Commands;
using MigrantProjectMVC.Interfaces;
using MigrantProjectMVC.Interfaces.Services;

namespace MigrantProjectMVC.CommandHandlers
{
    public class RegisterTargetCommandHandler : ICommandHandler<RegisterTargetCommand, bool>
    {
        private ITargetService _targetService;

        public RegisterTargetCommandHandler(ITargetService targetService)
        {
            _targetService = targetService;
        }
        
        public async Task<bool> Handle(RegisterTargetCommand requist)
        {
            var result = await _targetService.RegisterTarget(requist.TargetName);
            
            return result;
        }
    }    
}

