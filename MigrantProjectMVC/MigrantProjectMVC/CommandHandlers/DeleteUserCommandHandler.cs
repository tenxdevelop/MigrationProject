using MigrantProjectMVC.Commands;
using MigrantProjectMVC.Interfaces;

namespace MigrantProjectMVC.CommandHandlers
{
    public class DeleteUserCommandHandler : ICommandHandler<DeleteUserCommand, bool>
    {
        IUserRepository _repository;
        public DeleteUserCommandHandler(IUserRepository userRepository)
        {
            _repository = userRepository;
        }
        public async Task<bool> Handler(DeleteUserCommand requist)
        {
            await _repository.Remove(requist.Id);
            return true;
        }
    }
}
