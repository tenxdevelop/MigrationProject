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
        
        public async Task<bool> Handle(RegisterTargetCommand request)
        {
            var result = await _targetService.RegisterTarget(request.TargetName, request.Instruction, request.Regulations);
            
            return result;
        }
    }    
}

